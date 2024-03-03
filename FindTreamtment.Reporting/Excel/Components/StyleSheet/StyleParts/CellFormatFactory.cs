/*
* Find Treatment
*/

using DocumentFormat.OpenXml.Spreadsheet;

namespace FindTreatment.Reporting;

public static class CellFormatFactory
{
    public static DocumentFormat.OpenXml.Spreadsheet.CellFormats GetCellFormats()
    {
        var cellFormats = new DocumentFormat.OpenXml.Spreadsheet.CellFormats();

        // 0 General
        cellFormats.Append(new CellFormat
        {
            BorderId = 0,
            FillId = 0,
            FontId = 0,
            NumberFormatId = 0,
            FormatId = 0,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Left,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });

        // CellFormats.DateFormat
        cellFormats.Append(new CellFormat
        {
            BorderId = 0,
            FillId = 0,
            FontId = 0,
            NumberFormatId = 14,
            FormatId = 0,
            ApplyNumberFormat = true,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });

        // CellFormats.DateTimeFormat
        cellFormats.Append(new CellFormat
        {
            BorderId = 0,
            FillId = 0,
            FontId = 0,
            NumberFormatId = 22,
            FormatId = 0,
            ApplyNumberFormat = true,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });

        // CellFormats.Header1
        cellFormats.Append(new CellFormat
        {
            BorderId = 1,
            FillId = 3,
            FontId = 1,
            FormatId = 0,
            ApplyFill = true,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });

        // CellFormats.Header2
        cellFormats.Append(new CellFormat
        {
            BorderId = 0,
            FillId = 4,
            FontId = 1,
            FormatId = 0,
            ApplyFill = true,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });
        // CellFormats.Header3
        cellFormats.Append(new CellFormat
        {
            BorderId = 1,
            FillId = 0,
            FontId = 2,
            FormatId = 0,
            ApplyFill = true,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });
        // 8 ErrorTextCell
        cellFormats.Append(new CellFormat
        {
            BorderId = 0,
            FillId = 0,
            FontId = 0,
            NumberFormatId = 0,
            FormatId = 0,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Left,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });
        // CellFormats.AllBordersCell
        cellFormats.Append(new CellFormat
        {
            BorderId = 1,
            FillId = 0,
            FontId = 0,
            NumberFormatId = 0,
            FormatId = 0,
            ApplyAlignment = true,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Center,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });
        cellFormats.Count = (uint) cellFormats.ChildElements.Count;
        return cellFormats;
    }
}