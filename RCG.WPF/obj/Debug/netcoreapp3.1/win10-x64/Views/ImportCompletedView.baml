   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5      '    !RCG.WPF.Views.ImportCompletedView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      $	��470��5      $	��600��6   .��5	      � ���#ffffff  � RowDefinitions  5
   
   �� 5      $��52 �6   �� 5      $
��Auto �6   .+�5   
   � ���#EBEDF0$��0��6$    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6      PopupHeader#��[  6(   $��Import Price list��6M   �� 5      $��1��6     CloseButton#��[ 6%   ��5      �� *CancelCommand+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window5      � 5   
   $��1��6     5      �� 5      $
��Auto �6    �� 5      $��42 �6    .+�5   
   � $��0��6   $��20q�6     5       �� 5!      �� 5"      �� 5#       5%      �� 5&      $��45 �6#   �� 5'      .+�5)      �� $��0��6   $��0��6$   $'��!/Resources/Images/check-green.png��5*      $
��None=�5+      $��30��5,      $��30��5-      $
��Left=�5.      �� 5/      $��1��6   $��0��6(     MessageHeader#��[ 6O   ��66   �� *	Message+6O   � 50      $��1��6   $��1��6    $��Stretch=�60   $	��131��6N   $��0,0,0,10q�6[    51      �� 52      $��5* �6'   �� 53      $	��70* �6'   �� 54      $	��20* �6'     56      �� 57      �� 58      �� 59      �� 5:      .+�5=      �� $��0��6   $��0��6(     	GreenTick#��[ 65   �� 5>      $��1��6   $��0��6,     DarkTextBlock#��[ 6:   $
��Left=�5?      $��Total Number of Product:��5@      �� 5A      $��2��6   $��0��6,   #��[ 5B      $
��Bold"�5C      $
��Left=�5D      $	��100��5E      �� 5G      $��0��6   $��1��6(   #��[ 65   �� 5H      $��1��6   $��1��6,   #��[ 6:   $
��Left=�5I      $-��'Total Number of Price Updated Products:��5J      �� 5K      $��2��6   $��1��6,   #��[ 5L      $
��Bold"�5M      $
��Left=�5N      $��50��5O      �� 5Q      $��0��6   $��2��6(   #��[ 65   �� 5R      $��1��6   $��2��6,   #��[ 6:   $
��Left=�5S      $��Total No of New Products:��5T      �� 5U      $��2��6   $��2��6,   #��[ 5V      $
��Bold"�5W      $
��Left=�5X      $��2��5Y      �� 5[      $��0��6   $��3��6(    	 Error#��[ 65   �� 5\      $��1��6   $��3��6,   #��[ 6:   $
��Left=�5]      $(��"Total No of  Products With Errors:��5^      �� 5_      $��2��6   $��3��6,   #��[ 5`      $
��Bold"�5a      $
��Left=�5b      $��4��5c      5e      � 5g      $��2��6   $��2��6    ���#FAFAFA  5h      �� 5i      �� 5j       5l      �� 5m      $	��10* �6'   �� 5n      $	��90* �6'   .+�5q      �� $��0��6   $��0��6(     CSVIcon#��[ 65   $��38��5r      $��55��6#   $��10,0,0,0q�5s      �� 5t      $��1��6   $��0��6.   .+�5u      �� #��[ 6    $ ��Price List CSV With Errors��5v       $��	15,10,0,0q�5w       �� 5x      #��[ 6    $
��Wrap=�5y       $����To fix this errors you can download this modified CSV file that you uploaded. It only contains data with errors. Please fix the error and upload it again��5z       5{      �� 5|      $��	0,0,10,10q�6   $��1��60   $��1��6=   .+�5}      ��   DownloadButton#��[ 5~      ��5}      �� *DownloadCommand+.��5      ��  �� Orientation$ 
Horizontal=�6%   .+�5�      �� $&�� /Resources/Images/down-arrow.png��6$   $��0,0,10,3q�6N   $
��None=�6`   �� 5�      $��Download CSV��6(   5�      5�      5�      5�      5�      �� 5�   
   $��1��6     PrimaryButton#��[ 5�      $��OK��5�      $��75��5�      ��5�      �� *CancelCommand+��5�      ��  �� $ FindAncestor=�
 Window5�      6$   5�      5�      