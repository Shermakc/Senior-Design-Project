   M S B A M L   `   `   `  ����K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  5   	   )    #MediStoreManager.AddInventoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MediStoreManager     5   	     � Title$  Add Inventory��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterOwner=�5	   	   .��5
      �� $	��300��6   $	��380��6   .+�5   
   �� $
��Bold"�6   $��Center=�6"   .��6?   Enter Inventory Information5      � 5   
   $	��240��6   $	��400��6!    � 	Resources 5      %  MediStoreManager.InventoryTypes   InventoryTypes��%   &	          5      6'   5      .+�5      �� $	��110��6   $
��Left=�6$    �� TextAlignment$ Right=�6?   $��Name: ��6U   $��0,5,0,0q�6c   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��Type: ��6U   $��0,5,0,0q�6c   �� 5      $	��260��6   $��Right=�6#   $��0,5,0,5q�6?   #��[  6P    �� 
IsEditable$
 True��6~    �� 
IsReadOnly$
 True��6�   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��Size: ��6U   $��0,5,0,0q�6c   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��Brand: ��6U   $��0,5,0,0q�6d   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��
Quantity: ��6U   $��0,5,0,0q�6g   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��Price: ��6U   $��0,5,0,0q�6d   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5      $	��110��6   $
��Left=�6$   $ Right=�6?   $��Retail Price: ��6U   $��0,5,0,0q�6k   �� 5      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   �� 5       $	��110��6   $
��Left=�6$   $ Right=�6?   $��Rental Price: ��6U   $��0,5,0,0q�6k   �� 5!      $	��260��6   $��Right=�6"   $��0,5,0,5q�6>   5"      �� 5#   
   $	��400��6   $��20��6!    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5$      � $	��194��6   .+�5%      �� $��OK��6   $	��100��6&   $��Right=�62   $��0,0,15,0q�6N   5&      � 5'      $	��194��6   .+�5(      �� -   5        $��Cancel��5(      $	��100��6*   $
��Left=�66   $��15,0,0,0q�6Q   6c   5)      5*      5+      5,      