   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  '    !RCG.WPF.Views.ImportCompletedView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:RCG.WPF.Views     $	��470��$	��600��.��� ���#ffffff  � RowDefinitions  �� $��52 ��� $
��Auto �.+�� ���#EBEDF0$��0�� � ColumnDefinitions �� �� .+��� $��0��   PopupHeader#��[  $��Import Price list���� $��1��  CloseButton#��[ ���� *CancelCommand+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window� $��1��  �� $
��Auto ��� $��42 �.+�� $��0��$��20q�  �� �� ��  �� $��45 ��� .+��� $��0��$��0��$'��!/Resources/Images/check-green.png��$
��None=�$��30��$��30��$
��Left=��� $��1��$��0��  MessageHeader#��[ ���� *	Message+� $��1��$��1��$��Stretch=�$	��131��$��0,0,0,10q� �� $��5* ��� $	��70* ��� $	��20* �  �� �� �� �� .+��� $��0��$��0��  	GreenTick#��[ �� $��1��$��0��  DarkTextBlock#��[ $
��Left=�$��Total Number of Product:���� $��2��$��0��#��[ $
��Bold"�$
��Left=�$	��100���� $��0��$��1��#��[ �� $��1��$��1��#��[ $
��Left=�$-��'Total Number of Price Updated Products:���� $��2��$��1��#��[ $
��Bold"�$
��Left=�$��50���� $��0��$��2��#��[ �� $��1��$��2��#��[ $
��Left=�$��Total No of New Products:���� $��2��$��2��#��[ $
��Bold"�$
��Left=�$��2���� $��0��$��3�� 	 Error#��[ �� $��1��$��3��#��[ $
��Left=�$(��"Total No of  Products With Errors:���� $��2��$��3��#��[ $
��Bold"�$
��Left=�$��4��� $��2��$��2�����#FAFAFA  �� ��  �� $	��10* ��� $	��90* �.+��� $��0��$��0��  CSVIcon#��[ $��38��$��55��$��10,0,0,0q��� $��1��$��0��.+��� #��[ $ ��Price List CSV With Errors��$��	15,10,0,0q��� #��[ $
��Wrap=�$����To fix this errors you can download this modified CSV file that you uploaded. It only contains data with errors. Please fix the error and upload it again���� $��	0,0,10,10q�$��1��$��1��.+���   DownloadButton#��[ ���� *DownloadCommand+.����  �� Orientation$ 
Horizontal=�.+��� $&�� /Resources/Images/down-arrow.png��$��0,0,10,3q�$
��None=��� $��Download CSV���� $��1��  PrimaryButton#��[ $��OK��$��75������ *CancelCommand+����  �� $ FindAncestor=�
 Window