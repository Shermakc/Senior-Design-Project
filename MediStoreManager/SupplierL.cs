using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class SupplierL : INotifyPropertyChanged
    {
        private string _name;
        private string _phonenumber;
        private string _streetaddress;
        private string _city;
        private string _zipcode;
        private string _state;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string PhoneNumber { get => _phonenumber; set { _phonenumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string StreetAddress { get => _streetaddress; set { _streetaddress = value; OnPropertyChanged(nameof(StreetAddress)); } }
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }
        public string ZipCode { get => _zipcode; set { _zipcode = value; OnPropertyChanged(nameof(ZipCode)); } }
        public string State { get => _state; set { _state = value; OnPropertyChanged(nameof(State)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
