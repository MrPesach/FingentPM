   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RCG.WPFRCG.WPF  5   	   3clr-namespace:RCG.WPF.ControlsRCG.WPF.Controls  5   	       RCG.WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:RCG.WPF     5   	   3controlsclr-namespace:RCG.WPF.Controls     5   	   -   5          �Name$  MasterWindow��5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ CanMinimize=�5   	    � Title$ RCG - Product Manager��5   	    � WindowStartupLocation$ CenterScreen=�5   	   $
��1272��5   	   $	��592��6    � WindowState 5   	   �� *WindowState+.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��85* �6   .+�5   
   � $��0��6   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *
IsLoggedIn+
 �� Value	
 False6E   .a�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;   5      5      .+�5!      $   RCG.WPF.Controls.NavigationBar  5"      �� 5$   
   $��1��6   $
��Auto=�6$   $��Disabled=�6G   .��5%      �� ��6   �� *CurrentViewModel+5&      5'      5(      