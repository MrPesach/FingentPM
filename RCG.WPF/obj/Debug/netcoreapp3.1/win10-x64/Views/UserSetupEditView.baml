   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5      J FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components 5   L   %    RCG.WPF.Views.UserSetupEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     6L   $	��445��5	      $	��490��6     � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � ���#ffffff � RowDefinitions 5   
   �� 5      $��52 �6   �� 5      $
��Auto �6   �� 5      $��97 �6   .+�5   
   � ���#EBEDF0$��0��6$    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6     PopupHeader#��[ 6(   ��6M   �� *Title+�� 5      $��1��6     CloseButton#��[ 6%   ��5      �� *CancelCommand+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5      � 5   
   $��1��6   $��0,20,0,5q�6    5      �� 5       �� 5!      �� 5"      �� 5#      .+�5%      �� $��0��6     	FormGroup#��[ 6&    +� FocusedElement 6I   ��  �� ElementName$ NameTextBox��.+�5&      �� $
��Left=�6     DarkTextBlock#��[ 67   $
��Name��6^   �� 5'      -   5        $��NameTextBox��5(      $��1��5'        FormControl#��[ 5)      ��5*      �� *Name+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.��6_   5+      5,      �� 5-      #��[ 6   $��1��6<   .+�5.      �� $
��Left=�6   #��[ 67   $��Username��6^   �� 5/      $��1��6   #��[ 50      ��51      �� *
Username+$ TwoWay=�$	 PropertyChanged=�.��6c   52      53      �� 54      #��[ 6   $��2��6<   .+�55      �� $
��Left=�6   #��[ 67   $��Password��6^   4  .PasswordBoxMVVM.Components.BindablePasswordBox  56      $��1��61   $
��Left=�6A   $	��400��6\   $��40��6h   
   Password
 57      �� *
Password+58      �� 59      #��[ 6   $��3��6<   .+�5:      �� $
��Left=�6   #��[ 67   $��Confirm Password��6^     5;      $��1��61   $
��Left=�6A   $	��400��5<   >   $��40��6J   
 6   �� *ConfirmPassword+6J   5=      5>      � 5?   
   $��	18,0,10,0q�6   $��2��6"   $	��408��5@       5A      �� 5B      �� 5C      $��90 �6#   �� 5D      $��4 �6#   �� 5E      $��90 �6#   .+�5G      �� $��0��6     	ErrorText#��[ 5H      $
��Left=�5I      $��Center=�5J      $
��Wrap=�5M       � DataContext 5K      �� *ErrorMessageViewModel+��5L      �� *	Message+y�5N      �� *
HasMessage+ �� 	Converter# [  �� 5O      $��1��5P        LightButton#��[ 5R      $��Cancel��5S      $��80��5T      ��5O      �� *CancelCommand+��5Q      ��  �� $ FindAncestor=�
 Window5T      �� 5U       �� 	IsDefault$
 True��5V      $��3��5X        PrimaryButton#��[ 5Y      $
��Save��6<   $��80��5Z      ��5U      �� *UpdateUserCommand+��5W      ��  �� $ FindAncestor=�
 Window5[      5\      5]      5^      