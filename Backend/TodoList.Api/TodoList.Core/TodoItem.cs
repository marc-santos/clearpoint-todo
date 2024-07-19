namespace TodoList.Models
{
    public class TodoItem(Guid id, string description, bool isCompleted)
    {
        public Guid Id { get; set; } = id;

        public string Description { get; set; } = description;

        public bool IsCompleted { get; set; } = isCompleted;
    }
}
