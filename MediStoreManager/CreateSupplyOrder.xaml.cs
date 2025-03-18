using System;
using System.Collections.Generic;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for CreateSupplyOrder.xaml
    /// </summary>
    public partial class CreateSupplyOrder : Window
    {
        public string Supplier { get; private set; }
        public string InventoryID { get; private set; }
        public string Quantity { get; private set; }
        public string ShippingMethod { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime ReceivedDate { get; private set; }

        public CreateSupplyOrder()
        {
            Supplier = "";
            InventoryID = "";
            Quantity = "";
            ShippingMethod = "";
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            Supplier = SupplierTextBox.Text;
            InventoryID = InventoryTextBox.Text;
            Quantity = QuantityTextBox.Text;
            ShippingMethod = ShippingMethodTextBox.Text;
            if (OrderDateDatePicker.SelectedDate.HasValue) { OrderDate = OrderDateDatePicker.SelectedDate.Value; }
            if (ReceivedDateDatePicker.SelectedDate.HasValue) { ReceivedDate = ReceivedDateDatePicker.SelectedDate.Value; }
            this.DialogResult = true;
        }
    }
}
