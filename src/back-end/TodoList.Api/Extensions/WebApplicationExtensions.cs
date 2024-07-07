using System.Diagnostics.CodeAnalysis;
using TodoList.Api.Startup;

namespace TodoList.Api.Extensions
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    public static class WebApplicationExtensions
    {
        public static void ConfigureApi(this WebApplication app, IConfiguration configuration, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList.Api v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllHeaders");

            //TODO: Security Headers Middleware
            //TODO: Validation Exception Middleware
            //TODO: Authorization Exception Middleware

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapHealthCheckEndpoints();
            app.MapAlwaysOn();
        }
    }
}
