/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class ColumnOptionsMapper
{
    public static ColumnOptions ToOptions(this ColumnConfiguration options) =>
        new ColumnOptions(options.Property, options.Title, options.Width, options.CellOption);

    public static IEnumerable<ColumnOptions> ToOptions(
        this IEnumerable<ColumnConfiguration> options) =>
        options.Select(ToOptions);

    public static IReadOnlyDictionary<string, ColumnOptions> ToColumnFunctionMap(
        this IEnumerable<ColumnOptions> options) =>
        options.ToDictionary(z => z.Property, z => z);
}