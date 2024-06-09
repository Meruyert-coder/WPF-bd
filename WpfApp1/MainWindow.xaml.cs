using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString = @"Data Source=DESKTOP-HN5TR1Q\SQLEXPRESS; Initial Catalog=db;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signIn(object sender, RoutedEventArgs e)
        {
            string log = login.Text;
            string pas = pass.Text;
            string query = $"SELECT * FROM test WHERE loginn LIKE '{log}' AND passwordd LIKE '{pas}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("ok");
                        login.Text = "";
                        pass.Text = "";
                    }
                    else
                        MessageBox.Show("not ok");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void signUp(object sender, RoutedEventArgs e)
        {
            string log = newLogin.Text;
            string pas = newPass.Text;
            string query = $"INSERT INTO test VALUES ('{log}', '{pas}')";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("ok");
                }
                newLogin.Text = "";
                newPass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
