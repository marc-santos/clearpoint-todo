using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.RepositoryService
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
