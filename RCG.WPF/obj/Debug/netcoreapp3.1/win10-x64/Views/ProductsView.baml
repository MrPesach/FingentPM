   M S B A M L   `   `   `  ����J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  5      3clr-namespace:RCG.WPF.ControlsRCG.WPF.Controls  5      E ARCG.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM5clr-namespace:RCG.Domain.Entities;assembly=RCG.DomainRCG.Domain.Entities 5	           RCG.WPF.Views.ProductsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RCG.WPF.Views     5      3controlsclr-namespace:RCG.WPF.Controls     5      Hlocal15clr-namespace:RCG.Domain.Entities;assembly=RCG.Domain     5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aDInteractionTrigger+http://schemas.microsoft.com/xaml/behaviors  5
      -   5          >�Name$  ProductList��5      $
��1370��5      $	��600��5      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6*   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 65   �� *LoadedCommand+5       � 	Resources 5         MyDumbMockedList �� Type"  RCG.Domain.Entities.Products
   Sku   Length	   Weight
   Price   BooleanToVisibilityConverter�� 5   
   %�  &	        &	 s    �� 5      "  6/   .s�5        $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5      $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F     5       $
 Fred��6"   $
 10.8��6-   $	 9��6;   $
 100.80��6F   5!      �� 5"      6+   5#      .��5&      � ���#ffffff � RowDefinitions 5'   
   �� 5(      $��60 �6   �� 5)      $��* �6   �� 5*      $��60 �6   .+�5,   
   � $��0��6   $��	15,0,15,0q�6    � ColumnDefinitions 5-      �� 5.      $��* �6#   �� 5/      $	��282 �6#   �� 50      $	��173 �6#   �� 51      $	��173 �6#   .+�53      �� $��0��6   $��0q�6(     TextBlockHeading#��[ 63   $��Center=�54      ��55      �� *TotalRecords+ �� StringFormat$ Product List ({0})���� 56      -   5         ��Name$ 
SearchText��56      $��1��6*     SearchTextBox#��[ 6:   ��57      �� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6e    58      /  )Microsoft.Xaml.Behaviors.Input.KeyTrigger  59      
   Key$ Enter��64   . 5:         5;      �� *SearchCommand+   CommandParameter 5<      �� *Text+ �� ElementName$ 
SearchText��5=      .��5>   ;   5?      �� 5@      $��2��6     LightButton#��[ 6%   $��Add Product��5A      ��6+   �� *AddProductCommand+�� 5B      $��3��6     PrimaryButton#��[ 6%   $��Import products��5C      ��6/   �� *ImportPriceListCommand+5D      &   System.Windows.Controls.DataGrid  5H   
   -   5          Name$ ProductListGrid��5H   D   $��1��6   ��6    �� *ProductList+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 20
 6%   4  .System.Windows.Controls.DataGridTemplateColumn  5K      $ *
 6)    	  Header$	 SKU��63      CellTemplate 5L      �� 5M      .R�5N      �� $��Center=�6?   ��6(   �� *Style+6?   5O      5Q        5R      $ *
 6)   $ Length��63    5S      �� 5T      .R�5U      �� $��Center=�6I   ��6(   �� *AvailableLength+6I   5V      5X        5Y      $ *
 6)   $ Weight��63    5Z      �� 5[      .R�5\      �� $��Center=�6F   ��6(   �� *AvrageWeight+6F   5]      5_        5`      $ *
 6)   $ Price��63    5a      �� 5b      .R�5c      �� $��Center=�6?   ��6(   �� *Price+6?   5d      5f        5g      $ *
 6)   $ 
Updated On��63    5h      �� 5i      .R�5j      �� $��Center=�6C   ��6(   �� *	UpdatedOn+6C   5k      5m        5n      $ 60
 6)   $ Actions��64    5o      �� 5p      .R�5q      ��  �� Orientation$ 
Horizontal=�6)   $��Right=�6B   .+�5r   "   ��   
EditButton#��[ 5s   L   ��5r   )   ��  �� Path$$ DataContext.EditProductCommand�$ ProductListGrid����5s   %   �� *	ProductId+5t   #   �� 5u   "     TrashButton#��[ 5v   B   ��5u   )   �� $&  DataContext.DeleteProductCommand�$ ProductListGrid����5v   %   �� 5w   #   5x      5y      5{        5|      $ 20
 6%   5      �� 5�   
   $��1��6    K� ZIndex$ 1��6"   $��Center=�5�      $��Center=�5�      y�5�      �� *IsNoRecords+ �� 	Converter# [ .+�5�      �� $��Center=�6     MessageHeader#��[ 67   $��No record(s) found��5�      5�      � 5�   
   $��2��5�      $��36��6   $��Right=�6)   $��0,0,10,0q�6E   y�5�      �� *ShowPagination+# [  5�      �� 5�      $��* �6#   �� 5�      $��* �6#   �� 5�      $��* �6#   �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      �� $��0��6    	 PaginationMainButton#��[	 6&   $��First��6T   $��0,0,5,0q�5�      ��5�      �� $$ DataContext.FirstOrLastCommand�$ PaginationIC����5�      �� *	Content+ �� RelativeSource �� *Self+�� 5�      -   5        $
��Prev��5�      $��1��5�       
 PaginationPrevButton#��[
 6&   ��5�      �� $# DataContext.NextOrPrevCommand�$ PaginationIC����5�      �� *Name+ �� *Self+�� 5�      -   5        $��CategoryScrollViewer��5�      $��2��5�      $	��180��5�      $��Hidden=�5�      $��Disabled=�5�      $
��True��5�      .��5�      �� -   5        $��PaginationIC��5�   O   $��2��6   ��60   �� *Pages+��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6)   5�      5�      ��5�      �� 5�      .R�5�      ��   PaginationButton#��[ 6%   ��5�   !   �� *Number+��5�   !   �� $# DataContext.PaginationCommand�$ PaginationIC����5�   !   �� *	Content+ �� *Self+5�      5�      5�      �� 5�      -   5        $
��Next��5�      $��3��5�        PaginationNextButton#��[ 6&   ��5�      �� $# DataContext.NextOrPrevCommand�$ PaginationIC����5�      �� *Name+ �� *Self+�� 5�      $��4��6   #��[	 6%   $
��Last��5�      $��5,0,0,0q�5�      ��5�      �� $$ DataContext.FirstOrLastCommand�$ PaginationIC����5�      �� *	Content+ �� *Self+5�      5�      5�      