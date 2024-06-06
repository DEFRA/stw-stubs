namespace STW.StubApi.Presentation.Services.Bcp;

using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("bcps")]
public class BcpController : ControllerBase
{
    private static readonly List<BcpSearchResultDto.BcpDto> Bcps =
    [
        new BcpSearchResultDto.BcpDto
        {
            Id = 1,
            Name = "Belfast Airport",
            Code = "GBBEL1",
        },
        new BcpSearchResultDto.BcpDto
        {
            Id = 49,
            Name = "Manchester Airport",
            Code = "GBMNC1",
            Suspended = true,
        },
    ];

    [HttpGet("search")]
    [Consumes("application/json")]
    public BcpSearchResultDto Search([FromQuery] string code)
    {
        return new BcpSearchResultDto
        {
            Page = 1,
            Elements = 25,
            TotalPages = 1,
            SearchParameters = new BcpSearchResultDto.SearchParametersDto
            {
                Code = code,
            },
            Bcps = Bcps.FindAll(bcp => bcp.Code == code),
        };
    }
}
