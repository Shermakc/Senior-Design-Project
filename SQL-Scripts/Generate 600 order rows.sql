-- List of valid supplier names
SET @suppliers = 'Invacare,Golden Technologies,Pride,Medline,Medtronic,Johnson & Johnson,Siemens Healthineers,GE Healthcare,Philips Healthcare,Becton Dickinson,Baxter International,Fresenius Medical Care,Stryker Corporation,Cardinal Health';

-- Function to generate a random supplier name
DELIMITER //
CREATE FUNCTION GetRandomSupplier() RETURNS VARCHAR(50)
DETERMINISTIC
NO SQL
BEGIN
    DECLARE supplier_count INT;
    DECLARE random_index INT;
    DECLARE supplier_name VARCHAR(50);
    
    SET supplier_count = LENGTH(@suppliers) - LENGTH(REPLACE(@suppliers, ',', '')) + 1;
    SET random_index = FLOOR(1 + RAND() * supplier_count);
    SET supplier_name = SUBSTRING_INDEX(SUBSTRING_INDEX(@suppliers, ',', random_index), ',', -1);
    
    RETURN supplier_name;
END //
DELIMITER ;

-- Procedure to insert 600 rows
DELIMITER //
CREATE PROCEDURE InsertOrders()
BEGIN
    DECLARE i INT DEFAULT 1;
    DECLARE j INT DEFAULT 1;
    DECLARE supplier VARCHAR(50);
    DECLARE shipping_method VARCHAR(50);
    DECLARE inventory_id INT DEFAULT 1; -- Start InventoryID from 1
    
    WHILE i <= 100 DO
        -- Assign a random supplier and shipping method for each ID
        SET supplier = GetRandomSupplier();
        SET shipping_method = CASE FLOOR(1 + RAND() * 3) -- Random shipping method
            WHEN 1 THEN 'Standard'
            WHEN 2 THEN 'Express'
            WHEN 3 THEN 'Overnight'
        END;
        
        WHILE j <= 6 DO
            INSERT INTO `order` (
                `ID`,
                `InventoryID`,
                `Quantity`,
                `SupplierName`,
                `ShippingMethod`,
                `OrderDateTime`,
                `HasBeenReceived`,
                `ReceivedDate`
            ) VALUES (
                i,
                inventory_id, -- Use the global InventoryID counter
                FLOOR(1 + RAND() * 100), -- Random quantity between 1 and 100
                supplier,
                shipping_method, -- Same shipping method for all entries with the same ID
                DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY), -- Random order date within the last year
                FLOOR(RAND() * 2), -- Random HasBeenReceived (0 or 1)
                CASE FLOOR(RAND() * 2)
                    WHEN 1 THEN DATE_SUB(NOW(), INTERVAL FLOOR(RAND() * 365) DAY) -- Random received date if HasBeenReceived is 1
                    ELSE NULL
                END
            );
            SET j = j + 1;
            SET inventory_id = inventory_id + 1; -- Increment InventoryID globally
        END WHILE;
        
        SET j = 1;
        SET i = i + 1;
    END WHILE;
END //
DELIMITER ;

-- Call the procedure to insert the data
CALL InsertOrders();
DROP PROCEDURE IF EXISTS InsertOrders;
DROP FUNCTION IF EXISTS GetRandomSupplier;