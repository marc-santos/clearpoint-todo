using FastEndpoints;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TodoList.Api.TodoItems
{
    public class GetById() : Endpoint<GetTodoItemByIdRequest, TodoItemRecord>
    {
        public override void Configure()
        {
            Get(GetTodoItemByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetTodoItemByIdRequest request, CancellationToken cancellationToken)
        {
            //var command = new GetTodoItemQuery(request.TodoItemId);

            //var result = await _mediator.Send(command, cancellationToken);

            //if (result.Status == ResultStatus.NotFound)
            //{
            //    await SendNotFoundAsync(cancellationToken);
            //    return;
            //}

            //if (result.IsSuccess)
            //{
            //    Response = new TodoItemRecord(result.Value.Id, result.Value.Description, result.Value.IsCompleted);
            Response = new TodoItemRecord(Guid.NewGuid(), "This is a sample to do item", false);
            //}

        }
    }
}
