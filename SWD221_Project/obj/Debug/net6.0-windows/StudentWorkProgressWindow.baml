   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   .    (PRN221_Project.StudentWorkProgressWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  StudentWorkProgressWindow��5   	   $	��500��6B   $	��800��6O    � 	Resources 5	      "   PRN221_Project.WorkConverter   WorkConverter��%   &	          5
   
   66   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Work Progress6B   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6_   Search6g   5      �� 5      
���  ��$��20(�6%   .��63   Information6@   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5       �� 
IsReadOnly$
 True��6'   6;   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5      $
 True��6)   6=   �� 5       .��6   	ProcessId6   �� 5!      -   5        $��tbWorkId��5!      $
 True��6&   ��68   ��  �� Path$ 
ProgressId� �� Mode$ OneWay=� � DataContext 6f   ��  �� ElementName$ lvWorkProgress��$ SelectedItem�6�   �� 5"      .��6   
WorkName6   �� 5#      -   5        $��tbStudentName��5#      $
 True��6�   ��6+   �� $ WorkName�$ OneWay=� 6W   �� $ lvWorkProgress��$ SelectedItem�6�   �� 5$      .��6   Description6!   �� 5%      -   5        $��tbDescription��5%      $
 True��6�   ��6+   �� $ WorkDescription�$ OneWay=� 6^   �� $ lvWorkProgress��$ SelectedItem�6�   �� 5&      .��6   
Complete6   �� 5'      -	   5        $��	cbComplte��5'      	 d� 	IsChecked	 6(   �� $ Complete�$ OneWay=� 6Y   �� $ lvWorkProgress��$ SelectedItem�6�   �� 5)      $ 
Horizontal=�6   .+�5*      �� -
   5        $��btnAdd��5*   <   $��8q�6   $��30��6$   $��70��60   .��6`   Add6e   �� 5+      -   5        $��	btnUpdate��5+   ;   $��8q�6   $��30��6$   $��70��60   .��6d   
Update row6p   5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� -   5        $��	btnReload��5/   <   $��8q�6   $��30��6$   $��70��60   .��6e   Reload6m   �� 50      -   5        $��btnClose��50   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Close6i   51      54      �� 56   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�57      �� -   5        
 ��Name$
 lvWorkProgress��57       �� View 58      �� 59      .P�5:      ��  �� Width$	 100��6)   $��Progress Id��6a    �� DisplayMemberBinding 65   �� *
ProgressId+6a   �� 5;      $	 120��6)   $��
Student ID��6`    65   �� *	StudentID+6`   �� 5<      $	 110��6)   $��Work ID��6]    65   �� *WorkID+6]   �� 5=      $	 110��6)   $��	Work Name��6_    65   �� *
WorkName+6_   �� 5>      $	 110��6)   $��Work Description��6f    65   �� *WorkDescription+6f   �� 5?      $	 100��6)   $��Complete��6�    65   �� *
Complete+ �� 	Converter# [  6�   5@      5B      5C      5D      5E      