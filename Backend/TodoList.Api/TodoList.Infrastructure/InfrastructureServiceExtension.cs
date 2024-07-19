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
            //string? connectionString = config.GetConnectionString("SqliteConnection");
            //Guard.Against.Null(connectionString);
            //services.AddDbContext<AppDbContext>(options =>
            // options.UseSqlite(connectionString));

            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoItemsDB"));

            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
            //services.AddScoped<IDeleteContributorService, DeleteContributorService>();

            //logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }
    }
}
