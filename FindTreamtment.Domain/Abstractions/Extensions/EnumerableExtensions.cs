/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Coalesce<T>(this IEnumerable<T>? input) => input ?? new List<T>();
}