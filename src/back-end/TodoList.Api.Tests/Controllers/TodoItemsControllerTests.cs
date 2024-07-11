using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TodoList.Api.Controllers;
using TodoList.Api.Profiles;
using TodoList.Application.TodoItems.GetTodoItems;
using Xunit;

namespace TodoList.Api.Tests.Controllers
{
    public class TodoItemsControllerTests
    {
        private readonly Mock<ISender> _senderMock = new();
        private readonly NullLogger<TodoItemsController> _nullLogger = new();
        private readonly IMapper _mapper;

        public TodoItemsControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoItemsProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public void Given_NullSender_When_TodoItemsControllerInitialised_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsController(GetTodoContext(), _mapper, null!, _nullLogger);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Given_NullLogger_When_TodoItemsControllerInitialised_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsController(GetTodoContext(), _mapper, _senderMock.Object, null!);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Given_NullMapper_When_TodoItemsControllerInitialised_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsController(GetTodoContext(), null!, _senderMock.Object, _nullLogger);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Given_NullContext_When_TodoItemsControllerInitialised_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsController(null!, _mapper, _senderMock.Object, _nullLogger);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Given_GetTodoItems_When_SendGetTodoItemsQuery_Then_ReturnsTodoItemsFromContract()
        {
            _senderMock.Setup(x => x.Send(It.IsAny<GetTodoItemsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new GetTodoItemsResult(new List<Domain.TodoItems.TodoItem>()));

            var todoItemController = new TodoItemsController(GetTodoContext(), _mapper, _senderMock.Object, _nullLogger);

            var result = await todoItemController
                .GetTodoItems(CancellationToken.None);

            var okResult = result as OkObjectResult;
            
            okResult
                .Should()
                .NotBeNull();

            okResult!
                .Value
                .Should()
                .BeEquivalentTo(new List<Generated.TodoItem>());
        }

        private static TodoContext GetTodoContext()
        {
            var serviceCollection = new ServiceCollection()
                .AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoItemsDB"));
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetRequiredService<TodoContext>();
        }
    }
}
