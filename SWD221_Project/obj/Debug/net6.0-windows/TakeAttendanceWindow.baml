   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   )    #PRN221_Project.TakeAttendanceWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  TakeAttendanceWindow��5   	   $	��450��6=   $	��800��6J    � 	Resources 5	      (   "PRN221_Project.AttendanceConverter   AttendanceConverter��%   &	          5
   
   6B   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Take Attendance6D   �� 5      
���  ��$��20(�6%   .��63   Information6@   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5       �� 
IsReadOnly$
 True��6'   6;   �� 5      .��6   Date6   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpDate��5      6Z   �� 5      .��6   AttendanceId6"   �� 5      -   5        $��tbAttendanceId��5   �   $
 True��6�   ��6   ��  �� Path$ AttendanceId� �� Mode$ OneWay=� � DataContext 6F   ��  �� ElementName$ lvAttendance��$ SelectedItem�6�   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5   �   $
 True��6�   ��6   �� $ 	StudentID�$ OneWay=� 6C   �� $ lvAttendance��$ SelectedItem�6�   �� 5      .��6   StudentName6!   �� 5      -   5        $��tbStudentName��5   �   $
 True��6�   ��6   �� $ StudentName�$ OneWay=� 6E   �� $ lvAttendance��$ SelectedItem�6�   �� 5       .��6   	Present6   �� 5!      -   5        $��	cbPresent��5!      	 d� 	IsChecked	 6(   �� $ Present�$ OneWay=� 6X   �� $ lvAttendance��$ SelectedItem�6�   �� 5#      $ 
Horizontal=�6   .+�5$      �� -   5        $��	btnAddAll��5$   ;   $��8q�6   $��30��6$   $��70��60   .��6d   	Add All6m   �� 5%      -	   5        $��	btnUpdate��5%   ;   $��8q�6   $��30��6$   $��70��60   .��6d   
Update Row6p   �� 5&      -
   5        $��	btnDelete��5&   ;   $��8q�6   $��30��6$   $��70��60   .��6d   Delete Sheet6r   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� -   5        $��btnClose��5*   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Close6i   5+      �� 5-      $ 
Horizontal=�6   5.      �� 50      $ 
Horizontal=�6   51      52      �� 54   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�55      �� -   5        
 ��Name$
 lvAttendance��55       �� View 56      �� 57      .P�58      ��  �� Width$	 130��6)    �� DisplayMemberBinding 65   �� *AttendanceId+.��6c   AttendanceId6q   �� 59      $	 130��6)    65   �� *
DateAttend+ �� StringFormat$ {0:MM/dd/yyyy}��.��6�   Date6�   �� 5:      $	 130��6)    65   �� *	StudentID+.��6`   	StudentId6k   �� 5;      $	 150��6)    65   �� *StudentName+.��6b   StudentName6o   �� 5<      $	 150��6)    65   �� *	Present+ �� 	Converter# [  .��6�   	Present6�   5=      5?      5@      5A      5B      