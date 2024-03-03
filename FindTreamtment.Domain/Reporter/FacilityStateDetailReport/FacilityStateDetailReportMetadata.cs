/*
* Find Treatment
*/

using FindTreatment.Reporting;
using static FindTreatment.Reporting.CellOptions;

namespace FindTreatment.Domain;

public static class FacilityStateDetailReportMetadata
{
    public static readonly IEnumerable<ColumnConfiguration> UriColumnConfigurations = new[]
    {
        new ColumnConfiguration(nameof(FacilityStateDetailModel.Name), "Name", 50, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.AlternateName), "Alternate Name", 30, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.Address1), "Address 1", 30, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.Address2), "Address 2", 30, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.City), "City", 25, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.State), "State", 25, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.PostalCode), "Zip Code", 25, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.PhoneNumber), "Phone #", 25, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.WebSite), "Web Site", 50, StringType),
        new ColumnConfiguration(nameof(FacilityStateDetailModel.Services), "Services", 100, StringType)
    };
}