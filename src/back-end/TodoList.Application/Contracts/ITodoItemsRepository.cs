using TodoList.Domain.TodoItems;

namespace TodoList.Application.Contracts
{
    public interface ITodoItemsRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync(CancellationToken cancellationToken);
    }
}
