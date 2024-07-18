using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.TodoItems
{
    public class UpdateTodoItemRequest
    {
        public const string Route = "/api/todoitems/{TodoItemId:guid}";
        public static string BuildRoute(Guid todoItemId) => Route.Replace("{TodoItemId:guid}", todoItemId.ToString());

        public Guid TodoItemId { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
