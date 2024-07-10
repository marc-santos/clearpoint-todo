using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Persistence.Repositories;

namespace TodoList.Infrastructure.Tests.Persistence.Repositories
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class TodoItemsRepositoryTests
    {
        private readonly ServiceCollection _serviceCollection = new();
        private readonly IServiceProvider _serviceProvider;

        public TodoItemsRepositoryTests()
        {
            _serviceCollection
                .AddDbContext<TodoListDbContext>(opt => opt.UseInMemoryDatabase("TodoItemsDB"));

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void Given_NullDbContext_When_TodoItemsRepositoryInitialized_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsRepository(null!, new NullLogger<TodoItemsRepository>());

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Given_NullLogger_When_TodoItemsRepositoryInitialized_Then_ThrowsArgumentNullException()
        {
            var action = () => new TodoItemsRepository(_serviceProvider.GetRequiredService<TodoListDbContext>(), null!);

            action
                .Should()
                .Throw<ArgumentNullException>();
        }

    }
}
