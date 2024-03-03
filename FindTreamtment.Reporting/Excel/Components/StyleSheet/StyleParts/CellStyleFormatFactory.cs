/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class CellStyleFormatFactory
{
    public static CellStyleFormats CreateCellStyleFormats()
    {
        // Create "cellStyleXfs" node.
        var cellStyleFormats = new CellStyleFormats();
        cellStyleFormats.Append(new CellFormat
        {
            NumberFormatId = 0,
            FontId = 0,
            FillId = 0,
            BorderId = 0,
        });

        cellStyleFormats.Count = (uint)cellStyleFormats.ChildElements.Count;
            
        return cellStyleFormats;
    }
}