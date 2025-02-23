using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    class WorkOrderTypes : ObservableCollection<String>
    {
        public WorkOrderTypes() 
        {
            Add("Repair");
            Add("Delivery");
            Add("Pickup");
        }
    }
}
