/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public class FindTreatmentGovernmentApiScrubber
{
    private readonly record struct Request(Limit Limit, int Page, int PageSize);

    private readonly IFacilityClient _client;

    private const int BatchSize = 5;
    private const int PageSizeBuffer = 250;
    private const int PageSize = GovFacilitiesClient.MaxResults - PageSizeBuffer;

    public FindTreatmentGovernmentApiScrubber(IFacilityClient client)
    {
        this._client = client;
    }

    public async Task<IEnumerable<Facility>> GetStateFacilities(string stateCode)
    {
        var limit = new Limit(stateCode);
        var requestBatches = await this._client
            .FacilityCount(limit)
            .Map(ToPages)
            .Map(z => Enumerable.Range(1, z))
            .Map(z => z.Select(x => ToRequest(limit, x)))
            .Map(z => z.Chunk(BatchSize));

        IEnumerable<Facility> results = new List<Facility>();
        foreach (var batch in requestBatches)
        {
            results = await batch
                .Select(MakeRequest)
                .WhenAll()
                .Map(EnumerableExtensions.Flatten);
        }

        return results;
    }

    private async Task<IEnumerable<Facility>> MakeRequest(Request request)
    {
        try
        {
            return await this._client.FindFacilities(request.Page, request.PageSize, request.Limit)
                .Map(Enumerable.ToList)
                .Map(Enumerable.AsEnumerable);
        }
        catch (Exception e)
        {
            throw new Exception($"Was unable to make request for\r\n" +
                                $"page : {request.PageSize}",
                e);
        }
    }

    private static int ToPages(int records) => (records / (decimal) PageSize)
        .Apply(Math.Ceiling)
        .Apply(Convert.ToInt32);

    private static Request ToRequest(Limit limit, int pageNumber) => 
        new(limit, pageNumber, PageSize);
}