﻿using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MySql.Data.MySqlClient;
using MediStoreManager;
using System.Collections.ObjectModel;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static bool IsAdmin {  get; private set; }
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

        private CollectionViewSource _patientViewSource;
        private CollectionViewSource _equipmentViewSource;
        private CollectionViewSource _partViewSource;
        private CollectionViewSource _supplyViewSource;
        private CollectionViewSource _supplierViewSource;
        private CollectionViewSource _workOrderViewSource;
        private CollectionViewSource _supplyOrderViewSource;

        public MainWindow(bool isAdmin)
        {
            InitializeComponent();

            IsAdmin = isAdmin;

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
                RetrieveAddresses();
                RetrievePersons();
                RetrieveSuppliers();
                RetrieveInventoryItems();
                RetrieveOrders();
                RetrieveCustomerOrders();
                RetrieveUsers();

                PopulateWorkOrderList();
                PopulateSupplyOrderList();
                PopulatePatientList();
                PopulateSupplierList();
                PopulateEquipmentList();
                PopulateSupplyList();
                PopulatePartList();

                ClearUnusedAddresses();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            _patientViewSource = new CollectionViewSource { Source = PatientList };
            _patientViewSource.Filter += PatientFilter;

            PatientListBox.ItemsSource = _patientViewSource.View;

            _equipmentViewSource = new CollectionViewSource { Source = EquipmentList };
            _equipmentViewSource.Filter += EquipmentFilter;

            EquipmentListBox.ItemsSource = _equipmentViewSource.View;

            _partViewSource = new CollectionViewSource { Source = PartList };
            _partViewSource.Filter += PartFilter;

            PartsListBox.ItemsSource = _partViewSource.View;

            _supplyViewSource = new CollectionViewSource { Source = SupplyList };
            _supplyViewSource.Filter += SupplyFilter;

            SuppliesListBox.ItemsSource = _supplyViewSource.View;

            _supplierViewSource = new CollectionViewSource { Source = SupplierList };
            _supplierViewSource.Filter += SupplierFilter;

            SupplierListBox.ItemsSource = _supplierViewSource.View;

            _workOrderViewSource = new CollectionViewSource { Source = WorkOrdersList };
            _workOrderViewSource.Filter += WorkOrderFilter;

            WorkListBox.ItemsSource = _workOrderViewSource.View;

            _supplyOrderViewSource = new CollectionViewSource { Source = SupplyOrdersList };
            _supplyOrderViewSource.Filter += SupplyOrderFilter;

            SupplyListBox.ItemsSource = _supplyOrderViewSource.View;
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
                Address newAddress = CreateAddressEntry(addPatientWindow.Patient);
                
                Person newPerson = new Person(persons.Max(p => p.ID) + 1, firstName, lastName, middleName, homePhone, cellPhone,
                    newAddress.ID, insurance, isPatient);

                // Insert new person into the database
                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreatePersonEntry(con, newPerson);
                con.Close();

                persons.Add(newPerson);

                // Add person entries for new contacts   
                if (contacts.Any())
                {
                    foreach (Patient contact in contacts)
                    {
                        // Add new person for contact if they don't already exist
                        if (!persons.Any(p => p.ID == contact.ID) || contact.ID == 0)
                        {
                            uint contactID = persons.Max(p => p.ID) + 1;
                            // Create address entry for the contact
                            Address contactAddress = CreateAddressEntry(contact);
                            // Create person entry for the contact
                            Person contactPerson = new Person(contactID, contact.FirstName, contact.LastName,
                                contact.MiddleName, contact.HomePhone, contact.CellPhone, contactAddress.ID, contact.Insurance,
                                false, newPerson.ID, contact.RelationshipToPatient);

                            con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.CreatePersonEntry(con, contactPerson);
                            con.Close();

                            contact.ID = contactID;
                            persons.Add(contactPerson);
                        }
                    }
                }

                // Add patient to user interface
                if (!contacts.Any())
                {
                    PatientList.AddPatient(newPerson, newAddress, null);
                } else
                {
                    PatientList.AddPatient(newPerson, newAddress, null, contacts);
                }               
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
                    int index = PatientList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        
                        DatabaseFunctions.DeletePersonEntry(con, PatientList[index].ID);
                        con.Close();

                        Person deletedPerson = persons.Where(p => p.ID == PatientList[index].ID).FirstOrDefault();
                        int deletedIndex = persons.IndexOf(deletedPerson);
                        persons[deletedIndex].Deleted = true;
                        PatientList.RemoveAt(index);
                    }
                }
                else
                {
                    int index = PatientList.IndexOf(selectedEntry);
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
                            addressID = CreateAddressEntry(editPatientWindow.Patient).ID;
                        }

                        // Create a person to use in the update function
                        Person editPerson = new Person()
                        {
                            ID = editPatientWindow.Patient.ID,
                            FirstName = editPatientWindow.FirstName,
                            LastName = editPatientWindow.LastName,
                            MiddleName = editPatientWindow.MiddleName,
                            HomePhone = Convert.ToInt64(editPatientWindow.HomePhone),
                            CellPhone = Convert.ToInt64(editPatientWindow.CellPhone),
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
                                if (!persons.Any(p => p.ID == contact.ID) || contact.ID == 0)
                                {
                                    uint contactID = persons.Max(p => p.ID) + 1;
                                    // Create address entry for the contact
                                    Address contactAddress = CreateAddressEntry(contact);
                                    // Create person entry for the contact
                                    Person contactPerson = new Person(contactID, contact.FirstName, contact.LastName,
                                        contact.MiddleName, contact.HomePhone, contact.CellPhone, contactAddress.ID, contact.Insurance,
                                        false, editPerson.ID, contact.RelationshipToPatient);                                   

                                    con = DatabaseFunctions.OpenMySQLConnection();
                                    DatabaseFunctions.CreatePersonEntry(con, contactPerson);
                                    con.Close();

                                    contact.ID = contactID;
                                    persons.Add(contactPerson);
                                }
                            }
                        }

                        // Check for removed contacts and set their ContactID to 0
                        List<Patient> removedContacts = PatientList[index].Contacts
                            .Where(c => !editPatientWindow.Patient.Contacts.Any(pc => pc.ID == c.ID)).ToList();
                        foreach (Patient removedContact in removedContacts)
                        {
                            int contactIndex = persons.IndexOf(persons.Where(p => p.ID == removedContact.ID).FirstOrDefault());
                            persons[contactIndex].ContactID = 0;

                            con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.UpdatePersonEntry(con, persons[contactIndex]);
                            con.Close();
                        }

                        // Update patient in lists
                        PatientList[index] = editPatientWindow.Patient;
                        int pIndex = persons.IndexOf(originalPerson);
                        persons[pIndex] = editPerson;                      
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
                decimal price = addInventoryWindow.Price;
                decimal retailPrice = addInventoryWindow.RetailPrice;
                decimal rentalPrice = addInventoryWindow.RentalPrice;
                bool isRental = addInventoryWindow.IsRental;
                string serialNumber = addInventoryWindow.SerialNumber;

                InventoryItem newItem = new InventoryItem(inventoryItems.Max(i => i.ID) + 1, type, inventoryName, size, brand,
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
                    int index = EquipmentList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, EquipmentList[index].ID);
                        con.Close();

                        InventoryItem deletedItem = inventoryItems.Where(i => i.ID == EquipmentList[index].ID).FirstOrDefault();
                        int deletedIndex = inventoryItems.IndexOf(deletedItem);
                        inventoryItems[deletedIndex].Deleted = true;
                        EquipmentList.RemoveAt(index);
                    }
                }
                else
                {
                    int index = EquipmentList.IndexOf(selectedEntry);
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
                    InventoryItem editItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.InventoryName,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice),
                        IsRental = editInventoryWindow.IsRental,
                        RentalPrice = Convert.ToDecimal(editInventoryWindow.RentalPrice),
                        SerialNumber = editInventoryWindow.SerialNumber
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, editItem);
                    con.Close();

                    int eIndex = inventoryItems.IndexOf(originalItem);
                    inventoryItems[eIndex] = editItem;
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
                    int index = SupplyList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, SupplyList[index].ID);
                        con.Close();

                        InventoryItem deletedItem = inventoryItems.Where(i => i.ID == SupplyList[index].ID).FirstOrDefault();
                        int deletedIndex = inventoryItems.IndexOf(deletedItem);
                        inventoryItems[deletedIndex].Deleted = true;
                        SupplyList.RemoveAt(index);
                    }
                }
                else
                {
                    int index = SupplyList.IndexOf(selectedEntry);
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
                    InventoryItem editItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.InventoryName,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice)
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, editItem);
                    con.Close();

                    int sIndex = inventoryItems.IndexOf(originalItem);
                    inventoryItems[sIndex] = editItem;
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
                    int index = PartList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteInventoryItemEntry(con, PartList[index].ID);
                        con.Close();

                        InventoryItem deletedItem = inventoryItems.Where(i => i.ID == PartList[index].ID).FirstOrDefault();
                        int deletedIndex = inventoryItems.IndexOf(deletedItem);
                        inventoryItems[deletedIndex].Deleted = true;
                        PartList.RemoveAt(index);
                    }
                }
                else
                {
                    int index = PartList.IndexOf(selectedEntry);
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
                    InventoryItem editItem = new InventoryItem()
                    {
                        ID = originalItem.ID,
                        Type = editInventoryWindow.Type,
                        Name = editInventoryWindow.InventoryName,
                        Size = editInventoryWindow.Size,
                        Brand = editInventoryWindow.Brand,
                        NumInStock = editInventoryWindow.Quantity,
                        Cost = Convert.ToDecimal(editInventoryWindow.Price),
                        RetailPrice = Convert.ToDecimal(editInventoryWindow.RetailPrice)
                    };

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.UpdateInventoryItemEntry(con, editItem);
                    con.Close();

                    int pIndex = inventoryItems.IndexOf(originalItem);
                    inventoryItems[pIndex] = editItem;
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
                int partnerID = addSupplierWindow.PartnerID;

                (string, string) supplierAddress = SplitAddress(streetAddress);

                Address newAddress = CreateAddressEntry(addSupplierWindow);

                Supplier newSupplier = new Supplier(businessName, businessPhone, partnerID, newAddress.ID);

                MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                DatabaseFunctions.CreateSupplierEntry(con, newSupplier);
                con.Close();

                SupplierList.AddSupplier(newSupplier, newAddress, null);
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
                    int index = SupplierList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.DeleteSupplierEntry(con, SupplierList[index].Name);
                        con.Close();

                        Supplier deletedSupplier = suppliers.Where(s => s.Name == SupplierList[index].Name).FirstOrDefault();
                        int deletedIndex = suppliers.IndexOf(deletedSupplier);
                        suppliers[deletedIndex].Deleted = true;
                        SupplierList.RemoveAt(index);
                    }
                }
                else
                {
                    int index = SupplierList.IndexOf(selectedEntry);
                    if (index >= 0 && editSupplierWindow.Supplier != null)
                    {
                        Supplier originalSupplier = suppliers.Where(s => s.Name == editSupplierWindow.BusinessName).FirstOrDefault();
                        uint addressID = originalSupplier.AddressID;

                        if (editSupplierWindow.StreetAddress != SupplierList[index].StreetAddress
                            || editSupplierWindow.City != SupplierList[index].City
                            || editSupplierWindow.State != SupplierList[index].State
                            || editSupplierWindow.ZipCode != SupplierList[index].ZipCode)
                        {
                            addressID = CreateAddressEntry(editSupplierWindow).ID;                           
                        }

                        Supplier editSupplier = new Supplier()
                        {
                            Name = editSupplierWindow.BusinessName,
                            PhoneNumber = Convert.ToDecimal(editSupplierWindow.PhoneNumber),
                            PartnerID = editSupplierWindow.PartnerID,
                            AddressID = originalSupplier.AddressID
                        };

                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.UpdateSupplierEntry(con, editSupplier);
                        con.Close();

                        int sIndex = suppliers.IndexOf(originalSupplier);
                        suppliers[sIndex] = editSupplier;

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
                uint currentID = customerOrders.Max(o => o.ID) + 1;
                CustomerOrder newCustOrder = new CustomerOrder();

                // Create a row in work order table for each item in the work order
                foreach (InventoryEntry inventoryEntry in inventoryEntries)
                {
                    newCustOrder = new CustomerOrder(currentID, inventoryEntry.MainItem.ID, type, patientID,
                    inventoryEntry.MainItem.QuantitySelected, orderDate, haveReceivedPayment, dateOfPayment, inventoryEntry.RelatedItem, notes);

                    if (inventoryEntry.RelatedItem == null)
                    {
                        inventoryEntry.RelatedItem = new InventoryListItem();
                    }

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateCustomerOrderEntry(con, newCustOrder);
                    con.Close();

                    customerOrders.Add(newCustOrder);
                }

                WorkOrdersList.AddWorkOrder(newCustOrder, persons.FirstOrDefault(p => p.ID == newCustOrder.PersonID), inventoryEntries);

                if (type == "Delivery" || type == "Pickup" || type == "Repair")
                {                  
                    foreach (InventoryEntry inventoryEntry in inventoryEntries)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        int invIndex = inventoryItems.IndexOf(inventoryItems.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault());

                        if (inventoryEntry.MainItem.Type == "equipment")
                        {
                            // assign patient ID to equipment                           
                            DatabaseFunctions.UpdateInventoryItemPersonID(con, inventoryEntry.MainItem.ID, patientID);
                            con.Close();

                            // update patient ID in inventory list
                            inventoryItems[invIndex].PersonID = patientID;
                        }

                        // reduce number in stock of inventory item
                        con = DatabaseFunctions.OpenMySQLConnection();
                        // get num in stock from original database item
                        int newStock = inventoryItems[invIndex].NumInStock - inventoryEntry.MainItem.QuantitySelected;
                        DatabaseFunctions.UpdateInventoryQuantity(con, inventoryEntry.MainItem.ID, newStock);
                        con.Close();

                        // update NumInStock in inventory lists
                        UpdateQuantityInItemList(inventoryEntry.MainItem.Type, inventoryEntry.MainItem.ID, newStock);

                        inventoryItems[invIndex].NumInStock = newStock; 
                        
                        if (inventoryEntry.MainItem.Type == "equipment")
                        {
                            Equipment currentItem = EquipmentList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                        else if (inventoryEntry.MainItem.Type == "supply")
                        {
                            Supply currentItem = SupplyList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                        else if (inventoryEntry.MainItem.Type == "part")
                        {
                            Part currentItem = PartList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                    }
                }

                if (type == "Rental Pickup")
                {
                    
                    foreach (InventoryEntry inventoryEntry in inventoryEntries.Where(ie => ie.MainItem.Type == "equipment"))
                    {
                        // remove patient ID from equipment
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.UpdateInventoryItemPersonID(con, inventoryEntry.MainItem.ID, 0);
                        con.Close();

                        // increase number in stock of inventory item
                        con = DatabaseFunctions.OpenMySQLConnection();
                        DatabaseFunctions.UpdateInventoryQuantity(con, inventoryEntry.MainItem.ID,  1);
                        con.Close();

                        // update inventory lists
                        UpdateQuantityInItemList("equipment", inventoryEntry.MainItem.ID, 1);

                        int invIndex = inventoryItems.IndexOf(inventoryItems.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault());
                        inventoryItems[invIndex].NumInStock = 1;
                        inventoryItems[invIndex].PersonID = 0;
                    }
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
                    int index = WorkOrdersList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        foreach (InventoryEntry invEntry in WorkOrdersList[index].InventoryEntries)
                        {
                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteCustomerOrderEntry(con, WorkOrdersList[index].ID, invEntry.MainItem.ID);
                            con.Close();
                        }

                        List<CustomerOrder> ordersToRemove = customerOrders.Where(co => co.ID == WorkOrdersList[index].ID).ToList();
                        WorkOrdersList.RemoveAt(index);
                        int removeIndex;
                        foreach (CustomerOrder order in ordersToRemove)
                        {
                            removeIndex = customerOrders.IndexOf(order);
                            customerOrders[removeIndex].Deleted = true;
                        }
                    }
                }
                else
                {
                    int index = WorkOrdersList.IndexOf(selectedEntry);
                    if (index >= 0 && editWorkOrderWindow.WorkOrder != null)
                    {
                        List<CustomerOrder> originalOrder = customerOrders.Where(co => co.ID == editWorkOrderWindow.ID).ToList();
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        foreach (InventoryEntry inventoryEntry in editWorkOrderWindow.FinalInventoryEntries)
                        {
                            if (inventoryEntry.RelatedItem == null)
                            {
                                inventoryEntry.RelatedItem = new InventoryListItem();
                            }

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
                                    inventoryEntry.RelatedItem,
                                    editWorkOrderWindow.Notes);

                                con = DatabaseFunctions.OpenMySQLConnection();
                                DatabaseFunctions.UpdateCustomerOrderEntry(con, editOrder);
                                con.Close();

                                int oIndex = customerOrders.IndexOf(originalOrder.Where(o => o.InventoryID == inventoryEntry.MainItem.ID).FirstOrDefault());
                                customerOrders[oIndex] = editOrder;
                            }
                            else
                            {
                                // Create new order item
                                CustomerOrder newOrder = new CustomerOrder(originalOrder.FirstOrDefault().ID,
                                    inventoryEntry.MainItem.ID,
                                    editWorkOrderWindow.Type,
                                    editWorkOrderWindow.PatientID,
                                    inventoryEntry.MainItem.QuantitySelected,
                                    editWorkOrderWindow.OrderDate,
                                    editWorkOrderWindow.DateOfPayment != DateTime.MinValue,
                                    editWorkOrderWindow.DateOfPayment,
                                    inventoryEntry.RelatedItem,
                                    editWorkOrderWindow.Notes);

                                con = DatabaseFunctions.OpenMySQLConnection();
                                DatabaseFunctions.CreateCustomerOrderEntry(con, newOrder);
                                con.Close();

                                customerOrders.Add(newOrder);
                            }

                            // Edit inventory item ID and NumInStock
                            con = DatabaseFunctions.OpenMySQLConnection();

                            int invIndex = inventoryItems.IndexOf(inventoryItems.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault());
                            if (inventoryEntry.MainItem.Type == "equipment")
                            {
                                // assign patient ID to equipment                           
                                DatabaseFunctions.UpdateInventoryItemPersonID(con, inventoryEntry.MainItem.ID, editWorkOrderWindow.PatientID);
                                con.Close();

                                // update patient ID in inventory list
                                inventoryItems[invIndex].PersonID = editWorkOrderWindow.PatientID;
                            }

                            // update number in stock of inventory item
                            con = DatabaseFunctions.OpenMySQLConnection();
                            // get num in stock from original database item
                            int newStock = inventoryItems[invIndex].NumInStock - inventoryEntry.MainItem.QuantitySelected;
                            DatabaseFunctions.UpdateInventoryQuantity(con, inventoryEntry.MainItem.ID, newStock);
                            con.Close();

                            // update NumInStock in inventory lists
                            UpdateQuantityInItemList(inventoryEntry.MainItem.Type, inventoryEntry.MainItem.ID, newStock);

                            inventoryItems[invIndex].NumInStock = newStock;

                            if (inventoryEntry.MainItem.Type == "equipment")
                            {
                                Equipment currentItem = EquipmentList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                if (currentItem != null)
                                {
                                    currentItem.Quantity = newStock;
                                }
                            }
                            else if (inventoryEntry.MainItem.Type == "supply")
                            {
                                Supply currentItem = SupplyList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                if (currentItem != null)
                                {
                                    currentItem.Quantity = newStock;
                                }
                            }
                            else if (inventoryEntry.MainItem.Type == "part")
                            {
                                Part currentItem = PartList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                if (currentItem != null)
                                {
                                    currentItem.Quantity = newStock;
                                }
                            }
                        }

                        // Check for removed work order items
                        List<InventoryEntry> removedEntries = WorkOrdersList[index].InventoryEntries
                            .Where(e => !editWorkOrderWindow.WorkOrder.InventoryEntries.Any(ie => ie.MainItem.ID == e.MainItem.ID)).ToList();
                        foreach (InventoryEntry entry in removedEntries)
                        {

                            int orderItemIndex = customerOrders.IndexOf(originalOrder.Where(o => o.InventoryID == entry.MainItem.ID).FirstOrDefault());
                            // Delete items from order
                            customerOrders[orderItemIndex].Deleted = true;

                            con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteCustomerOrderEntry(con, customerOrders[orderItemIndex].ID, entry.MainItem.ID);
                            con.Close();
                        }

                        // update PatientID and NumInStock for items removed from order
                        foreach (CustomerOrder orderItem in originalOrder
                            .Where(o => !editWorkOrderWindow.FinalInventoryEntries
                            .Any(ie => ie.MainItem.ID == o.InventoryID)).ToList())
                        {
                            InventoryItem item = inventoryItems.Where(i => i.ID == orderItem.InventoryID).FirstOrDefault();
                            int invIndex = inventoryItems.IndexOf(item);

                            if (item.Type == "equipment")
                            {
                                con = DatabaseFunctions.OpenMySQLConnection();
                                DatabaseFunctions.UpdateInventoryItemPersonID(con, item.ID, 0);
                                con.Close();

                                inventoryItems[invIndex].PersonID = 0;
                            }

                            con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.UpdateInventoryQuantity(con, item.ID, item.NumInStock + orderItem.Quantity);
                            con.Close();

                            UpdateQuantityInItemList(item.Type, item.ID, item.NumInStock + orderItem.Quantity);

                            inventoryItems[invIndex].NumInStock = item.NumInStock + orderItem.Quantity;
                        }

                        // update work order for the UI
                        Person orderPerson = persons.Where(p => p.ID == editWorkOrderWindow.WorkOrder.PatientID).FirstOrDefault();
                        WorkOrdersList[index] = editWorkOrderWindow.WorkOrder;
                        WorkOrdersList[index].DisplayName = orderPerson.FirstName + " " +
                            orderPerson.LastName + " - " + editWorkOrderWindow.WorkOrder.Date.Month.ToString() +
                            "/" + editWorkOrderWindow.WorkOrder.Date.Day.ToString() +
                            "/" + editWorkOrderWindow.WorkOrder.Date.Year.ToString();
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
                uint currentID = orders.Max(o => o.ID) + 1;
                Order newOrder = new Order();

                // Create a row in the order table for each item in the supply order
                foreach (InventoryEntry inventoryEntry in inventoryEntries)
                {
                    newOrder = new Order(currentID, inventoryEntry.MainItem.ID, inventoryEntry.MainItem.QuantitySelected,
                        supplier, shippingMethod, orderDate, hasBeenReceived, receivedDate);

                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateOrderEntry(con, newOrder);
                    con.Close();

                    orders.Add(newOrder);

                    if (hasBeenReceived)
                    {
                        InventoryItem orderInventoryItem = inventoryItems.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                        int invIndex = inventoryItems.IndexOf(orderInventoryItem);

                        con = DatabaseFunctions.OpenMySQLConnection();
                        int newStock = orderInventoryItem.NumInStock + inventoryEntry.MainItem.QuantitySelected;
                        DatabaseFunctions.UpdateInventoryQuantity(con, inventoryEntry.MainItem.ID, newStock);
                        con.Close();

                        UpdateQuantityInItemList(inventoryEntry.MainItem.Type, inventoryEntry.MainItem.ID, newStock);

                        inventoryItems[invIndex].NumInStock = newStock;

                        if (inventoryEntry.MainItem.Type == "equipment")
                        {
                            Equipment currentItem = EquipmentList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                        else if (inventoryEntry.MainItem.Type == "supply")
                        {
                            Supply currentItem = SupplyList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                        else if (inventoryEntry.MainItem.Type == "part")
                        {
                            Part currentItem = PartList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                            if (currentItem != null)
                            {
                                currentItem.Quantity = newStock;
                            }
                        }
                    }
                }
                SupplyOrdersList.AddSupplyOrder(newOrder, inventoryEntries);
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
                    int index = SupplyOrdersList.IndexOf(selectedEntry);
                    if (index >= 0)
                    {
                        foreach (InventoryEntry invEntry in SupplyOrdersList[index].InventoryEntries)
                        {
                            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteOrderEntry(con, SupplyOrdersList[index].ID, invEntry.MainItem.ID);
                            con.Close();
                        }

                        List<Order> ordersToRemove = orders.Where(i => i.ID == SupplyOrdersList[index].ID).ToList();
                        SupplyOrdersList.RemoveAt(index);
                        int removeIndex;
                        foreach (Order order in ordersToRemove)
                        {
                            removeIndex = orders.IndexOf(order);
                            orders[removeIndex].Deleted = true;
                        }
                    }
                }
                else
                {
                    int index = SupplyOrdersList.IndexOf(selectedEntry);
                    if (index >= 0 && editSupplyOrderWindow.SupplyOrder != null)
                    {
                        MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                        List<Order> originalOrder = orders.Where(o => o.ID == editSupplyOrderWindow.ID).ToList();
                        bool newlyReceived = false;
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

                                con = DatabaseFunctions.OpenMySQLConnection();
                                DatabaseFunctions.UpdateOrderEntry(con, editOrder);
                                con.Close();

                                int oIndex = orders.IndexOf(originalOrder.Where(o => o.InventoryID == inventoryEntry.MainItem.ID).FirstOrDefault());
                                orders[oIndex] = editOrder;

                                newlyReceived = !originalOrder.FirstOrDefault().HasBeenReceived && editOrder.HasBeenReceived;
                            }
                            else
                            {
                                // Create new order item
                                Order newOrder = new Order(originalOrder.FirstOrDefault().ID,
                                    inventoryEntry.MainItem.ID,
                                    inventoryEntry.MainItem.QuantitySelected,
                                    editSupplyOrderWindow.Supplier,
                                    editSupplyOrderWindow.ShippingMethod,
                                    editSupplyOrderWindow.OrderDate,
                                    editSupplyOrderWindow.ReceivedDate != DateTime.MinValue,
                                    editSupplyOrderWindow.ReceivedDate);

                                con = DatabaseFunctions.OpenMySQLConnection();
                                DatabaseFunctions.CreateOrderEntry(con, newOrder);
                                con.Close();

                                orders.Add(newOrder);
                            }

                            if (newlyReceived)
                            {
                                InventoryItem orderInventoryItem = inventoryItems.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                int invIndex = inventoryItems.IndexOf(orderInventoryItem);

                                con = DatabaseFunctions.OpenMySQLConnection();
                                int newStock = orderInventoryItem.NumInStock + inventoryEntry.MainItem.QuantitySelected;
                                DatabaseFunctions.UpdateInventoryQuantity(con, inventoryEntry.MainItem.ID, newStock);
                                con.Close();

                                UpdateQuantityInItemList(inventoryEntry.MainItem.Type, inventoryEntry.MainItem.ID, newStock);

                                inventoryItems[invIndex].NumInStock = newStock;

                                if (inventoryEntry.MainItem.Type == "equipment")
                                {
                                    Equipment currentItem = EquipmentList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                    if (currentItem != null)
                                    {
                                        currentItem.Quantity = newStock;
                                    }
                                }
                                else if (inventoryEntry.MainItem.Type == "supply")
                                {
                                    Supply currentItem = SupplyList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                    if (currentItem != null)
                                    {
                                        currentItem.Quantity = newStock;
                                    }
                                }
                                else if (inventoryEntry.MainItem.Type == "part")
                                {
                                    Part currentItem = PartList.Where(i => i.ID == inventoryEntry.MainItem.ID).FirstOrDefault();
                                    if (currentItem != null)
                                    {
                                        currentItem.Quantity = newStock;
                                    }
                                }
                            }
                        }

                        // Check for removed supply order items
                        List<InventoryEntry> removedEntries = SupplyOrdersList[index].InventoryEntries
                            .Where(e => !editSupplyOrderWindow.SupplyOrder.InventoryEntries.Any(ie => ie.MainItem.ID == e.MainItem.ID)).ToList();
                        foreach (InventoryEntry entry in removedEntries)
                        {

                            int orderItemIndex = orders.IndexOf(originalOrder.Where(o => o.InventoryID == entry.MainItem.ID).FirstOrDefault());
                            orders[orderItemIndex].Deleted = true;

                            con = DatabaseFunctions.OpenMySQLConnection();
                            DatabaseFunctions.DeleteOrderEntry(con, orders[orderItemIndex].ID, entry.MainItem.ID);
                            con.Close();
                        }

                        // Update order for the UI
                        SupplyOrdersList[index] = editSupplyOrderWindow.SupplyOrder;
                        SupplyOrdersList[index].DisplayName =
                            editSupplyOrderWindow.SupplyOrder.Supplier + " - " +
                            editSupplyOrderWindow.SupplyOrder.OrderDate.Month.ToString() +
                            "/" + editSupplyOrderWindow.SupplyOrder.OrderDate.Day.ToString() +
                            "/" + editSupplyOrderWindow.SupplyOrder.OrderDate.Year.ToString();
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

            if (!addresses.Any(a => a.ID == 0))
            {
                con = DatabaseFunctions.OpenMySQLConnection();
                Address blankAddress = new Address()
                {
                    ID = 0,
                    StreetName = string.Empty,
                    AddressNumber = 0,
                    City = string.Empty,
                    State = string.Empty,
                    ZipCode = 0
                };
                DatabaseFunctions.CreateAddressEntry(con, blankAddress);
                con.Close();
            }
        }

        private void RetrievePersons()
        {
            persons.Clear();
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            persons = DatabaseFunctions.GetPersonList(con);
            con.Close();

            if (!persons.Any(p => p.ID == 0))
            {
                con = DatabaseFunctions.OpenMySQLConnection();
                Person blankPerson = new Person()
                {
                    ID = 0,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    IsPatient = false
                };
                DatabaseFunctions.CreatePersonEntry(con, blankPerson);
                con.Close();
            }
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
            PatientList.Clear();
            foreach (Person person in persons)
            {
                if (!person.Deleted)
                {
                    ObservableCollection<WorkOrder> workOrders = new ObservableCollection<WorkOrder>(WorkOrdersList.Where(o => o.PatientID == person.ID).ToList());
                    allPersonsList.AddPatient(person, addresses.Where(a => a.ID == person.AddressID).FirstOrDefault(), workOrders);
                    if (person.IsPatient)
                    {
                        PatientList.AddPatient(person, addresses.Where(a => a.ID == person.AddressID).FirstOrDefault(), workOrders);
                    }
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
            SupplierList.Clear();
            foreach (Supplier supplier in suppliers)
            {
                if (!supplier.Deleted)
                {
                    ObservableCollection<SupplyOrder> supplyOrders = new ObservableCollection<SupplyOrder>(SupplyOrdersList.Where(o => o.Supplier == supplier.Name).ToList());
                    SupplierList.AddSupplier(supplier, addresses.Where(a => a.ID == supplier.AddressID).FirstOrDefault(), supplyOrders);
                }                
            }
        }

        private void PopulateEquipmentList()
        {
            EquipmentList.Clear();
            List<InventoryItem> equipmentItems = inventoryItems.Where(i => i.Type == "equipment").ToList();
            foreach (InventoryItem item in equipmentItems)
            {
                if (!item.Deleted)
                {
                    ObservableCollection<SupplyOrder> supplyOrders = new ObservableCollection<SupplyOrder>(SupplyOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    ObservableCollection<WorkOrder> workOrders = new ObservableCollection<WorkOrder>(WorkOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    EquipmentList.AddEquipment(item, workOrders, supplyOrders);
                }
                
            }
        }

        private void PopulateSupplyList()
        {
            SupplyList.Clear();
            List<InventoryItem> supplyItems = inventoryItems.Where(i => i.Type == "supply").ToList();
            foreach (InventoryItem item in supplyItems)
            {
                if (!item.Deleted)
                {
                    ObservableCollection<SupplyOrder> supplyOrders = new ObservableCollection<SupplyOrder>(SupplyOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    ObservableCollection<WorkOrder> workOrders = new ObservableCollection<WorkOrder>(WorkOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    SupplyList.AddSupply(item, workOrders, supplyOrders);
                }                
            }
        }

        private void PopulatePartList()
        {
            PartList.Clear();
            List<InventoryItem> partItems = inventoryItems.Where(i => i.Type == "part").ToList();
            foreach (InventoryItem item in partItems)
            {
                if (!item.Deleted)
                {
                    ObservableCollection<SupplyOrder> supplyOrders = new ObservableCollection<SupplyOrder>(SupplyOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    ObservableCollection<WorkOrder> workOrders = new ObservableCollection<WorkOrder>(WorkOrdersList.Where(o => o.InventoryEntries.Any(e =>
                                                                                                                        e.MainItem.ID == item.ID ||
                                                                                                                        e.RelatedItem.ID == item.ID)).ToList());
                    PartList.AddPart(item, workOrders, supplyOrders);
                }                
            }
        }

        private void PopulateSupplyOrderList()
        {
            SupplyOrdersList.Clear();
            foreach (Order order in orders)
            {
                ObservableCollection<InventoryEntry> invEntries = new ObservableCollection<InventoryEntry>();
                // Only create 1 SupplyOrder for each ID in the orders
                if (!order.Deleted && !SupplyOrdersList.Any(o => o.ID == order.ID))
                {
                    // Create collection of inventoryItem for the supply order
                    foreach (Order continuedOrder in orders.Where(o => o.ID == order.ID && !o.Deleted))
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
                        entry.RelatedItem = new InventoryListItem();
                        invEntries.Add(entry);
                    }

                    // Add the new supply order
                    SupplyOrdersList.AddSupplyOrder(order, invEntries);
                }           
            }
        }

        private void PopulateWorkOrderList()
        {
            WorkOrdersList.Clear();
            foreach (CustomerOrder order in customerOrders)
            {
                ObservableCollection<InventoryEntry> invEntries = new ObservableCollection<InventoryEntry>();
                if (!order.Deleted && !WorkOrdersList.Any(wo => wo.ID == order.ID))
                {
                    foreach (CustomerOrder continuedOrder in customerOrders.Where(co => co.ID == order.ID && !co.Deleted))
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
                        } else
                        {
                            entry.RelatedItem = new InventoryListItem();
                        }
                        invEntries.Add(entry);
                    }

                    Person customer = persons.Where(p => p.ID == order.PersonID).FirstOrDefault();
                    WorkOrdersList.AddWorkOrder(order, customer, invEntries);
                }                             
            }
        }

        private void ClearUnusedAddresses()
        {
            foreach (Address address in addresses)
            {
                if (!persons.Any(p => p.AddressID == address.ID)
                    && !suppliers.Any(s => s.AddressID == address.ID))
                {
                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.FullyDeleteAddressEntry(con, address.ID);
                    con.Close();
                }
            }
        }

        private Address CreateAddressEntry(Patient patient)
        {
            if (!(patient.StreetAddress == string.Empty))
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
                return newAddress;
            }
            else
            {
                if (!addresses.Any(a => a.ID == 0))
                {
                    Address blankAddress = new Address(0);
                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateAddressEntry(con, blankAddress);
                    con.Close();

                    addresses.Add(blankAddress);
                }
                return addresses.Where(a => a.ID == 0).FirstOrDefault();
            }
        }

        private Address CreateAddressEntry(AddSupplierWindow addSupplierWindow)
        {
            if (!(addSupplierWindow.StreetAddress == string.Empty))
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
                return newAddress;
            }
            else
            {
                if (!addresses.Any(a => a.ID == 0))
                {
                    Address blankAddress = new Address(0);
                    MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
                    DatabaseFunctions.CreateAddressEntry(con, blankAddress);
                    con.Close();

                    addresses.Add(blankAddress);
                }
                return addresses.Where(a => a.ID == 0).FirstOrDefault();
            }
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
        private void PatientSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _patientViewSource.View.Refresh();
        }

        private void PatientFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is Patient patient)
            {
                string filter = PatientSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             patient.DisplayName.ToLower().Contains(filter);
            }
        }

        private void EquipmentSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _equipmentViewSource.View.Refresh();
        }

        private void EquipmentFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is Equipment equipment)
            {
                string filter = EquipmentSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             equipment.Name.ToLower().Contains(filter);
            }
        }

        private void PartSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _partViewSource.View.Refresh();
        }

        private void PartFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is Part part)
            {
                string filter = PartSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             part.Name.ToLower().Contains(filter);
            }
        }

        private void SupplySearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _supplyViewSource.View.Refresh();
        }

        private void SupplyFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is Supply supply)
            {
                string filter = SupplySearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             supply.Name.ToLower().Contains(filter);
            }
        }

        private void SupplierSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _supplierViewSource.View.Refresh();
        }

        private void SupplierFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is SupplierL supplier)
            {
                string filter = SupplierSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             supplier.Name.ToLower().Contains(filter);
            }
        }

        private void WorkOrderSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workOrderViewSource.View.Refresh();
        }

        private void WorkOrderFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is WorkOrder workOrder)
            {
                string filter = WorkOrderSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             workOrder.DisplayName.ToLower().Contains(filter);
            }
        }

        private void SupplyOrderSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _supplyOrderViewSource.View.Refresh();
        }

        private void SupplyOrderFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is SupplyOrder supplyOrder)
            {
                string filter = SupplyOrderSearchBox.Text.Trim().ToLower();

                e.Accepted = string.IsNullOrWhiteSpace(filter) ||
                             supplyOrder.DisplayName.ToLower().Contains(filter);
            }
        }

        private void UpdateQuantityInItemList(string type, uint itemID, int quantity)
        {
            switch (type)
            {
                case "equipment":
                    Equipment equip = EquipmentList.Where(e => e.ID == itemID).FirstOrDefault();
                    int eIndex = EquipmentList.IndexOf(equip);
                    EquipmentList[eIndex].Quantity = quantity;
                    break;
                case "supply":
                    Supply supply = SupplyList.Where(s => s.ID == itemID).FirstOrDefault();
                    int sIndex = SupplyList.IndexOf(supply);
                    SupplyList[sIndex].Quantity = quantity;
                    break;
                case "part":
                    Part part = PartList.Where(p => p.ID == itemID).FirstOrDefault();
                    int pIndex = PartList.IndexOf(part);
                    PartList[pIndex].Quantity = quantity;
                    break;
            }
        }

        private TabItem _previousTab = null;
        private bool _hasLoaded = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PatientListBox.SelectedIndex = -1;
            _hasLoaded = true;
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(MainTabControl.SelectedItem is TabItem selectedTab) || selectedTab == _previousTab)
            {
                return;
            }

            if (!_hasLoaded)
            {
                _previousTab = selectedTab;
                return;
            }

            _previousTab = selectedTab;

            if (selectedTab == PatientTab)
            {
                PopulatePatientList();
            }
            else if (selectedTab == InventoryTab)
            {
                PopulateEquipmentList();
                PopulateSupplyList();
                PopulatePartList();
            }
            else if (selectedTab == SupplierTab)
            {
                PopulateSupplierList();
            }
            else if (selectedTab == OrderTicketTab)
            {
                PopulateWorkOrderList();
                PopulateSupplyOrderList();
            }
        }
    }
}