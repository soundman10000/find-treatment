/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public readonly struct WorksheetPartitionOptions
{
    public IReadOnlyDictionary<string, ColumnOptions> ColumnOptions { get; }

    public HeaderTypes HeaderType { get; }
    public BufferTypes BufferType { get; }

    public int Buffer { get; }
    public double? HeaderRowHeight { get;}

    public WorksheetPartitionOptions(
        IEnumerable<ColumnOptions> columnOptions,
        HeaderTypes headerType,
        int buffer,
        BufferTypes bufferType,
        double? headerRowHeight = null)
    {
        this.ColumnOptions = columnOptions.ToColumnFunctionMap();
        this.HeaderType = headerType;
        this.Buffer = buffer;
        this.HeaderRowHeight = headerRowHeight;
        this.BufferType = bufferType;
    }
}