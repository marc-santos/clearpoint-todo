using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    [ExcludeFromCodeCoverage(Justification = "Record")]
    public sealed record GetTodoItemQuery(Guid Id) : IRequest<GetTodoItemResult>;
}