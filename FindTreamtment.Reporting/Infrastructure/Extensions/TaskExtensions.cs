/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class TaskExtensions
{
    public static async Task<TB> Map<TA, TB>(this Task<TA> source, Func<TA, TB> selector) =>
        selector(await source);

    public static async Task Map<TA>(this Task<TA> source, Action<TA> selector) =>
        selector(await source);

    public static async Task Map(this Task source, Action selector)
    {
        await source;
        selector();
    }

    public static Task<List<TB>> Apply<TA, TB>(this Task<IEnumerable<TA>> source, Func<TA, TB> selector) =>
        source.Map(z => z.Select(selector).ToList());

    public static Task<TA> ToUnit<TA>(this TA x) =>
        Task.FromResult(x);

    public static async Task<TB> Chain<TA, TB>(this Task<TA> x, Func<TA, Task<TB>> f) =>
        await f(await x);

    public static async Task Chain<TA>(
        this Task<TA> x, Func<TA, Task> f) =>
        await f(await x);

    public static async Task Chain(
        this Task x, Func<Task> f) =>
        await x.ContinueWith(_ => f());

    public static Task<IEnumerable<TA>> Flatten<TA>(this IEnumerable<Task<TA>> x) =>
        Task.WhenAll(x).Map(Enumerable.AsEnumerable);

    public static Task WhenAll(this IEnumerable<Task> x) =>
        Task.WhenAll(x);

}