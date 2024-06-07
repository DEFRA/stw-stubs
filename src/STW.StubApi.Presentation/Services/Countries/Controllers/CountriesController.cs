namespace STW.StubApi.Presentation.Services.Countries.Controllers;

using Helpers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("countries")]
public class CountriesController : ControllerBase
{
    [HttpGet("country-or-region")]
    public IActionResult GetCountryOrRegion([FromQuery] string isoCode)
    {
        var result = CountryHelper.GetCountryOrRegion(isoCode);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
