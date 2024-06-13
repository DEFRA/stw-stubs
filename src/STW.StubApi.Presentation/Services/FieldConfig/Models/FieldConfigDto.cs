namespace STW.StubApi.Presentation.Services.FieldConfig.Models;

public record FieldConfigDto
{
    public long Id { get; init; }

    public string CertificateType { get; init; }

    public string CommodityCode { get; init; }

    public string Data { get; init; }
}
