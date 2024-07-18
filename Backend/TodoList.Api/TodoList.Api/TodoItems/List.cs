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
            //    Result<IEnumerable<TodoItemDTO>> result = await _mediator.Send(new ListTodoItemsQuery(null, null), cancellationToken);

            //    if (result.IsSuccess)
            //    {
            //        Response = new TodoItemListResponse
            //        {
            //            TodoItems = result.Value.Select(c => new TodoItemRecord(c.Id, c.Description, c.IsCompleted)).ToList()
            //        };
            //    }
        }
    }
}
