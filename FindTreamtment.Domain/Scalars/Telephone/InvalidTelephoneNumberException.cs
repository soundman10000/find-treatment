/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public class InvalidTelephoneNumberException : Exception
{
    private const string ValidationMessage = "Invalid Phone Number {0}";
    public InvalidTelephoneNumberException(string badNumber) : base(string.Format(ValidationMessage, badNumber)) { }
}