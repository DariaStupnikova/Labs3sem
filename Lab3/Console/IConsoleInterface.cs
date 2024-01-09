using Lab3.Task;

namespace Lab3.Console;

public interface IConsoleInterface
{
    void ShowMenu();
    TaskItem AddTask();
    void SearchTasks(List<TaskItem> tasks);
    void DisplayLastTasks(List<TaskItem> tasks);
    void DisplayTasks(List<TaskItem> tasksToDisplay);
}