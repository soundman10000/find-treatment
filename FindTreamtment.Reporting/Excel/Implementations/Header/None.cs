/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class None : IHeader
{
    public CellFormats Style => CellFormats.General;

    public Task<IEnumerable<RowScaffold>> GenerateHeader(WorksheetPartitionScaffold scaffold) =>
        Array.Empty<RowScaffold>().AsEnumerable().ToUnit();
}