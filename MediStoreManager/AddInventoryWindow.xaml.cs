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
        public int Quantity { get; private set; }
        public string Price { get; private set; }
        public string RetailPrice { get; private set; }
        public string RentalPrice { get; private set; }
        public string SerialNumber { get; private set; }
        public bool IsEditMode { get; private set; }
        public bool DeleteItem { get; private set; }
        public Equipment Equipment { get; private set; }
        public Supply Supply { get; private set; }
        public Part Part { get; private set; }
        public uint ID { get; private set; }
        public bool? IsRental = null;
        public bool isAdmin { get; private set; }

        public AddInventoryWindow()
        {
            InventoryName = "";
            Type = "";
            Size = "";
            Brand = "";
            Price = "";
            RetailPrice = "";
            RentalPrice = "";
            SerialNumber = "";
            IsEditMode = false;
            InitializeComponent();
            DataContext = this;
        }

        public AddInventoryWindow(Equipment equipment = null, Part part = null, Supply supply = null, bool isEditMode = true)
        {
            InitializeComponent();
            IsEditMode = isEditMode;
            isAdmin = MainWindow.IsAdmin;
            if (equipment != null)
            {
                InventoryNameTextBox.Text = equipment.Name;
                TypeComboBox.SelectedItem = equipment.Type;
                SizeTextBox.Text = equipment.Size;
                BrandTextBox.Text = equipment.Brand;
                QuantityTextBox.Text = equipment.Quantity.ToString();
                PriceTextBox.Text = equipment.Price;
                RetailPriceTextBox.Text = equipment.RetailPrice;
                RentalPriceTextBox.Text = equipment.RentalPrice;
                SerialNumberTextBox.Text = equipment.SerialNumber;
                ID = equipment.ID;

            }
            else if (part != null)
            {
                InventoryNameTextBox.Text = part.Name;
                TypeComboBox.SelectedItem = part.Type;
                SizeTextBox.Text = part.Size;
                BrandTextBox.Text = part.Brand;
                QuantityTextBox.Text = part.Quantity.ToString();
                PriceTextBox.Text = part.Price;
                RetailPriceTextBox.Text = part.RetailPrice;
                ID = part.ID;
            }
            else if (supply != null)
            {
                InventoryNameTextBox.Text = supply.Name;
                TypeComboBox.SelectedItem = supply.Type;
                SizeTextBox.Text = supply.Size;
                BrandTextBox.Text = supply.Brand;
                QuantityTextBox.Text = supply.Quantity.ToString();
                PriceTextBox.Text = supply.Price;
                RetailPriceTextBox.Text = supply.RetailPrice;
                ID = supply.ID;
            }
            DataContext = this;
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
            if ((!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity < 0) && !string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                MessageBox.Show($"Please enter a valid quantity", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Quantity = int.TryParse(QuantityTextBox.Text, out int qty) ? qty : 0;
            Price = PriceTextBox.Text;
            RetailPrice = RetailPriceTextBox.Text;
            RentalPrice = RentalPriceTextBox.Text;
            SerialNumber = SerialNumberTextBox.Text;
            if (Type.Equals("equipment"))
            {
                if (YesRadioButton.IsChecked == true)
                {
                    IsRental = true;
                }
                else if (NoRadioButton.IsChecked == true)
                {
                    IsRental = false;
                }
                else if (NotApplicableRadioButton.IsChecked == true)
                {
                    IsRental = null;
                }
            }

            if (IsEditMode)
            {
                if (Type.Equals("equipment"))
                {
                    Equipment = new Equipment
                    {
                        ID = ID,
                        Name = InventoryName,
                        Type = Type,
                        Size = Size,
                        Brand = Brand,
                        Quantity = Quantity,
                        Price = Price,
                        RetailPrice = RetailPrice,
                        RentalPrice = RentalPrice,
                        SerialNumber = SerialNumber,
                        IsRental = IsRental
                    };
                }
                else if (Type.Equals("supply"))
                {
                    Supply = new Supply
                    {
                        ID = ID,
                        Name = InventoryName,
                        Type = Type,
                        Size = Size,
                        Brand = Brand,
                        Quantity = Quantity,
                        Price = Price,
                        RetailPrice = RetailPrice,
                    };
                }
                else if (Type.Equals("part"))
                {
                    Part = new Part
                    {
                        ID = ID,
                        Name = InventoryName,
                        Type = Type,
                        Size = Size,
                        Brand = Brand,
                        Quantity = Quantity,
                        Price = Price,
                        RetailPrice = RetailPrice,
                    };
                }
            }
            DeleteItem = false;
            this.DialogResult = true;
        }

        private void DeleteInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem = true;
            this.DialogResult = true;
        }
    }
}
