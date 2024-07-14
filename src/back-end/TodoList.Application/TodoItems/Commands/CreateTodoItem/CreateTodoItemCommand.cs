using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    [ExcludeFromCodeCoverage(Justification = "Record")]
    public sealed record CreateTodoItemCommand(Guid Id, string Description, bool isCompleted)
        : IRequest<CreateTodoItemResult>;

}
