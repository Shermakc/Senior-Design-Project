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

        private List<Person> persons = new List<Person>();
        private List<Address> addresses = new List<Address>();
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<Supplier> suppliers = new List<Supplier>();
        private List<User> users = new List<User>();
        private List<Order> orders = new List<Order>();
        private List<CustomerOrder> customerOrders = new List<CustomerOrder>();

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

            try
            {
                RetrievePersons();
                RetrieveAddresses();
                RetrieveSuppliers();
                RetrieveInventoryItems();
                RetrieveOrders();
                RetrieveCustomerOrders();
                RetrieveUsers();

                PopulatePatientList();
                PopulateSupplierList();
                PopulateEquipmentList();
                PopulateSupplyList();
                PopulatePartList();
                PopulateWorkOrderList();
                PopulateSupplyOrderList();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PatientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPatient = ((ListBox)sender).SelectedItem;
        }

        private void Button_AddPatient(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.Owner = this;
            bool? result = addPatientWindow.ShowDialog();

            if (result == true)
            {
                string firstName = addPatientWindow.FirstName;
                string middleName = addPatientWindow.MiddleName;
                string lastName = addPatientWindow.LastName;
                string homePhone = addPatientWindow.HomePhone;
                string cellPhone = addPatientWindow.CellPhone;
                string streetAddress = addPatientWindow.StreetAddress;
                string city = addPatientWindow.City;
                string state = addPatientWindow.State;
                string zipCode = addPatientWindow.ZipCode;
                string insurance = addPatientWindow.InsuranceProvider;

                // Simply for debugging purposes. Not intended to remain after everything is fully setup
                MessageBox.Show($"User Entered:\nFirst Name = {firstName}\nMiddle Name = {middleName}\nLast Name = {lastName}\nHome Phone # = {homePhone}\nCell Phone # = {cellPhone}\n" +
                    $"Street Address = {streetAddress}\nCity = {city}\nState = {state}\nZip Code = {zipCode}\nInsurance = {insurance}");
            }
        }

        private void Button_AddInventory(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow();
            addInventoryWindow.Owner = this;
            bool? result = addInventoryWindow.ShowDialog();
            if (result == true)
            {
                string inventoryName = addInventoryWindow.InventoryName;
                string type = addInventoryWindow.Type;
                string size = addInventoryWindow.Size;
                string brand = addInventoryWindow.Brand;
                string quantity = addInventoryWindow.Quantity;
                string price = addInventoryWindow.Price;
                string retailPrice = addInventoryWindow.RetailPrice;
                string rentalPrice = addInventoryWindow.RentalPrice;

                // Simply for debugging purposes. Not intended to remain after everything is fully setup
                MessageBox.Show($"User Entered:\nInventory Name = {inventoryName}\nInventory Type = {type}\nSize = {size}\nBrand = {brand}\n" +
                    $"Quantity = {quantity}\nPrice = {price}\nRetail Price = {retailPrice}\nRental Price = {rentalPrice}");
            }
        }

        private void Button_AddSupplier(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow addSupplierWindow = new AddSupplierWindow();
            addSupplierWindow.Owner = this;
            bool? result = addSupplierWindow.ShowDialog();
            if (result == true)
            {
                string businessName = addSupplierWindow.BusinessName;
                string businessPhone = addSupplierWindow.PhoneNumber;
                string streetAddress = addSupplierWindow.StreetAddress;
                string city = addSupplierWindow.City;
                string state = addSupplierWindow.State;
                string zipCode = addSupplierWindow.ZipCode;

                // Simply for debugging purposes. Not intended to remain after everything is fully setup
                MessageBox.Show($"User Entered:\nName = {businessName}\nBusiness Phone # = {businessPhone}\n" +
                    $"Street Address = {streetAddress}\nCity = {city}\nState = {state}\nZip Code = {zipCode}");
            }
        }

        private void Button_CreateWorkOrder(object sender, RoutedEventArgs e)
        {
            CreateWorkOrder createWorkOrder = new CreateWorkOrder();
            createWorkOrder.Owner = this;
            bool? result = createWorkOrder.ShowDialog();
            if (result == true)
            {
                string type = createWorkOrder.Type;
                string patientID = createWorkOrder.PatientID;
                string quantity = createWorkOrder.Quantity;
                string inventoryID = createWorkOrder.InventoryID;
                DateTime orderDate = createWorkOrder.OrderDate;
                DateTime dateOfPayment = createWorkOrder.DateOfPayment;
                string relatedInventoryID = createWorkOrder.RelatedInventoryID;
                string notes = createWorkOrder.Notes;

                // Simply for debugging purposes. Not intended to remain after everything is fully setup
                MessageBox.Show($"User Entered:\nType = {type}\nPatient ID = {patientID}\nQuantity = {quantity}\nInventory ID = {inventoryID}\n" +
                    $"Date = {orderDate.Date.ToShortDateString()}\nDate of Payment = {dateOfPayment.Date.ToShortDateString()}\nRelated Inventory ID = {relatedInventoryID}\nNotes = {notes}");
            }
        }

        private void Button_CreateSupplyOrder(object sender, RoutedEventArgs e)
        {
            CreateSupplyOrder createSupplyOrder = new CreateSupplyOrder();
            createSupplyOrder.Owner = this;
            bool? result = createSupplyOrder.ShowDialog();
            if (result == true)
            {
                string inventoryID = createSupplyOrder.InventoryID;
                string quantity = createSupplyOrder.Quantity;
                string suppplier = createSupplyOrder.Supplier;
                string shippingMethod = createSupplyOrder.ShippingMethod;
                DateTime orderDate = createSupplyOrder.OrderDate;
                DateTime receivedDate = createSupplyOrder.ReceivedDate;

                // Simply for debugging purposes. Not intended to remain after everything is fully setup
                MessageBox.Show($"User Entered:\nInventory ID = {inventoryID}\nQuantity = {quantity}\nSupplier = {suppplier}\nShipping Method = {shippingMethod}\n" +
                    $"Order Date = {orderDate.Date.ToShortDateString()}\nReceived Date = {receivedDate.Date.ToShortDateString()}");
            }
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

        #region Data Functions
        private void RetrieveAddresses()
        {
            addresses.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            addresses = DatabaseFunctions.GetAddressList(con);
            con.Close();
        }

        private void RetrievePersons()
        {
            persons.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            persons = DatabaseFunctions.GetPersonList(con);
            con.Close();
        }

        private void RetrieveUsers()
        {
            users.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            users = DatabaseFunctions.GetUserList(con);
            con.Close();
        }

        private void RetrieveSuppliers()
        {
            suppliers.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            suppliers = DatabaseFunctions.GetSupplierList(con);
            con.Close();
        }

        private void RetrieveInventoryItems()
        {
            inventoryItems.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            inventoryItems = DatabaseFunctions.GetInventoryList(con);
            con.Close();
        }

        private void RetrieveOrders()
        {
            orders.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            orders = DatabaseFunctions.GetOrderList(con);
            con.Close();
        }

        private void RetrieveCustomerOrders()
        {
            customerOrders.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            customerOrders = DatabaseFunctions.GetCustomerOrderList(con);
            con.Close();
        }

        private void PopulatePatientList()
        {
            foreach (Person person in persons)
            {
                PatientList.AddPatient(person, addresses.Where(a => a.ID == person.AddressID).FirstOrDefault());
            }
        }

        private void PopulateSupplierList()
        {
            foreach (Supplier supplier in suppliers)
            {
                SupplierList.AddSupplier(supplier, addresses.Where(a => a.ID == supplier.AddressID).FirstOrDefault());
            }
        }

        private void PopulateEquipmentList()
        {
            List<InventoryItem> equipmentItems = inventoryItems.Where(i => i.Type == "equipment").ToList();
            foreach (InventoryItem item in equipmentItems)
            {
                EquipmentList.AddEquipment(item);
            }
        }

        private void PopulateSupplyList()
        {
            List<InventoryItem> supplyItems = inventoryItems.Where(i => i.Type == "supply").ToList();
            foreach (InventoryItem item in supplyItems)
            {
                SupplyList.AddSupply(item);
            }
        }

        private void PopulatePartList()
        {
            List<InventoryItem> partItems = inventoryItems.Where(i => i.Type == "part").ToList();
            foreach (InventoryItem item in partItems)
            {
                PartList.AddPart(item);
            }
        }

        private void PopulateSupplyOrderList()
        {
            foreach (Order order in orders)
            {
                SupplyOrdersList.AddSupplyOrder(order);
            }
        }

        private void PopulateWorkOrderList()
        {
            foreach (CustomerOrder order in customerOrders)
            {
                WorkOrdersList.AddWorkOrder(order);
            }
        }

        //private void ConvertPatientToAddressAndPerson(Patient patient)
        //{
        //    (string, string) patientAddress = SplitAddress(patient.StreetAddress);
        //    Address newAddress = new Address()
        //    {
        //        ID = addresses.Max(a => a.ID) + 1,
        //        StreetName = patientAddress.Item2,
        //        AddressNumber = Convert.ToInt16(patientAddress.Item1),
        //        City = patient.City,
        //        State = patient.State,
        //        ZipCode = Convert.ToUInt16(patient.ZipCode)
        //    };

        //    Person newPerson = new Person()
        //    {
        //        ID = persons.Max(p => p.ID) + 1,
        //        FirstName = patient.FirstName,
        //        LastName = patient.LastName,
        //        MiddleName = patient.MiddleName,
        //        HomePhone = Convert.ToInt16(patient.HomePhone),
        //        CellPhone = Convert.ToInt16(patient.CellPhone),
        //        AddressID = newAddress.ID,
        //        InsuranceProvider = ,
        //        IsPatientContact = ,
        //        ContactID = ,
        //        ContactRelationship =

        //    };
        //}
        #endregion

        public (string, string) SplitAddress(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return (string.Empty, string.Empty);

            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex == -1)
                return (input, string.Empty); // No space found, return full string as first part.

            string addressNum = input.Substring(0, spaceIndex);
            string streetName = input.Substring(spaceIndex + 1);

            return (addressNum, streetName);
        }
    }
}