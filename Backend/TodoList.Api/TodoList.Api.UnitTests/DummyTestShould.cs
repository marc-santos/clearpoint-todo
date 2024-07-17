using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Controllers;
using TodoList.Models;
using TodoList.RepositoryService.Interface;
using Xunit;

namespace TodoList.Api.UnitTests
{
    public class DummyTestShould
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private readonly Mock<ILogger<TodoItemsController>> _mockLogger;
        private readonly TodoItemsController _controller;

        public DummyTestShould()
        {
            _mockRepo = new Mock<ITodoRepository>();
            _mockLogger = new Mock<ILogger<TodoItemsController>>();
            _controller = new TodoItemsController(_mockRepo.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetTodoItems_ReturnsOkResult_WithAListOfTodoItems()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetIncompleteItemsAsync()).ReturnsAsync(new List<TodoItem> { new TodoItem() });

            // Act
            var result = await _controller.GetTodoItems();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsType<List<TodoItem>>(okResult.Value);
            Assert.Single(items);
        }

        [Fact]
        public async Task GetTodoItem_ReturnsNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetItemByIdAsync(It.IsAny<Guid>())).ReturnsAsync((TodoItem)null);

            // Act
            var result = await _controller.GetTodoItem(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostTodoItem_ReturnsBadRequest_WhenDescriptionIsEmpty()
        {
            // Act
            var result = await _controller.PostTodoItem(new TodoItem { Description = "" });

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Description is required", badRequestResult.Value);
        }
    }
}
