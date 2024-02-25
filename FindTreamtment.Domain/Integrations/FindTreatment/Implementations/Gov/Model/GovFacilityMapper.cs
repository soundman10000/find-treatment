/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class GovFacilityMapper
{
    private static readonly IReadOnlyDictionary<string, Func<GovFacility, IContact?>> ContactFactory =
        new Dictionary<string, Func<GovFacility, IContact?>>
        {
            { nameof(GovFacility.Phone), f => ToContact(f.Phone, ContactTypes.Main) },
            { nameof(GovFacility.Hotline1), f => ToContact(f.Hotline1, ContactTypes.Hotline) },
            { nameof(GovFacility.Intake1), f => ToContact(f.Intake1, ContactTypes.Intake) }
        };

    public static IEnumerable<Facility> ToFacility(this IEnumerable<GovFacility> facility) =>
        facility.Select(ToFacility);

    public static Facility ToFacility(this GovFacility facility)
    {
        var addresses = facility.Apply(z =>
                new Address(
                    true,
                    AddressType.Mailing,
                    z.Street1,
                    z.Street2,
                    z.City,
                    z.State,
                    z.Zip))
            .Yield();

        var contacts = ContactFactory
            .Select(f => f.Value(facility))
            .Where(z => z != null)
            .Cast<IContact>();

        var webSite = facility.Website?.Apply(z => new Website(z));

        var location = facility.Apply(z => new Coordinate(z.Latitude, z.Longitude));

        return new Facility(facility.Name1, facility.Name2, addresses, contacts, webSite, location);
    }
        
    private static IContact? ToContact(string phone, ContactTypes type) =>
        phone?.Apply(z => new TelephoneNumber(z, type));
}