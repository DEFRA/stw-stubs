namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.CommodityCode.Helpers;
using TestHelpers;

[TestClass]
public class CommodityCategoriesHelperTests
{
    [TestMethod]
    public void GetCommodityCategory_ReturnsCommodityCategory_WhenMatchIsFound()
    {
        // Act
        var result = CommodityCategoriesHelper.GetCommodityCategory(TestConstants.Cvedp, TestConstants.CvedpCommodityCode);

        // Assert
        result!.CommodityCode.Should().Be(TestConstants.CvedpCommodityCode);
    }

    [TestMethod]
    public void GetCommodityCategory_ReturnsNull_WhenMatchIsFound()
    {
        // Act
        var result = CommodityCategoriesHelper.GetCommodityCategory(TestConstants.Cvedp, TestConstants.NonMatchingString);

        // Assert
        result.Should().BeNull();
    }
}
