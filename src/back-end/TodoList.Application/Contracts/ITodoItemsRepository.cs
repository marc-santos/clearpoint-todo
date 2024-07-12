using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Application.Contracts
{
    public interface ITodoItemsRepository
    {
        Task<TodoItem?> GetTodoItemAsync(TodoItemId todoItemId, CancellationToken cancellationToken);

        Task<IEnumerable<TodoItem>> GetTodoItemsAsync(CancellationToken cancellationToken);
    }
}
