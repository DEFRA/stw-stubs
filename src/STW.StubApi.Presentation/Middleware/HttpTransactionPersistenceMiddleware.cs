namespace STW.StubApi.Presentation.Middleware;

using System.Text;
using Persistence;
using Persistence.Entities;

public class HttpTransactionPersistenceMiddleware
{
    private readonly RequestDelegate _next;

    public HttpTransactionPersistenceMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
    {
        var request = context.Request;
        request.EnableBuffering();
        var httpTransaction = new HttpTransaction();

        await SetRequestData(request, httpTransaction);
        await SetResponseData(context, httpTransaction);
        await PersistHttpTransactionData(dbContext, httpTransaction);
    }

    private static async Task PersistHttpTransactionData(ApplicationDbContext dbContext, HttpTransaction httpTransaction)
    {
        await dbContext.HttpTransactions.AddAsync(httpTransaction);
        await dbContext.SaveChangesAsync();
    }

    private static async Task SetRequestData(HttpRequest request, HttpTransaction httpTransaction)
    {
        httpTransaction.RequestTimestamp = DateTime.Now;
        httpTransaction.CorrelationId = GetCorrelationIdHeader(request.Headers);
        httpTransaction.RequestMethod = request.Method;

        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer);
        request.Body.Position = 0;
        httpTransaction.RequestBody = Encoding.UTF8.GetString(buffer);
    }

    private static Guid? GetCorrelationIdHeader(IHeaderDictionary headerDictionary)
    {
        return headerDictionary.TryGetValue("X-STW-CorrelationId", out var value) && Guid.TryParse(value, out var correlationId)
            ? correlationId
            : null;
    }

    private async Task SetResponseData(HttpContext context, HttpTransaction httpTransaction)
    {
        var response = context.Response;
        var originalBodyStream = response.Body;

        try
        {
            var memoryBodyStream = new MemoryStream();
            context.Response.Body = memoryBodyStream;
            await _next(context);
            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            httpTransaction.ResponseStatusCode = response.StatusCode;
            httpTransaction.ResponseTimestamp = DateTime.Now;
            httpTransaction.ResponseBody = await new StreamReader(memoryBodyStream).ReadToEndAsync();
            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            await memoryBodyStream.CopyToAsync(originalBodyStream);
        }
        finally
        {
            response.Body = originalBodyStream;
        }
    }
}
