/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class ColumnConfiguration
{
    public string Property { get; }
    public string Title { get; }
    public double Width { get; }
    public CellOptions CellOption { get; }


    public ColumnConfiguration(string property, string title, double width = 15, CellOptions cellOptions = default)
    {
        this.Property = property;
        this.Title = title;
        this.Width = width;
        this.CellOption = cellOptions;
    }
}