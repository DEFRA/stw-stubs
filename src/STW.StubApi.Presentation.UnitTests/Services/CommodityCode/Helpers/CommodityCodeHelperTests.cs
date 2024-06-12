namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.CommodityCode.Helpers;
using TestHelpers;

[TestClass]
public class CommodityCodeHelperTests
{
    [TestMethod]
    public void GetCommodityConfigurations_ReturnsEmptyList_WhenNoMatchingConfigurationsAreFound()
    {
        // Act
        var result = CommodityCodeHelper.GetCommodityConfigurations([TestConstants.NonMatchingString]);

        // Assert
        result.Should().BeEmpty();
    }

    [TestMethod]
    public void GetCommodityConfigurations_ReturnsCorrectList_WhenMatchingConfigurationsAreFound()
    {
        // Act
        var result = CommodityCodeHelper.GetCommodityConfigurations([TestConstants.ChedppCommodityCode]);

        // Assert
        result.Should().HaveCount(1).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode);
    }
}
