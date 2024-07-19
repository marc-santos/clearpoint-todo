using FastEndpoints;
using FastEndpoints.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using TodoList.Api.TodoItems;
using Xunit;
using Xunit.Priority;

namespace TodoList.Api.IntegrationTests.TodoItems
{
    public class CreateTests(App _app) : TestBase<App>
    {
        private readonly CreateTodoItemRequest testPayload = new()
        {
            Id = Guid.NewGuid(),
            Description = "To do item description",
            IsCompleted = false
        };

        [Fact, Priority(1)]
        public async Task CreateTodoItem_ReturnsOk()
        {
            var (rsp, res) = await _app.Client.POSTAsync<Create, CreateTodoItemRequest, CreateTodoItemResponse>(testPayload);

            Assert.Equal(HttpStatusCode.OK, rsp.StatusCode);
            Assert.Equal(res.Id, testPayload.Id);
            Assert.Equal(res.Description, testPayload.Description);
            Assert.Equal(res.IsCompleted, testPayload.IsCompleted);
        }

        [Fact, Priority(2)]
        public async Task CreateTodoItem_ReturnsBadRequest()
        {
            await _app.Client.POSTAsync<Create, CreateTodoItemRequest, CreateTodoItemResponse>(testPayload);

            var (rsp, _) = await _app.Client.POSTAsync<Create, CreateTodoItemRequest, CreateTodoItemResponse>(testPayload);

            Assert.Equal(HttpStatusCode.BadRequest, rsp.StatusCode);
        }
    }
}
