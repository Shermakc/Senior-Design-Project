﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class OrderSummary : INotifyPropertyChanged
    {
        private uint _ID;
        private string _type;
        private DateTime _date;
        private string _notes;

        public uint ID { get => _ID; set { _ID = value; OnPropertyChanged(nameof(ID)); } }
        public string Type { get => _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
        public DateTime Date { get => _date; set { _date = value; OnPropertyChanged(nameof(Date)); } }
        public string Notes { get => _notes; set { _notes = value; OnPropertyChanged(nameof(Notes)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
