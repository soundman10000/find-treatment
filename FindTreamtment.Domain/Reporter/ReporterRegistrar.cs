/*
* Find Treatment
*/

using FindTreatment.Reporting;
using Microsoft.Extensions.DependencyInjection;

namespace FindTreatment.Domain;

public static class ReporterRegistrar
{
    public static IServiceCollection UseReports(this IServiceCollection services)
    {
        return services
            .UseReporting()
            .AddSingleton<FacilityStateDetailReport>();
    }
}