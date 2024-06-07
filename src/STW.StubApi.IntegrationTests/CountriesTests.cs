namespace STW.StubApi.IntegrationTests;

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Services.Countries.Models;

[TestClass]
public class CountriesTests
{
    private const string RequestUri = "/countries";
    private readonly HttpClient _httpClient;

    public CountriesTests()
    {
        var factory = new StubApiWebApplicationFactory();
        _httpClient = factory.CreateClient();
    }

    [TestMethod]
    public async Task GetCountryOrRegion_ReturnsOk_WhenCountry()
    {
        // Arrange
        const string isoCode = "AF";
        const string requestUri = $"{RequestUri}/country-or-region?isoCode={isoCode}";

        // Act
        var response = await _httpClient.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var countryResponse = await response.Content.ReadFromJsonAsync<Country>();
        countryResponse!.Code.Should().Be(isoCode);
    }

    [TestMethod]
    public async Task GetCountryOrRegion_ReturnsOk_WhenRegionExists()
    {
        // Arrange
        const string isoCode = "GB-WLS";
        const string requestUri = $"{RequestUri}/country-or-region?isoCode={isoCode}";

        // Act
        var response = await _httpClient.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var countryResponse = await response.Content.ReadFromJsonAsync<Country>();
        countryResponse!.Code.Should().Be(isoCode);
    }

    [TestMethod]
    public async Task GetCountryOrRegion_ReturnsNotFound_WhenCountryOrRegionIsNotFound()
    {
        // Arrange
        const string requestUri = $"{RequestUri}/country-or-region?isoCode=Unknown";

        // Act
        var response = await _httpClient.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
