namespace STW.StubApi.Presentation.UnitTests.Services.ApprovedEstablishment.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.ApprovedEstablishment.Helpers;
using Presentation.Services.ApprovedEstablishment.Models;
using TestHelpers;

[TestClass]
public class ApprovedEstablishmentHelperTests
{
    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoApprovedEstablishmentsHaveMatchingApprovalNumber()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ApprovalNumber = TestConstants.NonMatchingString
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoApprovedEstablishmentsHaveMatchingCountryCode()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            CountryCode = TestConstants.NonMatchingString
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoApprovedEstablishmentsHaveMatchingSection()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            Section = TestConstants.NonMatchingString
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoApprovedEstablishmentsHaveMatchingActivitiesLegend()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ActivitiesLegend = TestConstants.NonMatchingString
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenNoApprovedEstablishmentMatchesSearchQuery()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ApprovalNumber = TestConstants.NonMatchingString,
            CountryCode = TestConstants.NonMatchingString,
            ActivitiesLegend = TestConstants.NonMatchingString,
            Section = TestConstants.NonMatchingString,
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().BeEmpty();
        result.TotalElements.Should().Be(0);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenApprovedEstablishmentHasMatchingApprovalNumber()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ApprovalNumber = TestConstants.ApprovedEstablishmentApprovalNumber
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1).And.SatisfyRespectively(x => x.Id.Should().Be(TestConstants.ApprovedEstablishmentId));
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenApprovedEstablishmentHasMatchingCountryCode()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            CountryCode = TestConstants.ApprovedEstablishmentCountryCode
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1).And.SatisfyRespectively(x => x.Id.Should().Be(TestConstants.ApprovedEstablishmentId));
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenApprovedEstablishmentHasMatchingSection()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            Section = TestConstants.ApprovedEstablishmentSection
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1).And.SatisfyRespectively(x => x.Id.Should().Be(TestConstants.ApprovedEstablishmentId));
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenApprovedEstablishmentHasMatchingActivitiesLegend()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ActivitiesLegend = TestConstants.ApprovedEstablishmentActivitiesLegend
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1).And.SatisfyRespectively(x => x.Id.Should().Be(TestConstants.ApprovedEstablishmentId));
        result.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public void Search_ReturnsCorrectPageImpl_WhenApprovedEstablishmentMatchesSearchQuery()
    {
        // Arrange
        var searchQuery = new SearchQuery
        {
            ApprovalNumber = TestConstants.ApprovedEstablishmentApprovalNumber,
            CountryCode = TestConstants.ApprovedEstablishmentCountryCode,
            Section = TestConstants.ApprovedEstablishmentSection,
            ActivitiesLegend = TestConstants.ApprovedEstablishmentActivitiesLegend,
        };

        // Act
        var result = ApprovedEstablishmentHelper.Search(searchQuery);

        // Assert
        result.Content.Should().HaveCount(1).And.SatisfyRespectively(x => x.Id.Should().Be(TestConstants.ApprovedEstablishmentId));
        result.TotalElements.Should().Be(1);
    }
}
