/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class ObjectExtensions
{
    public static TB Apply<TA, TB>(this TA input, Func<TA, TB> func) => func(input);
    
    public static IEnumerable<TA> Yield<TA>(this TA input)
    {
        yield return input;
    }
}