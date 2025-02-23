using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediStoreManager
{
    public class DatabaseFunctions
    {
        private static List<Person> personList;
        private static List<InventoryItem> inventoryList;
        private static List<Supplier> supplierList;
        private static List<Address> addressList;

        public static string connString = "server=localhost;uid=root;pwd=Enough@99;database=medistore manager"; // Don't leave this as plain text

        public static MySqlConnection OpenMySQLConnection()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connString;
            con.Open();
            return con;
        }

        public static Person GetPerson(MySqlDataReader reader)
        {
            Person tempPerson = new Person();
            tempPerson.ID = GetColValAsUInt(reader, nameof(tempPerson.ID));
            tempPerson.FirstName = GetColValAsString(reader, nameof(tempPerson.FirstName));
            tempPerson.LastName = GetColValAsString(reader, nameof(tempPerson.LastName));
            tempPerson.MiddleName = GetColValAsString(reader, nameof(tempPerson.MiddleName));
            tempPerson.HomePhone = GetColValAsDecimal(reader, nameof(tempPerson.HomePhone));
            tempPerson.CellPhone = GetColValAsDecimal(reader, nameof(tempPerson.CellPhone));
            tempPerson.AddressID = GetColValAsUInt(reader, nameof(tempPerson.AddressID));
            tempPerson.InsuranceProvider = GetColValAsString(reader, nameof(tempPerson.InsuranceProvider));
            tempPerson.IsPatientContact = reader.GetBoolean(8);
            tempPerson.ContactID = GetColValAsUInt(reader, nameof(tempPerson.ContactID));
            tempPerson.ContactRelationship = GetColValAsString(reader, nameof(tempPerson.ContactRelationship));

            return tempPerson;
        }

        public static InventoryItem GetInventoryItem(MySqlDataReader reader)
        {
            InventoryItem tempItem = new InventoryItem();
            tempItem.ID = GetColValAsUInt(reader, nameof(tempItem.ID));
            tempItem.Type = GetColValAsString(reader, nameof(tempItem.Type));
            tempItem.Name = GetColValAsString(reader, nameof(tempItem.Name));
            tempItem.Size = GetColValAsString(reader, nameof(tempItem.Size));
            tempItem.Brand = GetColValAsString(reader, nameof(tempItem.Brand));
            tempItem.NumInStock = GetColValAsInt(reader, nameof(tempItem.NumInStock));
            tempItem.Cost = GetColValAsDecimal(reader, nameof(tempItem.Cost));
            tempItem.RetailPrice = GetColValAsDecimal(reader, nameof(tempItem.RetailPrice));
            tempItem.IsRental = reader.GetBoolean(8);
            tempItem.RentalPrice = GetColValAsDecimal(reader, nameof(tempItem.RentalPrice));
            tempItem.PersonID = GetColValAsUInt(reader, nameof(tempItem.PersonID));

            return tempItem;
        }

        public static Supplier GetSupplier(MySqlDataReader reader)
        {
            Supplier tempSupplier = new Supplier();
            tempSupplier.Name = GetColValAsString(reader, nameof(tempSupplier.Name));
            tempSupplier.PhoneNumber = GetColValAsDecimal(reader, nameof(tempSupplier.PhoneNumber));
            tempSupplier.PartnerID = GetColValAsInt(reader, nameof(tempSupplier.PartnerID));
            tempSupplier.AddressID = GetColValAsUInt(reader, nameof(tempSupplier.AddressID));

            return tempSupplier;
        }

        public static Address GetAddress(MySqlDataReader reader)
        {
            Address tempAddress = new Address();
            tempAddress.ID = GetColValAsUInt(reader, nameof(tempAddress.ID));
            tempAddress.StreetName = GetColValAsString(reader, nameof(tempAddress.StreetName));
            tempAddress.AddressNumber = GetColValAsInt(reader, nameof(tempAddress.AddressNumber));
            tempAddress.City = GetColValAsString(reader, nameof(tempAddress.City));
            tempAddress.State = GetColValAsString(reader, nameof(tempAddress.State));
            tempAddress.ZipCode = GetColValAsUInt(reader, nameof(tempAddress.ZipCode));

            return tempAddress;
        }

        public static Order GetOrder(MySqlDataReader reader)
        {
            Order tempOrder = new Order();
            tempOrder.ID = GetColValAsUInt(reader, nameof(tempOrder.ID));
            tempOrder.InventoryID = GetColValAsUInt(reader, nameof(tempOrder.InventoryID));
            tempOrder.Quantity = GetColValAsInt(reader, nameof(tempOrder.Quantity));
            tempOrder.SupplierName = GetColValAsString(reader, nameof(tempOrder.SupplierName));
            tempOrder.ShippingMethod = GetColValAsString(reader, nameof(tempOrder.ShippingMethod));
            tempOrder.OrderDateTime = GetColValAsDateTime(reader, nameof(tempOrder.OrderDateTime));
            tempOrder.HasBeenReceived = reader.GetBoolean(6);
            tempOrder.ReceivedDate = GetColValAsDateTime(reader, nameof(tempOrder.ReceivedDate));

            return tempOrder;
        }

        public static CustomerOrder GetCustomerOrder(MySqlDataReader reader)
        {
            CustomerOrder tempCustomerOrder = new CustomerOrder();
            tempCustomerOrder.ID = GetColValAsUInt(reader, nameof(tempCustomerOrder.ID));
            tempCustomerOrder.InventoryID = GetColValAsUInt(reader, nameof(tempCustomerOrder.InventoryID));
            tempCustomerOrder.Type = GetColValAsString(reader, nameof(tempCustomerOrder.Type));
            tempCustomerOrder.PersonID = GetColValAsUInt(reader, nameof(tempCustomerOrder.PersonID));
            tempCustomerOrder.Quantity = GetColValAsInt(reader, nameof(tempCustomerOrder.Quantity));
            tempCustomerOrder.Date = GetColValAsDateTime(reader, nameof(tempCustomerOrder.Date));
            tempCustomerOrder.HaveReceivedPayment = reader.GetBoolean(6);
            tempCustomerOrder.PaymentDate = GetColValAsDateTime(reader, nameof(tempCustomerOrder.PaymentDate));
            tempCustomerOrder.RelatedInventoryItemID = GetColValAsUInt(reader, nameof(tempCustomerOrder.RelatedInventoryItemID));
            tempCustomerOrder.Notes = GetColValAsString(reader, nameof(tempCustomerOrder.Notes));

            return tempCustomerOrder;
        }

        public static User GetUser(MySqlDataReader reader)
        {
            User tempUser = new User();
            tempUser.ID = GetColValAsUInt(reader, nameof(tempUser.ID));
            tempUser.FirstName = GetColValAsString(reader, nameof(tempUser.FirstName));
            tempUser.LastName = GetColValAsString(reader, nameof(tempUser.LastName));
            tempUser.Username = GetColValAsString(reader, nameof(tempUser.Username));
            tempUser.Password = GetColValAsString(reader, nameof(tempUser.Password));
            tempUser.Position = GetColValAsString(reader, nameof(tempUser.Position));

            return tempUser;
        }

        public static string GetColValAsString(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return string.Empty;
            else
                return reader[colName].ToString();
        }

        public static uint GetColValAsUInt(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return 0;
            else
                return (uint)reader[colName];
        }

        public static int GetColValAsInt(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return 0;
            else
                return (int)reader[colName];
        }

        public static decimal GetColValAsDecimal(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return 0;
            else
                return (decimal)reader[colName];
        }

        public static DateTime GetColValAsDateTime(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
                return DateTime.MinValue;
            else
                return (DateTime)reader[colName];
        }



        public static void GetPersonList(MySqlConnection con)
        {
            string sql = "select * from person;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static Person GetPersonByID(MySqlConnection con, uint id)
        {
            Person tempPerson = new Person();

            string sql = "select * from person where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempPerson.ID = GetColValAsUInt(reader, nameof(tempPerson.ID));
                tempPerson.FirstName = GetColValAsString(reader, nameof(tempPerson.FirstName));
                tempPerson.LastName = GetColValAsString(reader, nameof(tempPerson.LastName));
                tempPerson.MiddleName = GetColValAsString(reader, nameof(tempPerson.MiddleName));
                tempPerson.HomePhone = GetColValAsDecimal(reader, nameof(tempPerson.HomePhone));
                tempPerson.CellPhone = GetColValAsDecimal(reader, nameof(tempPerson.CellPhone));
                tempPerson.AddressID = GetColValAsUInt(reader, nameof(tempPerson.AddressID));
                tempPerson.InsuranceProvider = GetColValAsString(reader, nameof(tempPerson.InsuranceProvider));
                tempPerson.IsPatientContact = reader.GetBoolean(8);
                tempPerson.ContactID = GetColValAsUInt(reader, nameof(tempPerson.ContactID));
                tempPerson.ContactRelationship = GetColValAsString(reader, nameof(tempPerson.ContactRelationship));
            }

            return tempPerson;
        }

        public static void CreatePersonEntry(MySqlConnection con, Person newPerson)
        {
            string sql = "insert into person " +
                "(`ID`, `FirstName`, `LastName`, `MiddleName`, `HomePhone`, `CellPhone`, `AddressID`, `InsuranceProvider`, " +
                "`IsPatientContact`, `ContactID`, `ContactRelationship`) " +
                "VALUES ('" + newPerson.ID + "', '" + newPerson.FirstName + "', '" + newPerson.LastName + "', '"
                + newPerson.MiddleName + "', '" + newPerson.HomePhone + "', '" + newPerson.CellPhone + "', '"
                + newPerson.AddressID + "', '" + newPerson.InsuranceProvider + "', '" + newPerson.IsPatientContact + "', '"
                + newPerson.ContactID + "', '" + newPerson.ContactRelationship + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdatePersonEntry(MySqlConnection con, Person person)
        {
            string sql = "update person set FirstName = " + person.FirstName + ", LastName = " + person.LastName +
                ", MiddleName = " + person.MiddleName + ", HomePhone = " + person.HomePhone + ", CellPhone = " + person.CellPhone +
                ", AddressID = " + person.AddressID + ", InsuranceProvider = " + person.InsuranceProvider + ", IsPatientContact = " + person.IsPatientContact +
                ", ContactID = " + person.ContactID + ", ContactRelationship = " + person.ContactRelationship +
                " where ID = " + person.ID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeletePersonEntry(MySqlConnection con, uint id)
        {
            string sql = "delete from person where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetInventoryList(MySqlConnection con)
        {
            string sql = "select * from inventory;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static InventoryItem GetInventoryItemByID(MySqlConnection con, uint id, string itemType)
        {
            InventoryItem tempItem = new InventoryItem();

            string sql = "select * from inventory_item where ID = " + id + " and Type = " + itemType + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempItem.ID = GetColValAsUInt(reader, nameof(tempItem.ID));
                tempItem.Type = GetColValAsString(reader, nameof(tempItem.Type));
                tempItem.Name = GetColValAsString(reader, nameof(tempItem.Name));
                tempItem.Size = GetColValAsString(reader, nameof(tempItem.Size));
                tempItem.Brand = GetColValAsString(reader, nameof(tempItem.Brand));
                tempItem.NumInStock = GetColValAsInt(reader, nameof(tempItem.NumInStock));
                tempItem.Cost = GetColValAsDecimal(reader, nameof(tempItem.Cost));
                tempItem.RetailPrice = GetColValAsDecimal(reader, nameof(tempItem.RetailPrice));
                tempItem.IsRental = reader.GetBoolean(8);
                tempItem.RentalPrice = GetColValAsDecimal(reader, nameof(tempItem.RentalPrice));
                tempItem.PersonID = GetColValAsUInt(reader, nameof(tempItem.PersonID));
            }

            return tempItem;
        }

        public static void CreateInventoryItemEntry(MySqlConnection con, InventoryItem newItem)
        {
            string sql = "insert into inventory_item " +
                "(`ID`, `Type`, `Name`, `Size`, `Brand`, `NumInStock`, `Cost`, `RetailPrice`, " +
                "`IsRental`, `RentalPrice`, `PersonID`) " +
                "VALUES ('" + newItem.ID + "', '" + newItem.Type + "', '" + newItem.Name + "', '"
                + newItem.Size + "', '" + newItem.Brand + "', '" + newItem.NumInStock + "', '"
                + newItem.Cost + "', '" + newItem.RetailPrice + "', '" + newItem.IsRental + "', '"
                + newItem.RentalPrice + "', '" + newItem.PersonID + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateInventoryItemEntry(MySqlConnection con, InventoryItem item)
        {
            string sql = "update inventory_item set Name = " + item.Name + ", Size = " + item.Size +
                ", Brand = " + item.Brand + ", NumInStock = " + item.NumInStock + ", Cost = " + item.Cost +
                ", RetailPrice = " + item.RetailPrice + ", IsRental = " + item.IsRental +
                ", RentalPrice = " + item.RentalPrice + ", PersonID = " + item.PersonID +
                " where ID = " + item.ID + " and Type = " + item.Type + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteInventoryItemEntry(MySqlConnection con, uint id, string itemType)
        {
            string sql = "delete from inventory_item where ID = " + id + " and Type = " + itemType + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetSupplierList(MySqlConnection con)
        {
            string sql = "select * from supplier;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static Supplier GetSupplierByName(MySqlConnection con, string name)
        {
            Supplier tempSupplier = new Supplier();

            string sql = "select * from supplier where Name = " + name + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempSupplier.Name = GetColValAsString(reader, nameof(tempSupplier.Name));
                tempSupplier.PhoneNumber = GetColValAsDecimal(reader, nameof(tempSupplier.PhoneNumber));
                tempSupplier.PartnerID = GetColValAsInt(reader, nameof(tempSupplier.PartnerID));
                tempSupplier.AddressID = GetColValAsUInt(reader, nameof(tempSupplier.AddressID));
            }

            return tempSupplier;
        }

        public static void CreateSupplierEntry(MySqlConnection con, Supplier newSupplier)
        {
            string sql = "insert into supplier " +
                "(`Name`, `PhoneNumber`, `PartnerID`, `AddressID`) " +
                "VALUES ('" + newSupplier.Name + "', '" + newSupplier.PhoneNumber + "', '" + newSupplier.PartnerID + "', '"
                + newSupplier.AddressID + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateSupplierEntry(MySqlConnection con, Supplier supplier)
        {
            string sql = "update supplier set PhoneNumber = " + supplier.PhoneNumber + 
                ", PartnerID = " + supplier.PartnerID +
                ", AddressID = " + supplier.AddressID +
                " where Name = " + supplier.Name + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteSupplierEntry(MySqlConnection con, string name)
        {
            string sql = "delete from supplier where Name = " + name + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetAddressList(MySqlConnection con)
        {
            string sql = "select * from address;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                addressList.Add(GetAddress(reader));
            }
        }

        public static Address GetAddressByID(MySqlConnection con, uint id)
        {
            Address tempAddress = new Address();

            string sql = "select * from address where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempAddress.ID = GetColValAsUInt(reader, nameof(tempAddress.ID));
                tempAddress.StreetName = GetColValAsString(reader, nameof(tempAddress.StreetName));
                tempAddress.AddressNumber = GetColValAsInt(reader, nameof(tempAddress.AddressNumber));
                tempAddress.City = GetColValAsString(reader, nameof(tempAddress.City));
                tempAddress.State = GetColValAsString(reader, nameof(tempAddress.State));
                tempAddress.ZipCode = GetColValAsUInt(reader, nameof(tempAddress.ZipCode));
            }

            return tempAddress;
        }

        public static void CreateAddressEntry(MySqlConnection con, Address newAddress)
        {
            string sql = "insert into address " +
                "(`ID`, `StreetName`, `AddressNumber`, `City`, `State`, `ZipCode`) " +
                "VALUES ('" + newAddress.ID + "', '" + newAddress.StreetName + "', '" + newAddress.AddressNumber + "', '"
                + newAddress.City + "', '" + newAddress.State + "', '" + newAddress.ZipCode + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateAdressEntry(MySqlConnection con, Address address)
        {
            string sql = "update address set StreetName = '" + address.StreetName + "', AddressNumber = " + address.AddressNumber +
                ", City = '" + address.City + "', State = '" + address.State + "', ZipCode = " + address.ZipCode +
                " where ID = " + address.ID +";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAddressEntry(MySqlConnection con, uint id)
        {
            string sql = "delete from address where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetOrderList(MySqlConnection con)
        {
            string sql = "select * from order;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static Order GetOrderByID(MySqlConnection con, uint id, uint inventoryID)
        {
            Order tempOrder = new Order();

            string sql = "select * from order where ID = " + id + " and InventoryID = " + inventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempOrder.ID = GetColValAsUInt(reader, nameof(tempOrder.ID));
                tempOrder.InventoryID = GetColValAsUInt(reader, nameof(tempOrder.InventoryID));
                tempOrder.Quantity = GetColValAsInt(reader, nameof(tempOrder.Quantity));
                tempOrder.SupplierName = GetColValAsString(reader, nameof(tempOrder.SupplierName));
                tempOrder.ShippingMethod = GetColValAsString(reader, nameof(tempOrder.ShippingMethod));
                tempOrder.OrderDateTime = GetColValAsDateTime(reader, nameof(tempOrder.OrderDateTime));
                tempOrder.HasBeenReceived = reader.GetBoolean(6);
                tempOrder.ReceivedDate = GetColValAsDateTime(reader, nameof(tempOrder.ReceivedDate));
            }

            return tempOrder;
        }

        public static void CreateOrderEntry(MySqlConnection con, Order newOrder)
        {
            string sql = "insert into order " +
                "(`ID`, `InventoryID`, `Quantity`, `SupplierName`, `ShippingMethod`, " +
                "`OrderDateTime`, `HasBeenReceived`, `ReceivedDate`) " +
                "VALUES ('" + newOrder.ID + "', '" + newOrder.InventoryID + "', '" + newOrder.Quantity + "', '"
                + newOrder.SupplierName + "', '" + newOrder.ShippingMethod + "', '" + newOrder.OrderDateTime + "', '"
                + newOrder.HasBeenReceived + "', '" + newOrder.ReceivedDate + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateOrderEntry(MySqlConnection con, Order order)
        {
            string sql = "update order set Quantity = " + order.Quantity + ", SupplierName = " + order.SupplierName + 
                ", ShippingMethod = " + order.ShippingMethod + ", OrderDateTime = " + order.OrderDateTime + 
                ", HasBeenReceived = " + order.HasBeenReceived + ", ReceivedDate = " + order.ReceivedDate +
                " where ID = " + order.ID + " and InventoryID = " + order.InventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteOrderEntry(MySqlConnection con, uint id, uint inventoryID)
        {
            string sql = "delete from order where ID = " + id + " and InventoryID = " + inventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetCustomerOrderList(MySqlConnection con)
        {
            string sql = "select * from customer_order;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static CustomerOrder GetCustomerOrderByID(MySqlConnection con, uint id, uint inventoryID)
        {
            CustomerOrder tempCustomerOrder = new CustomerOrder();

            string sql = "select * from customer_order where ID = " + id + " and InventoryID = " + inventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempCustomerOrder.ID = GetColValAsUInt(reader, nameof(tempCustomerOrder.ID));
                tempCustomerOrder.InventoryID = GetColValAsUInt(reader, nameof(tempCustomerOrder.InventoryID));
                tempCustomerOrder.Type = GetColValAsString(reader, nameof(tempCustomerOrder.Type));
                tempCustomerOrder.PersonID = GetColValAsUInt(reader, nameof(tempCustomerOrder.PersonID));
                tempCustomerOrder.Quantity = GetColValAsInt(reader, nameof(tempCustomerOrder.Quantity));
                tempCustomerOrder.Date = GetColValAsDateTime(reader, nameof(tempCustomerOrder.Date));
                tempCustomerOrder.HaveReceivedPayment = reader.GetBoolean(6);
                tempCustomerOrder.PaymentDate = GetColValAsDateTime(reader, nameof(tempCustomerOrder.PaymentDate));
                tempCustomerOrder.RelatedInventoryItemID = GetColValAsUInt(reader, nameof(tempCustomerOrder.RelatedInventoryItemID));
                tempCustomerOrder.Notes = GetColValAsString(reader, nameof(tempCustomerOrder.Notes));
            }

            return tempCustomerOrder;
        }

        public static void CreateCustomerOrderEntry(MySqlConnection con, CustomerOrder newCustomerOrder)
        {
            string sql = "insert into customer_order " +
                "(`ID`, `InventoryID`, `Type`, `PersonID`, `Quantity`, `Date`, `HaveReceivedPayment`, " +
                "`PaymentDate`, `RelatedInventoryItemID`, `Notes`) " +
                "VALUES ('" + newCustomerOrder.ID + "', '" + newCustomerOrder.InventoryID + "', '" + newCustomerOrder.Type + "', '"
                + newCustomerOrder.PersonID + "', '" + newCustomerOrder.Quantity + "', '" + newCustomerOrder.Date + "', '"
                + newCustomerOrder.HaveReceivedPayment + "', '" + newCustomerOrder.PaymentDate + "', '"
                + newCustomerOrder.RelatedInventoryItemID + "', '" + newCustomerOrder.Notes + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateCustomerOrderEntry(MySqlConnection con, CustomerOrder customerOrder)
        {
            string sql = "update customer_order set Type = " + customerOrder.Type + ", PersonID = " + customerOrder.PersonID +
                ", Quantity = " + customerOrder.Quantity + ", Date = " + customerOrder.Date +
                ", HaveReceivedPayment = " + customerOrder.HaveReceivedPayment + ", PaymentDate = " + customerOrder.PaymentDate +
                ", RelatedInventoryItemID = " + customerOrder.RelatedInventoryItemID + ", Notes = " + customerOrder.Notes +
                " where ID = " + customerOrder.ID + " and InventoryID = " + customerOrder.InventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteCustomerOrderEntry(MySqlConnection con, uint id, uint inventoryID)
        {
            string sql = "delete from customer_order where ID = " + id + " and InventoryID = " + inventoryID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void GetUserList(MySqlConnection con)
        {
            string sql = "select * from user;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                personList.Add(GetPerson(reader));
            }
        }

        public static User GetUserByID(MySqlConnection con, uint id)
        {
            User tempUser = new User();

            string sql = "select * from user where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tempUser.ID = GetColValAsUInt(reader, nameof(tempUser.ID));
                tempUser.FirstName = GetColValAsString(reader, nameof(tempUser.FirstName));
                tempUser.LastName = GetColValAsString(reader, nameof(tempUser.LastName));
                tempUser.Username = GetColValAsString(reader, nameof(tempUser.Username));
                tempUser.Password = GetColValAsString(reader, nameof(tempUser.Password));
                tempUser.Position = GetColValAsString(reader, nameof(tempUser.Position));
            }

            return tempUser;
        }

        public static void CreateUserEntry(MySqlConnection con, User newUser)
        {
            string sql = "insert into user " +
                "(`ID`, `FirstName`, `LastName`, `Username`, `Password`, `Position`) " +
                "VALUES ('" + newUser.ID + "', '" + newUser.FirstName + "', '" + newUser.LastName + "', '"
                + newUser.Username + "', '" + newUser.Password + "', '" + newUser.Position + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateUserEntry(MySqlConnection con, User user)
        {
            string sql = "update user set FirstName = " + user.FirstName + ", PartnerID = " + user.LastName +
                ", AddressID = " + user.Username + ", Password = " + user.Password + ", Position = " + user.Position +
                " where ID = " + user.ID + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteSupplierEntry(MySqlConnection con, uint id)
        {
            string sql = "delete from user where ID = " + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}
