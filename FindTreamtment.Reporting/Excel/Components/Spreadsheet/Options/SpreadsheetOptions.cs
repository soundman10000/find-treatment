/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct SpreadsheetOptions
{
    public string FileName { get; }

    public SpreadsheetOptions(string fileName)
    {
        this.FileName = fileName;
    }
}