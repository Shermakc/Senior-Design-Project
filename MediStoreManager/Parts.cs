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
            for (int i = 0; i < 10; ++i)
            {
                Add(new Part
                {
                    ID = "Part " + i,
                    Type = "Part",
                    Name = "Part " + i.ToString(),
                    Quantity = (100 + i).ToString(),
                    Size = "L",
                    Brand = "Random",
                    Price = "$13.45",
                    RetailPrice = "$25.50",
                });
            }
        }
    }
}
