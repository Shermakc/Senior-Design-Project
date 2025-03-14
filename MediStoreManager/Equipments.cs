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

        public void AddEquipment(InventoryItem item)
        {
            Add(new Equipment
            {
                ID = item.ID.ToString(),
                Type = item.Type,
                Name = item.Name,
                Quantity = item.NumInStock.ToString(),
                Size = item.Size,
                Brand = item.Brand,
                Price = item.Cost.ToString(),
                RetailPrice = item.RetailPrice.ToString(),
                RentalPrice = item.RentalPrice.ToString()
            });
        }
    }
}
