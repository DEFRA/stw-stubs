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
    public async Task IsValid_ReturnsTrue_WhenNotificationSatisfiesTheSchema()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\" }";

        // Act
        var result = await _systemUnderTest.IsValidAsync(notification);

        // Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public async Task IsValid_ReturnsFalse_WhenNotificationDoesNotSatisfyTheSchema()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\", \"partOne\": { \"CustomsReferenceNumber\": \"\" } }";

        // Act
        var result = await _systemUnderTest.IsValidAsync(notification);

        // Assert
        result.Should().BeFalse();
    }
}
