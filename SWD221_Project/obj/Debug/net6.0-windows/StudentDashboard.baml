   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   %    PRN221_Project.StudentDashboard   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  StudentDashboard��5   	   $	��450��69   $	��800��6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   StudentDashboard6E   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6^   Search6f   5      �� 5      
���  ��$��20(�6%   .��63   Class Information6F   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5       �� 
IsReadOnly$
 True��6)   6=   �� 5      .��6   	TeacherId6   �� 5      -   5        $��tbTeacherId��5      $
 True��6�   ��6)   ��  �� Path$ 	TeacherId� �� Mode$ OneWay=� � DataContext 6V   ��  �� ElementName$ lvClass��$ SelectedItem�6�   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5      $
 True��6�   ��6'   �� $ ClassId�$ OneWay=� 6R   �� $ lvClass��$ SelectedItem�6�   �� 5      .��6   	ClassName6   �� 5       -   5        $��tbClassName��5       $
 True��6�   ��6)   �� $ 	ClassName�$ OneWay=� 6V   �� $ lvClass��$ SelectedItem�6�   �� 5"      $ 
Horizontal=�6   .+�5#      �� -   5        $��btnClear��5#   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Clear6i   �� 5$      -	   5        $��	btnReload��5$   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Reload6l   �� 5%      -
   5        $��	btnLogout��5%   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Logout6l   5&      �� 5(      $ 
Horizontal=�6   .+�5)      �� -   5        $��btnWorkProgress��5)   ;   $��5q�6   $��30��6$   $��70��60   .��6p   Work6v   �� 5*      -   5        $��btnAttendance��5*   ;   $��5q�6   $��30��6$   $��70��60   .��6l   
Attendance6x   5+      5-      �� 5/   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�50      �� -   5         ��Name$ lvClass��50      	 �� View	 51      �� 52      .P�53      �� 
 �� Width$	
 130��6)    �� DisplayMemberBinding 65   �� $ 	TeacherId�.��6e   	TeacherId6p   �� 54      $	
 130��6)    65   �� $ ClassId�.��6c   	ClassId6l   �� 55      $	
 150��6)    65   �� $ 	ClassName�.��6e   	ClassName6p   56      58      59      5:      5;      