using FastEndpoints.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TodoList.Infrastructure.Data;

namespace TodoList.Api.IntegrationTests
{
    public class App : AppFixture<Program>
    {
        protected override Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        protected override void ConfigureApp(IWebHostBuilder a)
        {
        }

        protected override void ConfigureServices(IServiceCollection s)
        {
            s.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoItemsTestDb"));
        }

        protected override Task TearDownAsync()
        {
            return Task.CompletedTask;
        }
    }
}
