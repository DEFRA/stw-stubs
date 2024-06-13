namespace STW.StubApi.IntegrationTests;

using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Models;
using Presentation.Services.ApprovedEstablishment.Models;

[TestClass]
public class ApprovedEstablishmentsTests
{
    private const string RequestUri = "/approved-establishment/search";
    private readonly HttpClient _httpClient;

    public ApprovedEstablishmentsTests()
    {
        var factory = new StubApiWebApplicationFactory();
        _httpClient = factory.CreateClient();
    }

    [TestMethod]
    public async Task Search_ReturnsOkWithApprovedEstablishments_WhenResultsAreFound()
    {
        // Arrange
        const string searchQuery = "{}";
        var content = new StringContent(searchQuery, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PostAsync(RequestUri, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responsePageImpl = await response.Content.ReadFromJsonAsync<PageImpl<ApprovedEstablishment>>();

        responsePageImpl!.Content.Should().HaveCount(1);
        responsePageImpl.TotalElements.Should().Be(1);
    }

    [TestMethod]
    public async Task Search_ReturnsOkWithNoApprovedEstablishments_WhenNoResultsAreFound()
    {
        // Arrange
        const string searchQuery = "{ \"ApprovalNumber\": \"XXXXXXX\" }";
        var content = new StringContent(searchQuery, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PostAsync(RequestUri, content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responsePageImpl = await response.Content.ReadFromJsonAsync<PageImpl<ApprovedEstablishment>>();

        responsePageImpl!.Content.Should().BeEmpty();
        responsePageImpl.TotalElements.Should().Be(0);
    }
}
