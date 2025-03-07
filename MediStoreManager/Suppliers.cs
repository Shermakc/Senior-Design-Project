using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Suppliers : ObservableCollection<SupplierL>
    {
        public Suppliers()
        {
            for (int i = 0; i < 10; ++i)
            {
                Add(new SupplierL
                {
                    ID = "Supplier " + i,
                    Name = "Big Medical Company",
                    PhoneNumber = "1-888-888-8888",
                    StreetAddress = "555 Gaddis Blvd",
                    City = "Dayton",
                    ZipCode = "45403",
                    State = "Ohio"
                });
            }
        }
    }
}
