using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class InventoryEntry
    {
        public InventoryListItem MainItem { get; set; }
        public InventoryListItem RelatedItem { get; set; } = new InventoryListItem();
    }

    public class InventoryListItem
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int QuantitySelected { get; set; }
        public int AllowedQuantity { get; set; }


        public override string ToString() => $"{Name} [{ID}] - {Type}]";

        public InventoryListItem()
        {
            ID = 0;
            Name = "";
            Type = "";
            QuantitySelected = 0;
            AllowedQuantity = 0;
        }
    }
}
