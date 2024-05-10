using STW.StubApi.Presentation.Extensions;
using STW.StubApi.Presentation.HealthChecks;
using STW.StubApi.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

builder.Services
    .RegisterComponents()
    .AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.MapHealthChecks(
    "/health",
    HealthCheckOptionsBuilder.Build(builder.Configuration.GetValue<string>("HealthCheck:Version")));

app.MapControllers();

app.Run();
