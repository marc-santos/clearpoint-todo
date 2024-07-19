namespace TodoList.Core.TodoListAggregate
{
    public class TodoList(string description, bool isCompleted)
    {
        public string Description { get; set; } = description;

        public bool IsCompleted { get; set; } = isCompleted;
    }
}
