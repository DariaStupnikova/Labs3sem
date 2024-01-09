using Lab2.Task;

namespace Lab2.Console;

using System;
using System.Collections.Generic;
using System.Linq;

public class ConsoleInterface : IConsoleInterface
{
    public void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Search task");
        Console.WriteLine("3. Last tasks");
        Console.WriteLine("4. Exit");
        Console.Write("> ");
    }

    public TaskItem AddTask()
    {
        Console.WriteLine("New task");
        Console.Write("Title: ");
        var title = Console.ReadLine();

        Console.Write("Description: ");
        var description = Console.ReadLine();

        Console.Write("Deadline: ");
        var deadline = Console.ReadLine();

        var tags = new List<string>();
        Console.WriteLine("Tags (finish on an empty line)");

        var tagIndex = 1;
        while (true)
        {
            Console.Write($"{tagIndex}: ");
            var tag = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tag))
                break;

            tags.Add(tag);
            tagIndex++;
        }

        return new TaskItem(title, description, deadline, tags);
    }

    public void SearchTasks(List<TaskItem> tasks)
    {
        Console.Write("Search tasks by tag: ");
        var searchTag = Console.ReadLine();

        var matchingTasks = tasks
            .Where(task => task.Tags.Contains(searchTag))
            .ToList();

        if (matchingTasks.Any())
        {
            Console.WriteLine("Matching tasks:");
            DisplayTasks(matchingTasks);
        }
        else
        {
            Console.WriteLine("No such tasks\n");
        }
    }

    public void DisplayLastTasks(List<TaskItem> tasks)
    {
        var actualTasks = tasks
            .OrderBy(task => task.Deadline)
            .ToList();

        Console.WriteLine("Actual tasks:");
        DisplayTasks(actualTasks);
    }

    public void DisplayTasks(List<TaskItem> tasksToDisplay)
    {
        var taskNumber = 1;
        foreach (var task in tasksToDisplay)
        {
            Console.WriteLine($"{taskNumber}. Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Deadline: {task.Deadline}");
            Console.WriteLine($"Tags: {string.Join(", ", task.Tags)}\n");

            taskNumber++;
        }
    } 
}