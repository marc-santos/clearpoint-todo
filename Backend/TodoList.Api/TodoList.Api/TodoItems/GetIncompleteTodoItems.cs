using FastEndpoints;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Infrastructure.Data;

namespace TodoList.Api.TodoItems
{
    public class GetIncompleteTodoItems(ITodoRepository _repository) : EndpointWithoutRequest<TodoItemsListResponse>
    {
        public override void Configure()
        {
            Get("/api/todoitems");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetManyAsync(t => !t.IsCompleted, cancellationToken);

            Response = new TodoItemsListResponse
            {
                TodoItems = result.Select(t => new TodoItemRecord(t.Id, t.Description, t.IsCompleted)).ToList()
            };
        }
    }
}
