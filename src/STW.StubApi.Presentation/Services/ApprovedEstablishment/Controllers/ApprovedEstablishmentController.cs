namespace STW.StubApi.Presentation.Services.ApprovedEstablishment.Controllers;

using System.Net.Mime;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("/approved-establishment")]
public class ApprovedEstablishmentController : ControllerBase
{
    [HttpPost("search")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Search([FromBody] SearchQuery searchQuery) => Ok(ApprovedEstablishmentHelper.Search(searchQuery));
}
