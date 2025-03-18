-- Procedure to generate 2000 customer_order entries
DELIMITER $$

CREATE PROCEDURE GenerateCustomerOrders()
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE currentID INT;
    DECLARE currentInventoryID INT;
    DECLARE currentType VARCHAR(10);
    DECLARE currentPersonID INT;
    DECLARE currentQuantity INT;
    DECLARE currentDate DATETIME;
    DECLARE currentHaveReceivedPayment TINYINT(1);
    DECLARE currentPaymentDate DATETIME;
    DECLARE currentRelatedInventoryItemID INT;
    DECLARE currentNotes TEXT;
    DECLARE isDuplicate BOOLEAN;

    -- Loop to generate 2000 entries
    WHILE i < 2000 DO
        -- Generate random values for each column
        SET currentID = FLOOR(1 + RAND() * 100); -- ID between 1 and 100
        SET currentInventoryID = FLOOR(1 + RAND() * 600); -- InventoryID between 1 and 600
        SET currentType = ELT(FLOOR(1 + RAND() * 3), 'Delivery', 'Pickup', 'Repair'); -- Random type
        SET currentPersonID = FLOOR(1 + RAND() * 1000); -- PersonID between 1 and 1000
        SET currentQuantity = FLOOR(1 + RAND() * 10); -- Quantity between 1 and 10
        SET currentDate = NOW() - INTERVAL FLOOR(RAND() * 365) DAY; -- Random date within the last year
        SET currentHaveReceivedPayment = FLOOR(RAND() * 2); -- Random 0 or 1

        -- Set PaymentDate based on HaveReceivedPayment
        IF currentHaveReceivedPayment = 1 THEN
            SET currentPaymentDate = currentDate + INTERVAL FLOOR(RAND() * 30) DAY; -- Random date within 30 days of currentDate
        ELSE
            SET currentPaymentDate = NULL;
        END IF;

        -- Set RelatedInventoryItemID if Type is "Repair"
        IF currentType = 'Repair' THEN
            SET currentRelatedInventoryItemID = FLOOR(551 + RAND() * 50); -- RelatedInventoryItemID between 551 and 600
        ELSE
            SET currentRelatedInventoryItemID = NULL;
        END IF;

        -- Set Notes to a random string
        SET currentNotes = CONCAT('Note ', FLOOR(1 + RAND() * 1000));

        -- Check for duplicate ID and InventoryID combination
        SET isDuplicate = TRUE;
        WHILE isDuplicate DO
            -- Check if the combination already exists
            SET isDuplicate = EXISTS (
                SELECT 1
                FROM customer_order
                WHERE ID = currentID AND InventoryID = currentInventoryID
            );

            -- If it's a duplicate, generate a new InventoryID
            IF isDuplicate THEN
                SET currentInventoryID = FLOOR(1 + RAND() * 600); -- Generate a new InventoryID
            END IF;
        END WHILE;

        -- Insert the generated entry into the table
        INSERT INTO customer_order (ID, InventoryID, Type, PersonID, Quantity, Date, HaveReceivedPayment, PaymentDate, RelatedInventoryItemID, Notes)
        VALUES (currentID, currentInventoryID, currentType, currentPersonID, currentQuantity, currentDate, currentHaveReceivedPayment, currentPaymentDate, currentRelatedInventoryItemID, currentNotes);

        -- Increment the counter
        SET i = i + 1;
    END WHILE;
END$$

DELIMITER ;

-- Call the procedure to generate the entries
CALL GenerateCustomerOrders();
DROP PROCEDURE IF EXISTS GenerateCustomerOrders;