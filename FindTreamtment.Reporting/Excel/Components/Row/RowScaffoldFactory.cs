/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public static class RowScaffoldFactory
{
    public static RowScaffold GenerateRowScaffold(
        DataRow data,
        RowTypes type,
        CellFormats style,
        double? rowHeight = null) =>
        new RowOptions(type, style, rowHeight)
            .Apply(z => new RowScaffold(data, z));
}