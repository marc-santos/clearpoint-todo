using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.Application.Contracts;
using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public sealed class TodoItemsRepository(TodoListDbContext dbContext, ILogger<TodoItemsRepository> logger)
        : ITodoItemsRepository
    {
        private readonly TodoListDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        private readonly ILogger<TodoItemsRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<TodoItem?> GetTodoItemAsync(TodoItemId todoItemId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving todo item with id {Id}.", todoItemId);

            return await _dbContext.TodoItems.FindAsync(todoItemId , cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving todo items.");

            return await _dbContext.TodoItems.ToListAsync(cancellationToken);
        }
    }
}
