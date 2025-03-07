using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class Patients : ObservableCollection<Patient>
    {
        public Patients()
        {
            for (int i = 0; i < 10; ++i)
            {
                Add(new Patient
                {
                    ID = "Patient " + i,
                    FirstName = "John",
                    LastName = "Smith",
                    MiddleName = "R",
                    HomePhone = "1-888-888-8888",
                    CellPhone = "1-234-567-8910",
                    StreetAddress = "1100 E 9th St",
                    City = "Cleveland",
                    ZipCode = "44114",
                    State = "Ohio"
                });
            }
        }
    }
}
