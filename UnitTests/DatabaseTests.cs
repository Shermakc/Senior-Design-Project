using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediStoreManager;
using NUnit.Framework;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace MediStoreManager
{
    public class DatabaseTests
    {
        private Address CreateTestAddress()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Address newAddress = new Address();
            newAddress.ID = 9999;
            newAddress.StreetName = "TestStreet";
            newAddress.AddressNumber = 9999;
            newAddress.City = "TestCity";
            newAddress.State = "TestState";
            newAddress.ZipCode = 99999;

            DatabaseFunctions.CreateAddressEntry(con, newAddress);
            con.Close();

            return newAddress;
        }

        private Supplier CreateTestSupplier(Address testAddress)
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Supplier newSupplier = new Supplier();
            newSupplier.Name = "TestName";
            newSupplier.PhoneNumber = 9999999999;
            newSupplier.PartnerID = 9999;
            newSupplier.AddressID = testAddress.ID;

            DatabaseFunctions.CreateSupplierEntry(con, newSupplier);
            con.Close();

            return newSupplier;
        }

        private Person CreateTestPerson(Address testAddress)
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Person newPerson = new Person();
            newPerson.ID = 9999;
            newPerson.FirstName = "TestFirst";
            newPerson.LastName = "TestLast";
            newPerson.MiddleName = "TestMiddle";
            newPerson.HomePhone = 9999999999;
            newPerson.CellPhone = 9999999999;
            newPerson.AddressID = testAddress.ID;
            newPerson.InsuranceProvider = "TestInsurance";
            newPerson.IsPatient = false;

            DatabaseFunctions.CreatePersonEntry(con, newPerson);
            con.Close();

            return newPerson;
        }

        private InventoryItem CreateTestItem(Person testPerson)
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            InventoryItem newInventoryItem = new InventoryItem();
            newInventoryItem.ID = 9999;
            newInventoryItem.Type = "Equipment";
            newInventoryItem.Name = "TestName";
            newInventoryItem.Size = "TestSize";
            newInventoryItem.Brand = "TestBrand";
            newInventoryItem.NumInStock = 999;
            newInventoryItem.Cost = 9999;
            newInventoryItem.RetailPrice = 9999;
            newInventoryItem.IsRental = false;
            newInventoryItem.RentalPrice = 0;
            newInventoryItem.PersonID = testPerson.ID;

            DatabaseFunctions.CreateInventoryItemEntry(con, newInventoryItem);
            con.Close();

            return newInventoryItem;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAddressTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Address address = DatabaseFunctions.GetAddressByID(con, 1);

            Assert.NotNull(address);
            con.Close();
        }

        [Test]
        public void CreateAddressTest()
        {
            Address newAddress = CreateTestAddress();

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Address retrievedAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);

            Assert.That(retrievedAddress.ID == newAddress.ID
                && retrievedAddress.StreetName == newAddress.StreetName
                && retrievedAddress.AddressNumber == newAddress.AddressNumber
                && retrievedAddress.City == newAddress.City
                && retrievedAddress.State == newAddress.State
                && retrievedAddress.ZipCode == newAddress.ZipCode);

            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdateAddressTest()
        {
            Address newAddress = CreateTestAddress();

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Address createdAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            newAddress.StreetName = "ChangedStreet";
            newAddress.AddressNumber = 9888;
            newAddress.City = "ChangedCity";
            newAddress.State = "ChangedState";
            newAddress.ZipCode = 98888;

            DatabaseFunctions.UpdateAdressEntry(con, newAddress);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Address retrievedAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);

            Assert.That(retrievedAddress.ID == newAddress.ID
                && retrievedAddress.StreetName == newAddress.StreetName
                && retrievedAddress.AddressNumber == newAddress.AddressNumber
                && retrievedAddress.City == newAddress.City
                && retrievedAddress.State == newAddress.State
                && retrievedAddress.ZipCode == newAddress.ZipCode);

            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, retrievedAddress.ID);
            con.Close();
        }

        [Test]
        public void DeleteAddressTest()
        {
            Address newAddress = CreateTestAddress();

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Address createdAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Address retrievedAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);
            con.Close();

            Assert.That(retrievedAddress.ID == 0
                && retrievedAddress.AddressNumber == 0
                && retrievedAddress.City == null);
        }

        [Test]
        public void GetPersonTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Person Person = DatabaseFunctions.GetPersonByID(con, 1);

            Assert.NotNull(Person);
            con.Close();
        }

        [Test]
        public void CreatePersonTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Person retrievedPerson = DatabaseFunctions.GetPersonByID(con, newPerson.ID);
            con.Close();

            Assert.That(retrievedPerson.ID == newPerson.ID
                && retrievedPerson.FirstName == newPerson.FirstName
                && retrievedPerson.LastName == newPerson.LastName
                && retrievedPerson.MiddleName == newPerson.MiddleName
                && retrievedPerson.HomePhone == newPerson.HomePhone
                && retrievedPerson.CellPhone == newPerson.CellPhone
                && retrievedPerson.AddressID == newPerson.AddressID
                && retrievedPerson.InsuranceProvider == newPerson.InsuranceProvider
                && retrievedPerson.IsPatient == newPerson.IsPatient);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdatePersonTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            newPerson.FirstName = "ChangedFirst";
            newPerson.LastName = "ChangedLast";
            newPerson.MiddleName = "ChangedMiddle";
            newPerson.HomePhone = 9888888888;
            newPerson.CellPhone = 9888888888;
            newPerson.AddressID = 9999;
            newPerson.InsuranceProvider = "ChangedInsurance";
            newPerson.IsPatient = false;

            DatabaseFunctions.UpdatePersonEntry(con, newPerson);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Person retrievedPerson = DatabaseFunctions.GetPersonByID(con, newPerson.ID);
            con.Close();

            Assert.That(retrievedPerson.ID == newPerson.ID
                && retrievedPerson.FirstName == newPerson.FirstName
                && retrievedPerson.LastName == newPerson.LastName
                && retrievedPerson.MiddleName == newPerson.MiddleName
                && retrievedPerson.HomePhone == newPerson.HomePhone
                && retrievedPerson.CellPhone == newPerson.CellPhone
                && retrievedPerson.AddressID == newPerson.AddressID
                && retrievedPerson.InsuranceProvider == newPerson.InsuranceProvider
                && retrievedPerson.IsPatient == newPerson.IsPatient);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, retrievedPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void DeletePersonTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Person createdPerson = DatabaseFunctions.GetPersonByID(con, newPerson.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Person retrievedPerson = DatabaseFunctions.GetPersonByID(con, newPerson.ID);
            con.Close();

            Assert.That(retrievedPerson.ID == 0
                && retrievedPerson.FirstName == null
                && retrievedPerson.HomePhone == 0);
        }

        [Test]
        public void GetUserTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            User User = DatabaseFunctions.GetUserByID(con, 1);

            Assert.NotNull(User);
            con.Close();
        }

        [Test]
        public void CreateUserTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            User newUser = new User();
            newUser.ID = 9999;
            newUser.FirstName = "TestFirst";
            newUser.LastName = "TestLast";
            newUser.Username = "TestMiddle";
            newUser.Password = "TestPassword";
            newUser.Position = "TestPosition";

            DatabaseFunctions.CreateUserEntry(con, newUser);
            User retrievedUser = DatabaseFunctions.GetUserByID(con, newUser.ID);
            con.Close();

            Assert.That(retrievedUser.ID == newUser.ID
                && retrievedUser.FirstName == newUser.FirstName
                && retrievedUser.LastName == newUser.LastName
                && retrievedUser.Username == newUser.Username
                && retrievedUser.Password == newUser.Password
                && retrievedUser.Position == newUser.Position);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteUserEntry(con, newUser.ID);
            con.Close();
        }

        [Test]
        public void UpdateUserTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            User newUser = new User();
            newUser.ID = 9999;
            newUser.FirstName = "TestFirst";
            newUser.LastName = "TestLast";
            newUser.Username = "TestMiddle";
            newUser.Password = "TestPassword";
            newUser.Position = "TestPosition";

            DatabaseFunctions.CreateUserEntry(con, newUser);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            newUser.FirstName = "ChangedFirst";
            newUser.LastName = "ChangedLast";
            newUser.Username = "ChangedMiddle";
            newUser.Password = "ChangedPassword";
            newUser.Position = "ChangedPosition";

            DatabaseFunctions.UpdateUserEntry(con, newUser);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            User retrievedUser = DatabaseFunctions.GetUserByID(con, newUser.ID);
            con.Close();

            Assert.That(retrievedUser.ID == newUser.ID
                && retrievedUser.FirstName == newUser.FirstName
                && retrievedUser.LastName == newUser.LastName
                && retrievedUser.Username == newUser.Username
                && retrievedUser.Password == newUser.Password
                && retrievedUser.Position == newUser.Position);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteUserEntry(con, retrievedUser.ID);
            con.Close();
        }

        [Test]
        public void DeleteUserTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            User newUser = new User();
            newUser.ID = 9999;
            newUser.FirstName = "TestFirst";
            newUser.LastName = "TestLast";
            newUser.Username = "TestMiddle";
            newUser.Password = "TestPassword";
            newUser.Position = "TestPosition";

            DatabaseFunctions.CreateUserEntry(con, newUser);
            User createdUser = DatabaseFunctions.GetUserByID(con, newUser.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteUserEntry(con, newUser.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            User retrievedUser = DatabaseFunctions.GetUserByID(con, newUser.ID);
            con.Close();

            Assert.That(retrievedUser.ID == 0
                && retrievedUser.FirstName == null
                && retrievedUser.Username == null);
        }

        [Test]
        public void GetSupplierTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Supplier Supplier = DatabaseFunctions.GetFirstSupplier(con);

            Assert.NotNull(Supplier);
            con.Close();
        }

        [Test]
        public void CreateSupplierTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Supplier retrievedSupplier = DatabaseFunctions.GetSupplierByName(con, newSupplier.Name);
            con.Close();

            Assert.That(retrievedSupplier.Name == newSupplier.Name
                && retrievedSupplier.PhoneNumber == newSupplier.PhoneNumber
                && retrievedSupplier.PartnerID == newSupplier.PartnerID
                && retrievedSupplier.AddressID == newSupplier.AddressID);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, newSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdateSupplierTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Address testAddress = new Address();
            testAddress.ID = 9998;
            testAddress.StreetName = "TestStreet";
            testAddress.AddressNumber = 9999;
            testAddress.City = "TestCity";
            testAddress.State = "TestState";
            testAddress.ZipCode = 99999;
            DatabaseFunctions.CreateAddressEntry(con, testAddress);
            con.Close();

            newSupplier.PhoneNumber = 9888888888;
            newSupplier.PartnerID = 9888;
            newSupplier.AddressID = 9998;

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.UpdateSupplierEntry(con, newSupplier);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Supplier retrievedSupplier = DatabaseFunctions.GetSupplierByName(con, newSupplier.Name);
            con.Close();

            Assert.That(retrievedSupplier.Name == newSupplier.Name
                && retrievedSupplier.PhoneNumber == newSupplier.PhoneNumber
                && retrievedSupplier.PartnerID == newSupplier.PartnerID
                && retrievedSupplier.AddressID == newSupplier.AddressID);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, retrievedSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, testAddress.ID);
            con.Close();

        }

        [Test]
        public void DeleteSupplierTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, newSupplier.Name);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Supplier retrievedSupplier = DatabaseFunctions.GetSupplierByName(con, newSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            Assert.That(retrievedSupplier.Name == null
                && retrievedSupplier.PhoneNumber == 0
                && retrievedSupplier.PartnerID == 0);
        }

        [Test]
        public void GetInventoryItemTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            InventoryItem InventoryItem = DatabaseFunctions.GetInventoryItemByID(con, 1);

            Assert.NotNull(InventoryItem);
            con.Close();
        }

        [Test]
        public void CreateInventoryItemTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            InventoryItem retrievedItem = DatabaseFunctions.GetInventoryItemByID(con, newItem.ID);
            con.Close();

            Assert.That(retrievedItem.ID == newItem.ID
                && retrievedItem.Type == newItem.Type
                && retrievedItem.Name == newItem.Name
                && retrievedItem.Size == newItem.Size
                && retrievedItem.Brand == newItem.Brand
                && retrievedItem.NumInStock == newItem.NumInStock
                && retrievedItem.Cost == newItem.Cost
                && retrievedItem.RetailPrice == newItem.RetailPrice
                && retrievedItem.IsRental == newItem.IsRental
                && retrievedItem.RetailPrice == newItem.RetailPrice
                && retrievedItem.PersonID == newItem.PersonID);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdateInventoryItemTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            newItem.Name = "ChangedName";
            newItem.Size = "ChangedSize";
            newItem.Brand = "ChangedBrand";
            newItem.NumInStock = 988;
            newItem.Cost = 9888;
            newItem.RetailPrice = 0;
            newItem.IsRental = true;
            newItem.RentalPrice = 9888;

            DatabaseFunctions.UpdateInventoryItemEntry(con, newItem);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            InventoryItem retrievedItem = DatabaseFunctions.GetInventoryItemByID(con, newItem.ID);
            con.Close();

            Assert.That(retrievedItem.ID == newItem.ID
                && retrievedItem.Name == newItem.Name
                && retrievedItem.Size == newItem.Size
                && retrievedItem.Brand == newItem.Brand
                && retrievedItem.NumInStock == newItem.NumInStock
                && retrievedItem.Cost == newItem.Cost
                && retrievedItem.RetailPrice == newItem.RetailPrice
                && retrievedItem.IsRental == newItem.IsRental
                && retrievedItem.RentalPrice == newItem.RentalPrice
                && retrievedItem.PersonID == newItem.PersonID);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void DeleteInventoryItemTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            InventoryItem createdInventoryItem = DatabaseFunctions.GetInventoryItemByID(con, newItem.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            InventoryItem retrievedItem = DatabaseFunctions.GetInventoryItemByID(con, newItem.ID);
            con.Close();

            Assert.That(retrievedItem.ID == 0
                && retrievedItem.Type == null
                && retrievedItem.Name == null);
        }

        [Test]
        public void GetOrderTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Order Order = DatabaseFunctions.GetOrderByID(con, 1, 1);

            Assert.NotNull(Order);
            con.Close();
        }

        [Test]
        public void CreateOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Order newOrder = new Order();
            newOrder.ID = 9999;
            newOrder.InventoryID = newItem.ID;
            newOrder.Quantity = 9999;
            newOrder.SupplierName = newSupplier.Name;
            newOrder.ShippingMethod = "TestMethod";
            newOrder.OrderDateTime = DateTime.Now;
            newOrder.HasBeenReceived = false;

            DatabaseFunctions.CreateOrderEntry(con, newOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Order retrievedOrder = DatabaseFunctions.GetOrderByID(con, newOrder.ID, newItem.ID);
            con.Close();

            Assert.That(retrievedOrder.ID == newOrder.ID
                && retrievedOrder.InventoryID == newOrder.InventoryID
                && retrievedOrder.Quantity == newOrder.Quantity
                && retrievedOrder.SupplierName == newOrder.SupplierName
                && retrievedOrder.ShippingMethod == newOrder.ShippingMethod
                && retrievedOrder.OrderDateTime.Date == newOrder.OrderDateTime.Date
                && retrievedOrder.OrderDateTime.TimeOfDay.Seconds == newOrder.OrderDateTime.TimeOfDay.Seconds
                && retrievedOrder.HasBeenReceived == newOrder.HasBeenReceived
                && retrievedOrder.ReceivedDate.Date == newOrder.ReceivedDate.Date
                && retrievedOrder.ReceivedDate.TimeOfDay.Seconds == newOrder.ReceivedDate.TimeOfDay.Seconds);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteOrderEntry(con, newOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, newSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdateOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Order newOrder = new Order();
            newOrder.ID = 9999;
            newOrder.InventoryID = newItem.ID;
            newOrder.Quantity = 9999;
            newOrder.SupplierName = newSupplier.Name;
            newOrder.ShippingMethod = "TestMethod";
            newOrder.OrderDateTime = DateTime.Now;
            newOrder.HasBeenReceived = false;

            DatabaseFunctions.CreateOrderEntry(con, newOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            newOrder.Quantity = 888;
            newOrder.ShippingMethod = "ChangedMethod";
            newOrder.HasBeenReceived = true;
            newOrder.ReceivedDate = DateTime.Now;

            DatabaseFunctions.UpdateOrderEntry(con, newOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Order retrievedOrder = DatabaseFunctions.GetOrderByID(con, newOrder.ID, newOrder.InventoryID);
            con.Close();

            Assert.That(retrievedOrder.ID == newOrder.ID
                && retrievedOrder.InventoryID == newOrder.InventoryID
                && retrievedOrder.Quantity == newOrder.Quantity
                && retrievedOrder.SupplierName == newOrder.SupplierName
                && retrievedOrder.ShippingMethod == newOrder.ShippingMethod
                && retrievedOrder.OrderDateTime.Date == newOrder.OrderDateTime.Date
                && retrievedOrder.OrderDateTime.Second == newOrder.OrderDateTime.Second
                && retrievedOrder.HasBeenReceived == newOrder.HasBeenReceived
                && retrievedOrder.ReceivedDate.Date == newOrder.ReceivedDate.Date
                && retrievedOrder.ReceivedDate.Second == newOrder.ReceivedDate.Second);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteOrderEntry(con, newOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, newSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void DeleteOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Supplier newSupplier = CreateTestSupplier(newAddress);
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            Order newOrder = new Order();
            newOrder.ID = 9999;
            newOrder.InventoryID = newItem.ID;
            newOrder.Quantity = 9999;
            newOrder.SupplierName = newSupplier.Name;
            newOrder.ShippingMethod = "TestMethod";
            newOrder.OrderDateTime = DateTime.Now;
            newOrder.HasBeenReceived = false;

            DatabaseFunctions.CreateOrderEntry(con, newOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Order createdOrder = DatabaseFunctions.GetOrderByID(con, newOrder.ID, newOrder.InventoryID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteOrderEntry(con, newOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteSupplierEntry(con, newSupplier.Name);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            Order retrievedOrder = DatabaseFunctions.GetOrderByID(con, newOrder.ID, newOrder.InventoryID);
            con.Close();

            Assert.That(retrievedOrder.ID == 0
                && retrievedOrder.Quantity == 0
                && retrievedOrder.ShippingMethod == null);
        }

        [Test]
        public void GetCustomerOrderTest()
        {
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder CustomerOrder = DatabaseFunctions.GetCustomerOrderByID(con, 1, 1);

            Assert.NotNull(CustomerOrder);
            con.Close();
        }

        [Test]
        public void CreateCustomerOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder newCustomerOrder = new CustomerOrder();
            newCustomerOrder.ID = 9999;
            newCustomerOrder.InventoryID = newItem.ID;
            newCustomerOrder.Type = "Delivery";
            newCustomerOrder.PersonID = newPerson.ID;
            newCustomerOrder.Quantity = 999;
            newCustomerOrder.Date = DateTime.Now;
            newCustomerOrder.HaveReceivedPayment = false;
            newCustomerOrder.RelatedInventoryItemID = newItem.ID;
            newCustomerOrder.Notes = "TestNotes";

            DatabaseFunctions.CreateCustomerOrderEntry(con, newCustomerOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder retrievedCustomerOrder = DatabaseFunctions.GetCustomerOrderByID(con, newCustomerOrder.ID, newItem.ID);
            con.Close();

            Assert.That(retrievedCustomerOrder.ID == newCustomerOrder.ID
                && retrievedCustomerOrder.InventoryID == newCustomerOrder.InventoryID
                && retrievedCustomerOrder.Type == newCustomerOrder.Type
                && retrievedCustomerOrder.PersonID == newCustomerOrder.PersonID
                && retrievedCustomerOrder.Quantity == newCustomerOrder.Quantity
                && retrievedCustomerOrder.Date.Date == newCustomerOrder.Date.Date
                && retrievedCustomerOrder.Date.TimeOfDay.Seconds == newCustomerOrder.Date.TimeOfDay.Seconds
                && retrievedCustomerOrder.HaveReceivedPayment == newCustomerOrder.HaveReceivedPayment
                && retrievedCustomerOrder.RelatedInventoryItemID == newCustomerOrder.RelatedInventoryItemID
                && retrievedCustomerOrder.Notes == newCustomerOrder.Notes);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteCustomerOrderEntry(con, newCustomerOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void UpdateCustomerOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder newCustomerOrder = new CustomerOrder();
            newCustomerOrder.ID = 9999;
            newCustomerOrder.InventoryID = newItem.ID;
            newCustomerOrder.Type = "Delivery";
            newCustomerOrder.PersonID = newPerson.ID;
            newCustomerOrder.Quantity = 999;
            newCustomerOrder.Date = DateTime.Now;
            newCustomerOrder.HaveReceivedPayment = false;
            newCustomerOrder.RelatedInventoryItemID = newItem.ID;
            newCustomerOrder.Notes = "TestNotes";

            DatabaseFunctions.CreateCustomerOrderEntry(con, newCustomerOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            newCustomerOrder.Type = "Repair";
            newCustomerOrder.Quantity = 888;
            newCustomerOrder.HaveReceivedPayment = true;
            newCustomerOrder.PaymentDate = DateTime.Now;
            newCustomerOrder.Notes = "ChangedNotes";

            DatabaseFunctions.UpdateCustomerOrderEntry(con, newCustomerOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder retrievedCustomerOrder = DatabaseFunctions.GetCustomerOrderByID(con, newCustomerOrder.ID, newCustomerOrder.InventoryID);
            con.Close();

            Assert.That(retrievedCustomerOrder.ID == newCustomerOrder.ID
                && retrievedCustomerOrder.InventoryID == newCustomerOrder.InventoryID
                && retrievedCustomerOrder.Type == newCustomerOrder.Type
                && retrievedCustomerOrder.PersonID == newCustomerOrder.PersonID
                && retrievedCustomerOrder.Quantity == newCustomerOrder.Quantity
                && retrievedCustomerOrder.Date.Date == newCustomerOrder.Date.Date
                && retrievedCustomerOrder.Date.TimeOfDay.Seconds == newCustomerOrder.Date.TimeOfDay.Seconds
                && retrievedCustomerOrder.HaveReceivedPayment == newCustomerOrder.HaveReceivedPayment
                && retrievedCustomerOrder.PaymentDate.Date == newCustomerOrder.PaymentDate.Date
                && retrievedCustomerOrder.PaymentDate.TimeOfDay.Seconds == newCustomerOrder.PaymentDate.TimeOfDay.Seconds
                && retrievedCustomerOrder.RelatedInventoryItemID == newCustomerOrder.RelatedInventoryItemID
                && retrievedCustomerOrder.Notes == newCustomerOrder.Notes);

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteCustomerOrderEntry(con, newCustomerOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();
        }

        [Test]
        public void DeleteCustomerOrderTest()
        {
            Address newAddress = CreateTestAddress();
            Person newPerson = CreateTestPerson(newAddress);
            InventoryItem newItem = CreateTestItem(newPerson);

            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder newCustomerOrder = new CustomerOrder();
            newCustomerOrder.ID = 9999;
            newCustomerOrder.InventoryID = newItem.ID;
            newCustomerOrder.Type = "Delivery";
            newCustomerOrder.PersonID = newPerson.ID;
            newCustomerOrder.Quantity = 999;
            newCustomerOrder.Date = DateTime.Now;
            newCustomerOrder.HaveReceivedPayment = false;
            newCustomerOrder.RelatedInventoryItemID = newItem.ID;
            newCustomerOrder.Notes = "TestNotes";

            DatabaseFunctions.CreateCustomerOrderEntry(con, newCustomerOrder);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder createdCustomerOrder = DatabaseFunctions.GetCustomerOrderByID(con, newCustomerOrder.ID, newCustomerOrder.InventoryID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteCustomerOrderEntry(con, newCustomerOrder.ID, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteInventoryItemEntry(con, newItem.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeletePersonEntry(con, newPerson.ID);
            con.Close();
            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            CustomerOrder retrievedCustomerOrder = DatabaseFunctions.GetCustomerOrderByID(con, newCustomerOrder.ID, newCustomerOrder.InventoryID);
            con.Close();

            Assert.That(retrievedCustomerOrder.ID == 0
                && retrievedCustomerOrder.Type == null
                && retrievedCustomerOrder.Quantity == 0);
        }
    }
}
