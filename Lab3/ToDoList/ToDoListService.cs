using Lab3.Console;
using Lab3.Task;

namespace Lab3.ToDoList;

public class ToDoListService
{
    private List<TaskItem> tasks;
    private readonly IConsoleInterface consoleInterface;
    private readonly DataStorage.DataStorage dataStorage;

    public ToDoListService(IConsoleInterface consoleInterface, DataStorage.DataStorage dataStorage)
    {
        this.tasks = new List<TaskItem>();
        this.consoleInterface = consoleInterface;
        this.dataStorage = dataStorage;
    }

    public void Start()
    {
        while (true)
        {
            consoleInterface.ShowMenu();
            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    SearchTasks();
                    break;
                case "3":
                    DisplayLastTasks();
                    break;
                case "4":
                    SaveOrLoadDataMenu();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void AddTask()
    {
        TaskItem newTask = consoleInterface.AddTask();
        tasks.Add(newTask);
        System.Console.WriteLine("Task added successfully.\n");
    }

    private void SearchTasks()
    {
        consoleInterface.SearchTasks(tasks);
    }

    private void DisplayLastTasks()
    {
        consoleInterface.DisplayLastTasks(tasks);
    }

    private void SaveOrLoadDataMenu()
    {
        System.Console.WriteLine("Save or Load Data Menu:");
        System.Console.WriteLine("1. Save to JSON");
        System.Console.WriteLine("2. Load from JSON");
        System.Console.WriteLine("3. Save to XML");
        System.Console.WriteLine("4. Load from XML");
        System.Console.WriteLine("5. Save to SQLite");
        System.Console.WriteLine("6. Load from SQLite");
        System.Console.WriteLine("7. Back to main menu");
        System.Console.Write("> ");

        string choice = System.Console.ReadLine();

        switch (choice)
        {
            case "1":
                dataStorage.SaveToJSON(tasks);
                System.Console.WriteLine("Data saved to JSON.");
                break;
            case "2":
                tasks = dataStorage.LoadFromJSON();
                System.Console.WriteLine("Data loaded from JSON.");
                break;
            case "3":
                dataStorage.SaveToXML(tasks);
                System.Console.WriteLine("Data saved to XML.");
                break;
            case "4":
                tasks = dataStorage.LoadFromXML();
                System.Console.WriteLine("Data loaded from XML.");
                break;
            case "5":
                dataStorage.SaveToSQLite(tasks);
                System.Console.WriteLine("Data saved to SQLite.");
                break;
            case "6":
                tasks = dataStorage.LoadFromSQLite();
                System.Console.WriteLine("Data loaded from SQLite.");
                break;
            case "7":
                break;
            default:
                System.Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}