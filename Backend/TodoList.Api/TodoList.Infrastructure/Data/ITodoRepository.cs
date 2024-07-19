using System.Linq.Expressions;
using TodoList.Models;

namespace TodoList.Infrastructure.Data
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync(CancellationToken cancellationToken);

        Task<TodoItem> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken);

        Task UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken);

        Task<List<TodoItem>> GetManyAsync(Expression<Func<TodoItem, bool>> predicate, CancellationToken cancellationToken);
    }
}