using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class SupplyOrder : INotifyPropertyChanged
    {
        private string _ID;
        private string _supplier;
        private string _inventoryID;
        private string _quantity;
        private string _shippingMethod;
        private DateTime _orderDate;
        private DateTime _receivedDate;
        ObservableCollection<InventoryEntry> _entries;

        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Supplier { get => _supplier; set { _supplier = value; OnPropertyChanged(nameof(Supplier)); } }
        public string InventoryID { get => _inventoryID; set { _inventoryID = value; OnPropertyChanged(nameof(InventoryID)); } }
        public string Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string ShippingMethod { get => _shippingMethod; set { _shippingMethod = value; OnPropertyChanged(nameof(ShippingMethod)); } }
        public DateTime OrderDate { get => _orderDate; set { _orderDate = value; OnPropertyChanged(nameof(OrderDate)); } }
        public DateTime ReceivedDate { get => _receivedDate; set { _receivedDate = value; OnPropertyChanged(nameof(ReceivedDate)); } }
        public ObservableCollection<InventoryEntry> Entries { get => _entries; set { _entries = value; OnPropertyChanged(nameof(Entries)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
