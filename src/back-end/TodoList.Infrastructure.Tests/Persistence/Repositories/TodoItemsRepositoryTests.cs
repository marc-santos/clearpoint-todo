using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using TodoList.Domain.TodoItems;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Persistence.Repositories;

namespace TodoList.Infrastructure.Tests.Persistence.Repositories
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class TodoItemsRepositoryTests
    {
        [Fact]
        public void Given_NullDbContext_When_TodoItemsRepositoryInitialised_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsRepository(null!, new NullLogger<TodoItemsRepository>());

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Given_NullLogger_When_TodoItemsRepositoryInitialised_Then_ThrowsArgumentNullException()
        {
            var serviceProvider = GetServiceProvider();
            var action = () => new TodoItemsRepository(serviceProvider.GetRequiredService<TodoListDbContext>(), null!);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Given_TodoItems_When_GetTodoItemsAsync_Then_ReturnsTodoItems()
        {
            var serviceProvider = GetServiceProvider();
            var dbContext = serviceProvider
                .GetRequiredService<TodoListDbContext>();

            var repository = new TodoItemsRepository(dbContext, new NullLogger<TodoItemsRepository>());

            var result = await repository
                .GetTodoItemsAsync(CancellationToken.None);

            result
                .Should()
                .BeEquivalentTo(new List<TodoItem>());
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<TodoListDbContext>(opt => opt.UseInMemoryDatabase("TodoItemsDB"));

            return serviceCollection.BuildServiceProvider();
        }
    }
}
