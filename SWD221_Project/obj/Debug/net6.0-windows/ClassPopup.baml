   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	       PRN221_Project.ClassPopup   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  
ClassPopup��5   	   $	��450��63   $	��800��6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Students in Class6F   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6^   Search6f   5      �� 5      
���  ��$��20(�6%   .��63   Class Information6F   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5       �� 
IsReadOnly$
 True��6'   6;   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5      ��6)   ��  �� Path$ 	StudentId� �� Mode$ OneWay=� � DataContext 6V   ��  �� ElementName$ lvStudentsInClass��$ SelectedItem�6�   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��btnAdd��5   ;   $��8q�6   $��30��6$   $��70��60   .��6^   Add6c   �� 5      -   5        $��	btnDelete��5   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Delete6l   �� 5       -   5        $��btnClose��5    ;   $��8q�6   $��30��6$   $��70��60   .��6c   Close6j   5!      �� 5#      $ 
Horizontal=�6   .+�5$      �� -	   5        $��btnClear��5$   ;   $��8q�6   $��30��6$   $��70��60   .��6c   Clear6j   �� 5%      -
   5        $��	btnReload��5%   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Reload6l   5&      5(      �� 5*   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�5+      �� -   5         ��Name$ lvStudentsInClass��5+      	 �� View	 5,      �� 5-      .P�5.      �� 
 �� Width$	
 100��6)    �� DisplayMemberBinding 65   �� $ 	StudentId�.��6e   	StudentId6p   �� 5/      $	
 120��6)    65   �� $
 Name�.��6`   Name6f   �� 50      $	
 110��6)    65   �� $ Email�.��6a   Email6h   �� 51      $	
 100��6)    65   �� $ Password�.��6d   
Password6n   52      54      55      56      57      