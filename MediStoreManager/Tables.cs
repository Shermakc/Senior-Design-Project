using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Org.BouncyCastle.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MediStoreManager
{
    // might want to change these to classes matching how it is displayed in the app
    // Ex: PatientInfo would display all person info including their address
    public class Address
    {
        public Address() { }

        public Address(uint id, string streetName, string addressNum, string city, string state, string zipCode)
        {
            ID = id;
            StreetName = streetName;
            AddressNumber = Convert.ToInt32(addressNum);
            City = city;
            State = state;
            if (zipCode != string.Empty) { ZipCode = Convert.ToUInt32(zipCode); }
        }

        public uint ID;
        public string StreetName;
        public int AddressNumber;
        public string City;
        public string State;
        public uint ZipCode;
        public bool Deleted;
    }

    public class CustomerOrder
    {
        public CustomerOrder() { }

        public CustomerOrder(uint id, uint inventoryID, string type, uint personID, int quantity, DateTime date,
            bool haveReceivedPayment, DateTime paymentDate, uint relatedItemID, string notes)
        {
            ID = id;
            InventoryID = Convert.ToUInt16(inventoryID);
            Type = type;
            PersonID = Convert.ToUInt16(personID);
            Quantity = quantity;
            Date = date;
            HaveReceivedPayment = haveReceivedPayment;
            PaymentDate = paymentDate;
            RelatedInventoryItemID = relatedItemID;
            Notes = notes;
        }

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
        public bool Deleted;
    }

    public class InventoryItem
    {
        public InventoryItem() { }

        public InventoryItem(uint id, string type, string name, string size, string brand, int numInStock, string cost,
            string retailPrice, bool isRental, string rentalPrice, string personID, string serialNumber)
        {
            ID = id;
            Type = type;
            Name = name;
            Size = size;
            Brand = brand;
            NumInStock = numInStock;
            if (cost != string.Empty) { Cost = Convert.ToDecimal(cost); }
            if (retailPrice != string.Empty) { RetailPrice = Convert.ToDecimal(retailPrice); }
            IsRental = isRental;
            if (rentalPrice != string.Empty) { RentalPrice = Convert.ToDecimal(rentalPrice); }
            if (personID != string.Empty) { PersonID = Convert.ToUInt16(personID); }
            SerialNumber = serialNumber;
        }

        public InventoryItem(uint id, string type, string name, string size, string brand, int numInStock, string cost,
            string retailPrice, bool isRental, string rentalPrice, string serialNumber)
        {
            ID = id;
            Type = type;
            Name = name;
            Size = size;
            Brand = brand;
            NumInStock = numInStock;
            if (cost != string.Empty) { Cost = Convert.ToDecimal(cost); }
            if (retailPrice != string.Empty) { RetailPrice = Convert.ToDecimal(retailPrice); }
            IsRental = isRental;
            if (rentalPrice != string.Empty) { RentalPrice = Convert.ToDecimal(rentalPrice); }
            SerialNumber = serialNumber;
        }

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
        public string SerialNumber;
        public bool Deleted;
    }

    public class Order
    {
        public Order() { }

        public Order(uint id, uint inventoryID, int quantity, string supplierName, string shippingMethod,
            DateTime orderDateTime, bool hasBeenReceived, DateTime receivedDate)
        {
            ID = id;
            InventoryID = Convert.ToUInt16(inventoryID);
            Quantity = Convert.ToInt16(quantity);
            SupplierName = supplierName;
            ShippingMethod = shippingMethod;
            OrderDateTime = orderDateTime;
            HasBeenReceived = hasBeenReceived;
            ReceivedDate = receivedDate;
        }

        public uint ID;
        public uint InventoryID;
        public int Quantity;
        public string SupplierName;
        public string ShippingMethod;
        public DateTime OrderDateTime;
        public bool HasBeenReceived;
        public DateTime ReceivedDate;
        public bool Deleted;
    }

    public class Person
    {
        public Person() { }

        public Person(uint id, string firstName, string lastName, string middleName, string homePhone, string cellPhone,
            uint addressID, string insurance, bool isPatient)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            if (homePhone != string.Empty) { HomePhone = Convert.ToInt64(homePhone); }
            if (cellPhone != string.Empty) { CellPhone = Convert.ToInt64(cellPhone); }
            AddressID = addressID;
            InsuranceProvider = insurance;
            IsPatient = isPatient;
        }

        public Person(uint id, string firstName, string lastName, string middleName, string homePhone, string cellPhone,
            uint addressID, string insurance, bool isPatient, string contactID, string contactRelation)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            if (homePhone != string.Empty) { HomePhone = Convert.ToInt64(homePhone); }
            if (cellPhone != string.Empty) { CellPhone = Convert.ToInt64(cellPhone); }
            AddressID = addressID;
            InsuranceProvider = insurance;
            IsPatient = isPatient;
            if (contactID != string.Empty) { ContactID = Convert.ToUInt16(contactID); }
            ContactRelationship = contactRelation;
        }

        public uint ID;
        public string? FirstName;
        public string? LastName;
        public string? MiddleName;
        public decimal HomePhone;
        public decimal CellPhone;
        public uint AddressID;
        public string? InsuranceProvider;
        public bool IsPatient;
        public uint ContactID;
        public string? ContactRelationship;
        public bool Deleted;
    }

    public class Supplier
    {
        public Supplier() 
        {

        }

        public Supplier(string name, string phoneNumber, string partnerID, uint addressID)
        {
            Name = name;
            if (phoneNumber != string.Empty) { PhoneNumber = Convert.ToInt64(phoneNumber); }
            if (partnerID != string.Empty) { PartnerID = Convert.ToInt32(partnerID); }
            AddressID = addressID;
        }
        public string Name;
        public decimal PhoneNumber;
        public int PartnerID;
        public uint AddressID;
        public bool Deleted;
    }

    public class User
    {
        public uint ID;
        public string FirstName;
        public string LastName;
        public string Username;
        public string Password;
        public string Position;
        public bool Deleted;
    }
}
