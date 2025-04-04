using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Equipment : INotifyPropertyChanged
    {
        private uint _ID;
        private string _name;
        private string _type;
        private string _size;
        private string _brand;
        private int _quantity;
        private decimal _price;
        private decimal _retailPrice;
        private decimal _rentalPrice;
        private string _serialNumber;
        private bool? _isRental;
        private ObservableCollection<OrderSummary> _workOrders;
        private ObservableCollection<OrderSummary> _supplyOrders;

        public uint ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
        public string Size { get => _size; set { _size = value; OnPropertyChanged(nameof(Size)); } }
        public string Brand { get => _brand; set { _brand = value; OnPropertyChanged(nameof(Brand)); } }
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public decimal Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public decimal RetailPrice { get => _retailPrice; set { _retailPrice = value; OnPropertyChanged(nameof(RetailPrice)); } }
        public decimal RentalPrice { get => _rentalPrice; set { _rentalPrice = value; OnPropertyChanged(nameof(RentalPrice)); } }
        public string SerialNumber { get => _serialNumber; set { _serialNumber = value; OnPropertyChanged(nameof(SerialNumber)); } }
        public bool? IsRental { get => _isRental; set { _isRental = value; OnPropertyChanged(nameof(IsRental)); } }
        public ObservableCollection<OrderSummary> WorkOrders { get => _workOrders; set { _workOrders = value; OnPropertyChanged(nameof(WorkOrders)); } }
        public ObservableCollection<OrderSummary> SupplyOrders { get => _supplyOrders; set { _supplyOrders = value; OnPropertyChanged(nameof(SupplyOrders)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
