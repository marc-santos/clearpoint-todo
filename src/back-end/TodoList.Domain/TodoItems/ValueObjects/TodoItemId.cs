using TodoList.Domain.Common.Models;

namespace TodoList.Domain.TodoItems.ValueObjects
{
    public class TodoItemId : ValueObject
    {
        public Guid Value { get; }

        public TodoItemId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("TodoItemId cannot be empty", nameof(value));
            }

            Value = value;
        }

        public static TodoItemId Create(Guid value)
        {
            return new TodoItemId(value);
        }

        public static implicit operator Guid(TodoItemId todoItemId) => todoItemId.Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
