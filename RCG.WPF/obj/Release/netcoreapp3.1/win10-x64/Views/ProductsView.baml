   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  3clr-namespace:RCG.WPF.ControlsRCG.WPF.Controls  E ARCG.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM5clr-namespace:RCG.Domain.Entities;assembly=RCG.DomainRCG.Domain.Entities      RCG.WPF.Views.ProductsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:RCG.WPF.Views     3controlsclr-namespace:RCG.WPF.Controls     Hlocal15clr-namespace:RCG.Domain.Entities;assembly=RCG.Domain     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aDInteractionTrigger+http://schemas.microsoft.com/xaml/behaviors  -     >�Name$  ProductList��$
��1370��$	��600��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ Loaded��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *LoadedCommand+ � 	Resources    MyDumbMockedList �� Type"  RCG.Domain.Entities.Products
   Sku   Length	   Weight
   Price   BooleanToVisibilityConverter�� %6  &	        &	     �� "  .s�  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80��  $
 Fred��$
 10.8��$	 9��$
 100.80���� .��� ���#ffffff � RowDefinitions �� $��60 ��� $��* ��� $��60 �.+�� $��0��$��	15,0,15,0q� � ColumnDefinitions �� $��* ��� $	��282 ��� $	��173 ��� $	��173 �.+��� $��0��$��0q�  TextBlockHeading#��[ $��Center=����� *TotalRecords+ �� StringFormat$ Product List ({0})���� -    ��Name$ 
SearchText��$��1��  SearchTextBox#��[ ���� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.�� /  )Microsoft.Xaml.Behaviors.Input.KeyTrigger  
   Key$ Enter��.    �� *SearchCommand+   CommandParameter �� *Text+ �� ElementName$ 
SearchText��.���� $��2��  LightButton#��[ $��Add Product������ *AddProductCommand+�� $��3��  PrimaryButton#��[ $��Import products������ *ImportPriceListCommand+&   System.Windows.Controls.DataGrid  -     Name$ ProductListGrid��$��1������ *ProductList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 20
 4  .System.Windows.Controls.DataGridTemplateColumn  $ *
  	  Header$	 SKU��   CellTemplate �� .R��� $��Center=����� *Style+  $ *
 $ Length�� �� .R��� $��Center=����� *AvailableLength+  $ *
 $ Weight�� �� .R��� $��Center=����� *AvrageWeight+  $ *
 $ Price�� �� .R��� $��Center=����� *Price+  $ *
 $ 
Updated On�� �� .R��� $��Center=����� *	UpdatedOn+  $ 60
 $ Actions�� �� .R���  �� Orientation$ 
Horizontal=�$��Right=�.+���   
EditButton#��[ ����  �� Path$$ DataContext.EditProductCommand�$ ProductListGrid������ *	ProductId+��   TrashButton#��[ ���� $&  DataContext.DeleteProductCommand�$ ProductListGrid������   $ 20
 �� $��1�� K� ZIndex$ 1��$��Center=�$��Center=�y��� *IsNoRecords+ �� 	Converter# [ .+��� $��Center=�  MessageHeader#��[ $��No record(s) found��� $��2��$��36��$��Right=�$��0,0,10,0q�y��� *ShowPagination+# [  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0�� 	 PaginationMainButton#��[	 $��First��$��0,0,5,0q����� $$ DataContext.FirstOrLastCommand�$ PaginationIC������ *	Content+ �� RelativeSource �� *Self+�� -   $
��Prev��$��1�� 
 PaginationPrevButton#��[
 ���� $# DataContext.NextOrPrevCommand�$ PaginationIC������ *Name+ �� *Self+�� -   $��CategoryScrollViewer��$��2��$	��180��$��Hidden=�$��Disabled=�$
��True��.���� -   $��PaginationIC��$��2������ *Pages+���� .R��� $ 
Horizontal=����� .R���   PaginationButton#��[ ���� *Number+���� $# DataContext.PaginationCommand�$ PaginationIC������ *	Content+ �� *Self+�� -   $
��Next��$��3��  PaginationNextButton#��[ ���� $# DataContext.NextOrPrevCommand�$ PaginationIC������ *Name+ �� *Self+�� $��4��#��[	 $
��Last��$��5,0,0,0q����� $$ DataContext.FirstOrLastCommand�$ PaginationIC������ *	Content+ �� *Self+