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
            for (int i = 0; i < 10; ++i)
            {
                Add(new Equipment
                {
                    ID = "Equipment " + i,
                    Type = "Equipment",
                    Name = "Equipment " + i.ToString(),
                    Quantity = (10 + i).ToString(),
                    Size = "L",
                    Brand = "Random",
                    Price = "$123.45",
                    RetailPrice = "$500.50",
                    RentalPrice = "$10/month"
                });
            }
        }
    }
}
