/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct CellOptions
{
    public static CellOptions StringType => new(CellTypes.String, CellFormats.General);
    public static CellOptions IntegerType => new(CellTypes.Integer, CellFormats.General);
    public static CellOptions DecimalType => new(CellTypes.Decimal, CellFormats.General);
    public static CellOptions BooleanType => new(CellTypes.Boolean, CellFormats.DateFormat);
    public static CellOptions DateType => new(CellTypes.Date, CellFormats.DateFormat);
    public static CellOptions TextStringType => new(CellTypes.String, CellFormats.TextCell);
    public static CellOptions BlueCellType => new(CellTypes.String, CellFormats.Header1);
    public static CellOptions AllBordersCellType => new(CellTypes.Decimal, CellFormats.AllBordersCell);

    public CellTypes CellType { get; }
    public CellFormats? Format { get; }

    public CellOptions(CellTypes cellType, CellFormats? format = null)
    {
        this.CellType = cellType;
        this.Format = format;
    }
}