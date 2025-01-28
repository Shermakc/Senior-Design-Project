using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    class InventoryInfo : ObservableCollection<String>
    {
        public InventoryInfo()
        {
            for (int i = 0; i < 1000; ++i)
            {
                Add("Part " + i.ToString());
            }
        }
    }
}
