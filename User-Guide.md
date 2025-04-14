# User Guide
## Table of Contents
1. [Installation](#installation) <br />
  1.1 [Database Creation](#database-creation) <br />
  1.2 [Database Initialization](#database-initialization) <br />
  1.2 [App Installation](#app-installation) <br />
3. [Usage](#usage)<br />
  2.1 [Login and Security](#login-and-security)<br />
  2.2 [Patient Information](#patient-information)<br />
  2.3 [Inventory Information](#inventory-information)<br />
  2.4 [Supplier Information](#supplier-information)<br />
  2.5 [Work and Order Tickets](#work-and-order-tickets)
4. [Frequently Asked Questions](#frequently-asked-questions)
<br />

## 1. Installation <a name="installation"></a>
### 1.1 Database Creation <a name="database-creation"></a>
This application will require you to have an active MySQL database to store the created records. This can be aquired from the MySQL website. On their site, go to the downloads section and scroll down to "MySQL Community (GPL) Downloads". In the community downloads, download the MySQL Installer for Windows. When using the installer, make sure to install both a MySQL server as well as MySQL Workbench. The workbench will make managing the database possible outside of the application and is required for setup. During installation, you will be asked to create accounts and roles for the server. Set the root password to "password". The user information can be whatever you like. For easiest use, make sure to check the box that says "Start the MySQL Server at System Startup".<br />

### 1.2 Database Initialization <a name="database-initialization"></a>
The database will require a bit of additional setup after installation. To do this, open the newly installed MySQL Workbench. Click on the "+" symbol to the right of "MySQL Connections". In the popup, set the name to whatever you like and set the password to "password" like you did before. Click OK to finish creating the connection and then double click on the new connection. This will connect you to the database and allow you to make changes. Download the file "Create Medistore Manager Schema and Tables.sql" from the repository and open it in MySQL Workbench. Then click the lightning bolt to run the script. Next, download the file "Create Initial Data.sql" from the repository and run the script. Finally, download the file "Create New User.sql" from the repository. Open this file and change the first name, last name, username, and password outlined in quotation marks to what you want for your account. Then click the lightning bolt to run the script.

### 1.2 App Installation <a name="app-installation"></a>
To install the application, download the file "Medistore-Manager.zip" from the repository. Unzip the contents somewhere you'll remember on your computer. This completes the installation and you can now run the application from the MedistoreManager.exe file.
<br />

## 2. Usage <a name="usage"></a>
### 2.1 Login and Security <a name="login-and-security"></a>
The first window that will open upon launching the application is the login window. This will prompt you for your username and password. <br />
![AltText](Assignments/Images/Login.jpg?raw=true "Login") <br />
<br />
If you enter invalid information, you will not be allowed to login and the window will update to show an invalid credential error. <br />
![AltText](Assignments/Images/LoginFailure.jpg?raw=true "LoginFailure") <br />
<br />
### 2.2 Patient Information <a name="patient-information"></a>
Clicking on the Patients tab will display a list of all the customers the application has in its database. The list shows each patient's first and last name. The search bar at the top of the list will allow you to find patients by typing any portion of their name. The list will then be filtered to show only patients with names matching the entry in the search bar. <br />
![AltText](Assignments/Images/PatientsTab.jpg?raw=true "PatientsTab") <br />
<br />
At the bottom of the list is a button labeled "Add New Patient".<br />
![AltText](Assignments/Images/AddPatientButton.jpg?raw=true "AddPatientButton") <br />
<br />
Clicking this button will bring up a popup allowing you to enter all the information required to add a patient to the application. Once you are finished entering the patient's information, click the "OK" button to add the new patient.<br />
![AltText](Assignments/Images/AddPatient.jpg?raw=true "AddPatient") <br />
<br />
Clicking on a patient in the list will display their full information in the large window on the right. At the top of this window are the tabs "Info" (which is selected by default), "History", and "Additional". The History tab will display previously created work orders made for the patient. The additional tab displays the patient's emergency contacts. <br />
![AltText](Assignments/Images/PatientInfo.jpg?raw=true "PatientInfo") <br />
![AltText](Assignments/Images/PatientHistory.jpg?raw=true "PatientHistory") <br />
![AltText](Assignments/Images/PatientAdditional.jpg?raw=true "PatientAdditional") <br />
<br />

Below this section there are two buttons: "Edit Patient Information" and "Create Work Order". <br />
![AltText](Assignments/Images/EditPatientButton.jpg?raw=true "EditPatientButton") <br />
<br />
Clicking the button "Edit Patient Info" will bring up a pop up allowing you to make changes to the patient's displayed info. There is a delete button on this pop up to allow you to delete the patient entirely. If you do not have permission, this button will be grayed out. Once you are satisfied with your changes, click "OK" to save them. The "Create Work Order" button will be discussed in further detail in the section **Work and Order Tickets**. <br />


### 2.3 Inventory Information <a name="inventory-information"></a>
Clicking on the Inventory tab will display a list of all the items the application keeps track of as store inventory. This includes three categories of items, Durable Medical Equipment, Consumable Medical Supplies, and Spare Parts. The search bar at the top of the list will allow you to find items by typing any portion of their name. The list will then be filtered to show only item with names matching the entry in the search bar. Additionally, you can filter the list to display only items from one of the three categories. <br />
![AltText](Assignments/Images/InventoryTab.jpg?raw=true "InventoryTab") <br />
<br />
At the bottom of the list is a button labeled "Add New Inventory".<br />
![AltText](Assignments/Images/AddInventoryButton.jpg?raw=true "AddInventoryButton") <br />
<br />
Clicking this button will bring up a popup allowing you to enter all the information required to add a new item to the inventory list. Once you are finished entering the item's information, click the "OK" button to add the new item.<br />
![AltText](Assignments/Images/AddInventory.jpg?raw=true "AddInventory") <br />
<br />
Clicking on a item in the list will display its full information in the large window on the right. The "History" tab will display all previous work and supply orders for the selected item. <br />
![AltText](Assignments/Images/InventoryInfo.jpg?raw=true "InventoryInfo") <br />
![AltText](Assignments/Images/InventoryHistory.jpg?raw=true "InventoryHistory") <br />
<br />
Below the information section is a button labeled "Edit Part/Equipment Information". <br />
![AltText](Assignments/Images/EditInventoryButton.jpg?raw=true "EditInventoryButton") <br />
<br />
Clicking this button will bring up a pop up allowing you to make changes to the displayed information. Once you are satisfied with your changes, click "OK" to save them. <br />

### 2.4 Supplier Information <a name="supplier-information"></a>
Clicking on the Suppliers tab will display a list of all the suppliers we order inventory from. The list will display the name of each supplier and the search bar at the top of the list will allow you to find suppliers by typing any portion of their name. The list will then be filtered to show only suppliers with names matching the entry in the search bar. <br />
![AltText](Assignments/Images/SuppliersTab.jpg?raw=true "SuppliersTab") <br />
<br />
At the bottom of the list is a button labeled "Add New Supplier". <br />
![AltText](Assignments/Images/AddSupplierButton.jpg?raw=true "AddSupplierButton") <br />
<br />
Clicking this button will bring up a popup allowing you to enter all the information required to add a new supplier to the list. Once you are finished entering the supplier's information, click the "OK" button to add the new supplier.<br />
![AltText](Assignments/Images/AddSupplier.jpg?raw=true "AddSupplier") <br />
<br />
Clicking on a supplier in the list will display their full information in the large window on the right. The "History" tab will display all previous supply orders for the selected supplier.<br />
![AltText](Assignments/Images/SupplierInfo.jpg?raw=true "SupplierInfo") <br />
![AltText](Assignments/Images/SupplierHistory.jpg?raw=true "SupplierHistory") <br />
<br />
Below the information section are two buttons: "Edit Supplier Information" and "Create Supply Order".<br />
![AltText](Assignments/Images/EditSupplierButton.jpg?raw=true "EditSupplierButton") <br />
<br />
Clicking the button labeled "Edit Supplier Information" will bring up a pop up allowing you to make changes to the displayed information. Once you are satisfied with your changes, click "OK" to save them. The "Create Supply Order" button will be discssed in further detail in the next section.

### 2.5 Work and Order Tickets <a name="work-and-order-tickets"></a>
#### Work Orders
On the fourth tab, "Order Tickets", there will be two separate tabs. One for Work orders, and another for Supply orders. The Work order tab will provide a list of all work orders and the box on the right will display all relevant information for the work order. <br />
![AltText](Assignments/Images/WorkOrderTab.jpg?raw=true "WorkOrderTab") <br />
<br />
Selecting "Create Work Order" button from any tab that it appears will open the below pop up. Fill in all necessary information and select OK to create the work order. <br />
![AltText](Assignments/Images/WorkOrder.jpg?raw=true "WorkOrder") <br />
<br />
#### Supply Orders
The Supply order tab will provide a list of all supply orders and the box on the right will display all relevant information for the selected supply order. <br />
![AltText](Assignments/Images/SupplyOrderTab.jpg?raw=true "SupplyOrderTab") <br />
<br />
Selecting "Create Supply Order" button from any tab that it appears will open the below pop up. Fill in all necessary information and select OK to create the supply order. <br />
![AltText](Assignments/Images/SupplyOrder.jpg?raw=true "SupplyOrder") <br />
<br />

## 3.0 FAQ <a name="frequently-asked-questions"></a>
**Q: Where is a patient's emergency contact information?**<br />
**A:** The emergency contact information for a patient is held within the "Additional" tab for that patient.

**Q: How can I track the history of repairs that a piece of equipment has undergone?**<br />
**A:** In the "History" tab for the equipment, you will see all previous rentals and repairs for that equipment.

**Q: I want to see our previous orders with a specific supplier, where can I find that?** <br />
**A:** In the Suppliers tab, click on the specific supplier and select the "History" tab. This will display all previous orders with that supplier.

**Q: Will work and supply orders update the quantity stored for inventory items, or will that have to be done manually?** <br />
**A:** The quantity will update automatically for all inventory items from work and supply orders. Work orders will reduce the quantity by the proper amount upon creation, and supply orders will increase the quantity by the proper amount once it has been marked as received (Received Date has been filled).
