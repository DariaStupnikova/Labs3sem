using System.Runtime.Serialization;

namespace Lab3.Task;

[Serializable]
public class TaskItem
{
    public TaskItem()
    {
    }

    public TaskItem(string title, string description, DateTime deadline, List<string> tags)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Tags = tags;
    }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public DateTime Deadline { get; set; }

    [DataMember]
    public List<string> Tags { get; set; }
}
