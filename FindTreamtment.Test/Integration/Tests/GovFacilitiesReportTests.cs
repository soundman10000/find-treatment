/*
* Find Treatment
*/

using FindTreatment.Domain;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FindTreatment.Test.Integration;

[Collection(nameof(IntegrationFixture))]
public class GovFacilitiesReportTests
{
    private readonly FacilityStateDetailReport _reporter;

    public GovFacilitiesReportTests(IntegrationFixture fixture)
    {
        this._reporter = fixture.Services.GetRequiredService<FacilityStateDetailReport>();
    }

    [Fact]
    public async Task WriteReport()
    {
        const string fileName = "C:\\users\\jmalley\\desktop\\test.xlsx";
        await this._reporter.RunStateTreatmentReport(fileName);
    }
}