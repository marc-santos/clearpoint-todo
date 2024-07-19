using System.Collections.Generic;

namespace TodoList.Api.TodoItems
{
    public class TodoItemsListResponse
    {
        public List<TodoItemRecord> TodoItems { get; set; } = [];
    }
}
