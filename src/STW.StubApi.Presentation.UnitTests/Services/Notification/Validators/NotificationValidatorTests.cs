namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Validators;

using System.Text.Json;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Services.Notification.Validators;

[TestClass]
public class NotificationValidatorTests
{
    private Mock<ILogger<NotificationValidator>> _loggerMock;
    private INotificationValidator _systemUnderTest;

    [TestInitialize]
    public void TestInitialize()
    {
        _loggerMock = new Mock<ILogger<NotificationValidator>>();
        _systemUnderTest = new NotificationValidator(_loggerMock.Object);
    }

    [TestMethod]
    public void IsValid_ReturnsTrue_WhenNotificationSatisfiesTheSchema()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\", \"status\": \"SUBMITTED\" }";

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void IsValid_ReturnsFalse_WhenNotificationDoesNotSatisfyTheSchema()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\", \"status\": \"unknown\" }";

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void IsValid_ReturnsFalseAndLogsException_WhenNotificationIsNotValidJson()
    {
        // Arrange
        const string notification = "{";

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeFalse();

        _loggerMock.VerifyLog(x => x.LogError(It.IsAny<JsonException>(), "Notification string does not contain valid JSON."));
    }
}
