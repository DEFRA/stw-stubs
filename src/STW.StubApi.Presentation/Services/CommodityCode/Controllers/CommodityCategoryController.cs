namespace STW.StubApi.Presentation.Services.CommodityCode.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("commodity-categories")]
public class CommodityCategoryController : ControllerBase
{
    [HttpGet("{certType}-{commodityCode}")]
    public CommodityCategory? GetCommodityCategory([FromRoute] string certType, [FromRoute] string commodityCode)
    {
        return CommodityCategoriesHelper.GetCommodityCategory(certType, commodityCode);
    }
}
