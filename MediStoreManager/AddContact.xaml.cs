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
    /// Interaction logic for AddContact.xaml
    /// </summary>
    /// public string FirstName { get; private set; }
    public partial class AddContact : Window
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string HomePhone { get; private set; }
        public string CellPhone { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string InsuranceProvider { get; private set; }
        public AddContact()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            HomePhone = "";
            CellPhone = "";
            StreetAddress = "";
            City = "";
            ZipCode = "";
            State = "";
            InsuranceProvider = "";
            InitializeComponent();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            FirstName = FirstNameTextBox.Text;
            MiddleName = MiddleNameTextBox.Text;
            LastName = LastNameTextBox.Text;
            HomePhone = HomePhoneTextBox.Text;
            CellPhone = CellPhoneTextBox.Text;
            StreetAddress = StreetAddressTextBox.Text;
            City = CityTextBox.Text;
            ZipCode = ZipTextBox.Text;
            State = StateTextBox.Text;
            InsuranceProvider = InsuranceTextBox.Text;
            this.DialogResult = true;
        }
    }
}
