# Appendix
## Meeting Frequency
- Weekly meetings between team members lasting roughly 1-3 hours each.
- Biweekly meeting between team members and faculty advisor lasting roughly an hour each.
  
## Meeting Notes
- Meeting with advisor on 9/30/2024
  - Think about how the application will be structured, it will affect the database.
  - Think about deletion of data. Might want to set a marker to hide data instead of actually deleting.
  - Create full design diagram for the database.
- Meeting with advisor on 10/16/2024
  - Consider using an ID rather than name (likely both) for Suppliers
  - Maybe include type of products supplied by a supplier
- Meeting with advisor on 10/28/2024
  - Split Equipment table into two
    - Equipment Type
    - Relationship between equipment, service, and patient
  - Rename Service Details to mention supplies
  - Create relation between equipment and service history
  - Change primary key of Supplies to Name instead of ID
  - Save new versions separately
- Meeting with advisor on 11/11/2024
  - Recieved Date in the order ticket table is the date the store received the item from the supplier
  - Patients do not make orders
  - Supplies are not always part of equipment orders
  - Break up equipment table to store by type of equipment
  - Serial just needs to be on order ticket, service history, and patient equipment
  - Might need to add a table for the store info if there are multiple locations
  - Important for seeing where inventory goes from supplier
  - Expand the supplies table for things like type, size, brand,
  - Could have one table for equipment and supplies (Supply ID# and equipment serial number are same column)
  - In order ticket table:
  - include delivery method
  - make ID # non unique
  - include supply ID #
  - priamary key is combination of Order ID and supply ID
  - include quantity column
  - Are equipment ordered singularly? (does there need to be a quantity?)
  - Remove Order details table
  - In service history, currently can't tell which equipment was delivered or repaired if a patient has multiple items
  - Separate supplies and spare parts into two tables
  - Separate service history into repairs and deliveries
  - might be able to combine order tickets and deliveries like in the PDF sent in chat
  
## Current Database Design
![AltText](Database Structure.png?raw=true "")
## Current User Interface Design Mockup

## References
