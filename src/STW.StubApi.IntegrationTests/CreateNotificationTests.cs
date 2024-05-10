namespace STW.StubApi.IntegrationTests;

using System.Net;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CreateNotificationTests
{
    private const string RequestUri = "/notifications";
    private readonly HttpClient _httpClient;

    public CreateNotificationTests()
    {
        var factory = new StubApiWebApplicationFactory();
        _httpClient = factory.CreateClient();
    }

    [TestMethod]
    public async Task CreateNotifications_ReturnsBadRequestStatus_WhenNotificationIsNotValid()
    {
        // Arrange
        const string notification = "{ \"type\": \"Unknown\" }";
        var content = new StringContent(notification, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PostAsync(RequestUri, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [TestMethod]
    public async Task CreateNotifications_ReturnsCreatedStatusWithReferenceNumber_WhenNotificationIsValid()
    {
        // Arrange
        const string notification = "{ \"type\": \"CHEDPP\", \"status\": \"SUBMITTED\" }";
        var content = new StringContent(notification, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PostAsync(RequestUri, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseBody = await response.Content.ReadAsStringAsync();
        responseBody.Should().MatchRegex("^SUBMITTED\\.GB\\.\\d{4}\\.1\\d{6}$");
    }
}
