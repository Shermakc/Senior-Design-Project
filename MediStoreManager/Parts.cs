using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Parts : ObservableCollection<Part>
    {
        public Parts()
        {

        }

        public void AddPart(InventoryItem item, ObservableCollection<WorkOrder> workOrders, ObservableCollection<SupplyOrder> supplyOrders)
        {
            Add(new Part
            {
                ID = item.ID,
                Type = item.Type,
                Name = item.Name,
                Quantity = item.NumInStock,
                Size = item.Size,
                Brand = item.Brand,
                Price = item.Cost,
                RetailPrice = item.RetailPrice,
                WorkOrders = new ObservableCollection<OrderSummary>(
                    workOrders
                        .Select(o => new OrderSummary
                        {
                            ID = o.ID,
                            Type = o.Type,
                            Date = o.Date,
                            Notes = o.Notes
                        })),
                SupplyOrders = new ObservableCollection<OrderSummary>(
                    supplyOrders
                        .Select(o => new OrderSummary
                        {
                            ID = o.ID,
                            Date = o.OrderDate,
                            SupplierName = o.Supplier,
                            Quantity = o.Quantity
                        }))
            });
        }
        
        public void AddPart(InventoryItem item)
        {
            Add(new Part
            {
                ID = item.ID,
                Type = item.Type,
                Name = item.Name,
                Quantity = item.NumInStock,
                Size = item.Size,
                Brand = item.Brand,
                Price = item.Cost,
                RetailPrice = item.RetailPrice,
                WorkOrders = new ObservableCollection<OrderSummary>(),
                SupplyOrders= new ObservableCollection<OrderSummary>()
            });
        }
    }
}
