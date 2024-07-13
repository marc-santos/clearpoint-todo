using FluentValidation;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public sealed class CreateTodoItemValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(ti => ti.Id)
                .NotEmpty();
            RuleFor(ti => ti.Description)
                .NotEmpty();
        }
    }
}
