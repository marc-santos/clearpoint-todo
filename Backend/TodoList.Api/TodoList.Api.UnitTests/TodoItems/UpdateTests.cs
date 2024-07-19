using FastEndpoints;
using FastEndpoints.Testing;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Net;
using System.Threading.Tasks;
using TodoList.Api.TodoItems;
using Xunit;
using Xunit.Priority;

namespace TodoList.Api.IntegrationTests.TodoItems
{
    public class UpdateTests(App _app) : TestBase<App>
    {
        private readonly UpdateTodoItemRequest testPayload = new()
        {
            Id = Guid.NewGuid(),
            Description = "To do item description",
            IsCompleted = false
        };

        [Fact, Priority(1)]
        public async Task UpdateTodoItem_ReturnsNoContent()
        {
            await _app.Client.POSTAsync<Create, CreateTodoItemRequest, CreateTodoItemResponse>(new CreateTodoItemRequest
            {
                Id = testPayload.Id,
                Description = testPayload.Description,
                IsCompleted = testPayload.IsCompleted
            });
            var (rsp, _) = await _app.Client.PUTAsync<UpdateTodoItemRequest, NoContent>($"/api/todoitems/{testPayload.Id}", testPayload);

            Assert.Equal(HttpStatusCode.NoContent, rsp.StatusCode);
        }

        [Fact, Priority(2)]
        public async Task UpdateTodoItem_ReturnsNotFound()
        {
            var (rsp, _) = await _app.Client.PUTAsync<UpdateTodoItemRequest, NotFound>($"/api/todoitems/{testPayload.Id}", testPayload);

            Assert.Equal(HttpStatusCode.NotFound, rsp.StatusCode);
        }

        [Fact, Priority(3)]
        public async Task UpdateTodoItem_ReturnsBadRequest()
        {
            var (rsp, _) = await _app.Client.PUTAsync<UpdateTodoItemRequest, BadRequest>($"/api/todoitems/{Guid.Empty}", testPayload);

            Assert.Equal(HttpStatusCode.BadRequest, rsp.StatusCode);
        }
    }
}
