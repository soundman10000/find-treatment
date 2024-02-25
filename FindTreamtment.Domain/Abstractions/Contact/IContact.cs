/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public interface IContact
{
    public ContactTypes Type { get; }
    public string Value { get; }
}