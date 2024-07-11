using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace TodoList.Application.TodoItems.GetTodoItems;

[ExcludeFromCodeCoverage(Justification = "Record")]
public sealed record GetTodoItemsQuery : IRequest<GetTodoItemsResult>;