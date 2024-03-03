/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class FontStyles
{
    public static FontName GeneralFontStyle => new() { Val = "Calibri" };
}

public static class FontSizes
{
    public static FontSize GeneralFontSize => new() { Val = 11 };
    public static FontSize HeaderFontSize => new() { Val = 12 };
}