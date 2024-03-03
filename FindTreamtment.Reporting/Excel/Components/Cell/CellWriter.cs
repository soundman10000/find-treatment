/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class CellWriter
{
    public static Task<Cell> Render(CellScaffold scaffold) =>
        CellValueFactory(scaffold.Options.CellType, scaffold.Data)
            .Apply(x => x.BuildCell(scaffold.Options))
            .ToUnit();

    private static Cell BuildCell(this CellValue value, CellOptions cellOptions)
        => new()
        {
            DataType = cellOptions.CellType.ToExcelCellType(),
            CellValue = value,
            StyleIndex = (uint)(cellOptions.Format ?? CellFormats.General),
        };

    private static CellValue CellValueFactory(CellTypes type, object data) =>
        type switch
        {
            CellTypes.Integer => new CellValue((int)data),
            CellTypes.Date => new CellValue((DateTime)data),
            CellTypes.String => new CellValue(data?.ToString() ?? string.Empty),
            CellTypes.Decimal => new CellValue((decimal)data),
            CellTypes.Boolean => new CellValue((bool)data),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}