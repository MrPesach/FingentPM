   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RCG.WPFRCG.WPF  3clr-namespace:RCG.WPF.ControlsRCG.WPF.Controls      RCG.WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:RCG.WPF     3controlsclr-namespace:RCG.WPF.Controls     -     �Name$  MasterWindow�� � WindowStyle$
 None=� � 
ResizeMode$ CanMinimize=� � Title$ RCG - Product Manager�� � WindowStartupLocation$ CenterScreen=�$
��1272��$	��592�� � WindowState �� *WindowState+.���  � RowDefinitions �� $
��Auto ��� $	��85* �.+�� $��0������  �� 
TargetType" � �� Triggers �� 	 �� Binding	 �� *
IsLoggedIn+
 �� Value	
 False.a���  �� Property � y� �� Value$ 	Collapsed=�.+�$   RCG.WPF.Controls.NavigationBar  �� $��1��$
��Auto=�$��Disabled=�.���� ���� *CurrentViewModel+