/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public class DefaultBuffer : IBuffer
{
    public Task<IEnumerable<RowScaffold>> GenerateBuffer(WorksheetPartitionScaffold scaffold) =>
        EmptyRow(scaffold)
            .Map(z => z
                .Select(a => RowScaffoldFactory
                    .GenerateRowScaffold(a, RowTypes.Buffer, CellFormats.General)));

    private static Task<IEnumerable<DataRow>> EmptyRow(WorksheetPartitionScaffold scaffold)
    {
        return new DataTable()
            .Pipe(t => t.Columns.Add("Buffer"))
            .NewRow()
            .Pipe(r => r.ItemArray =
                scaffold.Options.Buffer.ToRange().Select(_ => string.Empty).Cast<object>().ToArray())
            .Pipe(x => x.Table.Rows.InsertAt(x, 0))
            .Yield()
            .ToUnit();
    }
}