using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Service;
using Xunit;

namespace TodoList.Api.UnitTests
{
    public class DummyTestShould
    {
        private TodoContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "TodoItemsDB")
                .Options;

            var context = new TodoContext(options);
            return context;
        }

        [Fact]
        public async Task GetTodoItemsAsync_ShouldReturnIncompleteItems()
        {
            // Arrange
            var context = GetInMemoryContext();
            context.TodoItems.AddRange(
                new TodoItem { Id = Guid.NewGuid(), Description = "Item 1", IsCompleted = false }
            );
            await context.SaveChangesAsync();

            var service = new TodoItemsServiceImpl(context);

            // Act
            var result = await service.GetTodoItemsAsync();

            // Assert
            Assert.Equal("Item 1", result.LastOrDefault().Description);
        }

        [Fact]
        public async Task GetTodoItemByIdAsync_ShouldReturnNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new TodoItemsServiceImpl(context);

            // Act
            var result = await service.GetTodoItemByIdAsync(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetTodoItemByIdAsync_ShouldReturnItem_WhenItemExists()
        {
            // Arrange
            var context = GetInMemoryContext();
            var existingItem = new TodoItem { Id = Guid.NewGuid(), Description = "Existing Item", IsCompleted = false };
            context.TodoItems.Add(existingItem);
            await context.SaveChangesAsync();

            var service = new TodoItemsServiceImpl(context);

            // Act
            var result = await service.GetTodoItemByIdAsync(existingItem.Id);

            // Assert
            Assert.NotNull(result.Value);
            Assert.Equal(existingItem.Description, result.Value.Description);
        }

        [Fact]
        public async Task PutTodoItemAsync_ShouldReturnBadRequest_WhenIdMismatch()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new TodoItemsServiceImpl(context);
            var item = new TodoItem { Id = Guid.NewGuid(), Description = "Test Item", IsCompleted = false };

            // Act
            var result = await service.PutTodoItemAsync(Guid.NewGuid(), item);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostTodoItemAsync_ShouldReturnBadRequest_WhenDescriptionIsNull()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new TodoItemsServiceImpl(context);
            var item = new TodoItem { Id = Guid.NewGuid(), Description = null, IsCompleted = false };

            // Act
            var result = await service.PostTodoItemAsync(item);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task PostTodoItemAsync_ShouldReturnNoContent_WhenItemIsValid()
        {
            // Arrange
            var context = GetInMemoryContext();
            var service = new TodoItemsServiceImpl(context);
            var item = new TodoItem { Id = Guid.NewGuid(), Description = "New Item", IsCompleted = false };

            // Act
            var result = await service.PostTodoItemAsync(item);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
