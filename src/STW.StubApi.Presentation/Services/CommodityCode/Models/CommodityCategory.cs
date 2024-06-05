namespace STW.StubApi.Presentation.Services.CommodityCode.Models;

using System.Text.Json.Serialization;

public class CommodityCategory
{
    [JsonPropertyName("commodityCode")]
    public string CommodityCode { get; init; }

    [JsonPropertyName("certificateType")]
    public string CertificateType { get; init; }

    [JsonPropertyName("data")]
    public string Data { get; init; }
}
