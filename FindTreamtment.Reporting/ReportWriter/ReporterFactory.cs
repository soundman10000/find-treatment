/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class ReporterFactory
{
    private readonly OptionsMapper _optionsMapper;
    private readonly SpreadsheetStateFactory _stateFactory;

    public ReporterFactory(
        OptionsMapper optionsMapper, 
        SpreadsheetStateFactory stateFactory)
    {
        this._optionsMapper = optionsMapper;
        this._stateFactory = stateFactory;
    }

    public IReporter GenerateReporter(ReportConfiguration configuration) =>
        configuration.ReportType switch
        {
            ReportType.Excel => this.CreateExcelReporter(configuration),
            ReportType.Csv => new CsvReporter(),
            _ => throw new ArgumentOutOfRangeException(nameof(configuration.ReportType), configuration.ReportType, null)
        };

    private ExcelReporter CreateExcelReporter(ReportConfiguration configuration) =>
        this._optionsMapper.MapOptions(configuration)
            .Apply(o => new SpreadsheetWriter(o, this._stateFactory))
            .Apply(x => new ExcelReporter(x));
}