/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct WorksheetScaffold
{
    public WorksheetOptions Options { get; }
    public IEnumerable<WorksheetPartitionScaffold> PartitionScaffolds { get; }

    public WorksheetScaffold(
        WorksheetOptions options, 
        IEnumerable<WorksheetPartitionScaffold> partitionScaffolds)
    {
        this.Options = options;
        this.PartitionScaffolds = partitionScaffolds;
    }
}