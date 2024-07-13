using System.Diagnostics.CodeAnalysis;

namespace TodoList.Application.Common.Exceptions
{
    [ExcludeFromCodeCoverage(Justification = "Exception")]
    public sealed class TodoItemDuplicateException : Exception
    {
        public TodoItemDuplicateException() { }
        public TodoItemDuplicateException(string message) : base(message) { }
        public TodoItemDuplicateException(string message, Exception innerException) : base(message, innerException)
        { }

        public TodoItemDuplicateException(string property, object value)
            : base($"Property \"{property}\" with ({value}) was a duplicate.")
        {
        }
    }
}
