using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.RepositoryService.Interface;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(ITodoRepository todoRepository, ILogger<TodoItemsController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }


        /// <summary>
        /// Get Todo Items
        /// </summary>
        /// <returns>Todo Items</returns>
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            try
            {
                var results = await _todoRepository.GetIncompleteItemsAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TodoItemsController => GetTodoItems");
                throw;
            }

        }

        /// <summary>
        /// Get Todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Todo Item</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            try
            {
                var result = await _todoRepository.GetItemByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TodoItemsController => GetTodoItem");
                throw;
            }

        }

        /// <summary>
        /// Put Todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns>Error or Success Message</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, TodoItem todoItem)
        {
            try
            {

                if (id != todoItem.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await _todoRepository.UpdateItemAsync(todoItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _todoRepository.ItemExistsAsync(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(new { message = "Item has been updated successfully" });
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "TodoItemsController => PutTodoItem");
                throw;
            }
        }


        /// <summary>
        /// Post Todo Item
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Error or Success Message</returns>
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
        {
            try
            {

                if (string.IsNullOrEmpty(todoItem?.Description))
                {
                    return BadRequest("Description is required");
                }
                else if (await _todoRepository.DescriptionExistsAsync(todoItem.Description))
                {
                    return BadRequest("Description already exists");
                }

                await _todoRepository.AddItemAsync(todoItem);
                return Ok(new { message = "Item has been added successfully" });


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "TodoItemsController => PostTodoItem");
                throw;
            }
        }
    }
}
