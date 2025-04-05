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

        public void AddWorkOrder(CustomerOrder order, Person person, ObservableCollection<InventoryEntry> invEntries)
        {
            Add(new WorkOrder
            {
                ID = order.ID,
                Type = order.Type,
                PatientID = order.PersonID,
                Quantity = order.Quantity.ToString(),
                InventoryID = order.InventoryID.ToString(),
                Date = order.Date,
                Notes = order.Notes,
                InventoryEntries = invEntries,
                DisplayName = person.FirstName + " " + person.LastName + " - " + order.Date.Month.ToString() + "/" + order.Date.Day.ToString() + "/" + order.Date.Year.ToString()
            });
        }
    }
}
