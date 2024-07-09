using MediatR;
using TodoList.Domain.TodoItems.Entities;

namespace TodoList.Application.TodoItems.List;

public record Result (IEnumerable<TodoItem> TodoItems) : IRequest<Result>;