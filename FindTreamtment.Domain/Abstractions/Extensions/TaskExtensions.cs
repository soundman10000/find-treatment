/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class TaskExtensions
{
    public static async Task<TB> Map<TA, TB>(this Task<TA> input, Func<TA, TB> selector) => 
        selector(await input);

    public static Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> input) =>
        Task.WhenAll(input)
            .Map(Enumerable.AsEnumerable);
}