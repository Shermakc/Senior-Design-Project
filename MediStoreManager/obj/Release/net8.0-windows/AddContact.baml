   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  3clr-namespace:MediStoreManagerMediStoreManager  !    MediStoreManager.AddContact   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager     4	behaviorsclr-namespace:MediStoreManager       � Title$  Add Contact�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=�.���� $	��380��$	��400��.+��� $
��Bold"�$��Center=�.��Enter Contact Information� $	��320��$	��400��.+��� $	��130��$
��Left=� �� TextAlignment$ Right=�$��First Name: ��$��0,5,0,0q��� -   $��FirstNameTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��Middle Name: ��$��0,5,0,0q��� -   $��MiddleNameTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��Last Name: ��$��0,5,0,0q��� -   $��LastNameTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��Home Phone #: ��$��0,5,0,0q��� -   $��HomePhoneTextBox��$	��260��$��Right=�$��0,5,0,5q�-   'MediStoreManager.NumericTextBoxBehavior   EnableNumericValidation$
 True���� $	��130��$
��Left=�$ Right=�$��Cell Phone #: ��$��0,5,0,0q��� -   $��CellPhoneTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��130��$
��Left=�$ Right=�$��Street Address: ��$��0,5,0,0q��� -   $��StreetAddressTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��City: ��$��0,5,0,0q��� -   $��CityTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��State: ��$��0,5,0,0q��� -   $��StateTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��
Zip Code: ��$��0,5,0,0q��� -	   $��
ZipTextBox��$	��260��$��Right=�$��0,5,0,5q�$
 True���� $	��130��$
��Left=�$ Right=�$��Insurance Provider: ��$��0,5,0,0q��� -
   $��InsuranceTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��130��$
��Left=�$ Right=�$��Relationship to Patient: ��$��0,5,0,0q��� -   $��RelationshipTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��400��$��20�� �� Orientation$ 
Horizontal=�$��Center=�.+�� $	��194��.+��� -   $��OK��$	��100��$��Right=�$��0,0,15,0q�� $	��194��.+��� -   $��Cancel��$	��100��$
��Left=�$��15,0,0,0q�