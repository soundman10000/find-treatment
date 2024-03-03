/*
* Find Treatment
*/

using FindTreatment.Reporting;

namespace FindTreatment.Reporting
{
    public readonly struct WorksheetOptions
    {
        public string SheetName { get; }
        public int Throttle { get; }
        public IReadOnlyDictionary<uint, double> ColumnLookUps { get; }
        public bool DisplayLogo { get; }
        public int LogoEndColumnIndex { get; }
        public string LogoRightBorderOffset { get; }
        public int FreezeRowCount { get; }
        public IEnumerable<string> MergeCellsRangeList { get; }
        public IEnumerable<SingleCellStyle> CustomizedCellStyleList { get; }

        public WorksheetOptions(
            string sheetName,
            int throttle,
            bool displayLogo,
            int logoEndColumnIndex,
            int freezeRowCount,
            string logoRightBorderOffset,
            IReadOnlyDictionary<uint, double> columnLookUps,
            IEnumerable<string> mergeCellsRangeList,
            IEnumerable<SingleCellStyle> customizedCellStyleList)
        {
            this.SheetName = sheetName;
            this.Throttle = throttle;
            this.ColumnLookUps = columnLookUps;
            this.DisplayLogo = displayLogo;
            this.LogoEndColumnIndex = logoEndColumnIndex;
            this.FreezeRowCount = freezeRowCount;
            this.MergeCellsRangeList = mergeCellsRangeList;
            this.LogoRightBorderOffset = logoRightBorderOffset;
            this.CustomizedCellStyleList = customizedCellStyleList;
        }
    }
}


public static class WorkSheetOptionsExtensions
{
    public static bool ProcessColumnWidth(this WorksheetOptions worksheetOptions) => 
        worksheetOptions.ColumnLookUps.Any();

    public static bool ProcessMergeCells(this WorksheetOptions worksheetOptions) =>
        worksheetOptions.MergeCellsRangeList.Any();
    public static bool ProcessCustomizedCellStyle(this WorksheetOptions worksheetOptions) =>
        worksheetOptions.CustomizedCellStyleList.Any();
}