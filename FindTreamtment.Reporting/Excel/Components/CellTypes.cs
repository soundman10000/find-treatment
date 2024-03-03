/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class CellTypeHelpers
{
    public static CellValues ToExcelCellType(this CellTypes types) =>
        types switch
        {
            CellTypes.Date => CellValues.Date,
            CellTypes.String => CellValues.String,
            CellTypes.Integer => CellValues.Number,
            CellTypes.Decimal => CellValues.Number,
            CellTypes.Boolean => CellValues.Boolean,
            _ => throw new ArgumentOutOfRangeException(nameof(types), types, null)
        };
}

public enum CellTypes
{
    Integer,
    Date,
    String,
    Decimal,
    Boolean,
}