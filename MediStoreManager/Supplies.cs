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
            for (int i = 0; i < 10; ++i)
            {
                Add(new Supply
                {
                    ID = "Supply " + i,
                    Type = "Supplies",
                    Name = "Supply " + i.ToString(),
                    Quantity = (1000 + i).ToString(),
                    Size = "L",
                    Brand = "Random",
                    Price = "$3.45",
                    RetailPrice = "$15.50",
                });
            }
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
