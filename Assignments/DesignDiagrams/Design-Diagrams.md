# Project Title: JRKS
## Goal Statement:
Create a fully functional information management software for a medical supply store that employees can use to find and update information related to patients, suppliers, and inventory.
Records of previous services rendered will be kept to make future work with returning patients more efficient and effective. Equipment orders will be kept to assist in inventory audits.

## Design Diagrams
### Design D0:

This diagram shows a very basic workflow of the application.
* The user accesses the application to manage the inventory of the medical supply store.

![AltText](images/DesignD0.png?raw=true "Diagram0")

### Design D1:

This diagram expands on the actions the user can take and showcases the database behind the application.
* The database stores all relevant information for managing:
    * Patient records
    * Equipment inventory
    * Supplier information
    * Work and order ticket history
*  The application can be used to access the information in the database.

![AltText](images/DesignD1.png?raw=true "Diagram1")

### Design D2:

This diagram introduces the role of the DBMS on the software and further expands on user operations and database structure.
* The DBMS will take commands from the front end of the software to update or read from the database.
* Printing tickets is separated out from the other user processes as it doesn't interact with the database.
* User actions are expanded to include all database CRUD operations which are performed by the DBMS.

![AltText](images/DesignD2.png?raw=true "Diagram2")
