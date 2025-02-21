using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediStoreManager
{
    // might want to change these to classes matching how it is displayed in the app
    // Ex: PatientInfo would display all person info including their address
    public class Address
    {
        public uint ID;
        public string StreetName;
        public int AddressNumber;
        public string City;
        public string State;
        public uint ZipCode;
    }

    public class CustomerOrder
    {
        public uint ID;
        public uint InventoryID;
        public string Type;
        public uint PersonID;
        public int Quantity;
        public DateTime Date;
        public bool HaveReceivedPayment;
        public DateTime PaymentDate;
        public uint RelatedInventoryItemID;
        public string Notes;
    }

    public class InventoryItem
    {
        public uint ID;
        public string Type;
        public string Name;
        public string Size;
        public string Brand;
        public int NumInStock;
        public decimal Cost;
        public decimal RetailPrice;
        public bool IsRental;
        public decimal RentalPrice;
        public uint PersonID;
    }

    public class Order
    {
        public uint ID;
        public uint InventoryID;
        public int Quantity;
        public string SupplierName;
        public string ShippingMethod;
        public DateTime OrderDateTime;
        public bool HasBeenReceived;
        public DateTime ReceivedDate;
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
        public string Name;
        public decimal PhoneNumber;
        public int PartnerID;
        public uint AddressID;
    }

    public class User
    {
        public uint ID;
        public string FirstName;
        public string LastName;
        public string Username;
        public string Password;
        public string Position;
    }
}
