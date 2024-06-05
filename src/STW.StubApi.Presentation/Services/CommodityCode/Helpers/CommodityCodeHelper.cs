namespace STW.StubApi.Presentation.Services.CommodityCode.Helpers;

using Models;

public static class CommodityCodeHelper
{
    private static readonly List<CommodityConfiguration> CommodityConfigurations = new List<CommodityConfiguration>
    {
        new CommodityConfiguration
        {
            CommodityCode = "0808108090",
            RequiresFinishedAndPropagated = false,
            RequireTestAndTrail = false
        },
        new CommodityConfiguration
        {
            CommodityCode = "06011010",
            RequiresFinishedAndPropagated = true,
            RequireTestAndTrail = false
        }
    };

    public static List<CommodityConfiguration> GetCommodityConfigurations(List<string> commodityCodes)
    {
        return CommodityConfigurations
            .Where(x => commodityCodes.Contains(x.CommodityCode))
            .ToList();
    }
}
