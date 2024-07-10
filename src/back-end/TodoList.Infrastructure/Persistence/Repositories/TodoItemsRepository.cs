using Microsoft.Extensions.Logging;
using TodoList.Application.Contracts;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public sealed class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly TodoListDbContext _dbContext;
        private readonly ILogger<TodoItemsRepository> _logger;

        public TodoItemsRepository(TodoListDbContext dbContext, ILogger<TodoItemsRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
