using System;

namespace TodoList.Api.TodoItems
{
    public class CreateTodoItemResponse(Guid id, string description, bool isCompleted)
    {
        public Guid Id { get; set; } = id;

        public string Description { get; set; } = description;

        public bool IsCompleted { get; set; } = isCompleted;
    }
}
