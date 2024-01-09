using Lab3.Console;
using Lab3.ToDoList;

namespace Lab3;

class Program
{
    public static void Main()
    {
        IConsoleInterface consoleInterface = new ConsoleInterface();
        var dataStorage = new DataStorage.DataStorage();
        dataStorage.EnsureFilesAndDatabaseExist();
        var toDoList = new ToDoListService(consoleInterface, dataStorage);
        toDoList.Start();
    }
}