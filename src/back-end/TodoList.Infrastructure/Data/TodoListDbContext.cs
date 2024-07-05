using Microsoft.EntityFrameworkCore;

namespace TodoList.Infrastructure.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }
    }
}
