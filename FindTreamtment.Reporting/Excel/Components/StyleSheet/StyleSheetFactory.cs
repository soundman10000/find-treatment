/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class StyleSheetFactory
{
    public static Stylesheet GetStylesheet()
    {
        var styleSheet = new Stylesheet();

        var fonts = FontsFactory.CreateFonts();
        var fills = FillFactory.CreateFills();
        var borders = BorderFactory.CreateBorders();
        var cellStyleFormats = CellStyleFormatFactory.CreateCellStyleFormats();
        var cellFormats = CellFormatFactory.GetCellFormats();
        var cellStyles = CellStylesFactory.CreateCellStyles();

        styleSheet.Append(fonts);
        styleSheet.Append(fills);
        styleSheet.Append(borders);
        styleSheet.Append(cellStyleFormats);
        styleSheet.Append(cellFormats);
        styleSheet.Append(cellStyles);

        return styleSheet;
    }
}