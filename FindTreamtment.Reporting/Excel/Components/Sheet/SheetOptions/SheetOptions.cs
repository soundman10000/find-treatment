/*
* Find Treatment
*/

using DocumentFormat.OpenXml;

namespace FindTreatment.Reporting;

public readonly struct SheetOptions
{
    public UInt32Value SheetId { get; }
    public string TabName { get; }

    public SheetOptions(int sheetId, string tabName)
    {
        this.SheetId = (uint)sheetId;
        this.TabName = tabName;
    }
}