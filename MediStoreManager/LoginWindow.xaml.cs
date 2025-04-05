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
using MySql.Data.MySqlClient;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string[] adminRoles = new string[] { "developer", "manager" };
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (MySqlConnection conn = new MySqlConnection(DatabaseFunctions.connString))
            {
                conn.Open();
                string query = "SELECT Position FROM user WHERE Username = @username AND BINARY Password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string position = result.ToString();
                        bool isAdmin = false;
                        if (adminRoles.Any(p => p.Equals(position, StringComparison.OrdinalIgnoreCase))) {
                            isAdmin = true;
                        }
                        // Successful login
                        MainWindow main = new MainWindow(isAdmin);
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorTextBlock.Text = "Invalid credentials.";
                    }
                }
            }
        }
    }
}
