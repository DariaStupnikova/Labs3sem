using Lab3.Task;

namespace Lab3.ToDoList;

public class ToDoList
{
    public ToDoList(List<TaskItem> taskItems)
    {
        Tasks = taskItems;
    }
    public List<TaskItem> Tasks { get; private set; }
}