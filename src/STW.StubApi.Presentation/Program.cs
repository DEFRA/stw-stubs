using STW.StubApi.Presentation.Extensions;
using STW.StubApi.Presentation.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

builder.Services
    .RegisterComponents(builder.Configuration, builder.Environment)
    .AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterMiddleware();

app.UseHttpsRedirection();

app.MapHealthChecks(
    "/health",
    HealthCheckOptionsBuilder.Build(builder.Configuration.GetValue<string>("HealthCheck:Version")));

app.MapControllers();

app.Run();
