using FastEndpoints;
using FluentValidation;

namespace TodoList.Api.TodoItems
{
    public class UpdateTodoItemValidator : Validator<UpdateTodoItemRequest>
    {
        public UpdateTodoItemValidator()
        {
            RuleFor(x => x.TodoItemId)
                .Must((args, todoItemId) => args.Id == todoItemId)
                .WithMessage("Route and body IDs must match.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(2)
                .MaximumLength(20);
        }
    }
}
