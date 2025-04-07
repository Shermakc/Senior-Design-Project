UPDATE inventory_item
SET SerialNumber = 
    CONCAT(
        CHAR(FLOOR(65 + RAND() * 26)),
        LPAD(FLOOR(RAND() * POWER(10, 13)), 13, '0')
    )
WHERE Type = 'equipment'
AND ID < 10000
AND (SerialNumber IS NULL OR SerialNumber = '');