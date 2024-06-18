namespace STW.StubApi.IntegrationTests;

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.FieldConfig.Models;

[TestClass]
public class FieldConfigTests
{
    private readonly HttpClient _httpClient = new StubApiWebApplicationFactory().CreateClient();

    [TestMethod]
    public async Task GetWithOptionalComplementName_ReturnsOk()
    {
        // Act
        var response = await _httpClient.GetAsync("/configurations/v2/CHEDP-03061699");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<FieldConfigDto>();
        content!.CommodityCode.Should().Be("03061699");
        content.Data.Should().NotBeEmpty();
        content.Data.Should().Contain("\"commodityCode\": \"03061699\"");
    }
}
