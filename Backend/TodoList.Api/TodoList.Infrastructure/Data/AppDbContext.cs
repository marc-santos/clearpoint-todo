using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
