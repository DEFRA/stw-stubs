namespace STW.StubApi.Presentation.Services.Bcp.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("bcps")]
public class BcpController : ControllerBase
{
    [HttpGet("search")]
    [Consumes("application/json")]
    public BcpSearchResult Search([FromQuery] string? code, [FromQuery] string? type) => BcpHelper.Search(code, type);
}
