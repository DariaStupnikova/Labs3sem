   M S B A M L   `   `   `  ����?  ;Lab5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab5Lab5  5   	       Lab5.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab5     5   	     � Title$  Task Manager��5   	   $	��400��6   $	��600��6+    � 	Resources 5	         ListViewItemStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  &	        �� 5
   
   " ��6*   .�5      ��  � �� �#F0F0F06+   �� 5       � ��$ Stretch=�6;   �� 5       � �� �#CCCCCC6,   �� 5       � ��$ 0,0,0,1q�60   �� 5       � ��$ 5q�6(    5      P� 5       �@��
IsSelected$
 True��60   . �5      ��  � �� �#6495ED63   �� 5       � ��
 �����63   5      5      5      .��5      � .+�5   
   �� -   5        $��taskListView��5      #��[  6J   ��6'   �� *
_taskItems+ �� View 5      �� 5      .P�5      �� $��Title��6%   	 �� Width$		 200��6[   
 �� DisplayMemberBinding
 64   �� *Title+6[   �� 5      $��Deadline��6%   $		 150��6a   
 67   �� *
Deadline+6a   5      ��5       �� 5!      .R�5"      �  � ColumnDefinitions 5#      �� 5$      $
��Auto �6/   �� 5%      $��* �6/   .+�5'      �� -   5        $D��>C:\Users\nikha\RiderProjects\DesignLabsCS\Lab5\expand_icon.png��5'       $��20��6h   $��20��6s   $��Center=�6    � Cursor$
 Hand��6�   6�   9� 5(      $��1��6#    9� 
IsExpanded$ False��6L   ��63   �� *Title+.��5)      �� .+�5*   "   �� $��10,0,0,0q�6I   ��6,   �� *Description+6I   �� 5+   "   $��Tags:��6,   $
��Bold"�69   $��10,5,0,0q�6K   �� 5,   "   ��6/   �� *Tags+��5-   &   �� 5.   *   .R�5/   .   �� $��20,0,0,0q�6I   ��68   �� 6I   50   +   52   #   �� 53   "   $��10,5,0,0q�6u   ��6,   �� *
Deadline+ �� StringFormat$$ Deadline: {0:dd/MM/yyyy HH:mm}��6u   54      55      56      57      59      5:      5;      