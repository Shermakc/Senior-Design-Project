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
using MySql.Data.MySqlClient;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> personList;
        List inventoryList;
        List supplierList;

        string connString = "server=localhost;uid=root;pwd=Enough@99;database=medistore manager"; // Don't leave this as plain text

        public MainWindow()
        {
            InitializeComponent();
            personList = new List<Person>();
            inventoryList = new List();
            supplierList = new List();

            try
            {
                MySqlConnection con = OpenMySQLConnection();
                GetPersonList(con);
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

        private Person GetPerson(MySqlDataReader reader)
        {
            Person tempPerson = new Person();
            tempPerson.ID = GetColValAsUInt(reader, nameof(tempPerson.ID));
            tempPerson.FirstName = GetColValAsString(reader, nameof(tempPerson.FirstName));
            tempPerson.LastName = GetColValAsString(reader, nameof(tempPerson.LastName));
            tempPerson.MiddleName = GetColValAsString(reader, nameof(tempPerson.MiddleName));
            tempPerson.HomePhone = GetColValAsDecimal(reader, nameof(tempPerson.HomePhone));
            tempPerson.CellPhone = GetColValAsDecimal(reader, nameof(tempPerson.CellPhone));
            tempPerson.AddressID = GetColValAsUInt(reader, nameof(tempPerson.AddressID));
            tempPerson.InsuranceProvider = GetColValAsString(reader, nameof(tempPerson.InsuranceProvider));
            tempPerson.IsPatientContact = reader.GetBoolean(8);
            tempPerson.ContactID = GetColValAsUInt(reader, nameof(tempPerson.ContactID));
            tempPerson.ContactRelationship = GetColValAsString(reader, nameof(tempPerson.ContactRelationship));

            return tempPerson;
        }

        private string GetColValAsString(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return string.Empty;
            else
                return reader[colName].ToString();
        }

        private uint GetColValAsUInt(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return 0;
            else
                return (uint)reader[colName];
        }

        private decimal GetColValAsDecimal(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return 0;
            else
                return (decimal)reader[colName];
        }

        private DateTime GetColValAsDateTime(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return DateTime.MinValue;
            else
                return (DateTime)reader[colName];
        }

        private MySqlConnection OpenMySQLConnection()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connString;
            con.Open();
            return con;
        }

        private void GetPersonList(MySqlConnection con)
        {
            string sql = "select * from person;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }        
    }
}