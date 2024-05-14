namespace STW.StubApi.Presentation.Controllers;

using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

[ApiController]
[Route("transactions")]
public class HttpTransactionController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public HttpTransactionController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{correlationId:guid}")]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetByCorrelationId(Guid correlationId)
    {
        var result = await _dbContext.HttpTransactions.FirstOrDefaultAsync(x => x.CorrelationId == correlationId);

        return result is null
            ? NotFound()
            : Ok(result);
    }
}
