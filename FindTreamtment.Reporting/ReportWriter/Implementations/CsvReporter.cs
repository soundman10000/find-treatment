/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class CsvReporter : IReporter
{
    public ReportType ReportType => ReportType.Csv;

    public Task WriteToFile(IEnumerable<WorksheetConfiguration> data)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}