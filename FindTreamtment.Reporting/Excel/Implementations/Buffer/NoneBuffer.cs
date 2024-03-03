/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class NoneBuffer : IBuffer
{
    public Task<IEnumerable<RowScaffold>> GenerateBuffer(WorksheetPartitionScaffold scaffold) =>
        Array.Empty<RowScaffold>().AsEnumerable().ToUnit();
}