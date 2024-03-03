/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class OptionsMapper
{
    public SpreadsheetOptions MapOptions(ReportConfiguration config)
    {
        // We can do any mapping of simple configuration into a typed config
        return new SpreadsheetOptions(config.FileName);
    }
}