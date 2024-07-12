using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Application.Contracts;
using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public sealed record GetTodoItemResult(bool IsFound, TodoItem? TodoItem);

    public sealed class GetTodoItemHandler
    {
        public class Handler(ITodoItemsRepository repository, ILogger<GetTodoItemHandler> logger)
            : IRequestHandler<GetTodoItemQuery, GetTodoItemResult>
        {
            private readonly ITodoItemsRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            private readonly ILogger<GetTodoItemHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            public async Task<GetTodoItemResult> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Getting todo item with id {Id}", request.Id);

                var todoItem = await _repository.GetTodoItemAsync(new TodoItemId(request.Id), cancellationToken);

                if (todoItem == null)
                {
                    return new GetTodoItemResult(false, null);
                }

                _logger.LogInformation("Returning todo item with id {Id}", todoItem.Id.Value);

                return new GetTodoItemResult(true, todoItem);
            }
        }
    }
}
