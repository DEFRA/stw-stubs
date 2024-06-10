namespace STW.StubApi.Presentation.UnitTests.Services.Bcp;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Bcp;

[TestClass]
public class BcpControllerTests
{
    private BcpController _bcpController;

    [TestInitialize]
    public void TestInitialize()
    {
        _bcpController = new BcpController();
    }

    [TestMethod]
    public void Search_ReturnsBcpList_WhenResults()
    {
        // Act
        var result = _bcpController.Search("GBBEL1");

        // Assert
        result.SearchParameters.Code.Should().Be("GBBEL1");
        result.Bcps.Should().SatisfyRespectively(
            first =>
            {
                first.Id.Should().Be(1);
                first.Name.Should().Be("Belfast Airport");
                first.Code.Should().Be("GBBEL1");
                first.Suspended.Should().Be(false);
            });
    }

    [TestMethod]
    public void Search_ReturnsEmptyBcpList_WhenNoResults()
    {
        // Act
        var result = _bcpController.Search("UNKNOWN_CODE");

        // Assert
        result.SearchParameters.Code.Should().Be("UNKNOWN_CODE");
        result.Bcps.Should().BeEmpty();
    }
}
