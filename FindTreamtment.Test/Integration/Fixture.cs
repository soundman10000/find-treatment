/*
* Find Treatment
*/

using FindTreatment.Domain;
using FindTreatment.Reporting;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace FindTreatment.Test.Integration;

[CollectionDefinition(nameof(IntegrationFixture))]
public class IntegrationTestCollectionDefinition : ICollectionFixture<IntegrationFixture> { }

[Collection(nameof(IntegrationFixture))]
public class IntegrationFixture
{
    public IServiceProvider Services { get; }

    public IntegrationFixture()
    {
        var host = new HostBuilder()
            .ConfigureServices(s => s.UseFacilityClients().UseScrubbers().UseReporting())
            .Build();

        this.Services = host.Services;
    }
}