/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public record Address(
    bool IsPrimary,
    AddressType AddressType,
    string Address1,
    string? Address2,
    string City,
    string State,
    string Postal);
