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
        private void Setup()
        {
            
        }

        [Test]
        private void GetAddressTest()
        {

        }

        [Test]
        private void CreateAddressTest()
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

            Assert.That(createdAddress == newAddress);

            DatabaseFunctions.DeleteAddressEntry(con, newAddress.ID);

            con.Close();
        }

        [Test]
        private void UpdateAddressTest()
        {

        }

        [Test]
        private void DeleteAddressTest()
        {

        }


        [Test]
        private void GetPersonTest()
        {

        }

        [Test]
        private void CreatePersonTest()
        {

        }

        [Test]
        private void UpdatePersonTest()
        {

        }

        [Test]
        private void DeletePersonTest()
        {

        }



        [TearDown]
        private void TearDown()
        {

        }
    }
}
