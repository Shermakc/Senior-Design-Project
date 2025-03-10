CREATE SCHEMA `medistore manager`;

CREATE TABLE `medistore manager`.`user` (
	`ID` INT UNSIGNED NOT NULL,
    `FirstName` VARCHAR(100) NOT NULL,
    `LastName` VARCHAR(100) NOT NULL,
    `Username` VARCHAR(100) NOT NULL UNIQUE,
    `Password` VARCHAR(100) NOT NULL,
    `Position` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`ID`));
    
CREATE TABLE `medistore manager`.`address` (
    `ID` INT UNSIGNED NOT NULL,
    `StreetName` VARCHAR(100) NOT NULL,
    `AddressNumber` INT NOT NULL,
    `City` VARCHAR(100) NOT NULL,
    `State` VARCHAR(100),
    `ZipCode` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`ID`));

CREATE TABLE `medistore manager`.`supplier` (
	`Name` VARCHAR(100) NOT NULL,
    `PhoneNumber` DECIMAL(10) NOT NULL,
    `PartnerID` INT,
    `AddressID` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`Name`),
    FOREIGN KEY (`AddressID`) REFERENCES `address`(`ID`));
    
CREATE TABLE `medistore manager`.`person` (
	`ID` INT UNSIGNED NOT NULL,
    `FirstName` VARCHAR(100) NOT NULL,
    `LastName` VARCHAR(100) NOT NULL,
    `MiddleName` VARCHAR(100),
    `HomePhone` DECIMAL(10),
    `CellPhone` DECIMAL(10),
    `AddressID` INT UNSIGNED NOT NULL,
    `InsuranceProvider` VARCHAR(100),
    `IsPatientContact` BOOL NOT NULL DEFAULT 0,
    `ContactID` INT UNSIGNED,
    `ContactRelationship` VARCHAR(100),
    PRIMARY KEY (`ID`),
    FOREIGN KEY (`AddressID`) REFERENCES `address`(`ID`));
    
CREATE TABLE `medistore manager`.`inventory_item` (
	`ID` INT UNSIGNED NOT NULL,
    `Type` VARCHAR(10) NOT NULL,
    `Name` VARCHAR(100) NOT NULL,
    `Size` VARCHAR(100),
    `Brand` VARCHAR(100),
    `NumInStock` INT NOT NULL DEFAULT 0,
    `Cost` DECIMAL(10) NOT NULL DEFAULT 0,
    `RetailPrice` DECIMAL(10),
    `IsRental` BOOL NOT NULL DEFAULT 0,
    `RentalPrice` DECIMAL(10),
    `PersonID` INT UNSIGNED,
    PRIMARY KEY (`ID`),
    FOREIGN KEY (`PersonID`) REFERENCES `person`(`ID`));

CREATE TABLE `medistore manager`.`order` (
    `ID` INT UNSIGNED NOT NULL,
    `InventoryID` INT UNSIGNED NOT NULL,
    `Quantity` INT NOT NULL,
    `SupplierName` VARCHAR(100) NOT NULL,
    `ShippingMethod` VARCHAR(100),
    `OrderDateTime` DATETIME NOT NULL,
    `HasBeenReceived` BOOL NOT NULL DEFAULT 0,
    `ReceivedDate` DATETIME,
    PRIMARY KEY (`ID`, `InventoryID`),
    FOREIGN KEY (`InventoryID`) REFERENCES `inventory_item`(`ID`),
    FOREIGN KEY (`SupplierName`) REFERENCES `supplier`(`Name`));

CREATE TABLE `medistore manager`.`customer_order` (	
    `ID` INT UNSIGNED NOT NULL,
    `InventoryID` INT UNSIGNED NOT NULL,
    `Type` VARCHAR(100) NOT NULL,
    `PersonID` INT UNSIGNED NOT NULL,
    `Quantity` INT NOT NULL,
    `Date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `HaveReceivedPayment` BOOL NOT NULL DEFAULT 0,
    `PaymentDate` DATETIME,
    `RelatedInventoryItemID` INT UNSIGNED,
    `Notes` VARCHAR(100),
    PRIMARY KEY (`ID`, `InventoryID`),
    FOREIGN KEY (`InventoryID`) REFERENCES `inventory_item`(`ID`),
    FOREIGN KEY (`PersonID`) REFERENCES `person`(`ID`),
    FOREIGN KEY (`RelatedInventoryItemID`) REFERENCES `inventory_item`(`ID`));
