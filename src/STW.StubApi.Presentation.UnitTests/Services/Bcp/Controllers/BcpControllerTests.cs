namespace STW.StubApi.Presentation.UnitTests.Services.Bcp.Controllers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Bcp.Controllers;
using Presentation.Services.Bcp.Models;
using TestHelpers;

[TestClass]
public class BcpControllerTests
{
    private BcpController _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _systemUnderTest = new BcpController();
    }

    [TestMethod]
    public void Search_ReturnsBcpSearchResult()
    {
        // Act
        var result = _systemUnderTest.Search(TestConstants.BcpCode, TestConstants.Chedp);

        // Assert
        result.Should().BeOfType<BcpSearchResult>();
        result.Bcps.Should().HaveCount(1);
    }
}
