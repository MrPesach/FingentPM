   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RCG.WPF.ConvertersRCG.WPF.Converters  5      3clr-namespace:RCG.WPF.ControlsRCG.WPF.Controls  5      C&clr-namespace:RCG.WPF.State.NavigatorsRCG.WPF.State.Navigators  5	      7 clr-namespace:RCG.WPF.ViewModelsRCG.WPF.ViewModels  5
      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    RCG.WPF.Controls.NavigationBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7
converters clr-namespace:RCG.WPF.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:RCG.WPF.Controls     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      6nav&clr-namespace:RCG.WPF.State.Navigators     5	      /vm clr-namespace:RCG.WPF.ViewModels     5
      6sys&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5          BooleanToVisibilityConverter7   1RCG.WPF.Converters.EqualValueToParameterConverter " EqualValueToParameterConverter��%:   &	        &	      �� 5   
   6'     5   
   64   5      .��5      � $	��113��6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $	��30* �6   6+   �� 5      $	��70* �6   6+   ��5   
   �� 5       �� ImageSource$* $/Resources/images/app-header-new.png��6    j� Stretch$
 None=�6L   .+�5   
   �� $��0��6   $��0��6!   $
��Left=�61     LighTextBlock#��[ 5       $��Product Manager��6;   $��	10,10,0,0q�5!      �� 5"   
   $��0��6   $��1��6"   $��Right=�62    �� Orientation$ 
Horizontal=�6N   .+�5#      ��   TitleBarButton#��[ 6   ��6=   �� *MinimizeAppCommand+��5$      ��  �� RelativeSource ��  �� AncestorType" �.��5%      �� $&�� /Resources/Images/white-line.png��6   6D   5&      �� 5+      #��[ 6   ��6=   �� *CloseAppCommand+.��5,      �� $'��!/Resources/Images/white-close.png��6   6E   5-      5.      �� 5/   
   $��1��6   $��1��6"   $��0,0,30,0q�63   $��Right=�50      $ 
Horizontal=�51      .+�52      �� -   5         ��Name$ 
MainButton��54        TransparentButton#��[ 52      	 �� 	IsEnabled$	 False��55      
 �� ShowOnDisabled$

 True��56      $��Right=�58      y�53      �� *	IsAdmin+ �� 	Converter# [  .��59      �� $ 
Horizontal=�6   .+�5:      �� $$��/Resources/Images/settings.png��6   $��0,0,10,0q�6D   $��20��6V   $��22��6a   �� 5;      $��Settings��6    �� 5<      $/��)/Resources/Images/keyboard-arrow-down.png��6   $��20,0,0,0q�6O   $
��None=�6a   5=       � ContextMenu 5>      �� 5?      -   5         ��Name$ MainContextMenu��5?   "   ���#ffffff.@�5@      m� $��Manage User Account��6#    m� Icon$  /Resources/Images/user.png��5B       m� Command 5A      �� *UserSettingsCommand+5B      m� 5C      $��Change Index Path��6#   $' !/Resources/Images/folder-open.png��5E       5D   #   �� *ChangeIndexPathCommand+5E      5F      5H      � 5J      $��35,0,0,0q�6   .+�5K      A� ���#ffffff$��2��6+    J� SnapsToDevicePixels$
 True��6?     	BrushBlue#��[ 6[   $��40��6}   $��40��6�   �� 5L      #��[ 6   $��0q�5N        
BrushWhite#��[ 5O      $��14(�6A   ��5M      �� *LoggedUserFirstLetter+5O   A   5P      �� 5Q      $��1��6   $��3��6&   $��Center=�5S      $��Center=�5T      #��[ 5U      ��5V      �� *LoggedUserName+5W      5X      5Z      