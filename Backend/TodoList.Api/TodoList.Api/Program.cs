using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using TodoList.Infrastructure;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.ShortSchemaNames = true;
    });

builder.Services.AddInfrastructureServices(builder.Configuration, null);

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();
app.Run();
