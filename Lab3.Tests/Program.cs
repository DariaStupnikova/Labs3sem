using System;
using System.Collections.Generic;
using Lab3.DataStorage;
using Lab3.Task;
using Xunit;

namespace Lab3.Tests;

public class DataStorageTests
{
    [Fact]
    public void SaveAndLoadFromJsonTest()
    {
        var dataStorage = new DataStorage.DataStorage();

        // Test data
        var tasks = new List<TaskItem>
        {
            new TaskItem("Task 1", "Description 1", DateTime.Now, new List<string> { "Tag1", "Tag2" }),
            new TaskItem("Task 2", "Description 2", DateTime.Now, new List<string> { "Tag3", "Tag4" })
        };

        // Save to JSON
        dataStorage.SaveToJSON(tasks);

        // Load from JSON
        var loadedTasks = dataStorage.LoadFromJSON();

        // Assert
        Assert.Equal(tasks.Count, loadedTasks.Count);
        for (int i = 0; i < tasks.Count; i++)
        {
            Assert.Equal(tasks[i].Title, loadedTasks[i].Title);
            Assert.Equal(tasks[i].Description, loadedTasks[i].Description);
            Assert.Equal(tasks[i].Deadline, loadedTasks[i].Deadline);
            Assert.Equal(tasks[i].Tags, loadedTasks[i].Tags);
        }
    }

    [Fact]
    public void SaveAndLoadFromXmlTest()
    {
        var dataStorage = new DataStorage.DataStorage();

        // Test data
        var tasks = new List<TaskItem>
        {
            new TaskItem("Task 1", "Description 1", DateTime.Now, new List<string> { "Tag1", "Tag2" }),
            new TaskItem("Task 2", "Description 2", DateTime.Now, new List<string> { "Tag3", "Tag4" })
        };

        // Save to XML
        dataStorage.SaveToXML(tasks);

        // Load from XML
        var loadedTasks = dataStorage.LoadFromXML();

        // Assert
        Assert.Equal(tasks.Count, loadedTasks.Count);
        for (int i = 0; i < tasks.Count; i++)
        {
            Assert.Equal(tasks[i].Title, loadedTasks[i].Title);
            Assert.Equal(tasks[i].Description, loadedTasks[i].Description);
            Assert.Equal(tasks[i].Tags, loadedTasks[i].Tags);
        }
    }
}