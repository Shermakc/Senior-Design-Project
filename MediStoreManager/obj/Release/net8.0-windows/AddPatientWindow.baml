   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  3clr-namespace:MediStoreManagerMediStoreManager  '    !MediStoreManager.AddPatientWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager     4	behaviorsclr-namespace:MediStoreManager       � Title$  Add Patient�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=� � 	Resources 3   -MediStoreManager.BooleanToVisibilityConverter    BooleanToVisibilityConverter��%   &	          .���� $	��420��$	��400��.+��� $
��Bold"�$��Center=�.��Patient Information�� -   $��Delete Patient��$	��200��y��� *
IsEditMode+ �� 	Converter# [  {��� *	isAdmin+�� $
��Auto=�$	��340��.��� $	��380��.+��� $	��110��$
��Left=� �� TextAlignment$ Right=�$��First Name: ��$��0,10,0,0q��� -   $��FirstNameTextBox��$	��260��$��Right=�$��0,10,0,5q��� $	��110��$
��Left=�$ Right=�$��Middle Name: ��$��0,5,0,5q��� -   $��MiddleNameTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Last Name: ��$��0,5,0,5q��� -   $��LastNameTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Home Phone #: ��$��0,5,0,5q��� -   $��HomePhoneTextBox��$	��260��$��Right=�$��0,5,0,5q�-   'MediStoreManager.NumericTextBoxBehavior   EnableNumericValidation$
 True���� $	��110��$
��Left=�$ Right=�$��Cell Phone #: ��$��0,5,0,5q��� -   $��CellPhoneTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��110��$
��Left=�$ Right=�$��Street Address: ��$��0,5,0,5q��� -   $��StreetAddressTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��City: ��$��0,5,0,5q��� -   $��CityTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��State: ��$��0,5,0,5q��� -	   $��StateTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��
Zip Code: ��$��0,5,0,5q��� -
   $��
ZipTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��110��$
��Left=�$ Right=�$��Insurance Provider: ��$��0,5,0,5q��� -   $��InsuranceTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��380��$��0,5,0,5q�.+�� $	��380�� � ColumnDefinitions �� $	��110 ��� $	��260 �.+��� $��Patient Contacts: ��$ Right=�$��Center=�$��0���� -   $��AddNewContactButton��$��Add New Contact��$	��260��$��1��$��Right=��� -   $��ContactItemsControl��$	��260��$��
110,0,10,0q����� .R��� $��0,5,0,0q�.+���  �� Orientation$ 
Horizontal=�.+��� $	��150��$
��Bold"����� *DisplayName+�� $��RemoveContactButton��-   $��X��$��30���� $	��400��$��20��$ 
Horizontal=�$��Center=�.+�� $	��194��.+��� -   $��OK��$	��100��$��Right=�$��0,0,15,0q�� $	��194��.+��� -   $��Cancel��$	��100��$
��Left=�$��15,0,0,0q�