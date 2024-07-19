using Microsoft.EntityFrameworkCore;

namespace TodoList.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Core.TodoListAggregate.TodoList> TodoItems { get; set; }
    }
}
