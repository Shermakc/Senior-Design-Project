using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Supplies : ObservableCollection<Supply>
    {
        public Supplies()
        {

        }

        public void AddSupply(InventoryItem item)
        {
            Add(new Supply
            {
                ID = item.ID.ToString(),
                Type = item.Type,
                Name = item.Name,
                Quantity = item.NumInStock.ToString(),
                Size = item.Size,
                Brand = item.Brand,
                Price = item.Cost.ToString(),
                RetailPrice = item.RetailPrice.ToString(),
            });
        }
    }
}
