/*
* Find Treatment
*/

using Xunit;

namespace FindTreatment.Test.Domain;

[CollectionDefinition(nameof(DomainTestFixture))]
public class DomainTestCollectionDefinition : ICollectionFixture<DomainTestFixture> { }

[Collection(nameof(DomainTestFixture))]
public class DomainTestFixture
{
    public const string DomainTests = "Domain";
}