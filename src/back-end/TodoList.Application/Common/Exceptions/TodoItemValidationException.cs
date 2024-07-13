using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace TodoList.Application.Common.Exceptions
{
    [ExcludeFromCodeCoverage(Justification = "Exception")]
    public sealed class TodoItemValidationException : ValidationException
    {
        public TodoItemValidationException(string message) : base(message)
        {
        }

        public TodoItemValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
        {
        }

        public TodoItemValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
        {
        }

        public TodoItemValidationException(IEnumerable<ValidationFailure> errors) : base(errors)
        {
        }
    }
}
