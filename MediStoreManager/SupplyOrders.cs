using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class SupplyOrders : ObservableCollection<SupplyOrder>
    {
        public SupplyOrders()
        {

        }

        public void AddSupplyOrder(Order order, ObservableCollection<InventoryEntry> invEntries)
        {
            Add(new SupplyOrder
            {
                ID = order.ID,
                Supplier = order.SupplierName,
                InventoryID = order.InventoryID.ToString(),
                Quantity = order.Quantity.ToString(),
                ShippingMethod = order.ShippingMethod,
                OrderDate = order.OrderDateTime,
                ReceivedDate = order.ReceivedDate,
                InventoryEntries = invEntries,
                DisplayName = order.SupplierName + " - " + order.OrderDateTime.Month.ToString() + "/" + order.OrderDateTime.Day.ToString() + "/" + order.OrderDateTime.Year.ToString()
            });
        }
    }
}
