using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
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

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for AddSupplierWindow.xaml
    /// </summary>
    public partial class AddSupplierWindow : Window
    {
        public string BusinessName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public int PartnerID { get; private set; }
        public SupplierL Supplier { get; private set; }
        public bool IsEditMode { get; private set; }
        public bool DeleteSupplier { get; private set; }
        public bool isAdmin { get; private set; }
        private ObservableCollection<OrderSummary> supplyOrders { get; set; }

        public AddSupplierWindow()
        {
            BusinessName = "";
            PhoneNumber = "";
            StreetAddress = "";
            City = "";
            ZipCode = "";
            State = "";
            IsEditMode = false;
            InitializeComponent();
            DataContext = this;
        }

        public AddSupplierWindow(SupplierL supplier)
        {
            IsEditMode = true;
            isAdmin = MainWindow.IsAdmin;
            InitializeComponent();
            NameTextBox.Text = supplier.Name;
            BusinessPhoneTextBox.Text = supplier.PhoneNumber;
            StreetAddressTextBox.Text = supplier.StreetAddress;
            CityTextBox.Text = supplier.City;
            ZipTextBox.Text = supplier.ZipCode;
            StateTextBox.Text = supplier.State;
            PartnerIDTextBox.Text = supplier.PartnerID.ToString();
            DataContext = this;
            if (supplier.SupplyOrders != null)
            {
                supplyOrders = new ObservableCollection<OrderSummary>(supplier.SupplyOrders);
            }
            else
            {
                supplyOrders = new ObservableCollection<OrderSummary>();
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            BusinessName = NameTextBox.Text;
            PhoneNumber = BusinessPhoneTextBox.Text;
            StreetAddress = StreetAddressTextBox.Text;
            City = CityTextBox.Text;
            ZipCode = ZipTextBox.Text;
            State = StateTextBox.Text;
            if ((!int.TryParse(PartnerIDTextBox.Text, out int partnerID) || partnerID < 0) && !string.IsNullOrWhiteSpace(PartnerIDTextBox.Text))
            {
                MessageBox.Show($"Please enter a valid Partner ID", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            PartnerID = int.TryParse(PartnerIDTextBox.Text, out int pID) ? pID : -1;
            if (IsEditMode == true)
            {
                Supplier = new SupplierL
                {
                    Name = BusinessName,
                    PhoneNumber = PhoneNumber,
                    StreetAddress = StreetAddress,
                    City = City,
                    ZipCode = ZipCode,
                    State = State,
                    PartnerID = PartnerID,
                    SupplyOrders = supplyOrders
                };
            }
            DeleteSupplier = false;
            this.DialogResult = true;
        }

        private void DeleteSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteSupplier = true;
            this.DialogResult = true;
        }
    }
}
