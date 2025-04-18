﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class WorkOrder : INotifyPropertyChanged
    {
        private uint _ID;
        private string _type;
        private uint _patientID;
        private string _inventoryID;
        private string _quantity;
        private DateTime _date;
        private DateTime _paymentDate;
        private string _notes;
        ObservableCollection<InventoryEntry> _inventoryEntries;
        private string _displayName;

        public uint ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
        public uint PatientID { get => _patientID; set { _patientID = value; OnPropertyChanged(nameof(PatientID)); } }
        public string Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        public string InventoryID { get => _inventoryID; set { _inventoryID = value; OnPropertyChanged(nameof(InventoryID)); } }
        public DateTime Date { get => _date; set { _date = value; OnPropertyChanged(nameof(Date)); } }
        public DateTime PaymentDate { get => _paymentDate; set { _paymentDate = value; OnPropertyChanged(nameof(PaymentDate)); } }
        public string Notes { get => _notes; set { _notes = value; OnPropertyChanged(nameof(Notes)); } }
        public ObservableCollection<InventoryEntry> InventoryEntries { get => _inventoryEntries; set { _inventoryEntries = value; OnPropertyChanged(nameof(InventoryEntries)); } }
        public string DisplayName { get => _displayName; set { _displayName = value; OnPropertyChanged(nameof(DisplayName)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
