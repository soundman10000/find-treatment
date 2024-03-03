/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public record GovFacility(
    string Name1,
    string Name2,
    string Street1,
    string Street2,
    string City,
    string State,
    string Zip,
    string Phone,
    string Intake1,
    string Hotline1,
    string Website,
    float Latitude,
    float Longitude,
    string TypeFacility,
    List<GovFacilityService> Services);
