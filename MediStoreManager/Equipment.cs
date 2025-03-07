using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Equipment : INotifyPropertyChanged
    {
        private string _ID;
        private string _name;
        private string _type;
        private string _size;
        private string _brand;
        private string _quantity;
        private string _price;
        private string _retailPrice;
        private string _rentalPrice;

        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
        public string Size { get => _size; set { _size = value; OnPropertyChanged(nameof(Size)); } }
        public string Brand { get => _brand; set { _brand = value; OnPropertyChanged(nameof(Brand)); } }
        public string Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public string RetailPrice { get => _retailPrice; set { _retailPrice = value; OnPropertyChanged(nameof(RetailPrice)); } }
        public string RentalPrice { get => _rentalPrice; set { _rentalPrice = value; OnPropertyChanged(nameof(RentalPrice)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
