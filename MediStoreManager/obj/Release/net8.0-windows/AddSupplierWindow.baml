   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  3clr-namespace:MediStoreManagerMediStoreManager  (    "MediStoreManager.AddSupplierWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager     4	behaviorsclr-namespace:MediStoreManager       � Title$  Add Supplier�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=� � 	Resources 3   -MediStoreManager.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          .���� $	��290��$	��380��.+��� $
��Bold"�$��Center=�.��Enter Supplier Information�� -   $��Delete Supplier��$	��200��y��� *
IsEditMode+ �� 	Converter# [  {��� *	isAdmin+� $	��210��$	��400��.+��� $	��110��$
��Left=� �� TextAlignment$ Right=�$��Name: ��$��0,10,0,0q��� -   $��NameTextBox��$	��260��$��Right=�$��0,10,0,5q��� $	��110��$
��Left=�$ Right=�$��Business Phone #: ��$��0,5,0,0q��� -   $��BusinessPhoneTextBox��$	��260��$��Right=�$��0,5,0,5q�-   'MediStoreManager.NumericTextBoxBehavior   EnableNumericValidation$
 True���� $	��110��$
��Left=�$ Right=�$��Street Address: ��$��0,5,0,0q��� -   $��StreetAddressTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��City: ��$��0,5,0,0q��� -   $��CityTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��State: ��$��0,5,0,0q��� -   $��StateTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��
Zip Code: ��$��0,5,0,0q��� -   $��
ZipTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Partner ID: ��$��0,5,0,0q��� -   $��PartnerIDTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��400��$��20�� �� Orientation$ 
Horizontal=�$��Center=�.+�� $	��194��.+��� -	   $��OK��$	��100��$��Right=�$��0,0,15,0q�� $	��194��.+��� -
   $��Cancel��$	��100��$
��Left=�$��15,0,0,0q�