/*
* Find Treatment
*/

using Microsoft.Extensions.DependencyInjection;

namespace FindTreatment.Domain;

public static class ScrubbersRegistrar
{
    public static IServiceCollection UseScrubbers(this IServiceCollection services)
    {
        return services.AddSingleton<FindTreatmentGovernmentApiScrubber>();
    }
}