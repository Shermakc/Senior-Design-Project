   M S B A M L   `   `   `  ���� K  GMediStoreManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MediStoreManagerMediStoreManager  &     MediStoreManager.CreateWorkOrder   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MediStoreManager       � Title$  
Work Order�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=� � 	Resources     BooleanToVisibilityConverter0   *MediStoreManager.NullToVisibilityConverter  NullToVisibilityConverter��%   &	        &	      ��   .���� $	��420��$	��400��.+��� $
��Bold"�$��Center=�.��
Work Order�� -   $��Delete Work Order��$	��200��y��� *
IsEditMode+ �� 	Converter# [  {��� *	isAdmin+�� $
��Auto=�$	��345��.��� $	��380�� %  MediStoreManager.WorkOrderTypes  WorkOrderTypes��%   &	         .+��� $	��110��$
��Left=� �� TextAlignment$ Right=�$��Order Type: ��$��0,10,0,0q��� -   $��TypeComboBox��$	��260��$��Right=�$��0,10,0,5q�#��[  �� 
IsEditable$
 True�� �� 
IsReadOnly$
 True���� $	��110��$
��Left=�$ Right=�$��	Patient: ��$��0,5,0,0q��� $	��260��$��Right=�$��0,5,0,5q�.+��� -   $��PatientSearchBox��$	��260��$��Right=��� -   $��PatientResultsListBox��$	��260��$	��150��$��Right=����� .R���  �� Orientation$ 
Horizontal=�.+��� ���� *DisplayName+�� $�� [��
��������� 
����������� *ID+�� $��]��
��������� $	��380��$��0,5,0,5q�.+�� $	��380��	 � ColumnDefinitions	 �� $	��110 ��� $	��260 �.+��� $��Inventory Items: ��$ Right=�$��Center=�$��0���� -   $��Add New Inventory Item��$	��260��$��1��$��Right=��� -   $��InventoryItemsControl��$	��260��$��
110,0,10,0q����� .R��� $��0,5,0,0q�.+��� $ 
Horizontal=�.+��� $	��150��$
��Bold"����� *MainItem.Name+�� $
��Qty:��$��30��$��SemiBold"��� $��40������ *MainItem.QuantitySelected+�� -   $��X��$��30���� $��Related Inventory:��$��SemiBold"�$��5,0,0,2q��� $ 
Horizontal=�.+��� $	��200��
����������� *RelatedItem.Name+y��� *RelatedItem.ID+# [ �� -   $��X��$��30��y��� *RelatedItem.ID+# [ �� -	   $��Add Related Inventory��$	��260��$��0,5,0,5q�

 � Tag
 �� �� $	��110��$
��Left=�$ Right=�$��Order Date: ��$��0,5,0,5q�$��Center=�(  "System.Windows.Controls.DatePicker  -
   $��OrderDateDatePicker��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Date of Payment: ��$��0,5,0,5q�$��Center=�  -   $��DateOfPaymentDatePicker��$	��260��$��Right=�$��0,5,0,5q��� $	��110��$
��Left=�$ Right=�$��Notes: ��$��0,5,0,0q��� -   $��NotesTextBox��$	��260��$��Right=�$��0,5,0,5q��� $	��400��$��20��$ 
Horizontal=�$��Center=�.+�� $	��194��.+��� -   $��OK��$	��100��$��Right=�$��0,0,15,0q�� $	��194��.+��� -   $��Cancel��$	��100��$
��Left=�$��15,0,0,0q�