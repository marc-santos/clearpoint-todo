using MediatR;
using Microsoft.Extensions.Logging;
using TodoList.Domain.TodoItems.Entities;

namespace TodoList.Application.TodoItems.List
{
    public class Handler(ILogger<Handler> logger) : IRequestHandler<Request, Result>
    {
        private readonly ILogger<Handler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Result(new List<TodoItem>()));
        }
    }
}
