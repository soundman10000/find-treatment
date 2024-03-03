/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class ReportConfiguration
{
    public string FileName { get; }
    public ReportType ReportType { get; }

    public ReportConfiguration(
        string fileName,
        ReportType reportType)
    {
        this.FileName = fileName;
        this.ReportType = reportType;
    }
}