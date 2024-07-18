using System.Collections.Generic;

namespace TodoList.Api.TodoItems
{
    public class TodoItemListResponse
    {
        public List<TodoItemRecord> TodoItems { get; set; } = [];
    }
}
