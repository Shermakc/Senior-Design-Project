   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  3clr-namespace:MediStoreManagerMediStoreManager  )    #MediStoreManager.AddInventoryWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     4	behaviorsclr-namespace:MediStoreManager     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager       � Title$  Add Inventory�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=� � 	Resources 3   -MediStoreManager.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          .���� $	��375��$	��380��.+��� $
��Bold"�$��Center=�.��Enter Inventory Information�� -   $��Delete Inventory Item��$	��200��y��� *
IsEditMode+ �� 	Converter# [  {��� *	isAdmin+� $	��300��$	��380�� %  MediStoreManager.InventoryTypes  InventoryTypes��%   &	         .+��� $	��110��$
��Left=� �� TextAlignment$ Right=�$��Name: ��$��0,10,0,5q��� -   $��InventoryNameTextBox��$	��260��$��Right=�$��0,10,0,5q��� $	��110��$
��Left=�$ Right=�$��Type: ��$��0,5,0,5q��� -   $��TypeComboBox��$	��260��$��Right=�$��0,5,0,5q�#��[  �� 
IsEditable$
 True�� �� 
IsReadOnly$
 True���� $	��110��$
��Left=�$ Right=�$��Serial Number: ��$��0,5,0,5q��� -   $��SerialNumberTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Size: ��$��0,5,0,5q��� -   $��SizeTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Brand: ��$��0,5,0,5q��� -   $��BrandTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��
Quantity: ��$��0,5,0,5q��� -   $��QuantityTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Price: ��$��0,5,0,5q��� -   $��PriceTextBox��$	��260��$��Right=�$��0,5,0,5q�+   %MediStoreManager.PriceTextBoxBehavior   EnablePriceValidation$
 True���� $	��110��$
��Left=�$ Right=�$��Retail Price: ��$��0,5,0,5q��� -	   $��RetailPriceTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��110��$
��Left=�$ Right=�$��Rental Item(?): ��$��0,5,0,5q��� 	 �� Orientation$	 
Horizontal=�$��0,0,0,5q�.+�	� -
   $��YesRadioButton��$	��Yes��
 	� 	GroupName$
 	Agreement��$��0,7,10,0q�	� -   $��NoRadioButton��$��No��$
 	Agreement��$��0,7,10,0q�	� -   $��NotApplicableRadioButton��$��Not Applicable��$
 	Agreement��$��0,7,10,0q��� $	��110��$
��Left=�$ Right=�$��Rental Price: ��$��0,5,0,0q��� -   $��RentalPriceTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��400��$��20��$	 
Horizontal=�$��Center=�.+�� $	��194��.+��� -   $��OK��$	��100��$��Right=�$��0,0,15,0q�� $	��194��.+��� -   $��Cancel��$	��100��$
��Left=�$��15,0,0,0q�