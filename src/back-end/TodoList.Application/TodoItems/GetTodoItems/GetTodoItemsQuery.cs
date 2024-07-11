using MediatR;

namespace TodoList.Application.TodoItems.GetTodoItems;

public sealed record GetTodoItemsQuery() : IRequest<Result>;