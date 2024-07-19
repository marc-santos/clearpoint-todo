using System;

namespace TodoList.Api.TodoItems
{
    public class GetTodoItemByIdRequest
    {
        public const string Route = "/api/todoitems/{Id:guid}";
        public static string BuildRoute(Guid id) => Route.Replace("{Id:guid}", id.ToString());

        public Guid Id { get; set; }
    }
}
