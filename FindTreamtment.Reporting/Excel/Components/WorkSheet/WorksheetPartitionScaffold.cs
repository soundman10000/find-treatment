/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public readonly struct WorksheetPartitionScaffold
{
    public DataTable Data { get; }
    public WorksheetPartitionOptions Options { get; }
    public IReadOnlyDictionary<uint, double> ColumnLookUps { get; }

    public WorksheetPartitionScaffold(
        DataTable data, 
        WorksheetPartitionOptions options,
        IReadOnlyDictionary<uint, double> columnLookUps)
    {
        this.Data = data;
        this.Options = options;
        this.ColumnLookUps = columnLookUps;
    }
}