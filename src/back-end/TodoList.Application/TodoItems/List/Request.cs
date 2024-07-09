using MediatR;

namespace TodoList.Application.TodoItems.List;

public record Request() : IRequest<Result>;