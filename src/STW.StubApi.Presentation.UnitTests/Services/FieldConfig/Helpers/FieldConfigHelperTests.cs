namespace STW.StubApi.Presentation.UnitTests.Services.FieldConfig.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.FieldConfig.Helpers;

[TestClass]
public class FieldConfigHelperTests
{
    [TestMethod]
    public void GetFieldConfigDto_ReturnsFieldConfigDto_WhenSpecificCommodityCode()
    {
        // Act
        var result = FieldConfigHelper.GetFieldConfigDto("CHEDP", "03061699");

        // Assert
        result.CommodityCode.Should().Be("03061699");
        result.Data.Should().NotBeEmpty();
        result.Data.Should().Contain("\"commodityCode\": \"03061699\"");
    }

    [TestMethod]
    public void GetWithOptionalComplementName_ReturnsDefaultFieldConfigDto_WhenNoSpecificCommodityCode()
    {
        // Act
        var result = FieldConfigHelper.GetFieldConfigDto("CHEDP", string.Empty);

        // Assert
        result.Data.Should().NotBeEmpty();
        result.Data.Should().Contain("\"commodity_code\": \"00\"");
    }
}
