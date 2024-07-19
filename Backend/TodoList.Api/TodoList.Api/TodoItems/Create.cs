using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Infrastructure.Data;

namespace TodoList.Api.TodoItems
{
    public class Create(ITodoRepository _repository, ILogger<Create> _logger) : Endpoint<CreateTodoItemRequest, Results<Ok<CreateTodoItemResponse>, ProblemDetails>>
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

        public override async Task<Results<Ok<CreateTodoItemResponse>,ProblemDetails>> ExecuteAsync(CreateTodoItemRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddAsync(new Models.TodoItem(request.Id, request.Description, request.IsCompleted), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing CREATE to do item request");

                AddError(ex.Message);
                return new FastEndpoints.ProblemDetails(ValidationFailures);
            }

            return TypedResults.Ok(new CreateTodoItemResponse(request.Id, request.Description, request.IsCompleted));
        }
    }
}
