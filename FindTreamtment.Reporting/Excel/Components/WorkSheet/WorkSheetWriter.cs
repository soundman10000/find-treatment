/*
* Find Treatment
*/

using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

namespace FindTreatment.Reporting;

public static class WorkSheetWriter
{
    /// <summary>
    /// Sheet Number CANNOT BE 0
    /// </summary>
    private const uint SheetStartingId = 1;

    private class SheetMetadata
    {
        public SheetData SheetData { get; }
        public string WorksheetId { get; }
        public Worksheet Worksheet { get; }
        public WorksheetPart WorksheetPart { get; }
        public SheetMetadata(SheetData sheetData, string worksheetId, Worksheet worksheet, WorksheetPart worksheetPart)
        {
            this.SheetData = sheetData;
            this.WorksheetId = worksheetId;
            this.Worksheet = worksheet;
            this.WorksheetPart = worksheetPart;
        }
    }

    public static async Task RenderTableView(
        WorkbookPart workbookPart,
        Sheets sheets,
        WorksheetScaffold scaffold)
    {
        var sheetId = DeriveSheetNumber(sheets);
        var sheetMetadata = Boilerplate(workbookPart);

        await SheetWriter
            .Render(sheetMetadata.WorksheetId, sheetId, scaffold.Options)
            .Map(s => sheets.Append(s));

        foreach (var partition in scaffold.PartitionScaffolds.ToList())
        {
            await ProcessHeader(partition, sheetMetadata.SheetData)
                .Chain(() => ProcessRowData(scaffold, partition, sheetMetadata.SheetData))

                .Chain(() => ProcessPartitionBuffer(partition, sheetMetadata.SheetData));
        }

        var freezeRowCount = scaffold.Options.FreezeRowCount;
        FreezeHeaderRow(sheetMetadata.Worksheet, sheetMetadata.SheetData, freezeRowCount);
        ProcessColumnWidth(scaffold, sheetMetadata.Worksheet, sheetMetadata.SheetData);
        ProcessMergeCells(scaffold, sheetMetadata);
        ProcessCustomizedCellStyle(scaffold, sheetMetadata);
    }

    private static SheetMetadata Boilerplate(OpenXmlPartContainer workbookPart)
    {
        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        var sheetData = new SheetData();
        var workSheet = new Worksheet(sheetData);
        worksheetPart.Worksheet = workSheet;

        return new SheetMetadata(sheetData, workbookPart.GetIdOfPart(worksheetPart), workSheet, worksheetPart);
    }

    private static uint DeriveSheetNumber(OpenXmlElement sheets) =>
        sheets.Elements<Sheet>().Any() ? GetMaxSheetId(sheets) + 1 : SheetStartingId;

    private static uint GetMaxSheetId(OpenXmlElement sheets) =>
        sheets.Elements<Sheet>().Max(s => s.SheetId?.Value ?? SheetStartingId);

    private static async Task ProcessRowData(
        WorksheetScaffold worksheetScaffold,
        WorksheetPartitionScaffold scaffold,
        OpenXmlElement sheetData)
    {
        var i = 0;
        while (scaffold.Data.Rows.Count > 0)
        {
            var row = scaffold.Data.Rows[0];

            await WriteRowData(row, scaffold, sheetData);
            scaffold.Data.Rows.Remove(row);

            if (i >= worksheetScaffold.Options.Throttle)
            {
                i = 0;

                ForceCollection();
                continue;
            }

            i++;
        }
    }

    private static Task WriteRowData(
        DataRow row,
        WorksheetPartitionScaffold scaffold,
        OpenXmlElement sheetData) =>
        RowScaffoldFactory
            .GenerateRowScaffold(row, RowTypes.Data, CellFormats.General)
            .Apply(h => RowWriter.Render(scaffold, h))
            .Map(sheetData.AppendChild);

    private static void ForceCollection()
    {
        GC.Collect(2, GCCollectionMode.Forced, true, true);
        GC.WaitForPendingFinalizers();
    }

    private static Task ProcessHeader(
        WorksheetPartitionScaffold scaffold,
        OpenXmlElement sheetData) =>
        scaffold
            .Options
            .HeaderType
            .GenerateHeaderType()
            .GenerateHeader(scaffold)
            .Chain(header => header
                .Select(h => RowWriter.Render(scaffold, h))
                .Flatten())
            .Apply(sheetData.AppendChild);

    private static Task ProcessPartitionBuffer(
        WorksheetPartitionScaffold scaffold,
        OpenXmlElement sheetData) =>
        scaffold
            .Options
            .BufferType
            .GenerateBufferType()
            .GenerateBuffer(scaffold)
            .Chain(buffer => buffer
                .Select(h => RowWriter.Render(scaffold, h))
                .Flatten())
            .Apply(sheetData.AppendChild);

    private static void ProcessColumnWidth(
        WorksheetScaffold worksheetScaffold,
        Worksheet workSheet,
        SheetData sheetData)
    {
        // excel sheet will throw an error if inserting columns without any child
        if (!worksheetScaffold.Options.ProcessColumnWidth())
        {
            return;
        }

        var columns = worksheetScaffold
            .Options
            .ColumnLookUps
            .Aggregate(new Columns(), (cs, c) => cs.Pipe(clm => clm.AppendChild(ToWidthColumn(c))));

        if (columns.Any())
        {
            // If Columns appended to worksheet after SheetData Excel will throw an error.
            workSheet.InsertBefore(columns, sheetData);
        }
    }

    private static void FreezeHeaderRow(
        Worksheet workSheet,
        SheetData sheetData,
        int freezeRowCount)
    {
        SheetViews sheetViews = new SheetViews();

        var verticalSplit = Convert.ToDouble(freezeRowCount); // split number of rows from top
        var topLeftCell = "A" + Convert.ToString(freezeRowCount + 1); // freeze number of cells from top, this parameter can be configured if there is any need for freezing columns

        SheetView sheetView = new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U };
        Pane pane = new Pane() { VerticalSplit = verticalSplit, TopLeftCell = topLeftCell, ActivePane = PaneValues.BottomLeft, State = PaneStateValues.Frozen };

        sheetView.Append(pane);
        sheetViews.Append(sheetView);

        workSheet.InsertBefore(sheetViews, sheetData);
    }

    private static Column ToWidthColumn(KeyValuePair<uint, double> columnWidth) =>
        new Column()
        {
            Min = columnWidth.Key,
            Max = columnWidth.Key,
            Width = columnWidth.Value,
            CustomWidth = true
        };

    private static void ProcessMergeCells(WorksheetScaffold worksheetScaffold, SheetMetadata sheetMetadata)
    {
        // excel sheet will throw an error if inserting mergeCells without any child
        if (!worksheetScaffold.Options.ProcessMergeCells())
        {
            return;
        }
        var mergeCells = worksheetScaffold
            .Options
            .MergeCellsRangeList
            .Aggregate(new MergeCells(),
                (cs, c) => cs.Pipe(clm => clm.AppendChild(new MergeCell { Reference = new StringValue(c) })));
        if (mergeCells.Any())
        {
            sheetMetadata.Worksheet.InsertAfter(mergeCells, sheetMetadata.SheetData);
        }
    }

    private static void ProcessCustomizedCellStyle(WorksheetScaffold worksheetScaffold, SheetMetadata sheetMetadata)
    {
        // excel sheet will throw an error if inserting redCells without any child
        if (!worksheetScaffold.Options.ProcessCustomizedCellStyle())
        {
            return;
        }

        foreach (var item in worksheetScaffold.Options.CustomizedCellStyleList)
        {
            sheetMetadata.SheetData.Elements<Row>().ToList()[(int) item.RowIndex - 1].Elements<Cell>().ToList()[
                (int) item.ColumnIndex - 1].StyleIndex = (uint) item.CellFormat;
        }
    }
}