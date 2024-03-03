/*
* Find Treatment
*/

using FindTreatment.Domain;
using FluentAssertions;
using Xunit;

namespace FindTreatment.Test.Domain;

[Collection(nameof(DomainTestFixture))]
public class TelephoneTests
{
    [Theory]
    [InlineData("1236545555", true)]
    [InlineData("123-456-7890", true)]
    [InlineData("(123) 456-7890", true)]
    [InlineData("123 456 7890", true)]
    [InlineData("+91 (123) 456-7890", true)]
    [InlineData("12345698", false)]
    [InlineData("1298", false)]
    [InlineData("(123) 456-78901", false)]
    // No extensions in validation
    [InlineData("123-456-7890 x1234", false)]
    public void PhoneNumberValidationSucceed(string phoneNumber, bool success)
    {
        TelephoneNumber.IsValid(phoneNumber).Should().Be(success);
    }

    [Theory]
    [InlineData("1234567890", "(123) 456-7890")]
    [InlineData("911234567890", "+91 (123) 456-7890")]
    public void PhoneNumberFormat(string number, string shouldBe)
    {
        TelephoneNumber.FormatPhoneNumber(number).Should().Be(shouldBe);
    }

    [Fact]
    public void BadNumberThrow()
    {
        const string badNumber = "1548754";
        var test = () => new TelephoneNumber(badNumber, ContactTypes.Main);
        test.Should().Throw<InvalidTelephoneNumberException>();
    }

    [Fact]
    public void NumberWithExtension()
    {
        const string number = "(713) 555-5555 x1234";
        new TelephoneNumber(number, ContactTypes.Main).ToString().Should().Be(number);
    }

    [Fact]
    public void TelephoneInstantiation()
    {
        const string number = "(713) 555-5555";
        new TelephoneNumber(number, ContactTypes.Main).ToString().Should().Be(number);
    }

    [Fact]
    public void NumberWith1BeforeAreaCode()
    {
        const string number = "12404612481";
        var test = () => new TelephoneNumber(number, ContactTypes.Main);
        test.Should().NotThrow();
    }
}