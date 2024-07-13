using FluentValidation;
using TodoList.Application.Extensions;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public sealed class GetTodoItemValidator : AbstractValidator<GetTodoItemQuery>  
    {
        public GetTodoItemValidator()
        {
            RuleFor(ti => ti.Id)
                .ValidateId();
        }
    }
}
