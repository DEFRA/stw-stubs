namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Controllers;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.CommodityCode.Controllers;
using Presentation.Services.CommodityCode.Models;
using TestHelpers;

[TestClass]
public class CommodityCodeControllerTests
{
    private CommodityCodeController _commodityCodeController;

    [TestInitialize]
    public void TestInitialize()
    {
        _commodityCodeController = new CommodityCodeController();
    }

    [TestMethod]
    public void GetCommodityConfigurations_ReturnsCorrectListOfCommodityConfigurations()
    {
        // Act
        var result = _commodityCodeController.GetCommodityConfigurations([TestConstants.ChedppCommodityCode]);

        // Assert
        result.Should().HaveCount(1).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode);
    }
}
