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
            
        }

        public void AddPatient(Person person, Address address, ObservableCollection<WorkOrder> workOrders)
        {
            Add(new Patient
            {
                ID = person.ID,
                FirstName = person.FirstName,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                HomePhone = person.HomePhone.ToString(),
                CellPhone = person.CellPhone.ToString(),
                StreetAddress = address.AddressNumber + " " + address.StreetName,
                City = address.City,
                ZipCode = address.ZipCode.ToString(),
                State = address.State,
                Insurance = person.InsuranceProvider,
                ContactID = person.ContactID,
                DisplayName = person.LastName + ", " + person.FirstName,
                WorkOrders = new ObservableCollection<OrderSummary>(
                    workOrders
                        .Select(o => new OrderSummary
                        {
                            ID = o.ID,
                            Type = o.Type,
                            Date = o.Date,
                            Notes = o.Notes
                        }))
            });
        }
    }
}
