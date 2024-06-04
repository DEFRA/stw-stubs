namespace STW.StubApi.IntegrationTests;

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Models;

[TestClass]
public class BcpTests
{
    private readonly HttpClient _httpClient = new StubApiWebApplicationFactory().CreateClient();

    [TestMethod]
    public async Task Search_ReturnsOk_WhenValidCode()
    {
        // Act
        var response = await _httpClient.GetAsync("/bcps/search?code=GBBEL1");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<BcpSearchResultDto>();
        content!.Bcps.Should().SatisfyRespectively(
            first =>
            {
                first.Id.Should().Be(1);
                first.Name.Should().Be("Belfast Airport");
                first.Code.Should().Be("GBBEL1");
                first.Suspended.Should().Be(false);
            });
    }

    [TestMethod]
    public async Task Search_ReturnsBadRequest_WhenCodeIsEmpty()
    {
        // Act
        var response = await _httpClient.GetAsync("/bcps/search?code=");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [TestMethod]
    public async Task Search_ReturnsBadRequest_WhenCodeIsMissing()
    {
        // Act
        var response = await _httpClient.GetAsync("/bcps/search");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
