using FluentValidation;
using TodoList.Application.Extensions;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public sealed class CreateTodoItemValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(ti => ti.Id)
                .ValidateId();
            RuleFor(ti => ti.Description)
                .ValidateDescription();
        }
    }
}
