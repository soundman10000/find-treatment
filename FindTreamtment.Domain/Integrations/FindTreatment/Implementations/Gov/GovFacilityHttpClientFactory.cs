/*
* Find Treatment
*/

using Newtonsoft.Json;

namespace FindTreatment.Domain;

public class GovFacilityHttpClientFactory
{
    private readonly JsonSerializerSettings _settings;
    private static readonly Uri BaseUrl = new("https://findtreatment.gov/locator/exportsAsJson/v2");

    public GovFacilityHttpClientFactory(JsonSerializerSettings settings)
    {
        this._settings = settings;
    }

    public GovFacilitiesClient Generate() =>
        this.BuildClient()
            .Apply(z => new GovFacilitiesClient(z, this._settings));

    private HttpClient BuildClient() =>
        new()
        {
            BaseAddress = BaseUrl
        };
}