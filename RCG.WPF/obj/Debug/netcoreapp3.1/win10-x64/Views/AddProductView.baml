   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5      "    RCG.WPF.Views.AddProductView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      $	��445��5      $	��490��6+     � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5	   
   6'   5
      .��5      � ���#ffffff � RowDefinitions 5   
   �� 5      $��52 �6   �� 5      $
��Auto �6   �� 5      $��97 �6   .+�5   
   � ���#EBEDF0$��0��6$    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6     PopupHeader#��[ 6(   ��6M   �� *Title+�� 5      $��1��6     CloseButton#��[ 6%   ��5      �� *CancelCommand+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5      � 5   
   $��1��6   $��0,20,0,5q�6    5      �� 5      �� 5      �� 5      �� 5       .+�5"      �� $��0��6     	FormGroup#��[ 6&    +� FocusedElement 6I   ��  �� ElementName$ 
SkuTextBox��.+�5#      �� $
��Left=�6     DarkTextBlock#��[ 67   $	��SKU��6^   �� 5$      -   5        $��
SkuTextBox��5%      $��1��5$        FormControl#��[ 5&      $
|�True��5'      ��5(      �� *AddProduct.Style+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.��6k   5)      5*      �� 5+      #��[ 6   $��1��6<   .+�5,      �� $
��Left=�6   #��[ 67   $��Length��6^   �� 5-      $��1��6   #��[ 5.      ��5/      �� *AddProduct.AvailableLength+$ TwoWay=�$	 PropertyChanged=�.��6u   50      51      �� 52      #��[ 6   $��2��6<   .+�53      �� $
��Left=�6   #��[ 67   $��Weight��6^   �� 54      $��1��6   #��[ 55      ��56      �� *AddProduct.AvrageWeight+$ TwoWay=�$	 PropertyChanged=�.��6r   57      58      �� 59      #��[ 6   $��3��6<   .+�5:      �� $
��Left=�6   #��[ 67   $��Price in USD��6^   �� 5;      $��1��6   #��[ 5<      ��5=      �� *AddProduct.Price+$ TwoWay=�$	 PropertyChanged=�.��6k   5>      5?      5@      � 5A   
   $��	18,0,10,0q�6   $��2��6"   $	��408��5B       5C      �� 5D      �� 5E      $��90 �6#   �� 5F      $��4 �6#   �� 5G      $��90 �6#   .+�5I      �� $��0��6     	ErrorText#��[ 5J      $
��Left=�5K      $��Center=�5L      $
��Wrap=�5O      
 � DataContext
 5M      �� *ErrorMessageViewModel+��5N      �� *	Message+y�5P      �� *
HasMessage+ �� 	Converter# [  �� 5Q      $��1��5R        LightButton#��[ 5T      $��Cancel��5U      $��80��5V      ��5Q      �� *CancelCommand+��5S      ��  �� $ FindAncestor=�
 Window5V      �� 5W       �� 	IsDefault$
 True��5X      $��3��5Z        PrimaryButton#��[ 5[      $
��Save��6<   $��80��5\      ��5W      �� *SaveProductCommand+��5Y      ��  �� $ FindAncestor=�
 Window5]      5^      5_      5`      