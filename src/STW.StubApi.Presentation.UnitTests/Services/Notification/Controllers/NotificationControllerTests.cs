namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Controllers;

using System.Text.Json.Nodes;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Services.Notification.Controllers;
using Presentation.Services.Notification.Validators;

[TestClass]
public class NotificationControllerTests
{
    private NotificationController _systemUnderTest;
    private Mock<INotificationValidator> _notificationValidatorMock;

    [TestInitialize]
    public void TestInitialize()
    {
        _notificationValidatorMock = new Mock<INotificationValidator>();
        _systemUnderTest = new NotificationController(_notificationValidatorMock.Object);
    }

    [TestMethod]
    public void CreateNotification_ReturnsBadRequest_WhenNotificationIsNotValid()
    {
        // Arrange
        _notificationValidatorMock
            .Setup(x => x.IsValid(It.IsAny<JsonNode>()))
            .Returns(false);

        // Act
        var result = _systemUnderTest.CreateNotification(It.IsAny<JsonNode>());

        // Assert
        result.Should().BeOfType<BadRequestResult>();
        result.As<BadRequestResult>().StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    }

    [TestMethod]
    public void CreateNotification_ReturnsCreatedWithReferenceNumber_WhenNotificationIsValid()
    {
        // Arrange
        _notificationValidatorMock
            .Setup(x => x.IsValid(It.IsAny<JsonNode>()))
            .Returns(true);

        var notification = JsonNode.Parse("{ \"type\":  \"CHEDPP\" }");

        // Act
        var result = _systemUnderTest.CreateNotification(notification);

        // Assert
        result.Should().BeOfType<ObjectResult>();
        result.As<ObjectResult>().Value!.ToString().Should().StartWith("CHEDPP.GB.");
        result.As<ObjectResult>().StatusCode.Should().Be(StatusCodes.Status201Created);
    }
}
