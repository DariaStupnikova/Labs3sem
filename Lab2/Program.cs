
using Lab2.Console;
using Lab2.Task;
using Lab2.ToDoList;

namespace Lab2;

public static class Program
{
    public static void Main()
    {
        var toDoListService =
            new ToDoListService(new ToDoList.ToDoList(new List<TaskItem>()), new ConsoleInterface());
        
        toDoListService.Start();
    }
}