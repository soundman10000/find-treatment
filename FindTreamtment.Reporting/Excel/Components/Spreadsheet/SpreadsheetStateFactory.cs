/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class SpreadsheetStateFactory
{
    private readonly IFileManager _fileManager;

    public SpreadsheetStateFactory(IFileManager fileManager)
    {
        this._fileManager = fileManager;
    }

    public SpreadsheetState? GenerateSpreadsheetState(SpreadsheetOptions options) =>
        this._fileManager
            .Exists(options.FileName)
            .Apply(exists =>
                exists
                    ? SpreadsheetState.ResumedState(options)
                    : SpreadsheetState.NewState(options));
}