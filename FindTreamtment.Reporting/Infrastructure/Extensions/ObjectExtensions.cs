/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class ObjectExtensions
{
    public static TB Apply<TA, TB>(this TA input, Func<TA, TB> func) => func(input);

    public static IEnumerable<T> Yield<T>(this T input)
    {
        yield return input;
    }

    public static void Mutate<T>(this T input, Action<T> action) => action(input);

    public static List<T> YieldToList<T>(this T input) => input.Yield().ToList();

    public static (TA, TB) ToTuple<TA, TB>(this TA input, Func<TA, TB> fn) => (input, fn(input));

    public static TA Pipe<TA>(this TA input, Action<TA> func)
    {
        input.Mutate(func);
        return input;
    }
}