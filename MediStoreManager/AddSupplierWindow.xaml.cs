using System;
using System.Collections.Generic;
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

namespace MediStoreManager
{
    /// <summary>
    /// Interaction logic for AddSupplierWindow.xaml
    /// </summary>
    public partial class AddSupplierWindow : Window
    {
        public string BusinessName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }

        public AddSupplierWindow()
        {
            BusinessName = "";
            PhoneNumber = "";
            StreetAddress = "";
            City = "";
            ZipCode = "";
            State = "";
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            BusinessName = NameTextBox.Text;
            PhoneNumber = BusinessPhoneTextBox.Text;
            StreetAddress = StreetAddressTextBox.Text;
            City = CityTextBox.Text;
            ZipCode = ZipTextBox.Text;
            State = StateTextBox.Text;
            this.DialogResult = true;
        }
    }
}
