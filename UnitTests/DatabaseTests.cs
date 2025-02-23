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
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Address newAddress = new Address();
            newAddress.ID = 9999;
            newAddress.StreetName = "TestStreet";
            newAddress.AddressNumber = 9999;
            newAddress.City = "TestCity";
            newAddress.State = "TestState";
            newAddress.ZipCode = 99999;

            DatabaseFunctions.CreateAddressEntry(con, newAddress);
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
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Address newAddress = new Address();
            newAddress.ID = 9999;
            newAddress.StreetName = "TestStreet";
            newAddress.AddressNumber = 9999;
            newAddress.City = "TestCity";
            newAddress.State = "TestState";
            newAddress.ZipCode = 99999;

            DatabaseFunctions.CreateAddressEntry(con, newAddress);
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
            MySqlConnection con = DatabaseFunctions.OpenMySQLConnection();

            Address newAddress = new Address();
            newAddress.ID = 9999;
            newAddress.StreetName = "TestStreet";
            newAddress.AddressNumber = 9999;
            newAddress.City = "TestCity";
            newAddress.State = "TestState";
            newAddress.ZipCode = 99999;

            DatabaseFunctions.CreateAddressEntry(con, newAddress);
            Address createdAddress = DatabaseFunctions.GetAddressByID(con, newAddress.ID);
            con.Close();

            con = DatabaseFunctions.OpenMySQLConnection();
            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);


            con.Close();
        }

        [Test]
        public void GetPersonTest()
        {

        }

        [Test]
        public void CreatePersonTest()
        {

        }

        [Test]
        public void UpdatePersonTest()
        {

        }

        [Test]
        public void DeletePersonTest()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
