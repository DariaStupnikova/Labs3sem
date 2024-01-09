using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Lab3.Task;

public class AddTaskViewModel : INotifyPropertyChanged
{
    private TaskItem _newTask;
    private string _tagsString;

    public TaskItem NewTask
    {
        get { return _newTask; }
        set
        {
            if (_newTask != value)
            {
                _newTask = value;
                OnPropertyChanged(nameof(NewTask));
            }
        }
    }

    public string TagsString
    {
        get { return _tagsString; }
        set
        {
            if (_tagsString != value)
            {
                _tagsString = value;
                OnPropertyChanged(nameof(TagsString));
                NewTask.Tags = new List<string>(_tagsString.Split(',').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag)).ToList());
            }
        }
    }

    public AddTaskViewModel()
    {
        NewTask = new TaskItem();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}