using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Api.Service
{
    public class TodoItemsServiceImpl : ITodoItemsService
    {
        private readonly TodoContext _context;

        public TodoItemsServiceImpl(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await _context.TodoItems.OrderBy(x => x.IsCompleted).ToListAsync();
        }

        public async Task<ActionResult<TodoItem>> GetTodoItemByIdAsync(Guid id)
        {
            var result = await _context.TodoItems.FindAsync(id);

            if (result == null)
            {
                return new NotFoundResult();
            }

            return result;
        }

        public async Task<ActionResult> PutTodoItemAsync(Guid id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            todoItem.IsCompleted = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return new BadRequestObjectResult(
                    new { message = "Db Update Concurrency Exception" });
            }
            return new NoContentResult();
        }

        public async Task<ActionResult> PostTodoItemAsync(TodoItem todoItem)
        {
            if (string.IsNullOrEmpty(todoItem?.Description) || "".Equals(todoItem?.Description))
            {
                return new BadRequestObjectResult(
                    new { message = "Description is required" });
            }
            else if (TodoItemDescriptionExists(todoItem.Description))
            {
                return new BadRequestObjectResult(
                    new { message = "Description already exists" });
            }
            else if (TodoItemIdExists(todoItem.Id))
            {
                return new BadRequestObjectResult(
                    new { message = $"Id: {todoItem.Id} already exists" });
            }
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        private bool TodoItemIdExists(Guid id)
        {
            return _context.TodoItems.Any(x => x.Id == id);
        }

        private bool TodoItemDescriptionExists(string description)
        {
            return _context.TodoItems
                   .Any(x => x.Description
                    .ToLowerInvariant() == description.ToLowerInvariant() && !x.IsCompleted);
        }

    }
}


