   M S B A M L   `   `   `  ����D  @PspClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PspClient.ViewPspClient.View  5   	   &     PspClient.View.DeleteGradeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PspClient.View     5   	   
����ح�  � Icon$3  -C:\Users\User\source\repos\PspClient\icon.ico��5   	    � WindowStartupLocation$ CenterScreen=�5
   
    � Title$! Удалить оценку��5   	   $	��160��6    $	��350��6-    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ Manual=�6    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $
 5��5   !   ._�5!      �� $��Center=�6/   $��Center=�6L   5"      5#      5%       5&      P� 5'       �@J�IsMouseOver . . �5(      ��  � �� �#45A04963   5*      P� 5+       � �� . . �5,      ��  � �� �#2E7D3263   5.      50      51      .��52      � $��10q�6    � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6   .+�59   
   �� $��0��6   $��Center=�5:      $��0,0,0,10q�5;      $
��Wrap=�5<      $X��RВведите ID оценки, которую необходимо удалить��5=      �� 5?   
   -   5        $��DeleteGradeIDInput��5?      $��1��5@      $��Stretch=�5A      $��0,0,0,10q�5B       �� TextWrapping$
 Wrap=�5C      �� 5E   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5F      �� -   5         ��Name$ DeleteButton��5F      $��Удалить��6+   $��5q�6=   $��80��6c   �� 5G      -   5        $��Отмена��5G      $��5q�6&   $��80��6L   5H      5I      5J      