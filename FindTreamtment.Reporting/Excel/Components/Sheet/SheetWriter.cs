/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class SheetWriter
{
    public static Task<Sheet> Render(
        string id,
        uint sheetId,
        WorksheetOptions options)
    {
        return new Sheet
            {
                Id = id,
                SheetId = sheetId,
                Name = options.SheetName
            }
            .ToUnit();
    }
}