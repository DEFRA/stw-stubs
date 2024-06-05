namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Controllers;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Presentation.Services.CommodityCode.Controllers;
using Presentation.Services.CommodityCode.Models;
using TestHelpers;

[TestClass]
public class CommoditySpeciesControllerTests
{
    private CommoditySpeciesController _commoditySpeciesController;

    [TestInitialize]
    public void TestInitialize()
    {
        _commoditySpeciesController = new CommoditySpeciesController();
    }

    [TestMethod]
    public void GetSpecies_ReturnsCorrectPageImpl()
    {
        // Act
        var result = _commoditySpeciesController.GetSpecies(TestConstants.ChedppCommodityCode, TestConstants.EppoCode, TestConstants.SpeciesName);

        // Assert
        result.TotalElements.Should().Be(1);
        result.Content.Should().HaveCount(1);
    }
}
