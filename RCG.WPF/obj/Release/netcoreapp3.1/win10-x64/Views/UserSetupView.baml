   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  J FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components !    RCG.WPF.Views.UserSetupView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:RCG.WPF.Views     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM       � 	Resources      BooleanToVisibilityConverter��%   &	        �� .��� ����  �� ImageSource$( "/Resources/images/login-banner.png�� j� Stretch$
 None=�.+�� ���#ffffff$��Right=�$	��484�� � RowDefinitions �� $��2* ��� $	��98* �.+��� $��0��$��Right=� �� Orientation$ 
Horizontal=�.+���   TitleBarButton#��[ ���� *MinimizeAppCommand+����  �� RelativeSource ��  �� AncestorType" �.���� $&�� /Resources/Images/black-line.png���� #��[ ���� *CloseAppCommand+.���� $!��/Resources/Images/close.png��� $��1��$��Center=� �� �� �� �� �� �� .+��� $��1��  	FormGroup#��[ .+���   TextBlockHeading#��[ $��Setup Account���� $
��Left=�  DarkTextBlock#��[ $
��Name����   FormControl#��[ ���� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.���� $��2��#��[ .+��� $
��Left=�#��[ $��Username���� #��[ ���� *
Username+$ TwoWay=�$ PropertyChanged=�.���� $��3��#��[ .+��� $
��Left=�#��[ $��Password��4  .PasswordBoxMVVM.Components.BindablePasswordBox  $
��Left=�$	��400��$��40��	   Password	 �� *
Password+�� $��4��#��[ .+��� $
��Left=�#��[ $��Confirm Password��  $
��Left=�$	��400��$��40��	 �� *ConfirmPassword+� $	��400��$��5��$��Right=�$��	0,20,42,0q�
 � ColumnDefinitions
 �� $	��70* ��� $	��30* �.+���   	ErrorText#��[ $��0��$��0,0,10,0q�$
��Left=�$��Center=�$
��Wrap=� � DataContext �� *ErrorMessageViewModel+���� *	Message+y��� *
HasMessage+ �� 	Converter# [  �� $��1��$��Create Account�� �� 	IsDefault$
 True��  PrimaryButton#��[ $��35��$	��113��$��Right=����� *RegisterCommand+