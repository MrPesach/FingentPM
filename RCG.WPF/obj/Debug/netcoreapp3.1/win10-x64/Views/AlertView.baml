   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5          RCG.WPF.Views.AlertView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      $	��450��5      $	��180��6+     � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5	   
   6'   5
      .��5      � ���#ffffff � RowDefinitions 5   
   �� 5      $��52 �6   �� 5      $
��Auto �6   �� 5      $��42 �6   .+�5   
   � ���#EBEDF0$��0��6$    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6     PopupHeader#��[ 6(   ��6M   �� *Title+�� 5      $��1��6     CloseButton#��[ 6%   ��5      �� *	OkCommand+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5      � 5   
   $��1��6   $��20q�6   $��Center=�6(    5      �� 5      �� 5       5       �� 5!      $��45 �6#   �� 5"      .+�5$      �� $��0��6   $��0��6$   $
��None=�5&      $��30��5'      $��30��5(      $
��Left=�5)      ��5%      �� *	IconUri+5)      �� 5*      $��1��6   $��0��6(     MessageHeader#��[ 6O   ��66   �� *	Message+6O   5+      �� 5,   
   $��2��6   $��Right=�5-       �� Orientation$ 
Horizontal=�5.      $��0,0,15,0q�5/      y�50      �� *IsConfirmation+ �� 	Converter# [  .+�51      ��   TextOnlyButton#��[ 53      $��No��54      $��75��55      $��0q�56      ��51      �� *	NoCommand+��52      ��  �� $ FindAncestor=�
 Window56      �� 57        PrimaryButton#��[ 59      $	��Yes��5:      $��75��5;      ��57      �� *
YesCommand+��58      ��  �� $ FindAncestor=�
 Window5;      5<      �� 5=   
   $��2��6   #��[ 5@      $��OK��5A      $��75��5B      ��5>      �� *	OkCommand+��5?      ��  �� $ FindAncestor=�
 Windowy�5C      �� *	IsAlert+# [  5D      5E      