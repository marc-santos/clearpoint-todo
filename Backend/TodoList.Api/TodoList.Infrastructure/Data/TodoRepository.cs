using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Models;

namespace TodoList.Infrastructure.Data
{
    public class TodoRepository(AppDbContext _context) : ITodoRepository
    {
        public async Task<List<TodoItem>> GetAllAsync(CancellationToken cancellationToken) => await _context.TodoItems.ToListAsync(cancellationToken); 

        public async Task<TodoItem> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _context.TodoItems.FindAsync(id, cancellationToken);

        public async Task AddAsync(TodoItem todoItem, CancellationToken cancellationToken)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TodoItem>> GetManyAsync(Expression<Func<TodoItem, bool>> predicate, CancellationToken cancellationToken) => await _context.TodoItems.Where(predicate).ToListAsync(cancellationToken);   
    }
}
