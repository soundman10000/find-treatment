/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class WorksheetConfiguration
{
    /// <summary>
    /// Throttle for the GC
    /// higher the number, faster with more mem
    /// lower the number, slower with less mem
    /// </summary>
    private const int DefaultThrottle = 1000;

    /// <summary>
    /// When all columns have default width, set default logo end column index to 11
    /// </summary>
    private const int DefaultLogoEndColumnIndex = 11;

    /// <summary>
    /// Default value to freeze rows in sheet
    /// </summary>
    private const int DefaultFreezeRowCount = 1;

    /// <summary>
    /// Default logo right border offset from logo end column
    /// </summary>
    private const string DefaultLogoRightBorderOffset = "0";

    private readonly string? _sheetName;

    public IEnumerable<WorksheetPartitionConfiguration> Partitions { get; }
    public int Throttle { get; }

    public bool DisplayLogo { get; }

    public int LogoEndColumnIndex { get; }
    public int FreezeRowCount { get; }
    public IEnumerable<string> MergeCellsRangeList { get; }
    public IEnumerable<SingleCellStyle> CustomizedCellStyleList { get; }
    public string LogoRightBorderOffset { get; set; }

    public WorksheetConfiguration(
        IEnumerable<WorksheetPartitionConfiguration> partitions,
        string? sheetName = null,
        int? throttle = null,
        bool displayLogo = true,
        int? logoEndColumnIndex = null,
        int? freezeRowCount = null,
        string? logoRightBorderOffset = null,
        IEnumerable<string>? mergeCellsRangeList = null,
        IEnumerable<SingleCellStyle>? customizedCellStyleList = null)
    {
        this._sheetName = sheetName;
        this.Partitions = partitions;
        this.Throttle = throttle ?? DefaultThrottle;
        this.DisplayLogo = displayLogo;
        this.LogoEndColumnIndex = logoEndColumnIndex ?? DefaultLogoEndColumnIndex;
        this.FreezeRowCount = freezeRowCount ?? DefaultFreezeRowCount;
        this.MergeCellsRangeList = mergeCellsRangeList.Coalesce();
        this.CustomizedCellStyleList = customizedCellStyleList.Coalesce();
        this.LogoRightBorderOffset = logoRightBorderOffset ?? DefaultLogoRightBorderOffset;
    }

    // Abstractions
    public string SheetName => this._sheetName ??
                               this.Partitions.FirstOrDefault()?.Data.TableName ??
                               throw new Exception("No data or sheet name");
}