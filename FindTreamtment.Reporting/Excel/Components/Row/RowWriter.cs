/*
* Find Treatment
*/

using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class RowWriter
{
    public static Task<Row> Render(
        WorksheetPartitionScaffold scaffold,
        RowScaffold rowScaffold) =>
        rowScaffold.Row.Table.Columns
            .Cast<DataColumn>()
            .Select((c, i) => Configure(c, scaffold, rowScaffold, rowScaffold.Row[i]))
            .Flatten()
            .Chain(WriteCells)
            .Map(z => z.Aggregate(RowBuilder(rowScaffold), (r, d) => r.Pipe(a => a.AppendChild(d))));

    private static Task<IEnumerable<Cell>> WriteCells(IEnumerable<CellScaffold> dataWithConfig) =>
        dataWithConfig
            .Select(CellWriter.Render)
            .Flatten();

    private static Task<CellScaffold> Configure(
        DataColumn column,
        WorksheetPartitionScaffold scaffold,
        RowScaffold rowScaffold,
        object data) =>
        rowScaffold.Options.RowType switch
        {
            RowTypes.Header => ConfigureHeaderRow(column, scaffold, rowScaffold, data),
            RowTypes.Data => ConfigureDataRow(column, scaffold, rowScaffold, data),
            RowTypes.Buffer => ConfigureBufferRow(column, scaffold, rowScaffold, data),
            _ => throw new ArgumentOutOfRangeException()
        };

    private static Task<CellScaffold> ConfigureHeaderRow(
        DataColumn column,
        WorksheetPartitionScaffold scaffold,
        RowScaffold rowScaffold,
        object data) =>
        new CellScaffold(
                new CellOptions(CellTypes.String, rowScaffold.Options.Style),
                data)
            .ToUnit();

    private static Task<CellScaffold> ConfigureBufferRow(
        DataColumn column,
        WorksheetPartitionScaffold scaffold,
        RowScaffold rowScaffold,
        object data) =>
        new CellScaffold(
                new CellOptions(CellTypes.String, rowScaffold.Options.Style),
                data)
            .ToUnit();

    private static Task<CellScaffold> ConfigureDataRow(
        DataColumn column,
        WorksheetPartitionScaffold scaffold,
        RowScaffold rowScaffold,
        object data) =>
        scaffold.Options.ColumnOptions.TryGetValue(column.ColumnName, out var options)
            ? ConfigureOverride(rowScaffold, options, data)
            : ConfigureDefaultTask(data, options);

    private static Task<CellScaffold> ConfigureOverride(
        RowScaffold row,
        ColumnOptions options,
        object data)
    {
        return ConfigureDefaultTask(data, options);
    }

    private static Task<CellScaffold> ConfigureDefaultTask(object data, ColumnOptions options) =>
        ConfigureDefault(data, options).ToUnit();

    private static CellScaffold ConfigureDefault(object data, ColumnOptions options)
    {
        var t = data.GetType();
        if (t == typeof(bool))
        {
            return new CellScaffold(CellOptions.BooleanType, data);
        }
        if (t == typeof(DateTime))
        {
            return new CellScaffold(CellOptions.DateType, data);
        }
        if (t == typeof(Guid))
        {
            return new CellScaffold(CellOptions.StringType, data);
        }
        if (t == typeof(int))
        {
            return new CellScaffold(CellOptions.IntegerType, data);
        }
        if (t == typeof(double))
        {
            return new CellScaffold(CellOptions.DecimalType, data);
        }
        if (options.CellOption.Format != null)
        {
            return new CellScaffold(options.CellOption, data);
        }

        return new CellScaffold(CellOptions.StringType, data);
    }

    private static Row RowBuilder(RowScaffold scaffold) =>
        scaffold.Options.RowType switch
        {
            RowTypes.Header => BuildHeaderRow(scaffold),
            RowTypes.Data => BuildDataRow(scaffold),
            RowTypes.Buffer => BuildBufferRow(scaffold),
            _ => throw new ArgumentOutOfRangeException(nameof(scaffold.Options.RowType), scaffold.Options.RowType, null)
        };

    private static Row BuildHeaderRow(RowScaffold scaffold) =>
        !scaffold.Options.RowHeight.HasValue
            ? new Row()
            : new Row { CustomHeight = true, Height = scaffold.Options.RowHeight };

    private static Row BuildDataRow(RowScaffold scaffold)
    {
        return new Row();
    }

    private static Row BuildBufferRow(RowScaffold scaffold)
    {
        return new Row();
    }
}