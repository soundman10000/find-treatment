/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public class Default : IHeader
{
    public CellFormats Style => CellFormats.Header1;

    public Task<IEnumerable<RowScaffold>> GenerateHeader(WorksheetPartitionScaffold scaffold) =>
        ColumnsToDataRow(scaffold)
            .Map(z => z
                .Select(a => RowScaffoldFactory
                    .GenerateRowScaffold(a, RowTypes.Header, this.Style, scaffold.Options.HeaderRowHeight)));

    public static Task<IEnumerable<DataRow>> ColumnsToDataRow(WorksheetPartitionScaffold scaffold)
    {
        var columns = scaffold.Data.Columns.Cast<DataColumn>().ToArray();

        return new DataTable()
            .Pipe(t => columns.InvokeForEach(z => t.Columns.Add(z.ColumnName)))
            .NewRow()
            .Pipe(r => r.ItemArray = columns.Select(z => ToHeaderValue(scaffold, z)).Cast<object>().ToArray())
            .Pipe(x => x.Table.Rows.InsertAt(x, 0))
            .Yield()
            .ToUnit();
    }

    private static string ToHeaderValue(WorksheetPartitionScaffold scaffold, DataColumn column) =>
        scaffold.Options.ColumnOptions.TryGetValue(column.ColumnName, out var transform)
            ? string.IsNullOrEmpty(transform.Title) ? column.ColumnName : transform.Title
            : column.ColumnName;
}