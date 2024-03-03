/*
* Find Treatment
*/

using System.Data;
using FindTreatment.Reporting;

namespace FindTreatment.Domain;

public class FacilityStateDetailReport
{
    private readonly record struct ReportStateModel(string State, DataTable Data);

    private readonly FindTreatmentGovernmentApiScrubber _scrubber;
    private readonly ReporterFactory _reporterFactory;

    private readonly Func<string, ReportConfiguration> _configFactory =
        s => new ReportConfiguration(s, ReportType.Excel);

    public FacilityStateDetailReport(
        FindTreatmentGovernmentApiScrubber scrubber,
        ReporterFactory reporterFactory)
    {
        this._scrubber = scrubber;
        this._reporterFactory = reporterFactory;
    }

    public async Task RunStateTreatmentReport(string fileName)
    {
        var config = this._configFactory(fileName);

        using var reporter = this._reporterFactory.GenerateReporter(config);
        foreach (var (state, _) in CovStateCodeLookup.UriStateCodeLookup)
        {
            var model = await this.PrepareSheetModel(state);
            await reporter.WriteToFile(model.Yield());
        }
    }

    private Task<WorksheetConfiguration> PrepareSheetModel(string state) =>
        this._scrubber.GetStateFacilities(state)
            .Map(FacilityStateDetailMapper.ToReportModel)
            .Map(z => z.OrderBy(a => a.City).ThenBy(b => b.PostalCode).ThenBy(c => c.Name))
            .Map(z => z.ToDataTable())
            .Map(dt => new ReportStateModel(state, dt))
            .Map(ModelToWorksheetConfig);

    private static WorksheetConfiguration ModelToWorksheetConfig(ReportStateModel model) =>
        model.Data
            .Apply(z =>
                new WorksheetPartitionConfiguration(
                    z,
                    FacilityStateDetailReportMetadata.UriColumnConfigurations,
                    HeaderTypes.Default,
                    BufferTypes.None,
                    headerRowHeight: 25))
            .Yield()
            .Apply(z => new WorksheetConfiguration(z, model.State));
}