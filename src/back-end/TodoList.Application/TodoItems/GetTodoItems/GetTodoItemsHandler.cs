using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Domain.TodoItems;

namespace TodoList.Application.TodoItems.GetTodoItems
{
    public sealed record Result (IEnumerable<TodoItem> TodoItems) : IRequest<Result>;

    public sealed class GetTodoItemsHandler(ILogger<GetTodoItemsHandler> logger) : IRequestHandler<GetTodoItemsQuery, Result>
    {
        private readonly ILogger<GetTodoItemsHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<Result> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Result(new List<TodoItem>()));
        }
    }
}
