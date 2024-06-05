namespace STW.StubApi.Presentation.UnitTests.Services.ApprovedEstablishment.Controllers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.ApprovedEstablishment.Controllers;
using Presentation.Services.ApprovedEstablishment.Models;

[TestClass]
public class ApprovedEstablishmentControllerTests
{
    private ApprovedEstablishmentController _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _systemUnderTest = new ApprovedEstablishmentController();
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl()
    {
        // Arrange
        var searchQuery = new SearchQuery();

        // Act
        var result = _systemUnderTest.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1);
        result.TotalElements.Should().Be(1);
    }
}
