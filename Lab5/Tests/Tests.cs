using System;
using System.Collections.Generic;
using Lab3.DataStorage;
using Lab3.Task;
using Lab5.Models;
using Moq;
using Xunit;

namespace Lab5.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void EditMenuItem_Click_ShouldUpdateTask()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockDataStorage = new Mock<DataStorage>();
            var mockEditTaskViewModel = new Mock<EditTaskViewModel>();

            // Sample data for testing
            var selectedTask = new TaskItem
            {
                Title = "Task1",
                Description = "Description1",
                Deadline = DateTime.Now,
                Tags = new List<string> { "Tag1", "Tag2" }
            };

            var editedTask = new TaskItem
            {
                Title = "EditedTask",
                Description = "EditedDescription",
                Deadline = DateTime.Now.AddDays(1),
                Tags = new List<string> { "Tag1", "Tag3" }
            };

            mockEditTaskViewModel.SetupGet(vm => vm.EditedTask).Returns(editedTask);
            mockDataStorage.Setup(ds => ds.LoadFromSQLite()).Returns(new List<TaskItem> { selectedTask });

            mainWindow._dataStorage = mockDataStorage.Object;
            mainWindow.InitializeComponent();
            mainWindow.taskListView.ItemsSource = mainWindow._taskItems;
            mainWindow.taskListView.SelectedItem = selectedTask;

            // Act
            mainWindow.EditMenuItem_Click(null, null);

            // Assert
            Assert.Equal("EditedTask", selectedTask.Title);
            Assert.Equal("EditedDescription", selectedTask.Description);
            Assert.Equal(DateTime.Now.AddDays(1).Date, selectedTask.Deadline.Date);
            Assert.Equal(2, selectedTask.Tags.Count);
            Assert.Contains("Tag1", selectedTask.Tags);
            Assert.Contains("Tag3", selectedTask.Tags);
        }

        [Fact]
        public void MainWindow_Initialization_ShouldLoadTasksFromStorage()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var mockDataStorage = new Mock<DataStorage>();
            mockDataStorage.Setup(ds => ds.LoadFromSQLite()).Returns(new List<TaskItem>
            {
                new TaskItem { Title = "Task1" },
                new TaskItem { Title = "Task2" }
            });

            mainWindow._dataStorage = mockDataStorage.Object;

            // Act
            mainWindow.InitializeComponent();

            // Assert
            Assert.Equal(2, mainWindow._taskItems.Count); // Two tasks should be loaded during initialization
            Assert.Equal("Task1", mainWindow._taskItems[0].Title);
            Assert.Equal("Task2", mainWindow._taskItems[1].Title);
        }
    }
    
    public class EditTaskDialogTests
    {
        [Fact]
        public void OkButton_Click_ShouldSetDialogResultToTrue()
        {
            // Arrange
            var viewModel = new Mock<EditTaskViewModel>();
            var editTaskDialog = new EditTaskDialog(viewModel.Object);

            // Act
            editTaskDialog.OkButton_Click(null, null);

            // Assert
            Assert.True(editTaskDialog.DialogResult); // DialogResult should be set to true
        }

        [Fact]
        public void CancelButton_Click_ShouldSetDialogResultToFalse()
        {
            // Arrange
            var viewModel = new Mock<EditTaskViewModel>();
            var editTaskDialog = new EditTaskDialog(viewModel.Object);

            // Act
            editTaskDialog.CancelButton_Click(null, null);

            // Assert
            Assert.False(editTaskDialog.DialogResult); // DialogResult should be set to false
        }

        // Add more tests as needed
    }
    
    public class Test
    {
        public static void Testing()
        {
            var mainWindowTests = new MainWindowTests();
            var editTaskDialogTests = new EditTaskDialogTests();
            
            mainWindowTests.EditMenuItem_Click_ShouldUpdateTask();
            mainWindowTests.MainWindow_Initialization_ShouldLoadTasksFromStorage();
            
            editTaskDialogTests.CancelButton_Click_ShouldSetDialogResultToFalse();
            editTaskDialogTests.OkButton_Click_ShouldSetDialogResultToTrue();
        }
    }
}