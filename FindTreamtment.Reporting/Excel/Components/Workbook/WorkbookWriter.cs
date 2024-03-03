/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class WorkbookWriter
{
    public static WorkbookPart Create(SpreadsheetDocument spreadsheet, WorkbookOptions options)
    {
        var workbookPart = spreadsheet.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();

        var workbookStylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
        workbookStylesPart.Stylesheet = StyleSheetFactory.GetStylesheet();
        workbookStylesPart.Stylesheet.Save();

        return workbookPart;
    }
}