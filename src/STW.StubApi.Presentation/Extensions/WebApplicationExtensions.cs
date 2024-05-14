namespace STW.StubApi.Presentation.Extensions;

using Middleware;

public static class WebApplicationExtensions
{
    public static void RegisterMiddleware(this WebApplication app)
    {
        app.UseWhen(
            context => context.Request.Path.Equals("/notifications"),
            builder => builder.UseMiddleware<HttpTransactionPersistenceMiddleware>());

        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
