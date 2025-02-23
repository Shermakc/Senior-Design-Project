using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    class SupplierInfo : ObservableCollection<String>
    {
        public SupplierInfo()
        {
            for (int i = 0; i < 100; ++i)
            {
                Add("Supplier " + i.ToString());
            }
        }
    }
}
