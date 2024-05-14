namespace STW.StubApi.Presentation.UnitTests.Services.Notification.Helpers;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Notification.Helpers;

[TestClass]
public class NotificationHelperTests
{
    [TestMethod]
    public void GenerateReferenceNumber_ReturnsExpected_WhenCalledWithCertificateType()
    {
        // Arrange
        const string certificateType = "CHEDPP";

        // Act
        var result = NotificationHelper.GenerateReferenceNumber(certificateType);

        // Assert
        result.Should().MatchRegex("^CHEDPP\\.GB\\.\\d{4}\\.1\\d{6}$");
    }
}
