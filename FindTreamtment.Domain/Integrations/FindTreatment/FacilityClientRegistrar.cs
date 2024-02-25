/*
* Find Treatment
*/

using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FindTreatment.Domain;

public static class FacilityClientRegistrar
{
    public static IServiceCollection UseFacilityClients(this IServiceCollection services) =>
        services
            .AddSingleton<GovFacilityHttpClientFactory>()
            .AddSingleton(new JsonSerializerSettings())
            .AddSingleton<IFacilityClient>(s => s.GetRequiredService<GovFacilityHttpClientFactory>().Generate());
}