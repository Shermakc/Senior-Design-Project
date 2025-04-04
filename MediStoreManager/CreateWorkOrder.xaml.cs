using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
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
using System.Windows.Threading;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for CreateWorkOrder.xaml
    /// </summary>
    public partial class CreateWorkOrder : Window
    {
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Patient> _filteredPatients;
        private DispatcherTimer _timer;
        private bool _suppressTextChanged;

        private ObservableCollection<InventoryEntry> InventoryEntries = new ObservableCollection<InventoryEntry>();
        private ObservableCollection<InventoryListItem> AllInventoryItems;
        private ObservableCollection<InventoryListItem> AllRelatedInventory;

        public string Type { get; private set; }
        public uint PatientID { get; private set; }
        // MAYBE HAVE THIS VALUE BE PRE-SELECTED TO TODAY'S CURRENT DATE
        public DateTime OrderDate { get; private set; }
        public DateTime DateOfPayment { get; private set; }
        public string Notes { get; private set; }
        public Patient SelectedPatient { get; private set; }
        public ObservableCollection<InventoryEntry> FinalInventoryEntries = new ObservableCollection<InventoryEntry>();
        public WorkOrder WorkOrder { get; private set; }
        public bool IsEditMode { get; private set; }
        public bool DeleteOrder { get; private set; }
        public uint ID { get; private set; }
        public bool isAdmin { get; private set; }

        public CreateWorkOrder(ObservableCollection<Patient> patients, ObservableCollection<Equipment> equipment, ObservableCollection<Supply> supplies, ObservableCollection<Part> parts)
        {
            Type = "";
            Notes = "";
            InitializeComponent();
            _patients = patients;
            _filteredPatients = new ObservableCollection<Patient>(patients);
            PatientResultsListBox.ItemsSource = _filteredPatients;

            // Debounce timer setup
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(250) };
            _timer.Tick += FilterTimer_Tick;

            // Convert Equipment and Supplies into InventoryListItems
            AllInventoryItems = new ObservableCollection<InventoryListItem>(
                equipment.Where(e => e.Quantity > 0).Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", AllowedQuantity = e.Quantity, QuantitySelected = 0 })
                .Concat(
                supplies.Where(s => s.Quantity > 0).Select(s => new InventoryListItem { ID = s.ID, Name = s.Name, Type = "Supply", AllowedQuantity = s.Quantity, QuantitySelected = 0 }))
                .Concat(
                parts.Where(p => p.Quantity > 0).Select(p => new InventoryListItem { ID = p.ID, Name = p.Name, Type = "Part", AllowedQuantity = p.Quantity, QuantitySelected = 0 }))
            );

            AllRelatedInventory = new ObservableCollection<InventoryListItem>(
                equipment.Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", AllowedQuantity = 100, QuantitySelected = 0 })
            );

            // Bind the ItemsControl to the InventoryEntries collection
            InventoryItemsControl.ItemsSource = InventoryEntries;
            IsEditMode = false;
            DataContext = this;

        }

        public CreateWorkOrder(ObservableCollection<Patient> patients, ObservableCollection<Equipment> equipment, ObservableCollection<Supply> supplies, ObservableCollection<Part> parts, WorkOrder workOrder)
        {
            IsEditMode = true;
            isAdmin = MainWindow.IsAdmin;
            InitializeComponent();
            _patients = patients;
            _filteredPatients = new ObservableCollection<Patient>(patients);
            PatientResultsListBox.ItemsSource = _filteredPatients;

            // Debounce timer setup
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(250) };
            _timer.Tick += FilterTimer_Tick;

            // Convert Equipment and Supplies into InventoryListItems
            AllInventoryItems = new ObservableCollection<InventoryListItem>(
                equipment.Where(e => e.Quantity > 0).Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", AllowedQuantity = e.Quantity, QuantitySelected = 0 })
                .Concat(
                supplies.Where(s => s.Quantity > 0).Select(s => new InventoryListItem { ID = s.ID, Name = s.Name, Type = "Supply", AllowedQuantity = s.Quantity, QuantitySelected = 0 }))
                .Concat(
                parts.Where(p => p.Quantity > 0).Select(p => new InventoryListItem { ID = p.ID, Name = p.Name, Type = "Part", AllowedQuantity = p.Quantity, QuantitySelected = 0 }))
            );

            AllRelatedInventory = new ObservableCollection<InventoryListItem>(
                equipment.Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", AllowedQuantity = 100, QuantitySelected = 0 })
            );

            ID = workOrder.ID;
            TypeComboBox.SelectedItem = workOrder.Type;
            SelectedPatient = patients.FirstOrDefault(p => p.ID == workOrder.PatientID);
            _suppressTextChanged = true;

            if (SelectedPatient != null)
            {
                // Update the textbox explicitly
                PatientSearchBox.Text = $"{SelectedPatient.DisplayName} [{SelectedPatient.ID}]";
            }

            // Clear filter (show full list again)
            _filteredPatients.Clear();
            foreach (var patient in _patients/*.Take(100)*/) // Optionally limit again to avoid performance issues
                _filteredPatients.Add(patient);

            _suppressTextChanged = false;
            OrderDateDatePicker.SelectedDate = workOrder.Date;
            DateOfPaymentDatePicker.SelectedDate = workOrder.PaymentDate;
            InventoryEntries = new ObservableCollection<InventoryEntry>(workOrder.InventoryEntries);
            NotesTextBox.Text = workOrder.Notes;
            InventoryItemsControl.ItemsSource = InventoryEntries;
            DataContext = this;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            if (TypeComboBox.SelectedItem is string selectedType && !string.IsNullOrWhiteSpace(selectedType)) { Type = selectedType; }
            if (SelectedPatient != null) { PatientID = SelectedPatient.ID; }
            if (OrderDateDatePicker.SelectedDate.HasValue) { OrderDate = OrderDateDatePicker.SelectedDate.Value; }
            if (DateOfPaymentDatePicker.SelectedDate.HasValue) { DateOfPayment = DateOfPaymentDatePicker.SelectedDate.Value; }
            if (InventoryEntries != null) { FinalInventoryEntries = InventoryEntries; }
            Notes = NotesTextBox.Text;
            if (IsEditMode == true)
            {
                WorkOrder = new WorkOrder
                {
                    ID = ID,
                    Type = Type,
                    PatientID = PatientID,
                    Date = OrderDate,
                    PaymentDate = DateOfPayment,
                    Notes = Notes,
                    InventoryEntries = FinalInventoryEntries
                };
            }
            DeleteOrder = false;
            this.DialogResult = true;
        }

        private void PatientSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suppressTextChanged)
                return;

            _timer.Stop();
            _timer.Start();
        }

        private void FilterTimer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            string filter = PatientSearchBox.Text.Trim();

            Task.Run(() =>
            {
                var matches = string.IsNullOrEmpty(filter)
                    ? _patients./*Take(100).*/ToList() // limit initial display for speed
                    : _patients.Where(p =>
                          p.DisplayName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                          p.ID.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                      ).ToList();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    _filteredPatients.Clear();
                    foreach (var patient in matches)
                        _filteredPatients.Add(patient);
                });
            });
        }

        private void PatientResultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PatientResultsListBox.SelectedItem is Patient selectedPatient)
            {
                SelectedPatient = selectedPatient;

                // Temporarily suppress TextChanged event to prevent unwanted filter triggering
                _suppressTextChanged = true;

                // Update the textbox explicitly
                PatientSearchBox.Text = $"{selectedPatient.DisplayName} [{selectedPatient.ID}]";

                // Clear filter (show full list again)
                _filteredPatients.Clear();
                foreach (var patient in _patients/*.Take(100)*/) // Optionally limit again to avoid performance issues
                    _filteredPatients.Add(patient);

                _suppressTextChanged = false;
            }
        }

        private void AddNewInventory_Click(object sender, RoutedEventArgs e)
        {
            InventorySelectionPopup popup = new InventorySelectionPopup(AllInventoryItems, true, true);
            popup.Owner = this;
            bool? result = popup.ShowDialog();

            if (result == true && popup.SelectedInventory != null)
            {
                var selectedItem = popup.SelectedInventory;

                var existingItem = AllInventoryItems.FirstOrDefault(i => i.ID == selectedItem.ID);
                if (existingItem != null)
                {
                    existingItem.AllowedQuantity -= selectedItem.QuantitySelected; // Reduce available quantity

                    if (existingItem.AllowedQuantity <= 0)
                    {
                        AllInventoryItems.Remove(existingItem);
                    }
                }

                InventoryEntries.Add(new InventoryEntry
                {
                    MainItem = new InventoryListItem
                    {
                        ID = selectedItem.ID,
                        Name = selectedItem.Name,
                        Type = selectedItem.Type,
                        QuantitySelected = selectedItem.QuantitySelected // User-selected quantity
                    },
                    RelatedItem = null
                });
            }
        }

        private void AddRelatedInventory_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is InventoryEntry inventoryEntry)
            {
                InventorySelectionPopup popup = new InventorySelectionPopup(AllRelatedInventory, false, false); // Quantity disabled
                popup.Owner = this;
                bool? result = popup.ShowDialog();

                if (result == true && popup.SelectedInventory != null)
                {
                    inventoryEntry.RelatedItem = popup.SelectedInventory;

                    InventoryItemsControl.Items.Refresh();
                }
            }
        }

        private void RemoveInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is InventoryEntry entry)
            {
                var existingItem = AllInventoryItems.FirstOrDefault(i => i.ID == entry.MainItem.ID);
                if (existingItem != null)
                {
                    existingItem.AllowedQuantity += entry.MainItem.QuantitySelected;
                } else
                {
                    AllInventoryItems.Add(new InventoryListItem
                    {
                        ID = entry.MainItem.ID,
                        Name = entry.MainItem.Name,
                        Type = entry.MainItem.Type,
                        QuantitySelected = 0,
                        AllowedQuantity = entry.MainItem.QuantitySelected
                    });
                }
                InventoryEntries.Remove(entry);
            }
        }

        private void RemoveRelatedInventory_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is InventoryEntry inventoryEntry)
            {
                inventoryEntry.RelatedItem = null;

                InventoryItemsControl.Items.Refresh();
            }
        }

        private void DeleteWorkOrderButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder = true;
            this.DialogResult = true;
        }
    }

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
