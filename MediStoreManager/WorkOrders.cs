using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class WorkOrders : ObservableCollection<WorkOrder>
    {
        public WorkOrders()
        {
            for (int i = 0; i < 10; ++i)
            {
                Add(new WorkOrder
                {
                    ID = "Work Order " + i,
                    Type = "Repair",
                    PatientID = "Patient " + i.ToString(),
                    Quantity = "10",
                    InventoryID = "ABC",
                    Date = "2/15/2025",
                    Notes = "..."
                });
            }
        }
    }
}
