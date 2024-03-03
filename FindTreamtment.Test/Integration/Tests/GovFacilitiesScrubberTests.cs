/*
* Find Treatment
*/

using FindTreatment.Domain;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FindTreatment.Test.Integration;

[Collection(nameof(IntegrationFixture))]
public class GovFacilitiesScrubberTests
{
    private readonly FindTreatmentGovernmentApiScrubber _scrubber;
    private readonly IFacilityClient _client;

    public GovFacilitiesScrubberTests(IntegrationFixture fixture)
    {
        this._scrubber = fixture.Services.GetRequiredService<FindTreatmentGovernmentApiScrubber>();
        this._client = fixture.Services.GetRequiredService<IFacilityClient>();
    }
  
    [Fact]
    public async Task StateLimitSuccess()
    {
        const string state = "Tx";
        var limit = new Limit(state);
        
        var totalRecords = await this._client.FacilityCount(limit);

        var results = await this._scrubber
            .GetStateFacilities(state)
            .Map(Enumerable.ToList);

        results.Should().HaveCount(totalRecords);
    }
}