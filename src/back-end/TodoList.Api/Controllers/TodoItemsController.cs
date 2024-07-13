using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;
using TodoList.Application.TodoItems.GetTodoItems;
using TodoList.Application.TodoItems.Queries.GetTodoItem;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        private readonly ILogger<TodoItemsController> _logger;

        public TodoItemsController(TodoContext context, IMapper mapper, ISender sender, ILogger<TodoItemsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetTodoItems(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all todo items");

            var results = await _sender.Send(new GetTodoItemsQuery(), cancellationToken);
            var todoItems = _mapper.Map<IEnumerable<Generated.TodoItem>>(results.TodoItems);

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(Guid id, CancellationToken cancellation)
        {
            var result = await _sender
                .Send(new GetTodoItemQuery(id), cancellation);

            var todoItem = _mapper
                .Map<Generated.TodoItem>(result.TodoItem);

            return Ok(todoItem);
        }

        // PUT: api/TodoItems/... 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemIdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        } 

        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
        {
            var result = await _sender
                .Send(new CreateTodoItemCommand(todoItem.Id, todoItem.Description, todoItem.IsCompleted));

            var createdTodoItem = _mapper
                .Map<Generated.TodoItem>(result.TodoItem);
             
            return CreatedAtAction(nameof(GetTodoItem), new { id = createdTodoItem.Id }, createdTodoItem);
        } 

        private bool TodoItemIdExists(Guid id)
        {
            return _context.TodoItems.Any(x => x.Id == id);
        }
    }
}
