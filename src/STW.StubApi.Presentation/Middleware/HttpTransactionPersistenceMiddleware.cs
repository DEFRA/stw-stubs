namespace STW.StubApi.Presentation.Middleware;

using System.Text;
using Constants;
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

        var httpTransaction = new HttpTransaction
        {
            RequestTimestamp = DateTime.Now,
            CorrelationId = GetCorrelationIdHeader(request.Headers),
            RequestMethod = request.Method,
            RequestBody = await GetAndResetRequestBodyAsync(request)
        };

        var originalBodyStream = context.Response.Body;
        using var memoryBodyStream = new MemoryStream();
        context.Response.Body = memoryBodyStream;

        try
        {
            await _next(context);
            var response = context.Response;
            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryBodyStream).ReadToEndAsync();
            httpTransaction.ResponseStatusCode = response.StatusCode;
            httpTransaction.ResponseTimestamp = DateTime.Now;
            httpTransaction.ResponseBody = responseBody;

            await PersistHttpTransactionData(dbContext, httpTransaction);

            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            context.Response.Body = originalBodyStream;
            context.Response.ContentLength = memoryBodyStream.Length;
            await memoryBodyStream.CopyToAsync(originalBodyStream);
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private static async Task<string> GetAndResetRequestBodyAsync(HttpRequest request)
    {
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer);
        request.Body.Position = 0;

        return Encoding.UTF8.GetString(buffer);
    }

    private static async Task PersistHttpTransactionData(ApplicationDbContext dbContext, HttpTransaction httpTransaction)
    {
        await dbContext.HttpTransactions.AddAsync(httpTransaction);
        await dbContext.SaveChangesAsync();
    }

    private static Guid? GetCorrelationIdHeader(IHeaderDictionary headerDictionary)
    {
        return headerDictionary.TryGetValue(CustomRequestHeaderNames.CorrelationId, out var value)
               && Guid.TryParse(value, out var correlationId)
            ? correlationId
            : null;
    }
}
