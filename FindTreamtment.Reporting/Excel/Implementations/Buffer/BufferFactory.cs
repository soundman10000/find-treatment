/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class BufferFactory
{
    public static IBuffer GenerateBufferType(this BufferTypes buffer) =>
        buffer switch
        {
            BufferTypes.Default => new DefaultBuffer(),
            BufferTypes.None => new NoneBuffer(),
            _ => throw new ArgumentOutOfRangeException(nameof(buffer), buffer, null)
        };
}