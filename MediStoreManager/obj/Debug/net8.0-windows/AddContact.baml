   M S B A M L   `   `   `  ����K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  5   	   3clr-namespace:MediStoreManagerMediStoreManager  5   	   !    MediStoreManager.AddContact   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MediStoreManager     5   	   4	behaviorsclr-namespace:MediStoreManager     5   	     � Title$  Add Contact��5	   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterOwner=�5
   	   .��5      �� $	��380��6   $	��400��6   .+�5   
   �� $
��Bold"�6   $��Center=�6"   .��6?   Enter Contact Information5      � 5   
   $	��320��6   $	��400��6!   .+�5      �� $	��130��6   $
��Left=�6$    �� TextAlignment$ Right=�6?   $��First Name: ��6U   $��0,5,0,0q�6i   �� 5      -   5        $��FirstNameTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Middle Name: ��6U   $��0,5,0,0q�6j   �� 5      -   5        $��MiddleNameTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Last Name: ��6U   $��0,5,0,0q�6h   �� 5      -   5        $��LastNameTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Home Phone #: ��6U   $��0,5,0,0q�6k   �� 5      -   5        $��HomePhoneTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   -   'MediStoreManager.NumericTextBoxBehavior   EnableNumericValidation$
 True��6g   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Cell Phone #: ��6U   $��0,5,0,0q�6k   �� 5      -   5        $��CellPhoneTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   $
 True��6g   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Street Address: ��6U   $��0,5,0,0q�6m   �� 5      -   5        $��StreetAddressTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��City: ��6U   $��0,5,0,0q�6c   �� 5      -   5        $��CityTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5      $	��130��6   $
��Left=�6$   $ Right=�6?   $��State: ��6U   $��0,5,0,0q�6d   �� 5      -   5        $��StateTextBox��5   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5       $	��130��6   $
��Left=�6$   $ Right=�6?   $��
Zip Code: ��6U   $��0,5,0,0q�6g   �� 5!      -	   5        $��
ZipTextBox��5!   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   $
 True��6a   �� 5"      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Insurance Provider: ��6U   $��0,5,0,0q�6q   �� 5#      -
   5        $��InsuranceTextBox��5#   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   �� 5$      $	��130��6   $
��Left=�6$   $ Right=�6?   $��Relationship to Patient: ��6U   $��0,5,0,0q�6v   �� 5%      -   5        $��RelationshipTextBox��5%   O   $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   6O   5&      �� 5'   
   $	��400��6   $��20��6!    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5(      � $	��194��6   .+�5)      �� -   5        $��OK��5)      $	��100��6&   $��Right=�62   $��0,0,15,0q�6N   6`   5*      � 5+      $	��194��6   .+�5,      �� -   5        $��Cancel��5,      $	��100��6*   $
��Left=�66   $��15,0,0,0q�6Q   6c   5-      5.      5/      50      