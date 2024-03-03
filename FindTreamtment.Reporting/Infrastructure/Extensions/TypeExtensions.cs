/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class TypeExtensions
{
    public static bool ImplementsGenericInterface(this Type t, Type generic) =>
        t.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == generic);
}