namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Controllers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.CommodityCode.Controllers;
using TestHelpers;

[TestClass]
public class CommodityCategoryControllerTests
{
    private CommodityCategoryController _commodityCategoryController;

    [TestInitialize]
    public void TestInitialize()
    {
        _commodityCategoryController = new CommodityCategoryController();
    }

    [TestMethod]
    public void GetCommodityCategories_ReturnsCorrectCommodityCategory()
    {
        // Act
        var result = _commodityCategoryController.GetCommodityCategory(TestConstants.Cvedp, TestConstants.CvedpCommodityCode);

        // Assert
        result!.CommodityCode.Should().Be(TestConstants.CvedpCommodityCode);
    }
}
