/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class FillFactory
{
    public static Fills CreateFills()
    {
        var fills = new Fills(
            // Index 0
            DefaultFill,
            // Index 1
            GreyFill,
            // Index 2
            HighlightYellowFill,
            // Index 3
            BlueFill,
            //Index 4 
            BlackFill
        );

        fills.Count = (uint)fills.ChildElements.Count;

        return fills;
    }

    public static Fill DefaultFill => new(new PatternFill { PatternType = PatternValues.None });
    public static Fill GreyFill => new(new PatternFill { PatternType = PatternValues.Gray125 });

    public static Fill HighlightYellowFill => new(
        new PatternFill(new ForegroundColor
        {
            Rgb = Colors.UriYellow
        })
        {
            PatternType = PatternValues.Solid
        });

    public static Fill BlueFill => new(
        new PatternFill(new ForegroundColor
        {
            Rgb = Colors.UriBlue
        })
        {
            PatternType = PatternValues.Solid
        });

    public static Fill BlackFill => new(
        new PatternFill(new ForegroundColor
        {
            Rgb = Colors.UriBlack
        })
        {
            PatternType = PatternValues.Solid
        });
}