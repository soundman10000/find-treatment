/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class CellStylesFactory
{
    public static CellStyles CreateCellStyles()
    {
        // Create "cellStyles" node.
        var cellStyles = new CellStyles();
        cellStyles.Append(new CellStyle
            {
                Name = "Normal",
                FormatId = 0,
                BuiltinId = 0
            }
        );

        cellStyles.Count = (uint)cellStyles.ChildElements.Count;

        return cellStyles;
    }
}