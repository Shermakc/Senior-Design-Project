using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediStoreManager
{
    public class Address
    {
        int ID;
        string StreetName;
        int AddressNumber;
        string City;
        string State;
        int ZipCode;
    }

    public class CustomerOrder
    {
        int ID;
        int InventoryID;
        string Type;
        int PersonID;
        int Quantity;
        DateTime Date;
        bool HaveReceivedPayment;
        DateOnly PaymentDate;
        int RelatedInventoryItemID;
        string Notes;
    }

    public class Inventory
    {
        int ID;
        string Type;
        string Name;
        string Size;
        string Brand;
        int NumInStock;
        decimal Cost;
        decimal RetailPrice;
        bool IsRental;
        decimal RentalPrice;
        int PersonID;
    }

    public class Order
    {
        int ID;
        int InventoryID;
        int Quantity;
        string SupplierName;
        string ShippingMethod;
        DateTime OrderDateTime;
        bool HasBeenReceived;
        DateOnly ReceivedDate;
    }

    public class Person
    {
        public uint ID;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public decimal HomePhone;
        public decimal CellPhone;
        public uint AddressID;
        public string InsuranceProvider;
        public bool IsPatientContact;
        public uint ContactID;
        public string ContactRelationship;
    }

    public class Supplier
    {
        string Name;
        decimal PhoneNumber;
        int PartnerID;
        int AddressID;
    }

    public class User
    {
        int ID;
        string FirstName;
        string LastName;
        string Username;
        string Password;
        string Position;
    }
}
