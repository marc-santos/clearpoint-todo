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
                // XML Docs are used by default but are overridden by these properties:
                //s.Summary = "Create a new Contributor.";
                //s.Description = "Create a new Contributor. A valid name is required.";
                s.ExampleRequest = new CreateTodoItemRequest { Description = "This is a test to do item", IsCompleted = false };
            });
        }

        public override async Task HandleAsync(CreateTodoItemRequest request, CancellationToken cancellationToken)
        {
            //var result = await _mediator.Send(new CreateContributorCommand(request.Name!,
            //  request.PhoneNumber), cancellationToken);

            //if (result.IsSuccess)
            //{
            //    Response = new CreateContributorResponse(result.Value, request.Name!);
            //    return;
            //}
            // TODO: Handle other cases as necessary

            Response = new CreateTodoItemResponse(Guid.NewGuid(), "yay!", false);
            return;
        }
    }
}
