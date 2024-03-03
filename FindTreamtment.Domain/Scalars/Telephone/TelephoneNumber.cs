/*
* Find Treatment
*/

using System.Text.RegularExpressions;

namespace FindTreatment.Domain;

public readonly partial record struct TelephoneNumber : IContact
{

    private const char ExtensionDelimiter = 'x';

    private const string Validation = @"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
    [GeneratedRegex(Validation)]
    private static partial Regex ValidateRegex();
    
    public ContactTypes Type { get; }
    public string Value => this.ToString();
    
    public string UnderlyingValue { get; }
    public string? Extension { get; }

    public TelephoneNumber(string number, ContactTypes type)
    {
        // For people who put a 1 in their number
        if (number.Length == 11 && number[0] == '1')
        {
            number = number[1..];
        }

        var split = number.Split(ExtensionDelimiter, StringSplitOptions.TrimEntries);

        if (!IsValid(split[0]))
        {
            throw new InvalidTelephoneNumberException(number);
        }

        this.Type = type;
        this.UnderlyingValue = new string(split[0].Where(char.IsDigit).ToArray());
        this.Extension = split.Length > 1 ? split[1] : null;
    }

    public static bool IsValid(string input) => 
        input.Split(ExtensionDelimiter).First().Apply(ValidateRegex().IsMatch);

    public static string FormatPhoneNumber(string input, string? extension = null)
    {
        var ext = extension == null
            ? string.Empty
            : $" x{extension}";

        return input.Length <= 10
            ? $"{double.Parse(input):(###) ###-####}{ext}"
            : $"{double.Parse(input):+## (###) ###-####}{ext}";
    }

    public override string ToString() => 
        FormatPhoneNumber(this.UnderlyingValue, this.Extension);
}
