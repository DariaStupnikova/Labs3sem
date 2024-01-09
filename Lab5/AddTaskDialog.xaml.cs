using System.Windows;

namespace Lab5
{
    public partial class AddTaskDialog : Window
    {
        public AddTaskViewModel ViewModel { get; private set; }

        public AddTaskDialog()
        {
            InitializeComponent();
            ViewModel = new AddTaskViewModel();
            DataContext = ViewModel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}