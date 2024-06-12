namespace STW.StubApi.Presentation.Services.CommodityCode.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("commodity-codes")]
public class CommodityCodeController : ControllerBase
{
    [HttpGet("chedpp/commodity-configuration")]
    public List<CommodityConfiguration> GetCommodityConfigurations([FromQuery] List<string> commodityCodes)
    {
        return CommodityCodeHelper.GetCommodityConfigurations(commodityCodes);
    }
}
