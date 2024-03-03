/*
* Find Treatment
*/

using System.Data;
using System.Reflection;

namespace FindTreatment.Reporting;

public static class EnumerableExtensions
{
    public static IEnumerable<int> ToRange(this int i) => Enumerable.Range(0, i);

    public static IEnumerable<TElementType> Coalesce<TElementType>(
        this IEnumerable<TElementType>? items) =>
        items ?? Enumerable.Empty<TElementType>();

    public static IEnumerable<TA> ApplyForEach<TA>(this IEnumerable<TA> input, Action<TA> func) =>
        input.Select(x => x.Pipe(func));

    public static IEnumerable<TA> InvokeForEach<TA>(this IEnumerable<TA> input, Action<TA> func) =>
        input.Select(x => x.Pipe(func)).ToList();

    public static DataTable ToDataTable<T>(
        this IEnumerable<T> items,
        IEnumerable<string>? exclude = null) => items.ToDataTable(typeof(T).Name, exclude);

    public static DataTable ToDataTable<T>(
        this IEnumerable<T> items, 
        string tableName, 
        IEnumerable<string>? exclude = null)
    {
        var type = typeof(T);
        var properties = type
            .GetProperties()
            .Where(prop => !exclude.Coalesce().Contains(prop.Name, StringComparer.InvariantCultureIgnoreCase))
            .ToArray();

        var dataTable = new DataTable
        {
            TableName = tableName,
        };

        var columns = properties
            .Select(ToDataColumn)
            .ToArray();

        dataTable.Columns.AddRange(columns);

        foreach (var entity in items)
        {
            var values = new object[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity) ?? string.Empty;
            }

            dataTable.Rows.Add(values);
        }

        return dataTable;
    }

    private static DataColumn ToDataColumn(PropertyInfo y)
    {
        var type = Nullable.GetUnderlyingType(y.PropertyType) ?? y.PropertyType;
        return type.IsEnum ? new DataColumn(y.Name, typeof(int)) : new DataColumn(y.Name, type);
    }
}