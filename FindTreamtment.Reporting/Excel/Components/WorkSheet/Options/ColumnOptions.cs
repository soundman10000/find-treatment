/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct ColumnOptions
{
    public string Property { get; }
    public string Title { get; }
    public double Width { get; }
    public CellOptions CellOption { get; }

    public ColumnOptions(string property, string title, double width, CellOptions cellOption = default)
    {
        this.Property = property;
        this.Title = title;
        this.Width = width;
        this.CellOption = cellOption;
    }
}