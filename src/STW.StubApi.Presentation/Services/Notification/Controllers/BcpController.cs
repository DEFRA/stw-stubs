namespace STW.StubApi.Presentation.Services.Notification.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("bcps")]
public class BcpController
{
    [HttpGet("search")]
    [Consumes("application/json")]
    public ActionResult<BcpSearchResultDto> Search([FromQuery] string code, [FromQuery] string type)
    {
        List<BcpSearchResultDto.BcpDto> bcps = code == "GBBEL1"
            ?
            [
                new BcpSearchResultDto.BcpDto
                {
                    Id = 1,
                    Name = $"{code} name",
                    Code = code,
                },
            ]
            : [];
        return new BcpSearchResultDto()
        {
            Page = 1,
            Elements = 25,
            TotalPages = 1,
            SearchParameters = new BcpSearchResultDto.SearchParametersDto()
            {
                Code = code,
                Type = type,
            },
            Bcps = bcps,
        };
    }
}
