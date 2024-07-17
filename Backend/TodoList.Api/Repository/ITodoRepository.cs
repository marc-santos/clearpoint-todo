using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetIncompleteItemsAsync();
        Task<TodoItem> GetItemByIdAsync(Guid id);
        Task AddItemAsync(TodoItem item);
        Task UpdateItemAsync(TodoItem item);
        Task<bool> ItemExistsAsync(Guid id);
        Task<bool> DescriptionExistsAsync(string description);
    }s
}
