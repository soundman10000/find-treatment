/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public readonly struct RowScaffold
{
    public DataRow Row { get; }
    public RowOptions Options { get; }

    public RowScaffold(
        DataRow row,
        RowOptions options)
    {
        this.Row = row;
        this.Options = options;
    }
}