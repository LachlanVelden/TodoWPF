using System;
using System.Collections.Generic;
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
    /// Interaction logic for TaskListItem.xaml
    /// </summary>
    public partial class TaskListItem : ListBoxItem
    {
        private string _text;
        public string Text {
            get
            {
                return _text ?? this.TaskLabel.Content as string;
            }
            set
            {
                if(this.TaskLabel != null)
                {
                    this.TaskLabel.Content = value;
                    this._text = null;
                }
                this._text = value;
            }
        }
        public event EventHandler OnDeleteClicked;
        public event EventHandler OnEditClicked;
        public TaskListItem(string text)
        {
            InitializeComponent();
            this.Text = text;

            this.DeleteButton.Click += DeleteButton_Click;
            this.EditButton.Click += EditButton_Click;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnEditClicked?.Invoke(this, e);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnDeleteClicked?.Invoke(this, e);
        }
    }
}
