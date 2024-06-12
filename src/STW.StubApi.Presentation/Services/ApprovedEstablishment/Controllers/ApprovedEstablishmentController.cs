namespace STW.StubApi.Presentation.Services.ApprovedEstablishment.Controllers;

using System.Net.Mime;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Presentation.Models;

[ApiController]
[Route("/approved-establishment")]
public class ApprovedEstablishmentController : ControllerBase
{
    [HttpPost("search")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public PageImpl<ApprovedEstablishment> Search([FromBody] SearchQuery searchQuery) => ApprovedEstablishmentHelper.Search(searchQuery);
}
