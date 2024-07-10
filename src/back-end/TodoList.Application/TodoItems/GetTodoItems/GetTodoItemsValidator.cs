using FluentValidation;

namespace TodoList.Application.TodoItems.GetTodoItems
{
    public sealed class GetTodoItemsValidator : AbstractValidator<GetTodoItemsCommand>
    {
        public GetTodoItemsValidator()
        {
        }
    }
}
