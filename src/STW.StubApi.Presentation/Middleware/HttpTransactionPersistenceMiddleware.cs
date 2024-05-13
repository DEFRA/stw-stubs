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

    private async Task PersistHttpTransactionData(ApplicationDbContext dbContext, HttpTransaction httpTransaction)
    {
        Console.WriteLine(httpTransaction.CorrelationId);
        await dbContext.HttpTransactions.AddAsync(httpTransaction);
        await dbContext.SaveChangesAsync();
    }

    private async Task SetRequestData(HttpRequest request, HttpTransaction httpTransaction)
    {
        httpTransaction.RequestMethod = request.Method;
        httpTransaction.RequestTimestamp = DateTime.Now;
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer);
        httpTransaction.RequestBody = Encoding.UTF8.GetString(buffer);
        request.Body.Position = 0;
    }

    private async Task SetResponseData(HttpContext context, HttpTransaction transaction)
    {
        var response = context.Response;
        var originalBodyStream = response.Body;

        try
        {
            var memoryBodyStream = new MemoryStream();
            context.Response.Body = memoryBodyStream;
            await _next(context);
            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            transaction.ResponseStatusCode = response.StatusCode.ToString();
            transaction.ResponseTimestamp = DateTime.Now;
            transaction.ResponseBody = await new StreamReader(memoryBodyStream).ReadToEndAsync();
            memoryBodyStream.Seek(0, SeekOrigin.Begin);
            await memoryBodyStream.CopyToAsync(originalBodyStream);
        }
        finally
        {
            response.Body = originalBodyStream;
        }
    }
}
