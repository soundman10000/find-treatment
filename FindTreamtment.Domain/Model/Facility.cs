﻿/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public record Facility
{
    public string Name1 { get; }
    public string Name2 { get; }
    public IReadOnlyCollection<IContact> Contact { get; }
    public Website? Website { get; }
    public Coordinate GeoLocation { get; }
    public IReadOnlyCollection<Address> Addresses { get; }

    public Facility(
        string name1,
        string name2,
        IEnumerable<Address> addresses,
        IEnumerable<IContact> contact,
        Website? website,
        Coordinate geoLocation)
    {
        this.Name1 = name1;
        this.Name2 = name2;
        this.Contact = contact.Coalesce().ToList();
        this.Website = website;
        this.GeoLocation = geoLocation;
        this.Addresses = addresses.Coalesce().ToList();
    }
}