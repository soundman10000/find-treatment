/*
* Find Treatment
*/

using DocumentFormat.OpenXml;

namespace FindTreatment.Reporting;

public static class Colors
{
    public static readonly HexBinaryValue UriBlue = new() { Value = "0077B7" };
    public static readonly HexBinaryValue UriYellow = new() { Value = "FFFFFF00" };
    public static readonly HexBinaryValue UriWhite = new() { Value = "FFFFFF" };
    public static readonly HexBinaryValue UriBlack = new() { Value = "000000" };
    public static readonly HexBinaryValue UriCellRed = new() { Value = "FFC7CE" };
    public static readonly HexBinaryValue UriCellGreen = new() { Value = "C6EFCE" };
    public static readonly HexBinaryValue UriRed = new() { Value = "9C0006" };
    public static readonly HexBinaryValue UriGreen = new() { Value = "006100" };
}