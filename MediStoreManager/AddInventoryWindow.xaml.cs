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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for AddInventoryWindow.xaml
    /// </summary>
    public partial class AddInventoryWindow : Window
    {
        public string InventoryName { get; private set; }
        public string Type { get; private set; }
        public string Size { get; private set; }
        public string Brand { get; private set; }
        public string Quantity { get; private set; }
        public string Price { get; private set; }
        public string RetailPrice { get; private set; }
        public string RentalPrice { get; private set; }
        public string SerialNumber { get; private set; }

        public AddInventoryWindow()
        {
            InventoryName = "";
            Type = "";
            Size = "";
            Brand = "";
            Quantity = "";
            Price = "";
            RetailPrice = "";
            RentalPrice = "";
            SerialNumber = "";
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            InventoryName = InventoryNameTextBox.Text;
            if (TypeComboBox.SelectedItem is string selectedType && !string.IsNullOrWhiteSpace(selectedType)) { Type = selectedType; }
            Size = SizeTextBox.Text;
            Brand = BrandTextBox.Text;
            Quantity = QuantityTextBox.Text;
            Price = PriceTextBox.Text;
            RetailPrice = RetailPriceTextBox.Text;
            RentalPrice = RentalPriceTextBox.Text;
            SerialNumber = SerialNumberTextBox.Text;
            this.DialogResult = true;
        }
    }
}
