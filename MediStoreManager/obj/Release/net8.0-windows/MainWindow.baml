   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  !    MediStoreManager.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager     -     � Title$  MediStore Manager�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 	Resources 1   +MediStoreManager.WorkTabVisibilityConverter   WorkTabVisibilityConverter3   -MediStoreManager.SupplyTabVisibilityConverter   SupplyTabVisibilityConverter6   0MediStoreManager.EquipmentTabVisibilityConverter # EquipmentTabVisibilityConverter5   /MediStoreManager.SuppliesTabVisibilityConverter " SuppliesTabVisibilityConverter2   ,MediStoreManager.PartsTabVisibilityConverter  PartsTabVisibilityConverter0   *MediStoreManager.DateTimeToStringConverter  DateTimeToStringConverter:   4MediStoreManager.RelatedInventoryVisibilityConverter ' #RelatedInventoryVisibilityConverter+   %MediStoreManager.BoolToYesNoConverter  BoolToYesNoConverter3	   -MediStoreManager.BooleanToVisibilityConverter   BooleanToVisibilityConverter1
   +MediStoreManager.ZeroToEmptyStringConverter 	 ZeroToEmptyStringConverter��%�   &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 (     &		 -                     	  
  .��� $	��796��$
��1550��.+��� -   $��MainTabControl��$��16(�.@��� -   $��
PatientTab��$��Patients��.���� 
�������    MediStoreManager.Patients 
 patient��%   &	
         .+�� $	��595��$	��926��$��
610,10,0,0q�.+��� $��0,0,0,0q�.@��� $
��Info��.���� ���� *SelectedPatient+  �� DataType   MediStoreManager.Patient �� Orientation �� 	Converter��%�  (��       *, +)7 	 7 	 7 	 7 	 �� "  .R��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��First Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	FirstName+�� $��Last Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
LastName+�� $��Street Address: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *StreetAddress+8   �� $��City: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *City+�� $��State: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *State+�� $��Insurance: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	Insurance+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Middle Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
MiddleName+�� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Home Phone #: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	HomePhone+8  �� $��Cell Phone #: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	CellPhone+8  �� $��
Zip Code: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	ZipCode+8  �� $��History��.���� ���� *SelectedPatient+  �� Padding��%�  (��       *, +)7  �� "  .R��� $
��Auto=�.���� $��10q�.+��� $��Work Orders:��$
��Bold"�$��	0,10,0,10q��� ���� *
WorkOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   � $��0,0,0,0q�$	��463��$��Right=�.+��� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Notes: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Notes+�� $��
Additional��.���� ���� *SelectedPatient+ ��%�  (��       *, +)7 	 7 	 7 	 7 	 �� "  .R��� $
��Auto=�.���� $��10q�.+��� $��Emergency Contacts:��$
��Bold"�$��	0,10,0,10q��� ���� *
Contacts+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��First Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	FirstName+�� $��Last Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
LastName+�� $��Street Address: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *StreetAddress+8   �� $��City: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *City+�� $��State: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *State+�� $��Insurance: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	Insurance+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Middle Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
MiddleName+�� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Home Phone #: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	HomePhone+8  �� $��Cell Phone #: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	CellPhone+8  �� $��
Zip Code: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	ZipCode+8  �� $��Relationship: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *RelationshipToPatient+� $	��140��$	��906��$��620,615,0,0q�.+��� -   $��Edit Patient Information��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(��� -   $��Create Work Order��$	��140��$	��448��$��0,0,0,0q�$��Right=�$��20(�� $	��681��$	��590��$��	10,10,0,0q�.+��� -   $��PatientSearchBox���� -   $��PatientListBox�� �� DisplayMemberPath$ DisplayName��$	 �� IsSynchronizedWithCurrentItem$
	 TrueY�$��0,20,0,0q�
 �� SelectedItem
 �� *SelectedPatient+ �� Mode$ TwoWay=�� $��53��$	��550��$��30, 702, 0, 0q�.+��� -   $��Add New Patient��$��0,0,0,0q�$��53��$	��550��$��20(��� -	   $��InventoryTab��$��	Inventory��.���� 
�������    MediStoreManager.Supplies 
 supply!   MediStoreManager.Equipments  	equipment   MediStoreManager.Parts  part��%-   &	       &	      &	 
           .+�� $	��595��$	��926��$��
610,10,0,0q�.+��� $��0,0,0,0q�.@��� $
��Info��.���� ���� *CurrentItem+     MediStoreManager.Equipment   MediStoreManager.Supply   MediStoreManager.Part��%�  (��       *, +)7  7  7  (�� �    *, +)(�� �	    *, +)�� "  .R��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Name+�� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Quantity in Stock: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+�� $��Retail Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *RetailPrice+�� $��Rental Item(?): ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
IsRental+8   �� $��Rental Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142��y��� *
IsRental+8  �� $	��272��$��10,20q����� *RentalPrice+y��� *
IsRental+8  � $��0,0,0,0q�$	��463��$��Right=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Size: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Size+�� $��Brand: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Brand+�� $��Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Price+�� $��Serial Number: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *SerialNumber+�� "  .R��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Name+�� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Quantity in Stock: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+�� $��Retail Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *RetailPrice+� $��0,0,0,0q�$	��463��$��Right=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Size: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Size+�� $��Brand: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Brand+�� $��Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Price+�� "  .R��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Name+�� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Quantity in Stock: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+�� $��Retail Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *RetailPrice+� $��0,0,0,0q�$	��463��$��Right=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Size: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Size+�� $��Brand: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Brand+�� $��Price: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Price+�� $��History��.���� ���� *CurrentItem+ ��%K  (��       *, +)7  7  (��     *, +)7  7  (��     *, +)7  7  �� "  .R��� .+��� $��Work Orders:��$
��Bold"�$��
10,20,0,10q��� $
��Auto=�$	��300��.���� $��10q�.+��� ���� *
WorkOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   � $��0,0,0,0q�$	��463��$��Right=�.+��� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Notes: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Notes+�� $��Supply Orders:��$
��Bold"�$��
10,10,0,10q��� $
��Auto=�$	��160��.���� $��10q�.+��� ���� *SupplyOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��
Supplier: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *SupplierName+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8  �� $��Quantity Ordered: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+�� "  .R��� .+��� $��Work Orders:��$
��Bold"�$��
10,20,0,10q��� $
��Auto=�$	��300��.���� $��10q�.+��� ���� *
WorkOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   � $��0,0,0,0q�$	��463��$��Right=�.+��� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Notes: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Notes+�� $��Supply Orders:��$
��Bold"�$��
10,10,0,10q��� $
��Auto=�$	��160��.���� $��10q�.+��� ���� *SupplyOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��
Supplier: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *SupplierName+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8  �� $��Quantity Ordered: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+�� "  .R��� .+��� $��Work Orders:��$
��Bold"�$��
10,20,0,10q��� $
��Auto=�$	��300��.���� $��10q�.+��� ���� *
WorkOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   � $��0,0,0,0q�$	��463��$��Right=�.+��� $��Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Notes: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Notes+�� $��Supply Orders:��$
��Bold"�$��
10,10,0,10q��� $
��Auto=�$	��160��.���� $��10q�.+��� ���� *SupplyOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��
Supplier: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *SupplierName+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8  �� $��Quantity Ordered: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Quantity+� $	��140��$	��906��$��620,615,0,0q�.+��� -
   $ ��Edit Equipment Information��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(�y���  �� ElementName$ InventoryTabControl�� �� Path$ SelectedIndex�# [ �� -   $"��Edit Supply Item Information��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(�y��� $ InventoryTabControl��$ SelectedIndex�# [ �� -   $��Edit Part Information��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(�y��� $ InventoryTabControl��$ SelectedIndex�# [ �� -   $��Create Work Order��$	��140��$	��448��$��0,0,0,0q�$��Right=�$��20(�� $	��681��$	��590��$��	10,10,0,0q�.+��� -   $��InventoryTabControl�� �� SelectedIndex �� *SelectedInventoryTabIndex+.@��� $��	Equipment��$��0,0,0,0q�.��� $	��650��$	��584��$��0,0,0,0q�.+��� -   $��EquipmentSearchBox���� -   $��EquipmentListBox��$
 Name��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedEquipment+$ TwoWay=��� $��Supplies��.��� $	��650��$	��584��$��0,0,0,0q�.+��� -   $��SupplySearchBox���� -   $��SuppliesListBox��$
 Name��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedSupply+$ TwoWay=��� $��Parts��.��� $	��650��$	��584��$��0,0,0,0q�.+��� -   $��PartSearchBox���� -   $��PartsListBox��$
 Name��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedPart+$ TwoWay=�� $��53��$	��550��$��30, 702, 0, 0q�.+��� -   $��Add New Inventory��$��0,0,0,0q�$��53��$	��550��$��20(��� -   $��SupplierTab��$��	Suppliers��.���� 
�������     MediStoreManager.Suppliers  	supplierL��%   &	         .+�� $	��595��$	��926��$��
610,10,0,0q�.+��� $��0,0,0,0q�.@��� $
��Info��.���� ���� *SelectedSupplier+     MediStoreManager.SupplierL��%�  (��       *, +)7 	 7 	 7 	 �� "  .R��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $��Name: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Name+�� $��Street Address: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *StreetAddress+8   �� $��State: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *State+�� $��Partner ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	PartnerID+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Business Phone #: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *PhoneNumber+8  �� $��City: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *City+�� $��
Zip Code: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	ZipCode+8  �� $��History��.���� ���� *SelectedSupplier+ ��%"  (��       *, +)7  �� "  .R��� $
��Auto=�.���� $��10q�.+��� $��Orders:��$
��Bold"�$��	0,10,0,10q��� ���� *SupplyOrders+���� .R��� 
�������$��1q�$��0,0,0,10q�$ 10q�._��� $	��926��$ 
Horizontal=�.+�� $��0,0,0,0q�$	��463��$
��Left=�.+��� $
��ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+� $��0,0,0,0q�$	��463��$��Right=�.+��� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   � $	��140��$	��906��$��620,615,0,0q�.+��� -   $��Edit Supplier Information��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(��� -   $��Create Supply Order��$	��140��$	��448��$��0,0,0,0q�$��Right=�$��20(�� $	��681��$	��590��$��	10,10,0,0q�.+��� -   $��SupplierSearchBox���� -   $��SupplierListBox��$
 Name��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedSupplier+$ TwoWay=�� $��53��$	��550��$��30, 702, 0, 0q�.+��� -   $��Add New Supplier��$��0,0,0,0q�$��53��$	��550��$��20(��� -   $��OrderTicketTab��$��Order Tickets��.���� 
������� #   MediStoreManager.SupplyOrders!   MediStoreManager.WorkOrders  work��%   &	       &	          .+��� !  System.Windows.SystemColors   ControlDarkBrushKey#���  $��1q�$��
610,38,0,0q�$	��567��$	��926�� J� SnapsToDevicePixels$
 True��._�� $	��567��$	��926��
�������.+��� ���� *CurrentOrder+     MediStoreManager.WorkOrder"   MediStoreManager.SupplyOrder��%�
  (��       *, +)7  7  7  (�� �    *, +)7  7  �� "  .R��� $	��922��.+��� $ 
Horizontal=�.+�� $��0,0,0,0q�$	��461��$
��Left=�.+��� $��
Order ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Patient ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	PatientID+�� $��Notes: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Notes+� $��0,0,0,0q�$	��461��$��Right=�.+��� $��Order Type: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Type+�� $��Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *Date+8   �� $��Date of Payment: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *PaymentDate+8  �� $��Inventory Items:��$
��Bold"�$��	10,10,0,5q��� 
�������$��1q�$��
10,5,10,10q�._��� $	��330��$	��892��$
��Auto=�$
��Left=�.���� ���� *InventoryEntries+���� .R��� 
�������$��1q�$
��10,5q�$ 6q�._��� .+��� $
��Bold"����� *MainItem.Name+�� $��Inventory ID: ��$
��Bold"��� $��10,0,0,0q����� *MainItem.ID+�� $��
Quantity: ��$
��Bold"��� $��10,0,0,0q����� *MainItem.QuantitySelected+�� $��0,10,0,0q�y��� *RelatedItem.Name+8  .+��� $��Related Inventory:��$
��Bold"��� $��10,0,0,0q����� *RelatedItem+�� "  .R��� $	��922��.+��� $ 
Horizontal=�.+�� $��0,0,0,0q�$	��461��$
��Left=�.+��� $��
Order ID: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ID+�� $��Shipping Method: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ShippingMethod+�� $��Received Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *ReceivedDate+8   � $��0,0,0,0q�$	��461��$��Right=�.+��� $��
Supplier: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *
Supplier+�� $��Order Date: ��$
��Bold"�$
��Left=�$��10,20q�$	��142���� $	��272��$��10,20q����� *	OrderDate+8  �� $��Inventory Items:��$
��Bold"�$��	10,10,0,5q��� 
�������$��1q�$��
10,5,10,10q�._��� $	��330��$	��892��$
��Auto=�$
��Left=�.���� ���� *InventoryEntries+���� .R��� 
�������$��1q�$
��10,5q�$ 6q�._��� .+��� $
��Bold"����� *MainItem.Name+�� $��Inventory ID: ��$
��Bold"��� $��10,0,0,0q����� *MainItem.ID+�� $��
Quantity: ��$
��Bold"��� $��10,0,0,0q����� *MainItem.QuantitySelected+� $	��140��$	��906��$��620,615,0,0q�.+��� -   $��Create Work Order��$	��140��$	��448��$��0,0,0,0q�$
��Left=�$��20(��� -   $��Create Supply Order��$	��140��$	��448��$��0,0,0,0q�$��Right=�$��20(�� $	��681��$	��590��$��	10,10,0,0q�.+��� -   $��OrdersTabControl�� �� *SelectedOrderTabIndex+.@��� $
��Work��$��0,0,0,0q�.��� $	��650��$	��584��$��0,0,0,0q�.+��� -    $��WorkOrderSearchBox���� -!   $��WorkListBox��$ DisplayName��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedWorkOrder+$ TwoWay=��� $��Supply��.��� $	��650��$	��584��$��0,0,0,0q�.+��� -"   $��SupplyOrderSearchBox���� -#   $��SupplyListBox��$ DisplayName��$
	 TrueY�$��0,20,0,0q�
 �� *SelectedSupplyOrder+$ TwoWay=�� $��53��$	��550��$��30, 702, 0, 0q�.+��� -$   $ ��Update Selected Work Order��$��0,0,0,0q�$��53��$	��550��$��20(�y��� $ OrdersTabControl��$ SelectedIndex�# [  �� -%   $"��Update Selected Supply Order��$��0,0,0,0q�$��53��$	��550��$��20(�y��� $ OrdersTabControl��$ SelectedIndex�# [ 