namespace STW.StubApi.Presentation.UnitTests.Services.CommodityCode.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.CommodityCode.Helpers;
using TestHelpers;

[TestClass]
public class CommoditySpeciesHelperTests
{
    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenEppoCodeAndSpeciesNameAreNotProvided()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, default, default);

        // Assert
        result.Content.Should().HaveCount(2).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode, x => x.CommodityCode == TestConstants.ChedppCommodityCode);
        result.TotalElements.Should().Be(2);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenSpeciesIsFoundWithMatchingEppoCode()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, TestConstants.EppoCode, default);

        // Assert
        result.Content.Should().HaveCount(1).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode);
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoSpeciesIsFoundWithMatchingEppoCode()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, TestConstants.NonMatchingString, default);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenSpeciesIsFoundWithMatchingSpeciesName()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, default, TestConstants.SpeciesName);

        // Assert
        result.Content.Should().HaveCount(1).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode);
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoSpeciesIsFoundWithMatchingSpeciesName()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, default, TestConstants.NonMatchingString);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenSpeciesIsFoundWithMatchingEppoCodeAndSpeciesName()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, TestConstants.EppoCode, TestConstants.SpeciesName);

        // Assert
        result.Content.Should().HaveCount(1).And.Satisfy(x => x.CommodityCode == TestConstants.ChedppCommodityCode);
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoSpeciesIsFoundWithMatchingEppoCodeAndSpeciesName()
    {
        // Act
        var result = CommoditySpeciesHelper.Search(TestConstants.ChedppCommodityCode, TestConstants.NonMatchingString, TestConstants.NonMatchingString);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }
}
