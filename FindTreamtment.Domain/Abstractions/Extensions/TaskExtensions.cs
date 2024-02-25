/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class TaskExtensions
{
    public static async Task<TB> Map<TA, TB>(this Task<TA> input, Func<TA, TB> selector) => 
        selector(await input);
}