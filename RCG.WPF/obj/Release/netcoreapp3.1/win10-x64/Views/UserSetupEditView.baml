   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  J FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components %    RCG.WPF.Views.UserSetupEditView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:RCG.WPF.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     $	��445��$	��490��  � 	Resources      BooleanToVisibilityConverter��%   &	        �� .��� ���#ffffff � RowDefinitions �� $��52 ��� $
��Auto ��� $��97 �.+�� ���#EBEDF0$��0�� � ColumnDefinitions �� �� .+��� $��0��  PopupHeader#��[ ���� *Title+�� $��1��  CloseButton#��[ ���� *CancelCommand+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window� $��1��$��0,20,0,5q� �� �� �� �� .+��� $��0��  	FormGroup#��[  +� FocusedElement ��  �� ElementName$ NameTextBox��.+��� $
��Left=�  DarkTextBlock#��[ $
��Name���� -   $��NameTextBox��$��1��  FormControl#��[ ���� *Name+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.���� #��[ $��1��.+��� $
��Left=�#��[ $��Username���� $��1��#��[ ���� *
Username+$ TwoWay=�$	 PropertyChanged=�.���� #��[ $��2��.+��� $
��Left=�#��[ $��Password��4  .PasswordBoxMVVM.Components.BindablePasswordBox  $��1��$
��Left=�$	��400��$��40��
   Password
 �� *
Password+�� #��[ $��3��.+��� $
��Left=�#��[ $��Confirm Password��  $��1��$
��Left=�$	��400��$��40��
 �� *ConfirmPassword+� $��	18,0,10,0q�$��2��$	��408�� �� �� $��90 ��� $��4 ��� $��90 �.+��� $��0��  	ErrorText#��[ $
��Left=�$��Center=�$
��Wrap=� � DataContext �� *ErrorMessageViewModel+���� *	Message+y��� *
HasMessage+ �� 	Converter# [  �� $��1��  LightButton#��[ $��Cancel��$��80������ *CancelCommand+����  �� $ FindAncestor=�
 Window��  �� 	IsDefault$
 True��$��3��  PrimaryButton#��[ $
��Save��$��80������ *UpdateUserCommand+����  �� $ FindAncestor=�
 Window