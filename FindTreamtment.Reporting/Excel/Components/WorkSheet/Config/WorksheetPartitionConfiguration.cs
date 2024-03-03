/*
* Find Treatment
*/

using System.Data;

namespace FindTreatment.Reporting;

public class WorksheetPartitionConfiguration
{
    private const HeaderTypes DefaultPartitionHeader = HeaderTypes.Default;

    private const BufferTypes DefaultBufferType = BufferTypes.Default;

    private const int DefaultBuffer = 1;

    public WorksheetPartitionConfiguration(
        DataTable data, 
        IEnumerable<ColumnConfiguration> columns, 
        HeaderTypes? headerType,
        BufferTypes? bufferType,
        int? buffer = null,
        double? headerRowHeight = null)
    {
        this.Data = data;
        this.Columns = columns;
        this.HeaderType = headerType ?? DefaultPartitionHeader;
        this.Buffer = buffer ?? DefaultBuffer;
        this.HeaderRowHeight = headerRowHeight;
        this.BufferType = bufferType ?? DefaultBufferType;
    }

    public int Buffer { get; set; }
    public DataTable Data { get; }
    public IEnumerable<ColumnConfiguration> Columns { get; }
    public HeaderTypes HeaderType { get; }
    public double? HeaderRowHeight { get; }
    public BufferTypes BufferType { get; }
}