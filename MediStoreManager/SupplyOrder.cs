using System;
using System.Collections.Generic;
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
        private string _orderDate;
        private string _displayName;

        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Supplier { get => _supplier; set { _supplier = value; OnPropertyChanged(nameof(Supplier)); } }
        public string InventoryID { get => _inventoryID; set { _inventoryID = value; OnPropertyChanged(nameof(InventoryID)); } }
        public string Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string ShippingMethod { get => _shippingMethod; set { _shippingMethod = value; OnPropertyChanged(nameof(ShippingMethod)); } }
        public string OrderDate { get => _orderDate; set { _orderDate = value; OnPropertyChanged(nameof(OrderDate)); } }
        public string DisplayName { get => _displayName; set { _displayName = value; OnPropertyChanged(nameof(DisplayName)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
