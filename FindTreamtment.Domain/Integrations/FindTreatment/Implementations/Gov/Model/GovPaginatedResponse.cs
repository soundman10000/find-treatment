/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public record GovPaginatedResponse<T> where T : class
{
    public int Page { get; init; }
    public int TotalPages { get; init; }
    public int RecordCount { get; init; }
    public List<T> Rows { get; init; } = new();
}