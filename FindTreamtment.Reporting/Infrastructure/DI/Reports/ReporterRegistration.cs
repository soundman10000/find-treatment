/*
* Find Treatment
*/

using Microsoft.Extensions.DependencyInjection;

namespace FindTreatment.Reporting;

public static class ReporterRegistration
{
    public static IServiceCollection UsingReportWriters(this IServiceCollection services)
    {
        services.AddSingleton<ReporterFactory>();
        services.AddSingleton<IFileManager, FileManager>();
        services.AddSingleton<OptionsMapper>();
        services.AddSingleton<SpreadsheetStateFactory>();

        return services;
    }
}