/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class FacilityStateDetailMapper
{
    public static IEnumerable<FacilityStateDetailModel> ToReportModel(this IEnumerable<Facility> model) =>
        model.Select(ToReportModel);

    public static FacilityStateDetailModel ToReportModel(this Facility model)
    {
        var mainAddress = model.Addresses.FirstOrDefault(z => z.IsPrimary);
        var mainPhone = model.Contact.FirstOrDefault(z => z.Type == ContactTypes.Main);

        return new FacilityStateDetailModel
        {
            Name = model.Name1,
            AlternateName = model.Name2,
            Address1 = mainAddress?.Address1 ?? string.Empty,
            Address2 = mainAddress?.Address2 ?? string.Empty,
            City = mainAddress?.City ?? string.Empty,
            State = mainAddress?.State ?? string.Empty,
            PostalCode = mainAddress?.Postal ?? string.Empty,
            PhoneNumber = mainPhone?.Value ?? string.Empty,
            WebSite = model.Website?.Address ?? string.Empty,
            Services = string.Join("\r\n", model.Services.Coalesce())
        };
    }
}