using Lab3.DataStorage;
using Lab3.Task;
using Lab4.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace Lab4.Tests
{
    public class TasksControllerTests
    {
        [Fact]
        public void PostToSqlite_ReturnsOkResult()
        {
            // Arrange
            var dataStorageMock = new Mock<DataStorage>();
            var tasksController = new TasksController(dataStorageMock.Object);

            var mockTasks = new List<TaskItem>
            {
                new TaskItem("Task 1", "Description 1", DateTime.Now, new List<string> { "Tag1", "Tag2" }),
                new TaskItem("Task 2", "Description 2", DateTime.Now, new List<string> { "Tag3", "Tag4" })
            };

            // Act
            var result = tasksController.PostToSqlite(mockTasks);

            // Assert
            Assert.Equal(typeof(OkResult), result.GetType());
        }
    }
}