using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.TodoItems
{
    public class CreateTodoItemRequest
    {
        public const string Route = "/api/todoitems";

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
