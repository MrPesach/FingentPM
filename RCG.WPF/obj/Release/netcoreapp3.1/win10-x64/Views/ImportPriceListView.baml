   M S B A M L   `   `   `  ���� J  FProduct Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RCG.WPF.ViewsRCG.WPF.Views  #    RCG.WPF.Views.ImportPriceList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:RCG.WPF.Views     $	��588������ *PopupHeight+  � 	Resources      BooleanToVisibilityConverter��%   &	        �� .��� ���#ffffff � RowDefinitions �� $��52 ��� $
��Auto �.+�� ���#EBEDF0$��0�� � ColumnDefinitions �� �� .+��� $��0��  PopupHeader#��[ $��Import Products���� $��1��  CloseButton#��[ ���� *CancelCommand+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType
 Window� $��1��y��� *IsCompleted+ �� 	Converter# [   �� $
��Auto ��� $��42 �.+�� $��0��$��20q� �� �� ��  �� $��45 ��� .+��� $��0��$��0��$
��None=�$��30��$��30��$
��Left=����� *ImportCompleteImageUri+�� $��1��$��0��  MessageHeader#��[ ���� *ImportCompleteMessage+� $��1��$��1��$��Stretch=�$	��131��$��0,0,0,10q� �� $��5* ��� $	��70* ��� $	��20* � �� �� �� �� .+��� $��0��$��0��  	GreenTick#��[ �� $��1��$��0��  DarkTextBlock#��[ $
��Left=�$��Total no of products:���� $��2��$��0��#��[ $
��Bold"�$
��Left=����� *NumberOfTotal+�� $��0��$��1��#��[ �� $��1��$��1��#��[ $
��Left=�$#��Total no of products updated:���� $��2��$��1��#��[ $
��Bold"�$
��Left=����� *NumberOfUpdated+�� $��0��$��2��#��[ �� $��1��$��2��#��[ $
��Left=�$��Total no of new products:���� $��2��$��2��#��[ $
��Bold"�$
��Left=����� *NumberOfNew+�� $��0��$��3�� 	 Error#��[ y��� *CSVHasError+# [  �� $��1��$��3��#��[ $
��Left=�$&�� Total no of products with error:��y��� *CSVHasError+# [  �� $��2��$��3��#��[ $
��Bold"�$
��Left=����� *NumberOfFiled+y��� *CSVHasError+# [  � $��2��$��2�����#FAFAFAy��� *CSVHasError+# [   �� ��  �� $	��10* ��� $	��90* �.+��� $��0��$��0��  CSVIcon#��[ $��38��$��55��$��10,0,0,0q��� $��1��$��0��.+��� #��[ $ ��Price List CSV With Errors��$��	15,10,0,0q��� #��[ $
��Wrap=�$����To fix this errors you can download this modified CSV file that you uploaded. It only contains data with errors. Please fix the error and upload it again���� $��	0,0,10,10q�$��1��$��1��$��Right=� �� Orientation$ 
Horizontal=�.+���   TextOnlyButton#��[ $��
Upload CSV������ *BrowseFileCommand+��  	 DownloadButton#��[	 ���� *DownloadCSVCommand+.���� $ 
Horizontal=�.+��� $&�� /Resources/Images/down-arrow.png��$��0,0,10,3q�$
��None=��� $��Download CSV���� $ 
Horizontal=�$��1��$��Right=�.+��� y��� *CSVHasNoError+# [  .+���  
 ProceedButton#��[
 $��OK��$��75������ *CancelCommand+����  �� $ FindAncestor=�
 Window�� $ 
Horizontal=�y��� *CSVHasError+# [  .+��� #��[ $��Cancel������ *CancelCommand+����  �� $ FindAncestor=�
 Window�� #��[
 ���� *ProceedCommand+.���� $ 
Horizontal=�.+��� $��Proceed��$��0,0,10,3q��� $&�� /Resources/Images/next-arrow.png��$
��None=�� $��1��y��� *
InProgress+# [   �� $
��Auto ��� $��97 �.+���  �� CornerRadius$ 3��$��0��$��1q�$	��540��$	��236��$��
20,10,20,0q�	 �� Padding$	 
20,10,20,0q�y��� *FileUploadSection+# [  ��L� 
 j� Viewport$
 	0,0,18,18� j� ViewportUnits$ Absolute=� j� TileMode$
 Tile=� L� Drawing I� .���  � Brush �#A7A8A9 � Geometry � .����  �� Rect$ 	0,0,50,50��� $ 50,50,50,50�._��� .+��� #��[ ��   LightButton#��[ $��Browse File������ *BrowseFileCommand+�� #��[ $��Support .CSV format only��$��CharacterEllipsis=�$��0,10,0,0q��� #��[ $��	0,10,0,20q����� *
FileName+� $
��Auto��$��0��$��0,25,0,0q�y��� *ProgressBarSection+# [   �� �� .+��� $��0��.+��� #��[ $��Processing CSV file��$
��Left=�$��Bottom=�� $��1�� � Value �� *ProgressBarValue+�� $ 
Horizontal=�$��1��$��Right=�.+��� #��[ $��Cancel������ *CancelCommand+����  �� $ FindAncestor=�
 Window�� #��[
 ���� *ProceedCommand+.���� $ 
Horizontal=�.+��� $��Proceed��$��0,0,10,3q��� $&�� /Resources/Images/next-arrow.png��$
��None=�