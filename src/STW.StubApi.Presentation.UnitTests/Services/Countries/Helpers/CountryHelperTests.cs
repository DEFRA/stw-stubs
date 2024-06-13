namespace STW.StubApi.Presentation.UnitTests.Services.Countries.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Countries.Helpers;
using TestHelpers;

[TestClass]
public class CountryHelperTests
{
    [TestMethod]
    public void GetCountryOrRegion_ReturnsNull_WhenNoMatchingCountryOrRegionIsFound()
    {
        // Act
        var result = CountryHelper.GetCountryOrRegion(TestConstants.NonMatchingString);

        // Assert
        result.Should().BeNull();
    }

    [TestMethod]
    public void GetCountryOrRegion_ReturnsCountry_WhenMatchingCountryOrRegionIsFound()
    {
        // Act
        var result = CountryHelper.GetCountryOrRegion(TestConstants.AfghanistanIsoCode);

        // Assert
        result.Should().NotBeNull();
        result.Code.Should().Be(TestConstants.AfghanistanIsoCode);
    }
}
