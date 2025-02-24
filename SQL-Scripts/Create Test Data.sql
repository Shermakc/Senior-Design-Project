# Generate Addresses
INSERT INTO `medistor manager`.`address` (`ID`, `StreetName`, `AddressNumber`, `City`, `State`, `ZipCode`) VALUES ('0', 'Tharp Street', '114', 'Arlignton', 'TX', '76010');
INSERT INTO `medistore manager`.`address` (`ID`, `StreetName`, `AddressNumber`, `City`, `State`, `ZipCode`)
VALUES
(1, 'Main St', 123, 'New York', 'NY', '10001'),
(2, 'Broadway', 456, 'Los Angeles', 'CA', '90001'),
(3, 'Elm St', 789, 'Chicago', 'IL', '60601'),
(4, 'Oak St', 101, 'Houston', 'TX', '77001'),
(5, 'Pine St', 202, 'Phoenix', 'AZ', '85001'),
(6, 'Maple Ave', 303, 'Philadelphia', 'PA', '19019'),
(7, 'Cedar Blvd', 404, 'San Antonio', 'TX', '78201'),
(8, 'Birch Rd', 505, 'San Diego', 'CA', '92101'),
(9, 'Walnut St', 606, 'Dallas', 'TX', '75201'),
(10, 'Cherry Ln', 707, 'San Jose', 'CA', '95101'),
(11, 'Willow Dr', 808, 'Austin', 'TX', '73301'),
(12, 'Spruce Ct', 909, 'Jacksonville', 'FL', '32099'),
(13, 'Magnolia Way', 112, 'San Francisco', 'CA', '94101'),
(14, 'Cypress Pl', 223, 'Indianapolis', 'IN', '46201'),
(15, 'Poplar Ave', 334, 'Columbus', 'OH', '43085'),
(16, 'Sycamore St', 445, 'Fort Worth', 'TX', '76101'),
(17, 'Ash Blvd', 556, 'Charlotte', 'NC', '28201'),
(18, 'Beech Rd', 667, 'Seattle', 'WA', '98101'),
(19, 'Holly Dr', 778, 'Denver', 'CO', '80201'),
(20, 'Laurel Ln', 889, 'Washington', 'DC', '20001'),
(21, 'Dogwood Ct', 990, 'Boston', 'MA', '02101'),
(22, 'Redwood Way', 111, 'Nashville', 'TN', '37201'),
(23, 'Fir Pl', 222, 'Baltimore', 'MD', '21201'),
(24, 'Juniper Ave', 333, 'Oklahoma City', 'OK', '73101'),
(25, 'Palm St', 444, 'Louisville', 'KY', '40201'),
(26, 'Chestnut Blvd', 555, 'Portland', 'OR', '97201'),
(27, 'Hickory Rd', 666, 'Las Vegas', 'NV', '89101'),
(28, 'Locust Dr', 777, 'Milwaukee', 'WI', '53201'),
(29, 'Mulberry Ln', 888, 'Albuquerque', 'NM', '87101'),
(30, 'Alder Ct', 999, 'Tucson', 'AZ', '85701'),
(31, 'Ginkgo Way', 121, 'Fresno', 'CA', '93650'),
(32, 'Catalpa Pl', 232, 'Sacramento', 'CA', '94203'),
(33, 'Basswood Ave', 343, 'Kansas City', 'MO', '64101'),
(34, 'Buckeye St', 454, 'Long Beach', 'CA', '90801'),
(35, 'Catalina Blvd', 565, 'Mesa', 'AZ', '85201'),
(36, 'Canyon Rd', 676, 'Atlanta', 'GA', '30301'),
(37, 'Summit Dr', 787, 'Colorado Springs', 'CO', '80901'),
(38, 'Ridge Ln', 898, 'Raleigh', 'NC', '27601'),
(39, 'Valley Ct', 909, 'Omaha', 'NE', '68101'),
(40, 'Meadow Way', 112, 'Miami', 'FL', '33101'),
(41, 'Brook Pl', 223, 'Oakland', 'CA', '94601'),
(42, 'Lake Ave', 334, 'Minneapolis', 'MN', '55401'),
(43, 'River St', 445, 'Tulsa', 'OK', '74101'),
(44, 'Ocean Blvd', 556, 'Cleveland', 'OH', '44101'),
(45, 'Bay Rd', 667, 'Arlington', 'TX', '76001'),
(46, 'Harbor Dr', 778, 'New Orleans', 'LA', '70112'),
(47, 'Island Ln', 889, 'Wichita', 'KS', '67201'),
(48, 'Mountain Ct', 990, 'Honolulu', 'HI', '96801'),
(49, 'Forest Way', 101, 'Anaheim', 'CA', '92801'),
(50, 'Park Pl', 212, 'Tampa', 'FL', '33601');
INSERT INTO `medistore manager`.`address` (`ID`, `StreetName`, `AddressNumber`, `City`, `State`, `ZipCode`)
VALUES
(51, 'Market St', 100, 'San Francisco', 'CA', '94101'),
(52, 'Broadway', 200, 'New York', 'NY', '10001'),
(53, 'Main St', 300, 'Chicago', 'IL', '60601'),
(54, 'Elm St', 400, 'Houston', 'TX', '77001'),
(55, 'Oak St', 500, 'Phoenix', 'AZ', '85001'),
(56, 'Pine St', 600, 'Philadelphia', 'PA', '19019'),
(57, 'Cedar Blvd', 700, 'San Antonio', 'TX', '78201'),
(58, 'Birch Rd', 800, 'San Diego', 'CA', '92101'),
(59, 'Walnut St', 900, 'Dallas', 'TX', '75201'),
(60, 'Cherry Ln', 1000, 'San Jose', 'CA', '95101'),
(61, 'Willow Dr', 1100, 'Austin', 'TX', '73301'),
(62, 'Spruce Ct', 1200, 'Jacksonville', 'FL', '32099'),
(63, 'Magnolia Way', 1300, 'San Francisco', 'CA', '94101'),
(64, 'Cypress Pl', 1400, 'Indianapolis', 'IN', '46201'),
(65, 'Poplar Ave', 1500, 'Columbus', 'OH', '43085'),
(66, 'Sycamore St', 1600, 'Fort Worth', 'TX', '76101'),
(67, 'Ash Blvd', 1700, 'Charlotte', 'NC', '28201'),
(68, 'Beech Rd', 1800, 'Seattle', 'WA', '98101'),
(69, 'Holly Dr', 1900, 'Denver', 'CO', '80201'),
(70, 'Laurel Ln', 2000, 'Washington', 'DC', '20001');

# Generate People
INSERT INTO `medistore manager`.`person` (`ID`, `FirstName`, `LastName`, `MiddleName`, `HomePhone`, `CellPhone`, `AddressID`, `InsuranceProvider`, `IsPatientContact`, `ContactID`, `ContactRelationship`) VALUES ('0', 'John', 'Smith', 'A', '8177819169', '9566764181', '0', 'Signa', '1', '1', 'Wife');
INSERT INTO `medistore manager`.`person` (`ID`, `FirstName`, `LastName`, `MiddleName`, `HomePhone`, `CellPhone`, `AddressID`, `InsuranceProvider`, `IsPatientContact`) VALUES ('1', 'Jane', 'Doe', 'F', '8177819169', '2361703130', '0', 'Signa', '0');
INSERT INTO `medistore manager`.`person` (`ID`, `FirstName`, `LastName`, `MiddleName`, `HomePhone`, `CellPhone`, `AddressID`, `InsuranceProvider`, `IsPatientContact`, `ContactID`, `ContactRelationship`)
VALUES
(2, 'John', 'Doe', 'Michael', 1234567890, 9876543210, 1, 'Medicare', FALSE, NULL, NULL),
(3, 'Jane', 'Smith', 'Anne', 2345678901, 8765432109, 2, 'Medicaid', TRUE, 2, 'Sister'),
(4, 'Robert', 'Brown', 'Lee', 3456789012, 7654321098, 3, 'Signa', FALSE, NULL, NULL),
(5, 'Mary', 'Johnson', 'Elizabeth', 4567890123, 6543210987, 4, 'BlueShield', TRUE, 2, 'Daughter'),
(6, 'Michael', 'Davis', 'James', 5678901234, 5432109876, 5, 'Aetna', FALSE, NULL, NULL),
(7, 'Linda', 'Miller', 'Grace', 6789012345, 4321098765, 6, 'United Healthcare', TRUE, 4, 'Mother'),
(8, 'William', 'Wilson', 'Thomas', 7890123456, 3210987654, 7, 'Medicare', FALSE, NULL, NULL),
(9, 'Barbara', 'Moore', 'Ann', 8901234567, 2109876543, 8, 'Medicaid', TRUE, 5, 'Friend'),
(10, 'David', 'Taylor', 'Paul', 9012345678, 1098765432, 9, 'Signa', FALSE, NULL, NULL),
(11, 'Susan', 'Anderson', 'Marie', 1234509876, 9876012345, 10, 'BlueShield', TRUE, 6, 'Cousin'),
(12, 'Richard', 'Thomas', 'Edward', 2345610987, 8765123456, 11, 'Aetna', FALSE, NULL, NULL),
(13, 'Jessica', 'Jackson', 'Rose', 3456721098, 7654234567, 12, 'United Healthcare', TRUE, 7, 'Sister'),
(14, 'Joseph', 'White', 'Henry', 4567832109, 6543345678, 13, 'Medicare', FALSE, NULL, NULL),
(15, 'Sarah', 'Harris', 'Jane', 5678943210, 5432456789, 14, 'Medicaid', TRUE, 8, 'Daughter'),
(16, 'Thomas', 'Martin', 'Charles', 6789054321, 4321567890, 15, 'Signa', FALSE, NULL, NULL),
(17, 'Karen', 'Thompson', 'Louise', 7890165432, 3210678901, 16, 'BlueShield', TRUE, 9, 'Mother'),
(18, 'Charles', 'Garcia', 'George', 8901276543, 2109789012, 17, 'Aetna', FALSE, NULL, NULL),
(19, 'Nancy', 'Martinez', 'Patricia', 9012387654, 1098890123, 18, 'United Healthcare', TRUE, 10, 'Friend'),
(20, 'Daniel', 'Robinson', 'Frank', 1234598765, 9876901234, 19, 'Medicare', FALSE, NULL, NULL),
(21, 'Lisa', 'Clark', 'Margaret', 2345609876, 8765012345, 20, 'Medicaid', TRUE, 11, 'Cousin'),
(22, 'Matthew', 'Rodriguez', 'Anthony', 3456710987, 7654123456, 21, 'Signa', FALSE, NULL, NULL);

# Generate Inventory
INSERT INTO `medistore manager`.`inventory_item` (`ID`, `Type`, `Name`, `Size`, `Brand`, `NumInStock`, `Cost`, `RetailPrice`, `IsRental`, `RentalPrice`, `PersonID`)
VALUES
-- Equipment (NumInStock must be 1 or 0, IsRental can be true or false)
(1, 'equipment', 'Wheelchairs', 'Standard', 'Drive Medical', 1, 200.00, 0.00, TRUE, 50.00, NULL),
(2, 'equipment', 'Walkers', 'Standard', 'Medline', 1, 50.00, 0.00, TRUE, 15.00, NULL),
(3, 'equipment', 'Hospital Beds', 'Twin', 'Invacare', 0, 800.00, 0.00, TRUE, 100.00, 2), -- Rented to PersonID 2
(4, 'equipment', 'Patient Lifts', 'Heavy Duty', 'Vive', 1, 300.00, 0.00, TRUE, 40.00, NULL),
(5, 'equipment', 'Oxygen Concentrators', 'Portable', 'Inogen', 1, 1200.00, 0.00, TRUE, 150.00, NULL),
(6, 'equipment', 'Nebulizers', 'Compact', 'Philips', 1, 80.00, 0.00, FALSE, 0.00, NULL),
(7, 'equipment', 'CPAP Machines', 'Standard', 'ResMed', 0, 500.00, 0.00, TRUE, 75.00, 3), -- Rented to PersonID 3
(8, 'equipment', 'Blood Pressure Monitors', 'Arm Cuff', 'Omron', 1, 60.00, 0.00, FALSE, 0.00, NULL),
(9, 'equipment', 'Glucose Meters', 'Compact', 'Accu-Chek', 1, 40.00, 0.00, FALSE, 0.00, NULL),
(10, 'equipment', 'Diabetic Supplies', 'Standard', 'OneTouch', 1, 30.00, 0.00, FALSE, 0.00, NULL),

-- Supply (NumInStock can be any integer, IsRental must be false, RentalPrice must be 0)
(11, 'supply', 'Crutches', 'Adult', 'Medline', 10, 25.00, 50.00, FALSE, 0.00, NULL),
(12, 'supply', 'Canes', 'Standard', 'Carex', 15, 15.00, 30.00, FALSE, 0.00, NULL),
(13, 'supply', 'Compression Stockings', 'Medium', 'Jobst', 20, 20.00, 40.00, FALSE, 0.00, NULL),
(14, 'supply', 'Orthopedic Braces', 'Large', 'McDavid', 5, 50.00, 100.00, FALSE, 0.00, NULL),
(15, 'supply', 'First Aid Kits', '50-Piece', 'First Aid Only', 30, 25.00, 50.00, FALSE, 0.00, NULL),
(16, 'supply', 'Wound Care Supplies', 'Variety Pack', '3M', 50, 40.00, 80.00, FALSE, 0.00, NULL),
(17, 'supply', 'Incontinence Products', 'Large', 'Depend', 100, 30.00, 60.00, FALSE, 0.00, NULL),
(18, 'supply', 'Medical Gloves', 'Medium', 'Halyard', 200, 10.00, 20.00, FALSE, 0.00, NULL),
(19, 'supply', 'Stethoscopes', 'Standard', 'Littmann', 10, 80.00, 160.00, FALSE, 0.00, NULL),
(20, 'supply', 'Thermometers', 'Digital', 'Braun', 25, 20.00, 40.00, FALSE, 0.00, NULL);

# Generate Suppliers
INSERT INTO `medistore manager`.`supplier` (`Name`, `PhoneNumber`, `PartnerID`, `AddressID`)
VALUES
('MedEquip Inc.', 1234567890, 101, 51),
('HealthSupplies Co.', 2345678901, 102, 52),
('CarePlus Medical', 3456789012, 103, 53),
('AidFirst Supplies', 4567890123, 104, 54),
('MediCorp Solutions', 5678901234, 105, 55),
('LifeLine Equipment', 6789012345, 106, 56),
('HealWell Supplies', 7890123456, 107, 57),
('FirstAid Essentials', 8901234567, 108, 58),
('VitalCare Medical', 9012345678, 109, 59),
('MediTech Innovations', 1234509876, 110, 60),
('CareForAll Supplies', 2345610987, 111, 61),
('HealthFirst Equipment', 3456721098, 112, 62),
('Wellness Solutions', 4567832109, 113, 63),
('MediAid Supplies', 5678943210, 114, 64),
('Healing Hands Co.', 6789054321, 115, 65),
('CareMasters Medical', 7890165432, 116, 66),
('LifeSupport Equipment', 8901276543, 117, 67),
('MediCare Plus', 9012387654, 118, 68),
('HealthGuard Supplies', 1234598765, 119, 69),
('AidMasters Co.', 2345609876, 120, 70);