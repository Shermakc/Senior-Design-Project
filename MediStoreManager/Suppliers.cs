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
           
        }

        public void AddSupplier(Supplier supplier, Address address, ObservableCollection<SupplyOrder> supplyOrders)
        {
            Add(new SupplierL
            {
                Name = supplier.Name,
                PhoneNumber = supplier.PhoneNumber.ToString(),
                PartnerID = supplier.PartnerID,
                StreetAddress = address.AddressNumber + " " + address.StreetName,
                City = address.City,
                ZipCode = address.ZipCode.ToString(),
                State = address.State,
                SupplyOrders = new ObservableCollection<OrderSummary>(
                    supplyOrders
                        .Select(o => new OrderSummary
                        {
                            ID = o.ID,
                            Date = o.OrderDate
                        }))
            });
        }
    }
}
