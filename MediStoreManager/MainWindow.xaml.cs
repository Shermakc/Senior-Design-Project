using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Patients PatientList { get; set; }
        private object _selectedPatient;
        public object SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public Suppliers SupplierList { get; set; }
        private object _selectedSupplier;
        public object SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                _selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }
        public Equipments EquipmentList { get; set; }
        public Parts PartList { get; set; }
        public Supplies SupplyList { get; set; }

        private object _selectedInventory;

        public object SelectedInventory
        {
            get => _selectedInventory;
            set
            {
                _selectedInventory = value;
                OnPropertyChanged(nameof(SelectedInventory));
            }
        }

        public WorkOrders WorkOrdersList { get; set; }
        public SupplyOrders SupplyOrdersList { get; set; }

        private object _selectedOrder;
        public object SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            WorkOrdersList = new WorkOrders();
            SupplyOrdersList = new SupplyOrders();
            EquipmentList = new Equipments();
            PartList = new Parts();
            SupplyList = new Supplies();
            PatientList = new Patients();
            SupplierList = new Suppliers();
            DataContext = this;

            /*try
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
            }*/
        }

        private void DataGrid_SelectionChanged()
        {
            
        }

        private void PatientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPatient = ((ListBox)sender).SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.Owner = this;
            addPatientWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow();
            addInventoryWindow.Owner = this;
            addInventoryWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow addSupplierWindow = new AddSupplierWindow();
            addSupplierWindow.Owner = this;
            addSupplierWindow.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CreateWorkOrder createWorkOrder = new CreateWorkOrder();
            createWorkOrder.Owner = this;
            createWorkOrder.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CreateSupplyOrder createSupplyOrder = new CreateSupplyOrder();
            createSupplyOrder.Owner = this;
            createSupplyOrder.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void WorkListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedOrder = ((ListBox)sender).SelectedItem;
        }

        private void SupplyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedOrder = ((ListBox)sender).SelectedItem;
        }

        private void EquipmentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedInventory = ((ListBox)sender).SelectedItem;
        }

        private void SuppliesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedInventory = ((ListBox)sender).SelectedItem;
        }

        private void PartsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedInventory = ((ListBox)sender).SelectedItem;
        }

        private void SupplierListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSupplier = ((ListBox)sender).SelectedItem;
        }
    }
}