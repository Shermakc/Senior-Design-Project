-- Create supply items
INSERT INTO `medistore manager`.inventory_item (ID, Type, Name, Size, Brand, NumInStock, Cost, RetailPrice, IsRental, RentalPrice, PersonID)
VALUES
    (1, 'supply', 'Bandages (Adhesive)', 'Small', 'Band-Aid', 100, 0.10, 0.50, FALSE, 0, NULL),
    (2, 'supply', 'Gauze Pads', '4x4 inches', 'Curity', 200, 0.20, 1.00, FALSE, 0, NULL),
    (3, 'supply', 'Medical Tape', '1 inch', '3M', 150, 0.50, 2.00, FALSE, 0, NULL),
    (4, 'supply', 'Alcohol Wipes', '100 count', 'PDI', 300, 0.05, 0.25, FALSE, 0, NULL),
    (5, 'supply', 'Antiseptic Wipes', '50 count', 'Hibiclens', 250, 0.15, 0.75, FALSE, 0, NULL),
    (6, 'supply', 'Cotton Balls', '100 count', 'Swisspers', 500, 0.02, 0.10, FALSE, 0, NULL),
    (7, 'supply', 'Cotton Swabs', '200 count', 'Q-tips', 400, 0.03, 0.15, FALSE, 0, NULL),
    (8, 'supply', 'Disposable Gloves (Latex)', 'Medium', 'Medline', 1000, 0.10, 0.50, FALSE, 0, NULL),
    (9, 'supply', 'Disposable Gloves (Nitrile)', 'Large', 'Halyard', 800, 0.15, 0.75, FALSE, 0, NULL),
    (10, 'supply', 'Disposable Gloves (Vinyl)', 'Small', 'Cardinal Health', 600, 0.12, 0.60, FALSE, 0, NULL),
    (11, 'supply', 'Face Masks (Surgical)', 'Standard', '3M', 1200, 0.25, 1.25, FALSE, 0, NULL),
    (12, 'supply', 'N95 Respirators', 'Regular', 'Honeywell', 500, 1.00, 5.00, FALSE, 0, NULL),
    (13, 'supply', 'Face Shields', 'One Size', 'Dynarex', 300, 0.75, 3.75, FALSE, 0, NULL),
    (14, 'supply', 'Disposable Gowns', 'Large', 'Medline', 400, 1.50, 7.50, FALSE, 0, NULL),
    (15, 'supply', 'Shoe Covers', 'One Size', 'Cardinal Health', 600, 0.10, 0.50, FALSE, 0, NULL),
    (16, 'supply', 'Bouffant Caps', 'One Size', 'Dynarex', 800, 0.05, 0.25, FALSE, 0, NULL),
    (17, 'supply', 'Syringes (Disposable)', '10 mL', 'BD', 1000, 0.20, 1.00, FALSE, 0, NULL),
    (18, 'supply', 'Needles (Hypodermic)', '21G', 'BD', 1200, 0.15, 0.75, FALSE, 0, NULL),
    (19, 'supply', 'IV Catheters', '18G', 'BD', 900, 0.50, 2.50, FALSE, 0, NULL),
    (20, 'supply', 'IV Tubing', 'Standard', 'Baxter', 700, 1.00, 5.00, FALSE, 0, NULL),
    (21, 'supply', 'IV Bags', '500 mL', 'Baxter', 600, 2.00, 10.00, FALSE, 0, NULL),
    (22, 'supply', 'Saline Solution', '1000 mL', 'Baxter', 500, 3.00, 15.00, FALSE, 0, NULL),
    (23, 'supply', 'Alcohol Swabs', '100 count', 'PDI', 1000, 0.05, 0.25, FALSE, 0, NULL),
    (24, 'supply', 'Hydrogen Peroxide', '16 oz', 'Curity', 300, 0.50, 2.50, FALSE, 0, NULL),
    (25, 'supply', 'Isopropyl Alcohol', '32 oz', 'Curity', 400, 1.00, 5.00, FALSE, 0, NULL),
    (26, 'supply', 'Hand Sanitizer', '8 oz', 'Purell', 600, 0.75, 3.75, FALSE, 0, NULL),
    (27, 'supply', 'Wound Cleansers', '8 oz', 'Smith & Nephew', 200, 2.00, 10.00, FALSE, 0, NULL),
    (28, 'supply', 'Adhesive Bandages (Assorted Sizes)', '100 count', 'Band-Aid', 1000, 0.10, 0.50, FALSE, 0, NULL),
    (29, 'supply', 'Elastic Bandages (Ace Wraps)', '3 inch', '3M', 500, 1.00, 5.00, FALSE, 0, NULL),
    (30, 'supply', 'Compression Stockings', 'Medium', 'Medi', 300, 5.00, 25.00, FALSE, 0, NULL),
    (31, 'supply', 'Incontinence Pads', 'Large', 'Depend', 400, 0.50, 2.50, FALSE, 0, NULL),
    (32, 'supply', 'Adult Diapers', 'Medium', 'Depend', 600, 1.00, 5.00, FALSE, 0, NULL),
    (33, 'supply', 'Bed Pads (Disposable)', 'Standard', 'Medline', 500, 0.75, 3.75, FALSE, 0, NULL),
    (34, 'supply', 'Urinary Catheters', '14 Fr', 'Bard', 300, 2.00, 10.00, FALSE, 0, NULL),
    (35, 'supply', 'Ostomy Bags', 'One Piece', 'Hollister', 200, 5.00, 25.00, FALSE, 0, NULL),
    (36, 'supply', 'Ostomy Supplies', 'Standard', 'Coloplast', 150, 3.00, 15.00, FALSE, 0, NULL),
    (37, 'supply', 'Wound Dressings', '4x4 inches', '3M', 400, 1.00, 5.00, FALSE, 0, NULL),
    (38, 'supply', 'Hydrogel Dressings', '2x2 inches', 'Smith & Nephew', 300, 2.00, 10.00, FALSE, 0, NULL),
    (39, 'supply', 'Silicone Dressings', '3x3 inches', 'Mölnlycke', 200, 3.00, 15.00, FALSE, 0, NULL),
    (40, 'supply', 'Sterile Dressings', '4x4 inches', 'Curity', 500, 0.50, 2.50, FALSE, 0, NULL),
    (41, 'supply', 'Surgical Masks', 'Standard', '3M', 1000, 0.25, 1.25, FALSE, 0, NULL),
    (42, 'supply', 'Surgical Drapes', 'Standard', 'Cardinal Health', 600, 1.00, 5.00, FALSE, 0, NULL),
    (43, 'supply', 'Surgical Gowns', 'Large', 'Medline', 400, 2.00, 10.00, FALSE, 0, NULL),
    (44, 'supply', 'Surgical Sutures', '3-0', 'Ethicon', 300, 5.00, 25.00, FALSE, 0, NULL),
    (45, 'supply', 'Surgical Staples', 'Regular', 'Medtronic', 200, 10.00, 50.00, FALSE, 0, NULL),
    (46, 'supply', 'Sterile Water', '1000 mL', 'Baxter', 500, 1.00, 5.00, FALSE, 0, NULL),
    (47, 'supply', 'Lubricating Jelly', '4 oz', 'Surgilube', 300, 0.50, 2.50, FALSE, 0, NULL),
    (48, 'supply', 'Tongue Depressors', 'Standard', 'Dynarex', 1000, 0.02, 0.10, FALSE, 0, NULL),
    (49, 'supply', 'Specimen Containers', '120 mL', 'Medline', 800, 0.10, 0.50, FALSE, 0, NULL),
    (50, 'supply', 'Test Strips (Glucose)', '50 count', 'Accu-Chek', 600, 0.50, 2.50, FALSE, 0, NULL);
    
-- Randomly generate 500 equipment items from list of names
DELIMITER //

CREATE PROCEDURE InsertDurableMedicalEquipment()
BEGIN
    DECLARE i INT DEFAULT 51; -- Start ID at 51
    DECLARE item_name VARCHAR(255);
    DECLARE num_in_stock INT;
    DECLARE person_id INT;
    DECLARE is_rental BOOLEAN;
    DECLARE retail_price DECIMAL(10, 2);
    DECLARE rental_price DECIMAL(10, 2);

    -- List of durable medical equipment items
    SET @equipment_names = 'Wheelchair (Manual),Wheelchair (Electric),Hospital Bed (Manual),Hospital Bed (Electric),Patient Lift,Walker (Standard),Rollator,Crutch (Underarm),Crutch (Forearm),Cane (Standard),Cane (Quad),Transfer Board,Shower Chair,Commode,Bedside Rail,Overbed Table,Oxygen Concentrator,Portable Oxygen Tank,CPAP Machine,BiPAP Machine,Nebulizer,Blood Pressure Monitor,Pulse Oximeter,Glucose Meter,Thermometer (Digital),Thermometer (Ear),Thermometer (Forehead),Compression Therapy Device,Orthopedic Brace (Knee),Orthopedic Brace (Ankle),Orthopedic Brace (Wrist),Cervical Collar,Back Brace,Prosthetic Limb,Orthotic Insole,Power Scooter,Stair Lift,Scale (Digital),Scale (Bariatric),IV Pole,Suction Machine,Ventilator,Infant Warmer,Fetal Doppler,Ultrasound Machine,Defibrillator,Medical Cart,Stretcher,Exam Table,Surgical Light';

    WHILE i <= 550 DO -- Insert 500 entries (IDs from 51 to 550)
        -- Randomly select an item name from the list
        SET item_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@equipment_names, ',', FLOOR(1 + RAND() * 50)), ',', -1);

        -- Randomly set NumInStock to 1 or 0
        SET num_in_stock = FLOOR(RAND() * 2);

        -- Set PersonID based on NumInStock
        IF num_in_stock = 0 THEN
            SET person_id = FLOOR(RAND() * 1000);
        ELSE
            SET person_id = NULL;
        END IF;

        -- Randomly set IsRental (90% chance of 0, 10% chance of 1)
        IF RAND() < 0.9 THEN
            SET is_rental = FALSE;
            SET retail_price = FLOOR(10 + RAND() * 1000); -- Random RetailPrice between 10 and 1000
            SET rental_price = 0;
        ELSE
            SET is_rental = TRUE;
            SET retail_price = 0;
            SET rental_price = FLOOR(10 + RAND() * 100); -- Random RentalPrice between 10 and 100
        END IF;

        -- Insert the entry into the inventory_item table
        INSERT INTO `medistore manager`.inventory_item (ID, Type, Name, Size, Brand, NumInStock, Cost, RetailPrice, IsRental, RentalPrice, PersonID)
        VALUES (i, 'equipment', item_name, 'Standard', 'Generic Brand', num_in_stock, 0, retail_price, is_rental, rental_price, person_id);

        SET i = i + 1;
    END WHILE;
END //

DELIMITER ;

-- Call the procedure to insert 500 entries
CALL InsertDurableMedicalEquipment();
DROP PROCEDURE IF EXISTS InsertDurableMedicalEquipment;

-- Insert 50 part items
INSERT INTO `medistore manager`.inventory_item (ID, Type, Name, Size, Brand, NumInStock, Cost, RetailPrice, IsRental, RentalPrice, PersonID)
VALUES
    (551, 'part', 'Wheelchair Wheel', 'Standard', 'Generic Brand', 10, 25.00, 50.00, FALSE, 0, NULL),
    (552, 'part', 'Wheelchair Brake', 'Standard', 'Generic Brand', 15, 10.00, 20.00, FALSE, 0, NULL),
    (553, 'part', 'Wheelchair Seat Cushion', 'Standard', 'Generic Brand', 20, 30.00, 60.00, FALSE, 0, NULL),
    (554, 'part', 'Wheelchair Armrest', 'Standard', 'Generic Brand', 12, 15.00, 30.00, FALSE, 0, NULL),
    (555, 'part', 'Wheelchair Footrest', 'Standard', 'Generic Brand', 8, 20.00, 40.00, FALSE, 0, NULL),
    (556, 'part', 'Hospital Bed Mattress', 'Twin', 'Generic Brand', 5, 100.00, 200.00, FALSE, 0, NULL),
    (557, 'part', 'Hospital Bed Side Rail', 'Standard', 'Generic Brand', 7, 50.00, 100.00, FALSE, 0, NULL),
    (558, 'part', 'Hospital Bed Caster', 'Standard', 'Generic Brand', 10, 15.00, 30.00, FALSE, 0, NULL),
    (559, 'part', 'Hospital Bed Motor', 'Standard', 'Generic Brand', 3, 200.00, 400.00, FALSE, 0, NULL),
    (560, 'part', 'Patient Lift Strap', 'Standard', 'Generic Brand', 25, 10.00, 20.00, FALSE, 0, NULL),
    (561, 'part', 'Patient Lift Battery', 'Standard', 'Generic Brand', 6, 50.00, 100.00, FALSE, 0, NULL),
    (562, 'part', 'Walker Hand Grip', 'Standard', 'Generic Brand', 30, 5.00, 10.00, FALSE, 0, NULL),
    (563, 'part', 'Walker Rubber Tip', 'Standard', 'Generic Brand', 50, 2.00, 5.00, FALSE, 0, NULL),
    (564, 'part', 'Rollator Seat Pad', 'Standard', 'Generic Brand', 20, 15.00, 30.00, FALSE, 0, NULL),
    (565, 'part', 'Rollator Brake Cable', 'Standard', 'Generic Brand', 10, 10.00, 20.00, FALSE, 0, NULL),
    (566, 'part', 'Crutch Tip', 'Standard', 'Generic Brand', 100, 1.00, 2.00, FALSE, 0, NULL),
    (567, 'part', 'Crutch Handle', 'Standard', 'Generic Brand', 25, 5.00, 10.00, FALSE, 0, NULL),
    (568, 'part', 'Cane Tip', 'Standard', 'Generic Brand', 75, 1.00, 2.00, FALSE, 0, NULL),
    (569, 'part', 'Transfer Board Pad', 'Standard', 'Generic Brand', 15, 10.00, 20.00, FALSE, 0, NULL),
    (570, 'part', 'Shower Chair Leg', 'Standard', 'Generic Brand', 10, 15.00, 30.00, FALSE, 0, NULL),
    (571, 'part', 'Commode Seat Cover', 'Standard', 'Generic Brand', 20, 10.00, 20.00, FALSE, 0, NULL),
    (572, 'part', 'Overbed Table Top', 'Standard', 'Generic Brand', 5, 50.00, 100.00, FALSE, 0, NULL),
    (573, 'part', 'Oxygen Concentrator Filter', 'Standard', 'Generic Brand', 30, 5.00, 10.00, FALSE, 0, NULL),
    (574, 'part', 'Portable Oxygen Tank Valve', 'Standard', 'Generic Brand', 10, 20.00, 40.00, FALSE, 0, NULL),
    (575, 'part', 'CPAP Machine Tube', 'Standard', 'Generic Brand', 25, 15.00, 30.00, FALSE, 0, NULL),
    (576, 'part', 'CPAP Machine Mask', 'Standard', 'Generic Brand', 20, 30.00, 60.00, FALSE, 0, NULL),
    (577, 'part', 'BiPAP Machine Filter', 'Standard', 'Generic Brand', 15, 10.00, 20.00, FALSE, 0, NULL),
    (578, 'part', 'Nebulizer Mouthpiece', 'Standard', 'Generic Brand', 50, 2.00, 5.00, FALSE, 0, NULL),
    (579, 'part', 'Blood Pressure Monitor Cuff', 'Standard', 'Generic Brand', 20, 25.00, 50.00, FALSE, 0, NULL),
    (580, 'part', 'Pulse Oximeter Sensor', 'Standard', 'Generic Brand', 30, 10.00, 20.00, FALSE, 0, NULL),
    (581, 'part', 'Glucose Meter Test Strip', 'Standard', 'Generic Brand', 100, 0.50, 1.00, FALSE, 0, NULL),
    (582, 'part', 'Thermometer Probe Cover', 'Standard', 'Generic Brand', 200, 0.10, 0.25, FALSE, 0, NULL),
    (583, 'part', 'Compression Pump Hose', 'Standard', 'Generic Brand', 15, 20.00, 40.00, FALSE, 0, NULL),
    (584, 'part', 'Knee Brace Strap', 'Standard', 'Generic Brand', 25, 5.00, 10.00, FALSE, 0, NULL),
    (585, 'part', 'Ankle Brace Fastener', 'Standard', 'Generic Brand', 20, 3.00, 6.00, FALSE, 0, NULL),
    (586, 'part', 'Wrist Brace Padding', 'Standard', 'Generic Brand', 30, 4.00, 8.00, FALSE, 0, NULL),
    (587, 'part', 'Cervical Collar Strap', 'Standard', 'Generic Brand', 15, 5.00, 10.00, FALSE, 0, NULL),
    (588, 'part', 'Back Brace Closure', 'Standard', 'Generic Brand', 10, 10.00, 20.00, FALSE, 0, NULL),
    (589, 'part', 'Prosthetic Limb Socket', 'Standard', 'Generic Brand', 5, 100.00, 200.00, FALSE, 0, NULL),
    (590, 'part', 'Orthotic Insole Insert', 'Standard', 'Generic Brand', 50, 5.00, 10.00, FALSE, 0, NULL),
    (591, 'part', 'Mobility Scooter Battery', 'Standard', 'Generic Brand', 8, 150.00, 300.00, FALSE, 0, NULL),
    (592, 'part', 'Stair Lift Belt', 'Standard', 'Generic Brand', 5, 50.00, 100.00, FALSE, 0, NULL),
    (593, 'part', 'Patient Scale Sensor', 'Standard', 'Generic Brand', 10, 30.00, 60.00, FALSE, 0, NULL),
    (594, 'part', 'IV Pole Hook', 'Standard', 'Generic Brand', 20, 5.00, 10.00, FALSE, 0, NULL),
    (595, 'part', 'Suction Machine Tube', 'Standard', 'Generic Brand', 15, 10.00, 20.00, FALSE, 0, NULL),
    (596, 'part', 'Ventilator Filter', 'Standard', 'Generic Brand', 25, 5.00, 10.00, FALSE, 0, NULL),
    (597, 'part', 'Infant Warmer Bulb', 'Standard', 'Generic Brand', 10, 20.00, 40.00, FALSE, 0, NULL),
    (598, 'part', 'Fetal Doppler Probe', 'Standard', 'Generic Brand', 5, 50.00, 100.00, FALSE, 0, NULL),
    (599, 'part', 'Ultrasound Gel Bottle', 'Standard', 'Generic Brand', 30, 10.00, 20.00, FALSE, 0, NULL),
    (600, 'part', 'Defibrillator Pad', 'Standard', 'Generic Brand', 20, 25.00, 50.00, FALSE, 0, NULL);
