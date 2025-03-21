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

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for InventorySelectionPopup.xaml
    /// </summary>
    public partial class InventorySelectionPopup : Window
    {
        private ObservableCollection<InventoryListItem> _allInventoryItems;
        private ObservableCollection<InventoryListItem> _filteredItems = new ObservableCollection<InventoryListItem>();
        private bool _suppressFiltering = false;
        private bool _allowQuantitySelection; // ✅ Control quantity selection visibility
        private bool _enforceMaxQuantity;

        public InventoryListItem SelectedInventory { get; private set; }
        public int SelectedQuantity { get; private set; }

        public InventorySelectionPopup(ObservableCollection<InventoryListItem> inventoryItems, bool allowQuantitySelection, bool enforceMaxQuantity)
        {
            InitializeComponent();
            _allowQuantitySelection = allowQuantitySelection;
            _enforceMaxQuantity = enforceMaxQuantity;
            _allInventoryItems = inventoryItems;
            _filteredItems = new ObservableCollection<InventoryListItem>(inventoryItems);
            InventoryListBox.ItemsSource = _filteredItems;

            // ✅ Hide quantity box if selection is disabled
            QuantityTextBox.Visibility = _allowQuantitySelection ? Visibility.Visible : Visibility.Collapsed;
            QuantityTextBlock.Visibility = _allowQuantitySelection ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suppressFiltering) return; 

            string filter = SearchBox.Text.Trim().ToLower();
            _filteredItems.Clear();
            foreach (var item in _allInventoryItems.Where(i => i.Name.ToLower().Contains(filter)))
            {
                _filteredItems.Add(item);
            }
        }

        private void InventoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InventoryListBox.SelectedItem is InventoryListItem selected)
            {
                SelectedInventory = selected;
                _suppressFiltering = true;
                SearchBox.Text = selected.Name;

                // ✅ Automatically set quantity to max available if selection is enabled
                if (_allowQuantitySelection)
                {
                    QuantityTextBox.Text = "1";
                }

                _suppressFiltering = false;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedInventory == null)
            {
                MessageBox.Show("Please select an inventory item.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_allowQuantitySelection && _enforceMaxQuantity)
            {
                // ✅ Validate quantity input
                if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0 || quantity > SelectedInventory.AllowedQuantity)
                {
                    MessageBox.Show($"Please enter a valid quantity (1-{SelectedInventory.AllowedQuantity}).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                SelectedQuantity = quantity;
                SelectedInventory.QuantitySelected = quantity;
            } 
            else if (_allowQuantitySelection && !_enforceMaxQuantity)
            {
                if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show($"Please enter a valid quantity (1-{SelectedInventory.AllowedQuantity}).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                SelectedQuantity = quantity;
                SelectedInventory.QuantitySelected = quantity;
            }
            else
            {
                SelectedQuantity = 1; // Default to 1 when quantity is not used
            }

            DialogResult = true;
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _suppressFiltering = false; 
        }
    }
}
