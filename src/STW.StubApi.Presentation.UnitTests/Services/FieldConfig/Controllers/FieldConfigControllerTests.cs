namespace STW.StubApi.Presentation.UnitTests.Services.FieldConfig.Controllers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.FieldConfig.Controllers;

[TestClass]
public class FieldConfigControllerTests
{
    private FieldConfigController _fieldConfigController;

    [TestInitialize]
    public void TestInitialize()
    {
        _fieldConfigController = new FieldConfigController();
    }

    [TestMethod]
    public void GetWithOptionalComplementName_ReturnsFieldConfigDto()
    {
        // Act
        var result = _fieldConfigController.GetWithOptionalComplementName("CHEDP", "03061699");

        // Assert
        result.CommodityCode.Should().Be("03061699");
        result.Data.Should().NotBeEmpty();
    }
}
