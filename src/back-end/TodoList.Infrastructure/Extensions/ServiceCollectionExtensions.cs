using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Infrastructure.Data;

namespace TodoList.Infrastructure.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TodoListDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                    b => b.MigrationsAssembly(typeof(TodoListDbContext).Assembly.FullName)));

            return services;
        }
    }
}
