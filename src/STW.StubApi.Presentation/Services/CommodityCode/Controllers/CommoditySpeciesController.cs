namespace STW.StubApi.Presentation.Services.CommodityCode.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Presentation.Models;

[ApiController]
[Route("commodity-species")]
public class CommoditySpeciesController : ControllerBase
{
    [HttpGet("chedpp/{commodityCode}")]
    public PageImpl<ChedppSpecies> GetSpecies([FromRoute] string commodityCode, [FromQuery] string? eppoCode, [FromQuery] string? speciesName)
    {
        return CommoditySpeciesHelper.Search(commodityCode, eppoCode, speciesName);
    }
}
