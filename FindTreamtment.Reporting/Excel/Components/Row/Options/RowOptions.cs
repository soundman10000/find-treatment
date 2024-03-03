/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct RowOptions
{
    public RowTypes RowType { get; }
    public CellFormats Style { get; }
    public double? RowHeight { get; }

    public RowOptions(RowTypes rowType, CellFormats style, double? rowHeight = null)
    {
        this.RowType = rowType;
        this.Style = style;
        this.RowHeight = rowHeight;
    }
}