using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.RepositoryService.Interface
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Get Incomplete Items Async
        /// </summary>
        /// <returns>TodoItems</returns>
        Task<List<TodoItem>> GetIncompleteItemsAsync();

        /// <summary>
        /// Get Item By Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TodoItem</returns>
        Task<TodoItem> GetItemByIdAsync(Guid id);

        /// <summary>
        /// Add Item Async
        /// </summary>
        /// <param name="item"></param>
        /// <returns>void</returns>
        Task AddItemAsync(TodoItem item);

        /// <summary>
        /// Update Item Async
        /// </summary>
        /// <param name="item"></param>
        /// <returns>void</returns>
        Task UpdateItemAsync(TodoItem item);

        /// <summary>
        /// Description Exists Async
        /// </summary>
        /// <param name="description"></param>
        /// <returns>trur  or false</returns>
        Task<bool> ItemExistsAsync(Guid id);

        /// <summary>
        /// Description Exists Async
        /// </summary>
        /// <param name="description"></param>
        /// <returns>trur  or false</returns>
        Task<bool> DescriptionExistsAsync(string description);
    }
}
