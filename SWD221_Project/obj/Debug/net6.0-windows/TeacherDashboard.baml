   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   %    PRN221_Project.TeacherDashboard   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  TeacherDashboard��5   	   $	��450��69   $	��800��6F   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Teacher Dashboard6F   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6^   Search6f   5      �� 5      
���  ��$��20(�6%   .��63   Class Information6F   �� 5      .��6   	TeacherId6   �� 5      -   5        $��tbTeacherId��5       �� 
IsReadOnly$
 True��6)   6=   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5      $
 True��6�   ��6'   ��  �� Path$ ClassId� �� Mode$ OneWay=� � DataContext 6R   ��  �� ElementName$ lvClass��$ SelectedItem�6�   �� 5      .��6   	ClassName6   �� 5      -   5        $��tbClassName��5      $
 True��6�   ��6)   �� $ 	ClassName�$ OneWay=� 6V   �� $ lvClass��$ SelectedItem�6�   �� 5       $ 
Horizontal=�6   .+�5!      �� -   5        $��btnClear��5!   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Clear6i   �� 5"      -   5        $��	btnReload��5"   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Reload6l   �� 5#      -	   5        $��	btnLogout��5#   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Logout6l   5$      �� 5&      $ 
Horizontal=�6   .+�5'      �� -
   5        $��btnStudentsDetails��5'   <   $��5q�6   $��30��6$   $	��140��60   .��6w   Students Details6�   �� 5(      -   5        $��btnManageWorkInClass��5(   <   $��5q�6   $��30��6$   $	��140��60   .��6{   Manage Work in Class6�   5)      �� 5+      $ 
Horizontal=�6   .+�5,      �� -   5        $��btnTakeAttendance��5,   <   $��5q�6   $��30��6$   $	��140��60   .��6u   Take Attendance6�   5-      5.      �� 50   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�51      �� -   5         ��Name$ lvClass��51      	 �� View	 52      �� 53      .P�54      �� 
 �� Width$	
 130��6)    �� DisplayMemberBinding 65   �� $ 	TeacherId�.��6e   	TeacherId6p   �� 55      $	
 130��6)    65   �� $ ClassId�.��6c   	ClassId6l   �� 56      $	
 150��6)    65   �� $ 	ClassName�.��6e   	ClassName6p   57      59      5:      5;      5<      