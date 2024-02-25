/*
* Find Treatment
*/

using FindTreatment.Domain;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FindTreatment.Test.Integration;

[Collection(nameof(IntegrationFixture))]
public class GovFacilitiesClientTests
{
    private readonly IFacilityClient _client;

    public GovFacilitiesClientTests(IntegrationFixture fixture)
    {
        this._client = fixture.Services.GetRequiredService<IFacilityClient>();
    }

    [Fact]
    public async Task SimpleRequest()
    {
        var basicResults = await this._client.FindFacilities().Map(Enumerable.ToList);
        basicResults.Should().HaveCount(IFacilityClient.DefaultPageSize);
    }

    [Fact]
    public async Task PageSucceed()
    {
        var assertionResults = await this._client.FindFacilities(pageSize: 2).Map(Enumerable.ToList);
        var firstOne = await this._client.FindFacilities(pageSize: 1).Map(Enumerable.Single);
        var secondOne = await this._client.FindFacilities(2, pageSize: 1).Map(Enumerable.Single);
        
        firstOne.Should().BeEquivalentTo(assertionResults[0]);
        secondOne.Should().BeEquivalentTo(assertionResults[1]);
    }

    [Fact]
    public async Task PageSizeSucceed()
    {
        const int pageSize = 50;

        var basicResults = await this._client.FindFacilities(pageSize: pageSize).Map(Enumerable.ToList);
        basicResults.Should().HaveCount(pageSize);
    }

    [Fact]
    public async Task StateLimitSuccess()
    {
        const int pageSize = 50;
        const string state = "Tx";
        var limit = new Limit(state);

        var basicResults = await this._client
            .FindFacilities(pageSize: pageSize, limit: limit).Map(Enumerable.ToList);
        
        basicResults.Should().HaveCount(pageSize);
        basicResults.Should().AllSatisfy(z => z.Addresses.First(x => x.IsPrimary).State.Should().Be(state.ToUpper()));
    }

    [Fact]
    public async Task ToManyRecordsThrows()
    {
        var test = () => this._client.FindFacilities(2001);
        await test.Should().ThrowAsync<ArgumentException>();
    }
}