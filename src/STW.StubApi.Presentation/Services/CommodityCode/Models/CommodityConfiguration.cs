namespace STW.StubApi.Presentation.Services.CommodityCode.Models;

public class CommodityConfiguration
{
    public string CommodityCode { get; init; }

    public bool RequireTestAndTrail { get; init; }

    public bool RequiresFinishedAndPropagated { get; init; }
}
