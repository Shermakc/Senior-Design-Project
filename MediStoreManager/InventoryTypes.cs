using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    class InventoryTypes : ObservableCollection<String>
    {
        public InventoryTypes()
        {
            Add("equipment");
            Add("supply");
            Add("part");
        }
    }
}
