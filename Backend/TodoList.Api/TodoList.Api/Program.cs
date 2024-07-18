using FastEndpoints;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
