using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoItemsDB"));

            services.AddScoped<ITodoRepository, TodoRepository>();

            logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }
    }
}
