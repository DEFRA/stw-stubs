namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Controllers;

using System.Net;
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
        _systemUnderTest = new NotificationController(_notificationValidatorMock.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Request =
                    {
                        Body = new MemoryStream("{}"u8.ToArray())
                    }
                }
            }
        };
    }

    [TestMethod]
    public async Task CreateNotification_ReturnsBadRequest_WhenNotificationIsNotValid()
    {
        // Arrange
        _notificationValidatorMock
            .Setup(x => x.IsValid(It.IsAny<string>()))
            .Returns(false);

        // Act
        var result = await _systemUnderTest.CreateNotification();

        // Assert
        result.Should().BeOfType<BadRequestResult>();
        result.As<BadRequestResult>().StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
    }

    [TestMethod]
    public async Task CreateNotification_ReturnsCreatedWithReferenceNumber_WhenNotificationIsValid()
    {
        // Arrange
        _notificationValidatorMock
            .Setup(x => x.IsValid(It.IsAny<string>()))
            .Returns(true);

        // Act
        var result = await _systemUnderTest.CreateNotification();

        // Assert
        result.Should().BeOfType<ObjectResult>();
        result.As<ObjectResult>().Value!.ToString().Should().StartWith("SUBMITTED.GB.");
        result.As<ObjectResult>().StatusCode.Should().Be((int)HttpStatusCode.Created);
    }
}
