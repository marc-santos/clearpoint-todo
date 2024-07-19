using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace TodoList.Api.TodoItems
{
    public class List() : EndpointWithoutRequest<TodoItemListResponse>
    {
        public override void Configure()
        {
            Get("/api/todoitems");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
        }
    }
}
