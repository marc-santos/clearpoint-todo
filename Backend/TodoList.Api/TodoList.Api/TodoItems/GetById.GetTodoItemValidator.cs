using FastEndpoints;
using FluentValidation;

namespace TodoList.Api.TodoItems
{
    public class GetTodoItemValidator : Validator<GetTodoItemByIdRequest>
    {
        public GetTodoItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
