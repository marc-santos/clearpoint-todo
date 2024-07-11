using FluentValidation;

namespace TodoList.Application.TodoItems.GetTodoItems
{
    public sealed class GetTodoItemsValidator : AbstractValidator<GetTodoItemsQuery>
    {
        public GetTodoItemsValidator()
        {
        }
    }
}
