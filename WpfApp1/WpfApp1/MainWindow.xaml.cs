using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<TaskListItem> Tasks { get; set; }

        public TaskListItem CurrentlyEditing { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskListItem>();

            this.ListItems.ItemsSource = Tasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentlyEditing != null)
            {
                CurrentlyEditing.Text = TaskValueTextBox.Text;
                CurrentlyEditing = null;
                AddTaskButton.Content = "Add Task";
            }
            else
            {

                var taskItem = new TaskListItem(TaskValueTextBox.Text);

                taskItem.OnEditClicked += (sender1, e1) =>
                {
                    StartEdit(sender1 as TaskListItem);

                };

                taskItem.OnDeleteClicked += (sender1, e1) =>
                {
                    Tasks.Remove(sender1 as TaskListItem);
                };

                Tasks.Add(taskItem);
                //this.ListItems.ItemsSource = Tasks;
            }

            TaskValueTextBox.Text = "";
        }


        private void StartEdit(TaskListItem item)
        {
            CurrentlyEditing = item;
            AddTaskButton.Content = "Edit Task";
            TaskValueTextBox.Text = item.Text;
        }

        private void ListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListItems.SelectedItems.Count > 0)
            {
                var selected = ListItems.SelectedItems[0] as TaskListItem;
                StartEdit(selected);
            }
        }
    }
}
