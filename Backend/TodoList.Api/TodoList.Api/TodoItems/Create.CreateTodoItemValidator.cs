using FastEndpoints;
using FluentValidation;

namespace TodoList.Api.TodoItems
{
    public class CreateTodoItemValidator : Validator<CreateTodoItemRequest>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MinimumLength(2)
                .MaximumLength(20);
        }
    }
}
