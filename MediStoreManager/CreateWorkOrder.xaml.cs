using System;
using System.Collections.Generic;
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

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for CreateWorkOrder.xaml
    /// </summary>
    public partial class CreateWorkOrder : Window
    {
        public string Type { get; private set; }
        public string PatientID { get; private set; }
        public string Quantity { get; private set; }
        public string InventoryID { get; private set; }
        // MAYBE HAVE THIS VALUE BE PRE-SELECTED TO TODAY'S CURRENT DATE
        public DateTime OrderDate { get; private set; }
        public DateTime DateOfPayment { get; private set; }
        public string RelatedInventoryID { get; private set; }
        public string Notes { get; private set; }

        public CreateWorkOrder()
        {
            Type = "";
            PatientID = "";
            Quantity = "";
            InventoryID = "";
            RelatedInventoryID = "";
            Notes = "";
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            if (TypeComboBox.SelectedItem is string selectedType && !string.IsNullOrWhiteSpace(selectedType)) { Type = selectedType; }
            PatientID = PatientTextBox.Text;
            InventoryID = InventoryTextBox.Text;
            Quantity = QuantityTextBox.Text;
            if (OrderDateDatePicker.SelectedDate.HasValue) { OrderDate = OrderDateDatePicker.SelectedDate.Value; }
            if (DateOfPaymentDatePicker.SelectedDate.HasValue) { DateOfPayment = DateOfPaymentDatePicker.SelectedDate.Value; }
            RelatedInventoryID = RelatedInventoryTextBox.Text;
            Notes = NotesTextBox.Text;
            this.DialogResult = true;
        }
    }
}
