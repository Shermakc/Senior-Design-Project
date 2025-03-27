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
    /// Interaction logic for AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        private ObservableCollection<Patient> _contacts = new ObservableCollection<Patient>();
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
        public ObservableCollection<Patient> FinalContacts { get; private set; }
        public Patient Patient { get; private set; }
        public bool IsEditMode { get; private set; }
        public bool DeletePatient { get; private set; }
        public uint ID { get; private set; }
        public string DisplayName { get; private set; }

        public AddPatientWindow()
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
            FinalContacts = new ObservableCollection<Patient>();
            IsEditMode = false;
            InitializeComponent();
            ContactItemsControl.ItemsSource = _contacts;
            DataContext = this;
        }

        public AddPatientWindow(Patient patient, bool isEditMode = true)
        {
            IsEditMode = isEditMode;
            InitializeComponent();
            FirstNameTextBox.Text = patient.FirstName;
            MiddleNameTextBox.Text = patient.MiddleName;
            LastNameTextBox.Text = patient.LastName;
            HomePhoneTextBox.Text = patient.HomePhone;
            CellPhoneTextBox.Text = patient.CellPhone;
            StreetAddressTextBox.Text = patient.StreetAddress;
            CityTextBox.Text = patient.City;
            ZipTextBox.Text = patient.ZipCode;
            StateTextBox.Text = patient.State;
            InsuranceTextBox.Text = patient.Insurance;
            _contacts = patient.Contacts;
            ID = patient.ID;
            DisplayName = patient.DisplayName;
            DataContext = this;
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
            if (_contacts != null) { FinalContacts = _contacts; }
            if (IsEditMode == true)
            {
                Patient = new Patient
                {
                    ID = ID,
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    LastName = LastName,
                    HomePhone = HomePhone,
                    CellPhone = CellPhone,
                    StreetAddress = StreetAddress,
                    City = City,
                    ZipCode = ZipCode,
                    State = State,
                    Insurance = InsuranceProvider,
                    Contacts = FinalContacts,
                    DisplayName = DisplayName
                };
            }
            DeletePatient = false;
            this.DialogResult = true;
        }

        private void AddNewContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContact popup = new AddContact();
            popup.Owner = this;
            bool? result = popup.ShowDialog();

            if (result == true)
            {
                _contacts.Add(new Patient
                {
                    FirstName = popup.FirstName,
                    MiddleName = popup.MiddleName,
                    LastName = popup.LastName,
                    HomePhone = popup.HomePhone,
                    CellPhone = popup.CellPhone,
                    StreetAddress = popup.StreetAddress,
                    City = popup.City,
                    ZipCode = popup.ZipCode,
                    State = popup.State,
                    Insurance = popup.InsuranceProvider,
                    DisplayName = popup.LastName + ", " + popup.FirstName
                });
            }
        }

        private void RemoveContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Patient contact)
            {
                _contacts.Remove(contact);
            }
        }

        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            DeletePatient = true;
            this.DialogResult = true;
        }
    }
}
