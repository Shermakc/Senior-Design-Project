using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Patient : INotifyPropertyChanged
    {
        private uint _ID;
        private string _firstname;
        private string _lastname;
        private string _middlename;
        private string _homephone;
        private string _cellphone;
        private string _streetaddress;
        private string _city;
        private string _zipcode;
        private string _state;
        private string _displayname;
        private string _insurance;
        private uint _contactID;
        private string _relationshipToPatient;
        private ObservableCollection<Patient> _contacts;

        public uint ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string FirstName { get => _firstname; set { _firstname = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get => _lastname; set { _lastname = value; OnPropertyChanged(nameof(LastName)); } }
        public string MiddleName { get => _middlename; set { _middlename = value; OnPropertyChanged(nameof(MiddleName)); } }
        public string HomePhone { get => _homephone; set { _homephone = value; OnPropertyChanged(nameof(HomePhone)); } }
        public string CellPhone { get => _cellphone; set { _cellphone = value; OnPropertyChanged(nameof(CellPhone)); } }
        public string StreetAddress { get => _streetaddress; set { _streetaddress = value; OnPropertyChanged(nameof(StreetAddress)); } }
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }
        public string ZipCode { get => _zipcode; set { _zipcode = value; OnPropertyChanged(nameof(ZipCode)); } }
        public string State { get => _state; set { _state = value; OnPropertyChanged(nameof(State)); } }
        public string DisplayName { get => _displayname; set { _displayname = value; OnPropertyChanged(nameof(DisplayName)); } }
        public string Insurance { get => _insurance; set { _insurance = value; OnPropertyChanged(nameof(Insurance)); } }
        public uint ContactID { get => _contactID; set { _contactID = value; OnPropertyChanged(nameof(ContactID)); } }
        public string RelationshipToPatient { get => _relationshipToPatient; set { _relationshipToPatient = value; OnPropertyChanged(nameof(RelationshipToPatient)); } }
        public ObservableCollection<Patient> Contacts { get => _contacts; set { _contacts = value; OnPropertyChanged(nameof(Contacts)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString()
        {
            return $"{DisplayName} [{ID}]";
        }
    }
}
