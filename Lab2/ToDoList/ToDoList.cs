using Lab2.Task;

namespace Lab2.ToDoList;

public class ToDoList
{
    public ToDoList(List<TaskItem> taskItems)
    {
        Tasks = taskItems;
    }
    public List<TaskItem> Tasks { get; private set; }
}