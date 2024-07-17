using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.RepositoryService.Interface;

namespace TodoList.RepositoryService.Service
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Incomplete Items Async
        /// </summary>
        /// <returns>TodoItems</returns>
        public async Task<List<TodoItem>> GetIncompleteItemsAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        /// <summary>
        /// Get Item By Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TodoItem</returns>
        public async Task<TodoItem> GetItemByIdAsync(Guid id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        /// <summary>
        /// Add Item Async
        /// </summary>
        /// <param name="item"></param>
        /// <returns>void</returns>
        public async Task AddItemAsync(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Item Async
        /// </summary>
        /// <param name="item"></param>
        /// <returns>void</returns>
        public async Task UpdateItemAsync(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Item Exists Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>trur  or false</returns>
        public async Task<bool> ItemExistsAsync(Guid id)
        {
            return await _context.TodoItems.AnyAsync(x => x.Id == id);
        }

        /// <summary>
        /// Description Exists Async
        /// </summary>
        /// <param name="description"></param>
        /// <returns>trur  or false</returns>
        public async Task<bool> DescriptionExistsAsync(string description)
        {
            return await _context.TodoItems
                .AnyAsync(x => string.IsNullOrEmpty(x.Description) && x.Description.ToLowerInvariant() == description.ToLowerInvariant() && !x.IsCompleted);

        }
    }
}
