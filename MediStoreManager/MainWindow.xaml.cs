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
        }

        private void DataGrid_SelectionChanged()
        {

        }

        private void PatientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}