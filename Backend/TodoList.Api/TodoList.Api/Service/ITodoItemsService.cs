using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Service
{
    public interface ITodoItemsService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();

        Task<ActionResult<TodoItem>> GetTodoItemByIdAsync(Guid id);

        Task<ActionResult> PutTodoItemAsync(Guid id, TodoItem todoItem);

        Task<ActionResult> PostTodoItemAsync(TodoItem todoItem);
    }
}


