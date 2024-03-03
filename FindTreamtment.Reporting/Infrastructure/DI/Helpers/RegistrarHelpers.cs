/*
* Find Treatment
*/

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FindTreatment.Reporting
{
    public static class RegistrarHelpers
    {
        public static IServiceCollection AddTypeTransientImplementations<T>(
            this IServiceCollection services,
            Assembly assembly)
            where T : class =>
            typeof(T)
                .Apply(z => services.AddTypeImplementations(z, assembly, t => services.AddTransient(t)));

        public static IServiceCollection AddTypeSingletonImplementations<T>(
            this IServiceCollection services,
            Assembly assembly)
            where T : class =>
            typeof(T).Apply(z => services.AddTypeSingletonImplementations(z, assembly));

        public static IServiceCollection AddTypeSingletonImplementations(
            this IServiceCollection services,
            Type type,
            Assembly assembly) =>
            services.AddTypeImplementations(
                type,
                assembly,
                t => services.AddSingleton(t));

        private static IServiceCollection AddTypeImplementations(
            this IServiceCollection services,
            Type type,
            Assembly assembly,
            Action<Type> func)
        {
            var _ = assembly
                .GetTypes()
                .Where(x => (type.IsAssignableFrom(x) || x.ImplementsGenericInterface(type)) && x != type)
                .ApplyForEach(func)
                .ToList();

            return services;
        }
    }
}