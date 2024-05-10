namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Notification.Helpers;

[TestClass]
public class NotificationHelperTests
{
    [TestMethod]
    public void GenerateReferenceNumber_ReturnsExpected_WhenCalled()
    {
        // Act
        var result = NotificationHelper.GenerateReferenceNumber();

        // Assert
        result.Should().MatchRegex("^SUBMITTED\\.GB\\.\\d{4}\\.1\\d{6}$");
    }
}
