using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace TodoList.Api.TodoItems
{
    public class Update() : Endpoint<UpdateTodoItemRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Put(UpdateTodoItemRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateTodoItemRequest request, CancellationToken cancellationToken)
        {
            return;
        }
    }
}
