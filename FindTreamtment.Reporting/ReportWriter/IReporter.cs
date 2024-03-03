/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public interface IReporter : IDisposable
{
    ReportType ReportType { get; }
    Task WriteToFile(IEnumerable<WorksheetConfiguration> config);
}