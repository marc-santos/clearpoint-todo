using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using TodoList.Infrastructure;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .CreateLogger();

logger.Information("Starting TodoList.API");

var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var fileLogger = new SerilogLoggerFactory(logger).CreateLogger<Program>();

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.ShortSchemaNames = true;
    });

builder.Services.AddInfrastructureServices(builder.Configuration, fileLogger);

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();
app.Run();

public partial class Program { }
