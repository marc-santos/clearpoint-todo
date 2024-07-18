using System;

namespace TodoList.Api.TodoItems
{
    public record TodoItemRecord(Guid Id, string Description, bool IsCompleted);
}
