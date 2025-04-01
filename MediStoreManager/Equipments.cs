using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Equipments : ObservableCollection<Equipment>
    {
        public Equipments() 
        {

        }

        public void AddEquipment(InventoryItem item, ObservableCollection<WorkOrder> workOrders, ObservableCollection<SupplyOrder> supplyOrders)
        {
            Add(new Equipment
            {
                ID = item.ID,
                Type = item.Type,
                Name = item.Name,
                Quantity = item.NumInStock,
                Size = item.Size,
                Brand = item.Brand,
                Price = item.Cost.ToString(),
                RetailPrice = item.RetailPrice.ToString(),
                IsRental = item.IsRental,
                RentalPrice = item.RentalPrice.ToString(),
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
                            Date = o.OrderDate
                        }))
            });
        }
    }
}
