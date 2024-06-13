namespace STW.StubApi.Presentation.UnitTests.Services.Bcp.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Bcp.Helpers;
using TestHelpers;

[TestClass]
public class BcpHelperTests
{
    [TestMethod]
    public void Search_ReturnsExpected_WhenNoCodeOrTypeAreProvided()
    {
        // Act
        var result = BcpHelper.Search(default, default);

        // Assert
        result.Bcps.Should().HaveCount(3);
        result.SearchParameters.Code.Should().BeNull();
        result.SearchParameters.Type.Should().BeNull();
    }

    [TestMethod]
    public void Search_ReturnsExpected_WhenSearchingWithCodeAndType()
    {
        // Act
        var result = BcpHelper.Search(TestConstants.BcpCode, TestConstants.Chedp);

        // Assert
        result.Bcps.Should().HaveCount(1).And.SatisfyRespectively(
            x =>
            {
                x.Code.Should().Be(TestConstants.BcpCode);
                x.Types.Should().Contain(TestConstants.Chedp);
            });

        result.SearchParameters.Code.Should().Be(TestConstants.BcpCode);
        result.SearchParameters.Type.Should().Be(TestConstants.Chedp);
    }

    [TestMethod]
    public void Search_ReturnsExpected_WhenSearchingWithCodeOnly()
    {
        // Act
        var result = BcpHelper.Search(TestConstants.BcpCode, default);

        // Assert
        result.Bcps.Should().HaveCount(1).And.SatisfyRespectively(x => x.Code.Should().Be(TestConstants.BcpCode));
        result.SearchParameters.Code.Should().Be(TestConstants.BcpCode);
        result.SearchParameters.Type.Should().BeNull();
    }

    [TestMethod]
    public void Search_ReturnsExpected_WhenSearchingWithTypeOnly()
    {
        // Act
        var result = BcpHelper.Search(default, TestConstants.Chedp);

        // Assert
        result.Bcps.Should().HaveCount(2).And.SatisfyRespectively(x => x.Types.Should().Contain(TestConstants.Chedp), x => x.Types.Should().Contain(TestConstants.Chedp));
        result.SearchParameters.Code.Should().BeNull();
        result.SearchParameters.Type.Should().Be(TestConstants.Chedp);
    }

    [TestMethod]
    public void Search_ReturnsExpected_WhenNoBcpsMatchCodeAndType()
    {
        // Act
        var result = BcpHelper.Search(TestConstants.NonMatchingString, TestConstants.NonMatchingString);

        // Assert
        result.Bcps.Should().BeEmpty();
        result.SearchParameters.Code.Should().Be(TestConstants.NonMatchingString);
        result.SearchParameters.Type.Should().Be(TestConstants.NonMatchingString);
    }
}
