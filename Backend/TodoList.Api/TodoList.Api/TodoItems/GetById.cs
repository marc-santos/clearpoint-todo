using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Infrastructure.Data;

namespace TodoList.Api.TodoItems
{
    public class GetById(ITodoRepository _repository) : Endpoint<GetTodoItemByIdRequest, TodoItemRecord>
    {
        public override void Configure()
        {
            Get(GetTodoItemByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetTodoItemByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (result == null)
            {
                await SendNotFoundAsync(cancellationToken);
            }
            else
            {
                Response = new TodoItemRecord(result.Id, result.Description, result.IsCompleted);
            }
        }
    }
}
