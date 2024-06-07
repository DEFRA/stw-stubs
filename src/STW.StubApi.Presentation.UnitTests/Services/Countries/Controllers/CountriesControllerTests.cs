namespace STW.StubApi.Presentation.UnitTests.Services.Countries.Controllers;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Countries.Controllers;
using Presentation.Services.Countries.Models;
using TestHelpers;

[TestClass]
public class CountriesControllerTests
{
    private CountriesController _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _systemUnderTest = new CountriesController();
    }

    [TestMethod]
    public void GetCountryOrRegion_ReturnsOkResult_WhenMatchingCountryOrRegionIsFound()
    {
        // Act
        var result = _systemUnderTest.GetCountryOrRegion(TestConstants.AfghanistanIsoCode);

        // Assert
        result.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
        result.As<OkObjectResult>().Value.As<Country>().Code.Should().Be(TestConstants.AfghanistanIsoCode);
    }

    [TestMethod]
    public void GetCountryOrRegion_ReturnsNotFoundResult_WhenNoMatchingCountryOrRegionIsFound()
    {
        // Act
        var result = _systemUnderTest.GetCountryOrRegion(TestConstants.AlbaniaIsoCode);

        // Assert
        result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}
