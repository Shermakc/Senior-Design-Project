INSERT INTO `medistore manager`.address (ID, StreetName, AddressNumber, City, State, ZipCode) VALUES (0, "", 0, "", "", 0);
INSERT INTO `medistore manager`.person (ID, FirstName, LastName) VALUES (0, "", "");
INSERT INTO `medistore manager`.supplier (Name, PhoneNumber) VALUES ("Defualt", "0000000000");
INSERT INTO `medistore manager`.inventroy_item (ID, Type, Name) VALUES (0, "", "");
INSERT INTO `medistore manager`.order (ID, InventoryID, Quantity, SupplierName, OrderDateTime) VALUES (0, 0, 0, "Default", "0001-01-01 00:00:00");
INSERT INTO `medistore manager`.customer_order (ID, InventoryID, Type, PersonID, Quantity) VALUES (0, 0, "Delivery", 0, 0);