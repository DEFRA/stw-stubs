namespace STW.StubApi.Presentation.Services.CommodityCode.Helpers;

using System.Text.Json;
using Models;

public static class CommodityCategoriesHelper
{
    private static readonly string CommodityCategoryJson = File.ReadAllText("Services/CommodityCode/Fixtures/commodity-categories.json");
    private static readonly List<CommodityCategory> CommodityCategories = JsonSerializer.Deserialize<List<CommodityCategory>>(CommodityCategoryJson)!;

    public static CommodityCategory? GetCommodityCategory(string certType, string commodityCode)
    {
        return CommodityCategories.Find(x => x.CommodityCode == commodityCode && x.CertificateType.Equals(certType, StringComparison.OrdinalIgnoreCase));
    }
}
