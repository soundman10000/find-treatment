/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class HeaderFactory
{
    public static IHeader GenerateHeaderType(this HeaderTypes header) =>
        header switch
        {
            HeaderTypes.Default => new Default(),
            HeaderTypes.None => new None(),
            HeaderTypes.PartitionHeader => new PartitionHeader(),
            HeaderTypes.PlainHeader => new PlainHeader(),
            _ => throw new ArgumentOutOfRangeException(nameof(header), header, null)
        };
}