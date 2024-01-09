using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Lab3.Task;

namespace Lab5.Models
{
    public class EditTaskViewModel : INotifyPropertyChanged
    {
        private TaskItem _editedTask;

        public TaskItem EditedTask
        {
            get { return _editedTask; }
            set
            {
                if (_editedTask != value)
                {
                    _editedTask = value;
                    OnPropertyChanged(nameof(EditedTask));
                }
            }
        }

        public EditTaskViewModel(TaskItem task)
        {
            EditedTask = new TaskItem
            {
                Title = task.Title,
                Description = task.Description,
                Deadline = task.Deadline,
                Tags = new List<string>(task.Tags)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
