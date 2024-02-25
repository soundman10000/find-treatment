/*
* Find Treatment
*/

using Newtonsoft.Json;

namespace FindTreatment.Domain;

public class GovFacilitiesClient : IFacilityClient
{
    // Dictated by the government
    private const int MaxResults = 2000;

    private readonly HttpClient _client;
    private readonly JsonSerializerSettings _settings;

    public GovFacilitiesClient(HttpClient client, JsonSerializerSettings settings)
    {
        this._client = client;
        this._settings = settings;
    }

    public async Task<int> FacilityCount()
    {
        try
        {
            var response = await this._client.GetAsync(string.Empty);

            return response.IsSuccessStatusCode
                ? await response.ReadAndDeserializeResponse<GovPaginatedResponse<GovFacility>>(this._settings)
                    .Map(z => z?.RecordCount ?? 0)
                : throw await HandleFailureResponse(response);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not make request to government", ex);
        }
    }

    public async Task<IEnumerable<Facility>> FindFacilities(
        int page = 1,
        int pageSize = IFacilityClient.DefaultPageSize,
        Limit? limit = null)
    {
        if (page > MaxResults)
        {
            throw new ArgumentException($"Cannot exceed {MaxResults} records");
        } 

        var queryString = new
            {
                page,
                pageSize,
                limitType = (int?)limit?.Type,
                limitValue = limit?.Value
            }
            .ToQueryString();

        try
        {
            var response = await this._client.GetAsync(queryString);

            return response.IsSuccessStatusCode
                ? await response.ReadAndDeserializeResponse<GovPaginatedResponse<GovFacility>>(this._settings)
                    .Map(z => z?.Rows ?? Enumerable.Empty<GovFacility>())
                    .Map(GovFacilityMapper.ToFacility)
                    .Map(Enumerable.ToList)
                : throw await HandleFailureResponse(response);
        }
        catch (Exception ex)
        {
            throw new Exception("Could not make request to government", ex);
        }
    }

    private static async Task<Exception> HandleFailureResponse(HttpResponseMessage result)
    {
        var uri = result.RequestMessage?.RequestUri?.AbsoluteUri ?? string.Empty;
        var response = await result.Content.ReadAsStringAsync();

        return new Exception($"\r\nUri : {uri}" +
                             $"\r\nMessage: {response}");
    }
}