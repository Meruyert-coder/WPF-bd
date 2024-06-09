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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ListExample.xaml
    /// </summary>
    public partial class ListExample : Window
    {
        ListView listView = new ListView();
        public ListExample()
        {
            InitializeComponent();

            listView.Items.Add("pen");
            listView.Items.Add("apple");
            listView.Items.Add("computer");
            listView.Items.Add("banana");
            listView.Items.Add("phone");
            listView.Items.Add("dog");

            listView.MouseDoubleClick += List_Click;

            this.Content = listView;
        }
        private void List_Click(object sender, RoutedEventArgs e)
        {
            var selectedItemText = (listView.SelectedItem ?? "(none)").ToString();
            MessageBox.Show("Selected: " + selectedItemText);
        }
    }
}
