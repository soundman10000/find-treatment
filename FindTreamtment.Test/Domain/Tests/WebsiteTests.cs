/*
* Find Treatment
*/

using FindTreatment.Domain;
using FluentAssertions;
using Xunit;

namespace FindTreatment.Test.Domain;

[Collection(nameof(DomainTestFixture))]
public class WebsiteTests
{
    [Theory]
    [InlineData("http://google.com", true)]
    [InlineData("http://www.google.com", true)]
    // Will not validate, but will instantiate
    [InlineData("www.google.com", false)]
    [InlineData("httsgoogle", false)]
    public void WebsiteValidationSucceed(string uri, bool success)
    {
        Website.Validate(uri).Should().Be(success);
    }

    [Theory]
    [InlineData("http://google.com")]
    [InlineData("http://www.google.com")]
    [InlineData("www.google.com")]
    public void WebsiteInstantiation(string uri)
    {
        var test = () => new Website(uri);
        test.Should().NotThrow();
    }

    [Fact]
    public void BadWebsiteThrow()
    {
        const string uri = "htei://ohno.com";
        var test = () => new Website(uri);
        test.Should().Throw<InvalidWebsiteException>();
    }
}
