UPDATE `medistore manager`.customer_order SET Quantity = 1 WHERE InventoryID > 50 AND InventoryID < 551;

UPDATE `medistore manager`.inventory_item SET NumInStock = 1 WHERE Type = "equipment" AND ID < 5000;;

-- Procedure to generate customer_order entries
DELIMITER $$

CREATE PROCEDURE FixEquipmentQuantities()
BEGIN
    DECLARE currentInventoryID INT;
    DECLARE currentPersonID INT;
    DECLARE done BOOLEAN DEFAULT FALSE;
    DECLARE cur CURSOR FOR 
		SELECT InventoryID, PersonID FROM `medistore manager`.customer_order WHERE Type = "delivery" OR TYPE = "pickup" AND ID < 5000;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

	OPEN cur;

    read_loop: LOOP
        FETCH cur INTO currentInventoryID, currentPersonID;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Do your logic here, for example, inserting into another table:
         -- might want to skip some, not much inventory left afterwards
		UPDATE `medistore manager`.inventory_item SET NumInStock = 0 WHERE ID = currentInventoryID AND Type = "equipment";
		UPDATE `medistore manager`.inventory_item SET PersonID = currentPersonID WHERE ID = currentInventoryID AND Type = "equipment";

    END LOOP;

    CLOSE cur;
END$$

DELIMITER ;

-- Call the procedure to generate the entries
CALL FixEquipmentQuantities();
DROP PROCEDURE IF EXISTS FixEquipmentQuantities;

-- UPDATE `medistore manager`.inventory_item SET NumInStock = 1 WHERE Type = "supply";