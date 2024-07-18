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
            //var result = await _mediator.Send(new UpdateTodoItemCommand(request.Id, request.Description!, request.IsCompleted!), cancellationToken);

            //if (result.Status == ResultStatus.NotFound)
            //{
            //    await SendNotFoundAsync(cancellationToken);
            //    return;
            //}

            //var query = new GetTodoItemQuery(request.ContributorId);

            //var queryResult = await _mediator.Send(query, cancellationToken);

            //if (queryResult.Status == ResultStatus.NotFound)
            //{
            //    await SendNotFoundAsync(cancellationToken);
            //    return;
            //}

            //if (queryResult.IsSuccess)
            //{
            //    var dto = queryResult.Value;
            //    Response = new UpdateTodoItemResponse(new ContributorRecord(dto.Id, dto.Name, dto.PhoneNumber));
            return;
            //}
        }
    }
}
