using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Lab3;
using Lab3.DataStorage;
using Lab3.Task;
using Lab5.Models;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        private DataStorage _dataStorage = new DataStorage();
        private ObservableCollection<TaskItem> _taskItems;

        public MainWindow()
        {
            InitializeComponent();
            _taskItems = new ObservableCollection<TaskItem>(_dataStorage.LoadFromSQLite());
            taskListView.ItemsSource = _taskItems; // Basicly loading from sqlite
        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskListView.SelectedItem != null)
            {
                TaskItem selectedTask = (TaskItem)taskListView.SelectedItem;
                EditTaskDialog editDialog = new EditTaskDialog(new EditTaskViewModel(selectedTask));

                if (editDialog.ShowDialog() == true)
                {
                    selectedTask.Title = editDialog.ViewModel.EditedTask.Title;
                    selectedTask.Description = editDialog.ViewModel.EditedTask.Description;
                    selectedTask.Deadline = editDialog.ViewModel.EditedTask.Deadline;
                    selectedTask.Tags = new List<string>(editDialog.ViewModel.EditedTask.Tags);

                    taskListView.Items.Refresh();
                }
            }
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDialog addTaskDialog = new AddTaskDialog();
            if (addTaskDialog.ShowDialog() == true)
            {
                _taskItems.Add(addTaskDialog.ViewModel.NewTask);
                taskListView.Items.Refresh();
            }
        }

        private void TaskListView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem editMenuItem = new MenuItem { Header = "Edit Task" };
            editMenuItem.Click += EditMenuItem_Click;
            contextMenu.Items.Add(editMenuItem);

            MenuItem addMenuItem = new MenuItem { Header = "Add New Task" };
            addMenuItem.Click += AddMenuItem_Click;
            contextMenu.Items.Add(addMenuItem);

            taskListView.ContextMenu = contextMenu;
        }

        private void ExpandIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image expandIcon = (Image)sender;
            ListViewItem item = FindAncestor<ListViewItem>(expandIcon);
            if (item != null)
            {
                item.IsSelected = true;
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }
    }
}
