/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class BorderFactory
{
    public static Borders CreateBorders()
    {
        var borders = new Borders();
        borders.Append(new Border
        {
            LeftBorder = new LeftBorder(),
            RightBorder = new RightBorder(),
            TopBorder = new TopBorder(),
            BottomBorder = new BottomBorder(),
            DiagonalBorder = new DiagonalBorder()
        });
        // BorderId = 1
        borders.Append(new Border
        {
            LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin },
            RightBorder = new RightBorder { Style = BorderStyleValues.Thin },
            TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
            BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin }
        });

        borders.Count = (uint)borders.ChildElements.Count;
            
        return borders;
    }
}