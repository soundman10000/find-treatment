/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Coalesce<T>(this IEnumerable<T>? input) => input ?? new List<T>();

    public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>>? input) =>
        input?.SelectMany(z => z.Select(y => y)) ?? new List<T>();
}