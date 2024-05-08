namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Validators;

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
        const string notification = "{ \"type\": \"CHEDPP\" }";

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void IsValid_ReturnsTrue_WhenNotificationDoesNotSatisfyTheSchema()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\", \"partOne\": { \"CustomsReferenceNumber\": \"\" } }";

        // Act
        var result = _systemUnderTest.IsValid(notification);

        // Assert
        result.Should().BeFalse();
    }
}
