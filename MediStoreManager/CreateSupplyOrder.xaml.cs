using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for CreateSupplyOrder.xaml
    /// </summary>
    public partial class CreateSupplyOrder : Window
    {
        private ObservableCollection<SupplierL> _suppliers;
        private ObservableCollection<SupplierL> _filteredSuppliers;
        private DispatcherTimer _timer;
        private bool _suppressTextChanged;

        private ObservableCollection<InventoryEntry> InventoryEntries = new ObservableCollection<InventoryEntry>();
        private ObservableCollection<InventoryListItem> AllInventoryItems;

        public string Supplier { get; private set; }
        public string ShippingMethod { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime ReceivedDate { get; private set; }
        public SupplierL SelectedSupplier { get; private set; }
        public ObservableCollection<InventoryEntry> FinalInventoryEntries { get; private set; }
        public SupplyOrder SupplyOrder { get; private set; }
        public bool IsEditMode { get; private set; }
        public bool DeleteOrder { get; private set; }
        public uint ID { get; private set; }
        public bool isAdmin { get; private set; }

        public CreateSupplyOrder(ObservableCollection<SupplierL> suppliers, ObservableCollection<Equipment> equipment, ObservableCollection<Supply> supplies, ObservableCollection<Part> parts)
        {
            Supplier = "";
            ShippingMethod = "";
            InitializeComponent();
            _suppliers = suppliers;
            _filteredSuppliers = new ObservableCollection<SupplierL>(suppliers);
            SupplierResultsListBox.ItemsSource = _filteredSuppliers;
            FinalInventoryEntries = new ObservableCollection<InventoryEntry>();

            // Debounce timer setup
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(250) };
            _timer.Tick += FilterTimer_Tick;

            // Convert Equipment and Supplies into InventoryListItems
            AllInventoryItems = new ObservableCollection<InventoryListItem>(
                equipment.Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", QuantitySelected = 0 })
                .Concat(
                supplies.Select(s => new InventoryListItem { ID = s.ID, Name = s.Name, Type = "Supply", QuantitySelected = 0 }))
                .Concat(
                parts.Select(p => new InventoryListItem { ID = p.ID, Name = p.Name, Type = "Part", QuantitySelected = 0 }))
            );

            // Bind the ItemsControl to the InventoryEntries collection
            InventoryItemsControl.ItemsSource = InventoryEntries;
            IsEditMode = false;
            DataContext = this;
        }

        public CreateSupplyOrder(ObservableCollection<SupplierL> suppliers, ObservableCollection<Equipment> equipment, ObservableCollection<Supply> supplies, ObservableCollection<Part> parts, SupplyOrder supplyOrder)
        {
            InitializeComponent();
            _suppliers = suppliers;
            _filteredSuppliers = new ObservableCollection<SupplierL>(suppliers);
            SupplierResultsListBox.ItemsSource = _filteredSuppliers;
            FinalInventoryEntries = new ObservableCollection<InventoryEntry>();

            // Debounce timer setup
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(250) };
            _timer.Tick += FilterTimer_Tick;

            // Convert Equipment and Supplies into InventoryListItems
            AllInventoryItems = new ObservableCollection<InventoryListItem>(
                equipment.Select(e => new InventoryListItem { ID = e.ID, Name = e.Name, Type = "Equipment", QuantitySelected = 0 })
                .Concat(
                supplies.Select(s => new InventoryListItem { ID = s.ID, Name = s.Name, Type = "Supply", QuantitySelected = 0 }))
                .Concat(
                parts.Select(p => new InventoryListItem { ID = p.ID, Name = p.Name, Type = "Part", QuantitySelected = 0 }))
            );

            // Bind the ItemsControl to the InventoryEntries collection
            IsEditMode = true;
            isAdmin = MainWindow.IsAdmin;
            ID = supplyOrder.ID;
            SelectedSupplier = suppliers.FirstOrDefault(s => s.Name == supplyOrder.Supplier);
            _suppressTextChanged = true;

            // Update the textbox explicitly
            SupplierSearchBox.Text = $"{SelectedSupplier.Name}";

            // Clear filter (show full list again)
            _filteredSuppliers.Clear();
            foreach (var supplier in _suppliers/*.Take(100)*/) // Optionally limit again to avoid performance issues
                _filteredSuppliers.Add(supplier);

            _suppressTextChanged = false;
            InventoryEntries = new ObservableCollection<InventoryEntry>(supplyOrder.InventoryEntries);
            ShippingMethodTextBox.Text = supplyOrder.ShippingMethod;
            OrderDateDatePicker.SelectedDate = supplyOrder.OrderDate;
            ReceivedDateDatePicker.SelectedDate = supplyOrder.ReceivedDate;
            InventoryItemsControl.ItemsSource = InventoryEntries;
            DataContext = this;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            if (SelectedSupplier != null) { Supplier = SelectedSupplier.Name; }
            if (InventoryEntries != null) { FinalInventoryEntries = InventoryEntries; }
            ShippingMethod = ShippingMethodTextBox.Text;
            if (OrderDateDatePicker.SelectedDate.HasValue) { OrderDate = OrderDateDatePicker.SelectedDate.Value; }
            if (ReceivedDateDatePicker.SelectedDate.HasValue) { ReceivedDate = ReceivedDateDatePicker.SelectedDate.Value; }
            if (IsEditMode)
            {
                SupplyOrder = new SupplyOrder
                {
                    ID = ID,
                    Supplier = Supplier,
                    ShippingMethod = ShippingMethod,
                    OrderDate = OrderDate,
                    ReceivedDate = ReceivedDate,
                    InventoryEntries = FinalInventoryEntries
                };
            }
            DeleteOrder = false;
            this.DialogResult = true;
        }

        private void SupplierSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suppressTextChanged)
                return;

            _timer.Stop();
            _timer.Start();
        }

        private void FilterTimer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            string filter = SupplierSearchBox.Text.Trim();

            Task.Run(() =>
            {
                var matches = string.IsNullOrEmpty(filter)
                    ? _suppliers./*Take(100).*/ToList() // limit initial display for speed
                    : _suppliers.Where(s =>
                          s.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                      ).ToList();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    _filteredSuppliers.Clear();
                    foreach (var supplier in matches)
                        _filteredSuppliers.Add(supplier);
                });
            });
        }

        private void SupplierResultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupplierResultsListBox.SelectedItem is SupplierL selectedSupplier)
            {
                SelectedSupplier = selectedSupplier;

                // Temporarily suppress TextChanged event to prevent unwanted filter triggering
                _suppressTextChanged = true;

                // Update the textbox explicitly
                SupplierSearchBox.Text = $"{selectedSupplier.Name}";

                // Clear filter (show full list again)
                _filteredSuppliers.Clear();
                foreach (var supplier in _suppliers/*.Take(100)*/) // Optionally limit again to avoid performance issues
                    _filteredSuppliers.Add(supplier);

                _suppressTextChanged = false;
            }
        }

        private void AddNewInventory_Click(object sender, RoutedEventArgs e)
        {
            InventorySelectionPopup popup = new InventorySelectionPopup(AllInventoryItems, true, false);
            popup.Owner = this;
            bool? result = popup.ShowDialog();

            if (result == true && popup.SelectedInventory != null)
            {
                var selectedItem = popup.SelectedInventory;

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

        private void RemoveInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is InventoryEntry entry)
            {
                InventoryEntries.Remove(entry);
            }
        }

        private void DeleteSupplyOrderButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder = true;
            this.DialogResult = true;
        }
    }
}
