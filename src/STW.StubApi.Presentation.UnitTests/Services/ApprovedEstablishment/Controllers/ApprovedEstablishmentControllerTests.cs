namespace STW.StubApi.Presentation.UnitTests.Services.ApprovedEstablishment.Controllers;

using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
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
    public void Search_ReturnsCorrectResponse_WhenCalled()
    {
        // Arrange
        var searchQuery = new SearchQuery();

        // Act
        var result = _systemUnderTest.Search(searchQuery) as OkObjectResult;

        // Assert
        result!.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Value.As<PageImpl<ApprovedEstablishment>>().Content.Should().HaveCount(1);
        result.Value.As<PageImpl<ApprovedEstablishment>>().TotalElements.Should().Be(1);
    }
}
