using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using MySql.Data.MySqlClient;
using MediStoreManager;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.GetPersonList(con);                
                con.Close();

                con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.GetAddressList(con);
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataGrid_SelectionChanged()
        {
            
        }

        private void PatientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}