/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class WorkSheetPartitionMapper
{
    public static WorksheetPartitionOptions ToOptions(
        this WorksheetPartitionConfiguration configuration) =>
        new WorksheetPartitionOptions(
            configuration.Columns.ToOptions(),
            configuration.HeaderType,
            configuration.Buffer,
            configuration.BufferType,
            configuration.HeaderRowHeight);

    public static WorksheetPartitionScaffold ToScaffold(
        this WorksheetPartitionConfiguration configuration) =>
        new WorksheetPartitionScaffold(configuration.Data,
            configuration.ToOptions(),
            configuration.Columns
                .Where(c => configuration.Data.Columns.Contains(c.Property))
                .Select(c => new
                {
                    Key = (uint)configuration.Data.Columns.IndexOf(c.Property) + 1,
                    Width = c.Width
                })
                .ToDictionary(x => x.Key, x => x.Width));
}