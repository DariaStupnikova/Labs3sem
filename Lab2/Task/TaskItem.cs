namespace Lab2.Task;

public class TaskItem
{
    public TaskItem(string title, string description, string deadline, List<string> tags)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Tags = tags;
    }

    public TaskItem()
    {
        throw new NotImplementedException();
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Deadline { get; private set; }

    public List<string> Tags { get; private set; }
}