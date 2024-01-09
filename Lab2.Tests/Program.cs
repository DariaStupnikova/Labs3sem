using System;
using System.Collections.Generic;
using Lab2.Console;
using Lab2.Task;
using Lab2.ToDoList;
using Xunit;

namespace Lab2.Tests
{
    public class ToDoListTests
    {
        [Fact]
        public void ConsoleInterface_AddTask_ReturnsValidTask()
        {
            // Arrange
            var consoleInterface = new ConsoleInterface();
        
            // Act
            var task = consoleInterface.AddTask();
        
            // Assert
            Assert.NotNull(task);
            Assert.NotNull(task.Title);
            Assert.NotNull(task.Description);
            Assert.NotNull(task.Deadline);
            Assert.NotNull(task.Tags);
        }

        [Fact]
        public void TaskItem_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var title = "Test Title";
            var description = "Test Description";
            var deadline = "Test Deadline";
            var tags = new List<string> { "tag1", "tag2" };

            // Act
            var task = new TaskItem(title, description, deadline, tags);

            // Assert
            Assert.Equal(title, task.Title);
            Assert.Equal(description, task.Description);
            Assert.Equal(deadline, task.Deadline);
            Assert.Equal(tags, task.Tags);
        }

        [Fact]
        public void ToDoListService_AddTask_AddsTaskToList()
        {
            // Arrange
            var toDoListService = new ToDoListService(null, null);
            var task = new TaskItem("Test Title", "Test Description", "Test Deadline", new List<string>());
        
            // Act
            toDoListService.ToDoList.Tasks.Add(task);
        
            // Assert
            Assert.Contains(task, toDoListService.ToDoList.Tasks);
        }
    }
}
