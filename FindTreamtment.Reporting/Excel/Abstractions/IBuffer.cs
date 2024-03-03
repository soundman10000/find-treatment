/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public interface IBuffer
{
    Task<IEnumerable<RowScaffold>> GenerateBuffer(WorksheetPartitionScaffold scaffold);
}