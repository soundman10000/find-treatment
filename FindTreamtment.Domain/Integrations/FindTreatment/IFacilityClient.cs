/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public interface IFacilityClient
{
    const int DefaultPageSize = 30;

    Task<int> FacilityCount(Limit? limit = null);

    Task<IEnumerable<Facility>> FindFacilities(
        int page = 1,
        int pageSize = DefaultPageSize,
        Limit? limit = null);
}