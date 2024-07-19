using FastEndpoints;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TodoList.Api.TodoItems
{
    public class Create() : Endpoint<CreateTodoItemRequest, CreateTodoItemResponse>
    {
        public override void Configure()
        {
            Post(CreateTodoItemRequest.Route);
            AllowAnonymous();
            Summary(s =>
            {
                s.ExampleRequest = new CreateTodoItemRequest { Description = "This is a test to do item", IsCompleted = false };
            });
        }

        public override async Task HandleAsync(CreateTodoItemRequest request, CancellationToken cancellationToken)
        {
            Response = new CreateTodoItemResponse(Guid.NewGuid(), "yay!", false);
            return;
        }
    }
}
