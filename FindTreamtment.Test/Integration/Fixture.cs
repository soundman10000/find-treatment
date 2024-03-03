/*
* Find Treatment
*/

using FindTreatment.Domain;
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
            .ConfigureServices(s => s
                .UseFacilityClients()
                .UseScrubbers()
                .UseReports())
            .Build();

        this.Services = host.Services;
    }
}