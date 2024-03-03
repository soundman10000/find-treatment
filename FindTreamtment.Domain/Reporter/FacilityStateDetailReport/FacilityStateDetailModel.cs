/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public record FacilityStateDetailModel
{
    public string Name { get; init; } = null!;
    public string AlternateName { get; init; } = null!;
    public string Address1 { get; init; } = null!;
    public string Address2 { get; init; } = null!;
    public string City { get; init; } = null!;
    public string State { get; init; } = null!;
    public string PostalCode { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string WebSite { get; init; } = null!;
    public string Services { get; init; } = null!;
}