/*
* Find Treatment
*/

using Microsoft.Extensions.DependencyInjection;

namespace FindTreatment.Reporting;

public static class ReportingRegistrar
{
    public static IServiceCollection UseReporting(this IServiceCollection services)
    {
        services.UsingReportWriters();
        return services;
    }
}