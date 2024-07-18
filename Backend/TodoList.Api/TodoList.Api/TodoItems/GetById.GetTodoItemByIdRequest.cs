using System;

namespace TodoList.Api.TodoItems
{
    public class GetTodoItemByIdRequest
    {
        public const string Route = "/api/todoitems/{TodoItemId:guid}";
        public static string BuildRoute(Guid todoItemId) => Route.Replace("{TodoItemId:guid}", todoItemId.ToString());

        public Guid TodoItemId { get; set; }
    }
}
