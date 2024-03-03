/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct CellScaffold
{
    public CellOptions Options { get; }
    public object Data { get; }

    public CellScaffold(CellOptions options, object data)
    {
        this.Options = options;
        this.Data = data;
    }
}