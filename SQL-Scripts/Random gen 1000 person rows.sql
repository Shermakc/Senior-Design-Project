-- Disable foreign key checks to avoid issues during insertion
SET FOREIGN_KEY_CHECKS = 0;

-- Insert 1000 entries into the "person" table
INSERT INTO person (ID, FirstName, LastName, MiddleName, HomePhone, CellPhone, AddressID, InsuranceProvider, IsPatientContact, ContactID, ContactRelationship)
SELECT
    -- Generate IDs from 1 to 1000
    seq.id AS ID,

    -- Random first names (50 options)
    ELT(FLOOR(1 + RAND() * 50),
        'James', 'Mary', 'John', 'Patricia', 'Robert', 'Jennifer', 'Michael', 'Linda', 'William', 'Elizabeth',
        'David', 'Barbara', 'Richard', 'Susan', 'Joseph', 'Jessica', 'Thomas', 'Sarah', 'Charles', 'Karen',
        'Christopher', 'Nancy', 'Daniel', 'Lisa', 'Matthew', 'Margaret', 'Anthony', 'Betty', 'Mark', 'Sandra',
        'Donald', 'Ashley', 'Steven', 'Kimberly', 'Paul', 'Emily', 'Andrew', 'Donna', 'Joshua', 'Michelle',
        'Kenneth', 'Carol', 'Kevin', 'Amanda', 'Brian', 'Melissa', 'George', 'Deborah', 'Timothy', 'Stephanie',
        'Ronald', 'Rebecca', 'Edward', 'Laura', 'Jason', 'Sharon', 'Jeffrey', 'Cynthia', 'Ryan', 'Kathleen',
        'Jacob', 'Amy', 'Gary', 'Shirley', 'Nicholas', 'Angela', 'Eric', 'Helen', 'Jonathan', 'Anna',
        'Stephen', 'Brenda', 'Larry', 'Pamela', 'Justin', 'Nicole', 'Scott', 'Emma', 'Brandon', 'Samantha'
    ) AS FirstName,

    -- Random last names (50 options)
    ELT(FLOOR(1 + RAND() * 50),
        'Smith', 'Johnson', 'Williams', 'Brown', 'Jones', 'Garcia', 'Miller', 'Davis', 'Rodriguez', 'Martinez',
        'Hernandez', 'Lopez', 'Gonzalez', 'Wilson', 'Anderson', 'Thomas', 'Taylor', 'Moore', 'Jackson', 'Martin',
        'Lee', 'Perez', 'Thompson', 'White', 'Harris', 'Sanchez', 'Clark', 'Ramirez', 'Lewis', 'Robinson',
        'Walker', 'Young', 'Allen', 'King', 'Wright', 'Scott', 'Torres', 'Nguyen', 'Hill', 'Flores',
        'Green', 'Adams', 'Nelson', 'Baker', 'Hall', 'Rivera', 'Campbell', 'Mitchell', 'Carter', 'Roberts'
    ) AS LastName,

    -- Random middle names (optional, can be null)
    CASE WHEN RAND() > 0.5 THEN ELT(FLOOR(1 + RAND() * 5), 'A', 'B', 'C', 'D', 'E') ELSE NULL END AS MiddleName,

    -- Random 10-digit HomePhone
    LPAD(FLOOR(RAND() * 10000000000), 10, '0') AS HomePhone,

    -- Random 10-digit CellPhone
    LPAD(FLOOR(RAND() * 10000000000), 10, '0') AS CellPhone,

    -- Random AddressID between 1 and 1000
    FLOOR(1 + RAND() * 1000) AS AddressID,

    -- Random InsuranceProvider
    ELT(FLOOR(1 + RAND() * 6), 'Medicare', 'Medicaid', 'Signa', 'BlueShield', 'Aetna', 'United Healthcare') AS InsuranceProvider,

    -- Random IsPatientContact (true or false)
    CASE WHEN RAND() > 0.5 THEN TRUE ELSE FALSE END AS IsPatientContact,

    -- ContactID: If IsPatientContact is true, set to a random ID from 1 to 1000, else null
    CASE WHEN RAND() > 0.5 THEN FLOOR(1 + RAND() * 1000) ELSE NULL END AS ContactID,

    -- ContactRelationship: If IsPatientContact is true, set to a random relationship, else null
    CASE WHEN RAND() > 0.5 THEN ELT(FLOOR(1 + RAND() * 8), 'Brother', 'Sister', 'Mother', 'Daughter', 'Father', 'Son', 'Cousin', 'Friend') ELSE NULL END AS ContactRelationship
FROM
    -- Generate a sequence of numbers from 1 to 1000
    (SELECT (a.a + (10 * b.a) + (100 * c.a)) AS id
     FROM (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS a
     CROSS JOIN (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS b
     CROSS JOIN (SELECT 0 AS a UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) AS c) AS seq
LIMIT 1000;

-- Re-enable foreign key checks
SET FOREIGN_KEY_CHECKS = 1;