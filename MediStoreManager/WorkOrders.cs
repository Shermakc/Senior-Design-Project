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

        }

        public void AddWorkOrder(CustomerOrder order)
        {
            Add(new WorkOrder
            {
                ID = order.ID.ToString(),
                Type = order.Type,
                PatientID = order.PersonID.ToString(),
                Quantity = order.Quantity.ToString(),
                InventoryID = order.InventoryID.ToString(),
                Date = order.Date,
                Notes = order.Notes
            });
        }
    }
}
