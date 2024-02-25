/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public readonly record struct Website
{
    public readonly string DefaultScheme = Uri.UriSchemeHttp;

    public string Address { get; }

    public Website(string uri)
    {
        if (Uri.CheckSchemeName(uri))
        {
            uri = $"{DefaultScheme}:\\\\{uri}";
        }

        if (!Validate(uri))
        {
            throw new InvalidWebsiteException(uri);
        }

        this.Address = uri;
    }

    public static bool Validate(string input) =>
        Uri.TryCreate(input, UriKind.Absolute, out var uriResult)
        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

    public override string ToString() => this.Address;
}
