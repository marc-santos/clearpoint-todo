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
    public class Update(ITodoRepository _repository, ILogger<Update> _logger) : Endpoint<UpdateTodoItemRequest, Results<NoContent, NotFound, ProblemDetails>>
    {
        public override void Configure()
        {
            Put(UpdateTodoItemRequest.Route);
            AllowAnonymous();
        }

        public override async Task<Results<NoContent, NotFound, ProblemDetails>> ExecuteAsync(UpdateTodoItemRequest request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (itemToUpdate == null)
            {
                return TypedResults.NotFound();
            }
            else
            {
                itemToUpdate.Description = request.Description;
                itemToUpdate.IsCompleted = request.IsCompleted;

                try
                {
                    await _repository.UpdateAsync(itemToUpdate, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while processing UPDATE to do item request");

                    AddError(ex.Message);
                    return new FastEndpoints.ProblemDetails(ValidationFailures);
                }

                return TypedResults.NoContent();
            }
        }
    }
}
