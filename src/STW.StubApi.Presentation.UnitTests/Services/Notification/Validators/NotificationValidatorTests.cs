namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Validators;

using System.Text.Json.Nodes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Notification.Validators;

[TestClass]
public class NotificationValidatorTests
{
    private INotificationValidator _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _systemUnderTest = new NotificationValidator();
    }

    [TestMethod]
    public void IsValid_ReturnsTrue_WhenNotificationSatisfiesTheSchema()
    {
        // Arrange
        var notification = JsonNode.Parse("{ \"type\": \"CHEDPP\", \"status\": \"SUBMITTED\" }");

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void IsValid_ReturnsFalse_WhenNotificationDoesNotSatisfyTheSchema()
    {
        // Arrange
        var notification = JsonNode.Parse("{ \"type\": \"CHEDPP\", \"status\": \"unknown\" }");

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeFalse();
    }
}
