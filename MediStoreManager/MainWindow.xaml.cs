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
using System.Collections.ObjectModel;
using Org.BouncyCastle.Utilities;

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

        public object CurrentItem
        {
            get
            {
                return SelectedInventoryTabIndex == 0 ? SelectedEquipment :
                       SelectedInventoryTabIndex == 1 ? SelectedSupply : 
                       SelectedInventoryTabIndex == 2 ? SelectedPart : null;
            }
        }

        private int _selectedInventoryTabIndex;
        public int SelectedInventoryTabIndex
        {
            get => _selectedInventoryTabIndex;
            set
            {
                _selectedInventoryTabIndex = value;
                OnPropertyChanged(nameof(SelectedInventoryTabIndex));
                OnPropertyChanged(nameof(CurrentItem)); // Update the display when the tab changes
            }
        }

        private object _selectedEquipment;
        public object SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged(nameof(SelectedEquipment));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        private object _selectedSupply;
        public object SelectedSupply
        {
            get => _selectedSupply;
            set
            {
                _selectedSupply = value;
                OnPropertyChanged(nameof(SelectedSupply));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }
        private object _selectedPart;

        public object SelectedPart
        {
            get => _selectedPart;
            set
            {
                _selectedPart = value;
                OnPropertyChanged(nameof(SelectedPart));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public WorkOrders WorkOrdersList { get; set; }
        public SupplyOrders SupplyOrdersList { get; set; }

        public object CurrentOrder
        {
            get
            {
                return SelectedOrderTabIndex == 0 ? SelectedWorkOrder :
                       SelectedOrderTabIndex == 1 ? SelectedSupplyOrder : null;
            }
        }

        private int _selectedOrderTabIndex;
        public int SelectedOrderTabIndex
        {
            get => _selectedOrderTabIndex;
            set
            {
                _selectedOrderTabIndex = value;
                OnPropertyChanged(nameof(SelectedOrderTabIndex));
                OnPropertyChanged(nameof(CurrentOrder)); // Update the display when the tab changes
            }
        }

        private object _selectedWorkOrder;
        public object SelectedWorkOrder
        {
            get => _selectedWorkOrder;
            set
            {
                _selectedWorkOrder = value;
                OnPropertyChanged(nameof(SelectedWorkOrder));
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        private object _selectedSupplyOrder;
        public object SelectedSupplyOrder
        {
            get => _selectedSupplyOrder;
            set
            {
                _selectedSupplyOrder = value;
                OnPropertyChanged(nameof(SelectedSupplyOrder));
                OnPropertyChanged(nameof(CurrentOrder));
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
                bool isPatient = true;
                ObservableCollection<Patient> contacts = addPatientWindow.FinalContacts;

                // Create new database class items with info from popup
                (string, string) patientAddress = SplitAddress(streetAddress);

                Address newAddress = new Address(addresses.Max(a => a.ID) + 1, patientAddress.Item2, patientAddress.Item1,
                    city, state, zipCode);

                Person newPerson = new Person(persons.Max(p => p.ID) + 1, firstName, lastName, middleName, homePhone, cellPhone,
                    newAddress.ID, insurance, isPatient);

                // Insert new items into the database
                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreateAddressEntry(con, newAddress);
                con.Close();

                con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreatePersonEntry(con, newPerson);
                con.Close();

                // Add patient to user interface
                PatientList.AddPatient(newPerson, newAddress);
                addresses.Add(newAddress);
                persons.Add(newPerson);
            }
        }

        private void Button_EditPatient(object sender, RoutedEventArgs e)
        {
            var selectedEntry = PatientListBox.SelectedItem as Patient;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a patient to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddPatientWindow editPatientWindow = new AddPatientWindow(selectedEntry, true);
            editPatientWindow.Owner = this;
            bool? result = editPatientWindow.ShowDialog();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            if (result == true)
            {
                if (editPatientWindow.DeletePatient == true)
                {
                    int index = PatientListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        
                        DatabaseFunctions.DeletePersonEntry(con, PatientList[index].ID);
                        con.Close();

                        PatientList.RemoveAt(index);
                        persons.Remove(persons.Where(p => p.ID == PatientList[index].ID).FirstOrDefault());
                    }
                }
                else
                {
                    int index = PatientListBox.SelectedIndex;
                    if (index >= 0 && editPatientWindow.Patient != null)
                    {                        
                        Person originalPerson = persons.Where(p => p.ID == editPatientWindow.Patient.ID).FirstOrDefault();
                        uint addressID = originalPerson.AddressID;

                        // Create new address if it was edited
                        if (PatientList[index].StreetAddress != editPatientWindow.Patient.StreetAddress 
                            || PatientList[index].City != editPatientWindow.Patient.City
                            || PatientList[index].State != editPatientWindow.Patient.State
                            || PatientList[index].ZipCode != editPatientWindow.Patient.ZipCode)
                        {
                            addressID = CreateAddressEntry(editPatientWindow.Patient);
                        }

                        // Create a person to use in the update function
                        Person editPerson = new Person()
                        {
                            ID = editPatientWindow.Patient.ID,
                            FirstName = editPatientWindow.FirstName,
                            LastName = editPatientWindow.LastName,
                            MiddleName = editPatientWindow.MiddleName,
                            HomePhone = Convert.ToDecimal(editPatientWindow.HomePhone),
                            CellPhone = Convert.ToDecimal(editPatientWindow.CellPhone),
                            AddressID = addressID,
                            InsuranceProvider = editPatientWindow.InsuranceProvider,
                            IsPatient = originalPerson.IsPatient,
                            ContactID = originalPerson.ContactID,
                            ContactRelationship = originalPerson.ContactRelationship
                        };

                        con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.UpdatePersonEntry(con, editPerson);
                        con.Close();

                        // Add person entries for new contacts
                        if (editPatientWindow.Patient.Contacts.Any())
                        {
                            foreach (Patient contact in editPatientWindow.Patient.Contacts)
                            {
                                // Add new person for contact if they don't already exist
                                if (!PatientList.Any(p => p.ID == contact.ID))
                                {
                                    // Create address entry for the contact
                                    uint contactAddID = CreateAddressEntry(contact);
                                    // Create person entry for the contact
                                    Person contactPerson = new Person()
                                    {
                                        ID = contact.ID,
                                        FirstName = contact.FirstName,
                                        LastName = contact.LastName,
                                        MiddleName = contact.MiddleName,
                                        HomePhone = Convert.ToDecimal(contact.HomePhone),
                                        CellPhone = Convert.ToDecimal(contact.CellPhone),
                                        AddressID = contactAddID,
                                        InsuranceProvider = contact.Insurance,
                                        IsPatient = false,
                                        ContactID = editPerson.ID
                                        //ContactRelationship = contact.Relationsip
                                    };

                                    con = DatabaseFunctions.OpenMySQLConnection();
                                    DatabaseFunctions.UpdatePersonEntry(con, contactPerson);
                                    con.Close();
                                }                            
                            }

                        PatientList[index] = editPatientWindow.Patient;
                        //persons.ElementAt(index) = editPerson;
                        }                        
                    }
                }
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
                int quantity = addInventoryWindow.Quantity;
                string price = addInventoryWindow.Price;
                string retailPrice = addInventoryWindow.RetailPrice;
                string rentalPrice = addInventoryWindow.RentalPrice;
                bool isRental = rentalPrice != string.Empty;
                string serialNumber = addInventoryWindow.SerialNumber;

                InventoryItem newItem = new InventoryItem(inventoryItems.Max(i => i.ID) + 1, inventoryName, type, size, brand,
                    quantity, price, retailPrice, isRental, rentalPrice, serialNumber);

                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreateInventoryItemEntry(con, newItem);
                con.Close();

                // Add to interface based on type
                switch (newItem.Type)
                {
                    case "equipment":
                        EquipmentList.AddEquipment(newItem);                    
                        break;
                    case "supply":
                        SupplyList.AddSupply(newItem);
                        break;
                    case "part":
                        PartList.AddPart(newItem);
                        break;
                }
                inventoryItems.Add(newItem);
            }
        }

        private void Button_EditEquipment(object sender, RoutedEventArgs e)
        {
            var selectedEntry = EquipmentListBox.SelectedItem as Equipment;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select an equipment to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddInventoryWindow editInventoryWindow = new AddInventoryWindow(selectedEntry, null, null, true);
            editInventoryWindow.Owner = this;
            bool? result = editInventoryWindow.ShowDialog();
            if (result == true)
            {
                if (editInventoryWindow.DeleteItem == true)
                {
                    int index = EquipmentListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, EquipmentList[index].ID);
                        con.Close();

                        EquipmentList.RemoveAt(index);
                        inventoryItems.Remove(inventoryItems.Where(i => i.ID == EquipmentList[index].ID).FirstOrDefault());
                    }
                }
                else
                {
                    int index = EquipmentListBox.SelectedIndex;
                    if (index >= 0 && editInventoryWindow.Equipment != null)
                    {
                        EquipmentList[index] = editInventoryWindow.Equipment;
                    }
                    else if (editInventoryWindow.Supply != null)
                    {
                        EquipmentList.RemoveAt(index);
                        SupplyList.Add(editInventoryWindow.Supply);
                    }
                    else if (editInventoryWindow.Part != null)
                    {
                        EquipmentList.RemoveAt(index);
                        PartList.Add(editInventoryWindow.Part);
                    }

                    InventoryItem originalItem = inventoryItems.Where(i => i.ID == editInventoryWindow.ID).FirstOrDefault();
                    InventoryItem tempItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.Name,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice),
                        //IsRental = editInventoryWindow.,
                        RentalPrice = Convert.ToDecimal(editInventoryWindow.RentalPrice),
                        SerialNumber = editInventoryWindow.SerialNumber
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, tempItem);
                    con.Close();
                }
            }
        }

        private void Button_EditSupply(object sender, RoutedEventArgs e)
        {
            var selectedEntry = SuppliesListBox.SelectedItem as Supply;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a supply item to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddInventoryWindow editInventoryWindow = new AddInventoryWindow(null, null, selectedEntry, true);
            editInventoryWindow.Owner = this;
            bool? result = editInventoryWindow.ShowDialog();
            if (result == true)
            {
                if (editInventoryWindow.DeleteItem == true)
                {
                    int index = SuppliesListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, SupplyList[index].ID);
                        con.Close();

                        SupplyList.RemoveAt(index);
                        inventoryItems.Remove(inventoryItems.Where(i => i.ID == SupplyList[index].ID).FirstOrDefault());
                    }
                }
                else
                {
                    int index = SuppliesListBox.SelectedIndex;
                    if (index >= 0 && editInventoryWindow.Supply != null)
                    {
                        SupplyList[index] = editInventoryWindow.Supply;
                    }
                    else if (editInventoryWindow.Equipment != null)
                    {
                        SupplyList.RemoveAt(index);
                        EquipmentList.Add(editInventoryWindow.Equipment);
                    }
                    else if (editInventoryWindow.Part != null)
                    {
                        SupplyList.RemoveAt(index);
                        PartList.Add(editInventoryWindow.Part);
                    }

                    InventoryItem originalItem = inventoryItems.Where(i => i.ID == editInventoryWindow.ID).FirstOrDefault();
                    InventoryItem tempItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.Name,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice)
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, tempItem);
                    con.Close();
                }
            }
        }

        private void Button_EditPart(object sender, RoutedEventArgs e)
        {
            var selectedEntry = PartsListBox.SelectedItem as Part;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a part to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddInventoryWindow editInventoryWindow = new AddInventoryWindow(null, selectedEntry, null, true);
            editInventoryWindow.Owner = this;
            bool? result = editInventoryWindow.ShowDialog();
            if (result == true)
            {
                if (editInventoryWindow.DeleteItem == true)
                {
                    int index = PartsListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, PartList[index].ID);
                        con.Close();

                        PartList.RemoveAt(index);
                        inventoryItems.Remove(inventoryItems.Where(i => i.ID == PartList[index].ID).FirstOrDefault());
                    }
                }
                else
                {
                    int index = PartsListBox.SelectedIndex;
                    if (index >= 0 && editInventoryWindow.Part != null)
                    {
                        PartList[index] = editInventoryWindow.Part;
                    }
                    else if (editInventoryWindow.Equipment != null)
                    {
                        PartList.RemoveAt(index);
                        EquipmentList.Add(editInventoryWindow.Equipment);
                    }
                    else if (editInventoryWindow.Supply != null)
                    {
                        PartList.RemoveAt(index);
                        SupplyList.Add(editInventoryWindow.Supply);
                    }

                    InventoryItem originalItem = inventoryItems.Where(i => i.ID == editInventoryWindow.ID).FirstOrDefault();
                    InventoryItem tempItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.Name,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice)
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, tempItem);
                    con.Close();
                }
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
                string partnerID = string.Empty;

                (string, string) supplierAddress = SplitAddress(streetAddress);

                Address newAddress = new Address(addresses.Max(a => a.ID) + 1, supplierAddress.Item2, supplierAddress.Item1,
                    city, state, zipCode);

                Supplier newSupplier = new Supplier(businessName, businessPhone, partnerID, newAddress.ID);

                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreateAddressEntry(con, newAddress);
                con.Close();

                con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreateSupplierEntry(con, newSupplier);
                con.Close();

                SupplierList.AddSupplier(newSupplier, newAddress);
                addresses.Add(newAddress);
                suppliers.Add(newSupplier);
            }
        }

        private void Button_EditSupplier(object sender, RoutedEventArgs e)
        {
            var selectedEntry = SupplierListBox.SelectedItem as SupplierL;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a supplier to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddSupplierWindow editSupplierWindow = new AddSupplierWindow(selectedEntry);
            editSupplierWindow.Owner = this;
            bool? result = editSupplierWindow.ShowDialog();
            if (result == true)
            {
                if (editSupplierWindow.DeleteSupplier == true)
                {
                    int index = SupplierListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteSupplierEntry(con, SupplierList[index].Name);
                        con.Close();

                        SupplierList.RemoveAt(index);
                        suppliers.Remove(suppliers.Where(s => s.Name == SupplierList[index].Name).FirstOrDefault());
                    }
                }
                else
                {
                    int index = SupplierListBox.SelectedIndex;
                    if (index >= 0 && editSupplierWindow.Supplier != null)
                    {
                        Supplier originalSupplier = suppliers.Where(s => s.Name == editSupplierWindow.Name).FirstOrDefault();
                        uint addressID = originalSupplier.AddressID;

                        if (editSupplierWindow.StreetAddress != SupplierList[index].StreetAddress
                            || editSupplierWindow.City != SupplierList[index].City
                            || editSupplierWindow.State != SupplierList[index].State
                            || editSupplierWindow.ZipCode != SupplierList[index].ZipCode)
                        {
                            addressID = CreateAddressEntry(editSupplierWindow);
                        }

                        Supplier editSupplier = new Supplier()
                        {
                            Name = editSupplierWindow.Name,
                            PhoneNumber = Convert.ToDecimal(editSupplierWindow.PhoneNumber),
                            PartnerID = editSupplierWindow.PartnerID,
                            AddressID = originalSupplier.AddressID
                        };

                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.UpdateSupplierEntry(con, editSupplier);
                        con.Close();

                        SupplierList[index] = editSupplierWindow.Supplier;
                    }                  
                }
            }
        }

        private void Button_CreateWorkOrder(object sender, RoutedEventArgs e)
        {
            CreateWorkOrder createWorkOrder = new CreateWorkOrder(PatientList, EquipmentList, SupplyList, PartList);
            createWorkOrder.Owner = this;
            bool? result = createWorkOrder.ShowDialog();
            if (result == true)
            {
                string type = createWorkOrder.Type;
                uint patientID = createWorkOrder.PatientID;
                ObservableCollection<InventoryEntry> inventoryEntries = createWorkOrder.FinalInventoryEntries;
                DateTime orderDate = createWorkOrder.OrderDate;
                DateTime dateOfPayment = createWorkOrder.DateOfPayment;
                bool haveReceivedPayment = dateOfPayment != DateTime.MinValue;
                string notes = createWorkOrder.Notes;

                // Create a row in work order table for each item in the work order
                foreach (InventoryEntry inventoryEntry in inventoryEntries)
                {
                    CustomerOrder newCustOrder = new CustomerOrder(customerOrders.Max(o => o.ID) + 1, inventoryEntry.MainItem.ID, type, patientID,
                    inventoryEntry.MainItem.QuantitySelected, orderDate, haveReceivedPayment, dateOfPayment, inventoryEntry.RelatedItem.ID, notes);

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateCustomerOrderEntry(con, newCustOrder);
                    con.Close();

                    WorkOrdersList.AddWorkOrder(newCustOrder, persons.FirstOrDefault(p => p.ID == newCustOrder.PersonID), inventoryEntries);
                    customerOrders.Add(newCustOrder);
                }
            }
        }

        private void Button_EditWorkOrder(object sender, RoutedEventArgs e)
        {
            var selectedEntry = WorkListBox.SelectedItem as WorkOrder;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a work order to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            CreateWorkOrder editWorkOrderWindow = new CreateWorkOrder(PatientList, EquipmentList, SupplyList, PartList, selectedEntry);
            editWorkOrderWindow.Owner = this;
            bool? result = editWorkOrderWindow.ShowDialog();
            if (result == true)
            {
                if (editWorkOrderWindow.DeleteOrder == true)
                {
                    int index = WorkListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        foreach (InventoryEntry invEntry in WorkOrdersList[index].InventoryEntries)
                        {
                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteCustomerOrderEntry(con, WorkOrdersList[index].ID, invEntry.MainItem.ID);
                            con.Close();
                        }

                        WorkOrdersList.RemoveAt(index);
                        List<CustomerOrder> ordersToRemove = customerOrders.Where(i => i.ID == WorkOrdersList[index].ID).ToList();
                        foreach (CustomerOrder order in ordersToRemove)
                            customerOrders.Remove(order);
                    }
                }
                else
                {
                    int index = WorkListBox.SelectedIndex;
                    if (index >= 0 && editWorkOrderWindow.WorkOrder != null)
                    {
                        WorkOrdersList[index] = editWorkOrderWindow.WorkOrder;
                    }

                    List<CustomerOrder> originalOrder = customerOrders.Where(co => co.ID == editWorkOrderWindow.ID).ToList();
                    foreach (InventoryEntry inventoryEntry in editWorkOrderWindow.FinalInventoryEntries)
                    {
                        if (originalOrder.Any(o => o.InventoryID == inventoryEntry.MainItem.ID))
                        {
                            // Edit existing order item
                            CustomerOrder editOrder = new CustomerOrder(editWorkOrderWindow.ID,
                                inventoryEntry.MainItem.ID,
                                editWorkOrderWindow.Type,
                                editWorkOrderWindow.PatientID,
                                inventoryEntry.MainItem.QuantitySelected,
                                editWorkOrderWindow.OrderDate,
                                editWorkOrderWindow.DateOfPayment != DateTime.MinValue,
                                editWorkOrderWindow.DateOfPayment,
                                inventoryEntry.RelatedItem.ID,
                                editWorkOrderWindow.Notes);

                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.UpdateCustomerOrderEntry(con, editOrder);
                            con.Close();
                        }
                        else
                        {
                            // Create new order item
                            CustomerOrder newOrder = new CustomerOrder(customerOrders.Max(o => o.ID) + 1,
                                inventoryEntry.MainItem.ID,
                                editWorkOrderWindow.Type,
                                editWorkOrderWindow.PatientID,
                                inventoryEntry.MainItem.QuantitySelected,
                                editWorkOrderWindow.OrderDate,
                                editWorkOrderWindow.DateOfPayment != DateTime.MinValue,
                                editWorkOrderWindow.DateOfPayment,
                                inventoryEntry.RelatedItem.ID,
                                editWorkOrderWindow.Notes);

                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.CreateCustomerOrderEntry(con, newOrder);
                            con.Close();
                        }
                    }
                }
            }
        }
        private void Button_CreateSupplyOrder(object sender, RoutedEventArgs e)
        {
            CreateSupplyOrder createSupplyOrder = new CreateSupplyOrder(SupplierList, EquipmentList, SupplyList, PartList);
            createSupplyOrder.Owner = this;
            bool? result = createSupplyOrder.ShowDialog();
            if (result == true)
            {
                ObservableCollection<InventoryEntry> inventoryEntries = createSupplyOrder.FinalInventoryEntries;
                string supplier = createSupplyOrder.Supplier;              
                string shippingMethod = createSupplyOrder.ShippingMethod;
                DateTime orderDate = createSupplyOrder.OrderDate;
                DateTime receivedDate = createSupplyOrder.ReceivedDate;
                bool hasBeenReceived = receivedDate != DateTime.MinValue;              

                // Create a row in the order table for each item in the supply order
                foreach (InventoryEntry inventoryEntry in inventoryEntries)
                {
                    Order newOrder = new Order(orders.Max(o => o.ID) + 1, inventoryEntry.MainItem.ID, inventoryEntry.MainItem.QuantitySelected,
                        supplier, shippingMethod, orderDate, hasBeenReceived, receivedDate);

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateOrderEntry(con, newOrder);
                    con.Close();

                    SupplyOrdersList.AddSupplyOrder(newOrder, inventoryEntries);
                    orders.Add(newOrder);
                }              
            }
        }

        private void Button_EditSupplyOrder(object sender, RoutedEventArgs e)
        {
            var selectedEntry = SupplyListBox.SelectedItem as SupplyOrder;
            if (selectedEntry == null)
            {
                MessageBox.Show("Please select a supply order to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            CreateSupplyOrder editSupplyOrderWindow = new CreateSupplyOrder(SupplierList, EquipmentList, SupplyList, PartList, selectedEntry);
            editSupplyOrderWindow.Owner = this;
            bool? result = editSupplyOrderWindow.ShowDialog();
            if (result == true)
            {
                if (editSupplyOrderWindow.DeleteOrder == true)
                {
                    int index = SupplyListBox.SelectedIndex;
                    if (index >= 0)
                    {
                        foreach (InventoryEntry invEntry in SupplyOrdersList[index].InventoryEntries)
                        {
                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteOrderEntry(con, SupplyOrdersList[index].ID, invEntry.MainItem.ID);
                            con.Close();
                        }

                        SupplyOrdersList.RemoveAt(index);
                        List<Order> ordersToRemove = orders.Where(i => i.ID == SupplyOrdersList[index].ID).ToList();
                        foreach (Order order in ordersToRemove)
                            orders.Remove(order);
                    }
                }
                else
                {
                    int index = SupplyListBox.SelectedIndex;
                    if (index >= 0 && editSupplyOrderWindow.SupplyOrder != null)
                    {
                        SupplyOrdersList[index] = editSupplyOrderWindow.SupplyOrder;
                    }

                    List<Order> originalOrder = orders.Where(o => o.ID == editSupplyOrderWindow.ID).ToList();
                    foreach (InventoryEntry inventoryEntry in editSupplyOrderWindow.FinalInventoryEntries)
                    {
                        if (originalOrder.Any(o => o.InventoryID == inventoryEntry.MainItem.ID))
                        {
                            // Edit existing order item
                            Order editOrder = new Order(editSupplyOrderWindow.ID,
                                inventoryEntry.MainItem.ID,
                                inventoryEntry.MainItem.QuantitySelected,
                                editSupplyOrderWindow.Supplier,
                                editSupplyOrderWindow.ShippingMethod,
                                editSupplyOrderWindow.OrderDate,
                                editSupplyOrderWindow.ReceivedDate != DateTime.MinValue,
                                editSupplyOrderWindow.ReceivedDate);

                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.UpdateOrderEntry(con, editOrder);
                            con.Close();
                        }
                        else
                        {
                            // Create new order item
                            Order newOrder = new Order(orders.Max(o => o.ID) + 1, 
                                inventoryEntry.MainItem.ID, 
                                inventoryEntry.MainItem.QuantitySelected,
                                editSupplyOrderWindow.Supplier, 
                                editSupplyOrderWindow.ShippingMethod, 
                                editSupplyOrderWindow.OrderDate,
                                editSupplyOrderWindow.ReceivedDate != DateTime.MinValue, 
                                editSupplyOrderWindow.ReceivedDate);

                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.CreateOrderEntry(con, newOrder);
                            con.Close();
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void WorkListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedWorkOrder = ((ListBox)sender).SelectedItem;
        }

        private void SupplyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSupplyOrder = ((ListBox)sender).SelectedItem;
        }

        private void EquipmentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedEquipment = ((ListBox)sender).SelectedItem;
        }

        private void SuppliesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSupply = ((ListBox)sender).SelectedItem;
        }

        private void PartsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPart = ((ListBox)sender).SelectedItem;
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
            Patients allPersonsList = new Patients();
            foreach (Person person in persons)
            {
                allPersonsList.AddPatient(person, addresses.Where(a => a.ID == person.AddressID).FirstOrDefault());
                if (person.IsPatient)
                {
                    PatientList.AddPatient(person, addresses.Where(a => a.ID == person.AddressID).FirstOrDefault());
                }                
            }

            foreach (Patient patient in PatientList)
            {
                patient.Contacts = new ObservableCollection<Patient>();
                List<Patient> contactsList = allPersonsList.Where(p => p.ContactID == patient.ID).ToList();
                foreach (Patient contact in contactsList)
                {
                    patient.Contacts.Add(contact);
                }
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
                ObservableCollection<InventoryEntry> invEntries = new ObservableCollection<InventoryEntry>();
                // Only create 1 SupplyOrder for each ID in the orders
                if (!SupplyOrdersList.Any(o => o.ID == order.ID))
                {
                    // Create collection of inventoryItem for the supply order
                    List<Order> orders2 = new List<Order>(orders.Where(i => i.ID == order.ID));
                    foreach (Order continuedOrder in orders.Where(i => i.ID == order.ID))
                    {
                        InventoryItem item = inventoryItems.Where(i => i.ID == continuedOrder.InventoryID).FirstOrDefault();
                        InventoryEntry entry = new InventoryEntry();
                        entry.MainItem = new InventoryListItem()
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Type = item.Type,
                            QuantitySelected = continuedOrder.Quantity
                        };
                        invEntries.Add(entry);
                    }

                    // Add the new supply order
                    SupplyOrdersList.AddSupplyOrder(order, invEntries);
                }           
            }
        }

        private void PopulateWorkOrderList()
        {
            foreach (CustomerOrder order in customerOrders)
            {
                ObservableCollection<InventoryEntry> invEntries = new ObservableCollection<InventoryEntry>();
                if (!WorkOrdersList.Any(wo => wo.ID == order.ID))
                {
                    foreach (CustomerOrder continuedOrder in customerOrders.Where(i => i.ID == order.ID))
                    {
                        InventoryItem mainItem = inventoryItems.Where(i => i.ID == continuedOrder.InventoryID).FirstOrDefault();
                        InventoryEntry entry = new InventoryEntry();
                        entry.MainItem = new InventoryListItem()
                        {
                            ID = mainItem.ID,
                            Name = mainItem.Name,
                            Type = mainItem.Type,
                            QuantitySelected = continuedOrder.Quantity
                        };
                        if (continuedOrder.RelatedInventoryItemID != 0)
                        {
                            InventoryItem relatedItem = inventoryItems.Where(i => i.ID == continuedOrder.RelatedInventoryItemID).FirstOrDefault();
                            entry.RelatedItem = new InventoryListItem()
                            {
                                ID = relatedItem.ID,
                                Name = relatedItem.Name,
                                Type = relatedItem.Type,
                            };
                        }                       
                        invEntries.Add(entry);
                    }

                    Person customer = persons.Where(p => p.ID == order.PersonID).FirstOrDefault();
                    WorkOrdersList.AddWorkOrder(order, customer, invEntries);
                }              
            }
        }

        private uint CreateAddressEntry(Patient patient)
        {
            (string, string) address = SplitAddress(patient.StreetAddress);

            Address newAddress = new Address(addresses.Max(a => a.ID) + 1,
                address.Item2,
                address.Item1,
                patient.City,
                patient.State,
                patient.ZipCode);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.CreateAddressEntry(con, newAddress);
            con.Close();

            addresses.Add(newAddress);
            return newAddress.ID;
        }

        private uint CreateAddressEntry(AddSupplierWindow addSupplierWindow)
        {
            (string, string) address = SplitAddress(addSupplierWindow.StreetAddress);

            Address newAddress = new Address(addresses.Max(a => a.ID) + 1,
                address.Item2,
                address.Item1,
                addSupplierWindow.City,
                addSupplierWindow.State,
                addSupplierWindow.ZipCode);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.CreateAddressEntry(con, newAddress);
            con.Close();

            addresses.Add(newAddress);
            return newAddress.ID;
        }
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

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PatientTab.IsSelected)
            {
                string test = "test";
            }

        }

        // maybe add event for OrdersTabControl
    }
}