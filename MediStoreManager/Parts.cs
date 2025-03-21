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
                Price = item.Cost.ToString(),
                RetailPrice = item.RetailPrice.ToString(),
            });
        }
    }
}
