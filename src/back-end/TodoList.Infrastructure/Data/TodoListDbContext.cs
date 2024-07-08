using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Data.Models;

namespace TodoList.Infrastructure.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

        public DbSet<TodoItemDto> TodoItems { get; set; } 
    }
}
