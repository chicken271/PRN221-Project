   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   "    PRN221_Project.ManageStudent   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  ManageStudent��5   	   $	��450��66   $	��730��6C   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Manage Student6C   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6^   Search6f   5      �� 5      
���  ��$��20(�6%   .��63   Student Information6H   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5      ��6)   ��  �� Path$ 	StudentId� �� Mode$ OneWay=� � DataContext 6V   ��  �� ElementName$ 	lvStudent��$ SelectedItem�6�   �� 5      .��6   StudentName6!   �� 5      -   5        $��tbStudentName��5      ��6+   �� $
 Name�$ OneWay=� 6S   �� $ 	lvStudent��$ SelectedItem�6�   �� 5      .��6   Email6   �� 5      -   5        $��tbStudentEmail��5      ��6,   �� $ Email�$ OneWay=� 6U   �� $ 	lvStudent��$ SelectedItem�6�   �� 5      .��6   
Password6   �� 5       -   5        $��tbStudentPassword��5       ��6/   �� $ Password�$ OneWay=� 6[   �� $ 	lvStudent��$ SelectedItem�6�   �� 5"      $ 
Horizontal=�6   .+�5#      �� -   5        $��btnStudentAdd��5#   ;   $��8q�6   $��30��6$   $��70��60   .��6l   Add6q   �� 5$      -	   5        $��btnStudentUpdate��5$   ;   $��8q�6   $��30��6$   $��70��60   .��6r   Update6z   �� 5%      -
   5        $��btnStudentDelete��5%   ;   $��8q�6   $��30��6$   $��70��60   .��6r   Delete6z   5&      �� 5(      $ 
Horizontal=�6   .+�5)      �� -   5        $��btnClear��5)   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Clear6i   �� 5*      -   5        $��	btnReload��5*   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Reload6l   �� 5+      -   5        $��	btnReturn��5+   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Return6l   5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� -   5        $��btnImportExcel��5/   ;   $��8q�6   $��30��6$   $��70��60   .��6n   Import Excel6|   �� 50      -   5        $��btnExportExcel��50   ;   $��8q�6   $��30��6$   $��70��60   .��6n   Export Excel6|   51      52      �� 54   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�55      �� -   5         ��Name$ 	lvStudent��55       �� View 56      �� 57      .P�58      �� 	 �� Width$		 100��6)   
 �� DisplayMemberBinding
 65   �� $ 	StudentId�.��6e   	StudentId6p   �� 59      $		 120��6)   
 65   �� $
 Name�.��6`   Name6f   �� 5:      $		 110��6)   
 65   �� $ Email�.��6a   Email6h   �� 5;      $		 100��6)   
 65   �� $ Password�.��6d   
Password6n   5<      5>      5?      5@      5A      