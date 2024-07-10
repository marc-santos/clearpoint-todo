using MediatR;

namespace TodoList.Application.TodoItems.GetTodoItems;

public sealed record GetTodoItemsCommand() : IRequest<Result>;