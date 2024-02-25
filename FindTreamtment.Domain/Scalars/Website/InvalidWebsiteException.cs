/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public class InvalidWebsiteException : Exception
{
    private const string ValidationMessage = "Invalid Website {0}";

    public InvalidWebsiteException(string url) : base(string.Format(ValidationMessage, url)) { }
}