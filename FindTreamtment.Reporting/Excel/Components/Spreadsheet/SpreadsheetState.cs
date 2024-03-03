/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using static DocumentFormat.OpenXml.Packaging.SpreadsheetDocument;

namespace FindTreatment.Reporting;

public class SpreadsheetState
{
    public SpreadsheetDocument Doc { get; }
    public WorkbookPart Book { get; }
    public Sheets Sheets { get; }
    public SpreadsheetOptions Options { get; }

    public SpreadsheetState(
        SpreadsheetDocument doc, 
        WorkbookPart book, 
        Sheets sheets, 
        SpreadsheetOptions options)
    {
        this.Doc = doc;
        this.Book = book;
        this.Sheets = sheets;
        this.Options = options;
    }

    public static SpreadsheetState NewState(SpreadsheetOptions options) =>
        Create(options.FileName, SpreadsheetDocumentType.Workbook)
            .ToTuple(doc => WorkbookWriter.Create(doc, new WorkbookOptions()))
            .ToTuple(i => i.Item2.Workbook.AppendChild(new Sheets()))
            .Apply(x => new SpreadsheetState(x.Item1.Item1, x.Item1.Item2, x.Item2, options));

    public static SpreadsheetState ResumedState(SpreadsheetOptions options) =>
        Open(options.FileName, true)
            .ToTuple(x => x.WorkbookPart)
            .ToTuple(y => y.Item2?.Workbook.Sheets ?? new Sheets())
            .Apply(x => new SpreadsheetState(x.Item1.Item1, x.Item1.Item2!, x.Item2, options));
}