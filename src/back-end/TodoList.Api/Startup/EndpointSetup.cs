using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TodoList.Api.Startup
{
    public static class EndpointSetup
    {
        [ExcludeFromCodeCoverage(Justification = "Wiring")]
        public static WebApplication MapHealthCheckEndpoints(this WebApplication app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => false });
            app.MapHealthChecks("/health/dependency",
                new HealthCheckOptions
                {
                    Predicate = healthCheck => healthCheck.Tags.Contains("dependency"),
                    ResponseWriter = HealthResponseWriter
                });

            return app;
        }

        public static Task HealthResponseWriter(HttpContext context, HealthReport report)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return context.Response.WriteAsJsonAsync(new
            {
                Status = report.Status.ToString(),
                report.TotalDuration,
                Entries = report.Entries
                    .ToDictionary(
                        entry => entry.Key,
                        entry =>
                            new
                            {
                                entry.Value.Description,
                                entry.Value.Duration,
                                Status = entry.Value.Status.ToString(),
                                Error = entry.Value.Exception?.Message,
                            }
                    )
            }, options, context.RequestAborted);
        }

        /// Prevent 404 on the application root URL. Azure Web Apps with Always On enabled invoke the root of the application every 5 minutes
        /// to keep your web app awake. If you run an API-only app you likely have nothing listening to /, which results in a 404 response
        /// that shows up in monitoring. This endpoint returns 200 with content Ok only for the always on check.
        [ExcludeFromCodeCoverage(Justification = "Wiring")]
        public static WebApplication MapAlwaysOn(this WebApplication app)
        {
            app.MapGet("/", async context =>
            {
                if (context.Request.Headers.UserAgent != "AlwaysOn")
                {
                    context.Response.StatusCode = 404;
                    return;
                }

                await context.Response.WriteAsync("Ok", context.RequestAborted);
            });

            return app;
        }
    }
}
