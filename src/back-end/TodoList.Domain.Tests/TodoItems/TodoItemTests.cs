using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using TodoList.Domain.TodoItems;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Domain.Tests.TodoItems
{
    [ExcludeFromCodeCoverage(Justification = "Tests")]
    public class TodoItemTests
    {
        [Fact]
        public void Given_TodoItem_When_Created_Then_PropertiesMatch()
        {
            var todoItemId = new TodoItemId(Guid.NewGuid());
            var description = "Test";
            var isCompleted = false;
            var createdAt = DateTimeOffset.Now;
            var modifiedAt = DateTimeOffset.Now;

            var todoItem = new TodoItem(todoItemId, description, isCompleted, createdAt, modifiedAt);

            todoItem.Id.Should().BeEquivalentTo(todoItemId);
            todoItem.Description.Should().Be(description);
            todoItem.IsCompleted.Should().Be(isCompleted);
            todoItem.CreatedAt.Should().Be(createdAt);
            todoItem.ModifiedAt.Should().Be(modifiedAt);
        }

        [Fact]
        public void Given_TodoItem_When_MarkAsCompleted_Then_IsCompletedIsTrue()
        {
            var todoItem = new TodoItem(new TodoItemId(Guid.NewGuid()), "Test", false, DateTimeOffset.Now, DateTimeOffset.Now);

            todoItem.MarkAsCompleted();

            todoItem.IsCompleted
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Given_TodoItem_When_SetModified_Then_ModifiedAtIsNow()
        {
            var modifiedAt = DateTimeOffset.Now;

            var todoItem = new TodoItem(new TodoItemId(Guid.NewGuid()), "Test", false, DateTimeOffset.Now, modifiedAt);

            todoItem.SetModified();

            todoItem.ModifiedAt
                .Should()
                .BeAfter(modifiedAt);
        }
    }
}
