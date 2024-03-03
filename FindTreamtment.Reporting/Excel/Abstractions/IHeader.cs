/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public interface IHeader
{
    CellFormats Style { get; }
    Task<IEnumerable<RowScaffold>> GenerateHeader(WorksheetPartitionScaffold scaffold);
}