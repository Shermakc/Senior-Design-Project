﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStoreManager
{
    public class SupplyOrders : ObservableCollection<SupplyOrder>
    {
        public SupplyOrders()
        {
            for (int i = 0; i < 10; ++i)
            {
                Add(new SupplyOrder
                {
                    ID = "Supply Order " + (i + 10).ToString(),
                    Supplier = "Supplier " + i,
                    InventoryID = "abc",
                    Quantity = "25",
                    ShippingMethod = "Ground",
                    OrderDate = "1/03/2025"
                });
            }
        }

        public void AddSupplyOrder(Order order)
        {
            Add(new SupplyOrder
            {
                ID = order.ID.ToString(),
                Supplier = order.SupplierName,
                InventoryID = order.InventoryID.ToString(),
                Quantity = order.Quantity.ToString(),
                ShippingMethod = order.ShippingMethod,
                OrderDate = order.OrderDateTime.ToString()
            });
        }
    }
}
