   M S B A M L   `   `   `  ����I  EPRN221_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRN221_ProjectPRN221_Project  5   	   '    !PRN221_Project.WorkProgressWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PRN221_Project     5   	   -   5          � Title$  WorkProgressWindow��5   	   $	��450��6;   $	��800��6H    � 	Resources 5	      "   PRN221_Project.WorkConverter   WorkConverter��%   &	          5
   
   66   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��5* �6   6,   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   
����ح�.+�5      �� 
���  ��$��30(�6%   .��63   Work Progress6B   �� 5      $ 
Horizontal=�6   $��0 5 0 0q�62   .+�5      �� -   5        $��tbSearch��5   &   $	��200��6   68   �� 5      -   5        $��	btnSearch��5   5   $��4 0 0 0q�6   $��60��6*   .��6^   Search6f   5      �� 5      
���  ��$��20(�6%   .��63   Information6@   �� 5      .��6   	ClassId6   �� 5      -   5        $��	tbClassId��5       �� 
IsReadOnly$
 True��6'   6;   �� 5      .��6   	StudentId6   �� 5      -   5        $��tbStudentId��5      $
 True��6)   6=   �� 5       .��6   
WorkName6   �� 5!      -   5        $��tbStudentName��5!      $
 True��6�   ��6+   ��  �� Path$ WorkName� �� Mode$ OneWay=� � DataContext 6W   ��  �� ElementName$ lvWorkProgress��$ SelectedItem�6�   �� 5"      .��6   Description6!   �� 5#      -   5        $��tbDescription��5#      $
 True��6�   ��6+   �� $ WorkDescription�$ OneWay=� 6^   �� $ lvWorkProgress��$ SelectedItem�6�   �� 5$      .��6   
Complete6   �� 5%      -   5        $��	cbComplte��5%      ${�False��6(   	 d� 	IsChecked	 6:   �� $ Complete�$ OneWay=� 6k   �� $ lvWorkProgress��$ SelectedItem�6�   �� 5'      $ 
Horizontal=�6   .+�5(      �� -	   5        $��	btnReload��5(   ;   $��8q�6   $��30��6$   $��70��60   .��6e   Reload6m   �� 5)      -
   5        $��btnClose��5)   ;   $��8q�6   $��30��6$   $��70��60   .��6b   Close6i   5*      5-      �� 5/   
   $��1��6   $
��Left=�6%   $��10q�6@   .+�50      �� -   5        
 ��Name$
 lvWorkProgress��50       �� View 51      �� 52      .P�53      ��  �� Width$	 100��6)   $��Progress Id��6a    �� DisplayMemberBinding 65   �� *
ProgressId+6a   �� 54      $	 120��6)   $��
Student ID��6`    65   �� *	StudentID+6`   �� 55      $	 110��6)   $��Work ID��6]    65   �� *WorkID+6]   �� 56      $	 110��6)   $��	Work Name��6_    65   �� *
WorkName+6_   �� 57      $	 110��6)   $��Work Description��6f    65   �� *WorkDescription+6f   �� 58      $	 100��6)   $��Complete��6�    65   �� *
Complete+ �� 	Converter# [  6�   59      5;      5<      5=      5>      