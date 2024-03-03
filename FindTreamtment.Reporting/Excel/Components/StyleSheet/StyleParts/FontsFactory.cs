/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class FontsFactory
{
    public static Fonts CreateFonts()
    {
        var fonts = new Fonts();
        fonts.Append(
            // 0
            StandardFont,
            // 1
            HeaderFont,
            // 2
            WhiteHeaderFont,
            // 3
            RedFont,
            // 4
            GreenFont,
            // 5
            BoldFont
        );

        fonts.Count = (uint)fonts.ChildElements.Count;
        return fonts;
    }

    public static Font StandardFont => new Font()
    {
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.GeneralFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 0 }
    };

    public static Font HeaderFont => new Font()
    {
        Bold = new Bold(),
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.HeaderFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 1 },
        Color = new Color { Rgb = Colors.UriWhite }
    };

    public static Font WhiteHeaderFont => new Font()
    {
        Bold = new Bold(),
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.HeaderFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 1 },
        Color = new Color { Rgb = Colors.UriBlack }
    };
    public static Font RedFont => new Font()
    {
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.GeneralFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 0 },
        Color = new Color { Rgb = Colors.UriRed }
    };
    public static Font GreenFont => new Font()
    {
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.GeneralFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 0 },
        Color = new Color { Rgb = Colors.UriGreen }
    }; 
    public static Font BoldFont => new Font()
    {
        Bold = new Bold(),
        FontName = FontStyles.GeneralFontStyle,
        FontSize = FontSizes.GeneralFontSize,
        FontFamilyNumbering = new FontFamilyNumbering { Val = 0 }
    };
}