/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class ExcelReporter : IReporter
{
    private readonly SpreadsheetWriter _writer;

    public ExcelReporter(SpreadsheetWriter writer)
    {
        this._writer = writer;
    }

    public ReportType ReportType => ReportType.Excel;

    public async Task WriteToFile(IEnumerable<WorksheetConfiguration> worksheets)
    {
        try
        {
            var scaffold = worksheets.Select(WorksheetScaffoldMapper.MapToScaffold);

            foreach (var config in scaffold)
            {
                await this._writer.RenderTableView(config);
            }
        }
        catch (Exception e)
        {
            // TODO: maybe cleanup
            throw new Exception("Was unable to write your file.", e);
        }
    }

    public void Dispose()
    {
        this._writer.Dispose();
        GC.SuppressFinalize(this);
    }
}