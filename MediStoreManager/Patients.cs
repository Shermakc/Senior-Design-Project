﻿using System;
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
            
        }

        public void AddPatient(Person person, Address address)
        {
            Add(new Patient
            {
                ID = person.ID.ToString(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                HomePhone = person.HomePhone.ToString(),
                CellPhone = person.CellPhone.ToString(),
                StreetAddress = address.AddressNumber + address.StreetName,
                City = address.City,
                ZipCode = address.ZipCode.ToString(),
                State = address.State,
                DisplayName = person.LastName + ", " + person.FirstName
            });
        }
    }
}
