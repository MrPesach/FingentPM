   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5      !    RCG.WPF.Views.IndexPathView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aDInteractionTrigger+http://schemas.microsoft.com/xaml/behaviors  5	      $	��255��5      $	��440��6   *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5
      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6*   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 65   �� *LoadedCommand+   CommandParameter 6W   �� 5       � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � ���#ffffff � RowDefinitions 5   
   �� 5      $��52 �6   �� 5      $
��Auto �6   �� 5      $��97 �6   .+�5   
   � ���#EBEDF0$��0��6$    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6     PopupHeader#��[ 6(   $��Change Index Path��6M   �� 5      $��1��6     CloseButton#��[ 6%   ��5      �� *CancelCommand+��5       ��  �� RelativeSource �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType

 Window5!      � 5"   
   $��1��6   $��0,20,0,5q�6    5#      �� 5$      �� 5%      �� 5&      �� 5'      .+�5)      �� $��0��6     	FormGroup#��[ 6&   .+�5*      �� $
��Left=�6     DarkTextBlock#��[ 67   $��Folder Path��6^   �� 5+      $��1��6     FolderPathTextBox#��[ 5,      ��5-      �� *SelectedPath+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6l   5.      5/      50      � 51   
   $��	18,0,15,0q�6   $��2��6"    53      �� 54      �� 55      $��90 �6#   �� 56      $��4 �6#   �� 57      $��90 �6#   .+�59      �� $��0��6     	ErrorText#��[ 5:      $
��Left=�5;      $��Center=�5<      $
��Wrap=�5?       � DataContext 5=      �� *ErrorMessageViewModel+��5>      �� *	Message+y�5@      �� *
HasMessage+ �� 	Converter# [  �� 5A      $��1��5B        LightButton#��[ 5D      $��Cancel��5E      $��80��5F      ��5A      �� *CancelCommand+��5C      ��  �� $	 FindAncestor=�

 Window5F      �� 5G      $��3��5I        PrimaryButton#��[ 5J      $
��Save��6<   $��80��5K      ��5G      �� *SaveIndexFilePathCommand+��5H      ��  �� $	 FindAncestor=�

 Window5L      5M      5N      5O      