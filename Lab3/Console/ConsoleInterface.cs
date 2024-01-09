using Lab3.Task;

namespace Lab3.Console;

public class ConsoleInterface : IConsoleInterface
{
    public void ShowMenu()
    {
        System.Console.WriteLine("Menu:");
        System.Console.WriteLine("1. Add task");
        System.Console.WriteLine("2. Search task");
        System.Console.WriteLine("3. Last tasks");
        System.Console.WriteLine("4. Save or Load Data");
        System.Console.WriteLine("5. Exit");
        System.Console.Write("> ");
    }

    public TaskItem AddTask()
    {
        System.Console.WriteLine("New task");
        System.Console.Write("Title: ");
        string title = System.Console.ReadLine();

        System.Console.Write("Description: ");
        string description = System.Console.ReadLine();

        System.Console.Write("Deadline: ");
        DateTime deadline;
        while (!DateTime.TryParse(System.Console.ReadLine(), out deadline))
        {
            System.Console.WriteLine("Invalid date format. Please enter the date again (e.g., 10.11.2022): ");
        }

        List<string> tags = new List<string>();
        System.Console.WriteLine("Tags (finish on empty line)");

        int tagIndex = 1;
        while (true)
        {
            System.Console.Write($"{tagIndex}: ");
            string tag = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tag))
                break;

            tags.Add(tag);
            tagIndex++;
        }

        return new TaskItem(title, description, deadline, tags);
    }

    public void SearchTasks(List<TaskItem> tasks)
    {
        System.Console.Write("Search tasks by tag: ");
        string searchTag = System.Console.ReadLine();

        var matchingTasks = tasks
            .Where(task => task.Tags.Contains(searchTag))
            .ToList();

        if (matchingTasks.Any())
        {
            System.Console.WriteLine("Matching tasks:");
            DisplayTasks(matchingTasks);
        }
        else
        {
            System.Console.WriteLine("No such tasks\n");
        }
    }

    public void DisplayLastTasks(List<TaskItem> tasks)
    {
        var actualTasks = tasks
            .OrderBy(task => task.Deadline)
            .ToList();

        System.Console.WriteLine("Actual tasks:");
        DisplayTasks(actualTasks);
    }

    public void DisplayTasks(List<TaskItem> tasksToDisplay)
    {
        int taskNumber = 1;
        foreach (var task in tasksToDisplay)
        {
            System.Console.WriteLine($"{taskNumber}. Title: {task.Title}");
            System.Console.WriteLine($"Description: {task.Description}");
            System.Console.WriteLine($"Deadline: {task.Deadline.ToShortDateString()}");
            System.Console.WriteLine($"Tags: {string.Join(", ", task.Tags)}\n");

            taskNumber++;
        }
    }
}