using System;
using System.Windows;
using Lab5.Models;

namespace Lab5
{
    public partial class EditTaskDialog : Window
    {
        public EditTaskViewModel ViewModel { get; private set; }

        public EditTaskDialog(EditTaskViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        public void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}