   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
TargetType �� Property $   DataGrid.AlternateRow.Background �� Value  DataGrid.Static.BorderBrush % !DataGrid.Grid.HorizontalLineBrush �� 
TargetType �� Padding J� SnapsToDevicePixels ��Name � ColumnDefinitions � RowDefinitions	    SelectAllCommand
 �� 
ResourceId �� TypeInTargetAssembly7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column ��Name �� CanContentScroll ��Name �� ScrollableHeight � Maximum �� Orientation* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize � Value �� Mode �� ScrollableWidth,  �� %ComputedHorizontalScrollBarVisibility! �� ViewportWidth" �� Triggers# ]� 
Conditions$ �� Property% �� Value  ColumnHeaderGripperStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader % !DataGrid.Column.Header.Background , (DataGrid.Column.Header.Static.Foreground& �� Orientation' F�Name 
 SortUp & "DataGrid.Column.Header.Icon.Static( �� Stretch  SortDown) n�Name* �� Triggers+ P� Property, P� Value- �� 
TargetName 	 Sort.Up.Icon.Active*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow. ��Name?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter/   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter0   DetailsVisibility$1   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation2 	  Vertical#3    RowDetailsScrollingConverter:
  4System.Windows.Controls.Primitives.DataGridRowHeader
4   Row�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     8d2http://schemas.microsoft.com/expression/blend/2008  VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  %�  '         &	 S    '  �    7  7  '  �	    '  
    �� "    .���   �@  AlternatingRowBackground# �   ��  � ��# � ����  � ��$ 0,0,0,1q���  � ��# � ����  � ��# �  ��  �@  GridLinesVisibility$ 
Horizontal=���   �@  HorizontalGridLinesBrush# �  ��  �@  HeadersVisibility$ Column=���   �@  RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� .  ��  �@  SelectionMode$ Single=���  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� "   .R��� #��z��#��z��#��z��# z�� . ._��� $ DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z	 |�.  ��C� *�� $"
 DataGridSelectAllButtonStyle��"   +y��� *HeadersVisibility+# Z # Z  �� "   ���� *CellsPanelHorizontalOffset+ �� "     $! PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z # Z  �� "   �� $! PART_ScrollContentPresenter��# z��$��2��$��1���� $ PART_VerticalScrollBar��$��2��# z $ Vertical=�$��1��#y�z # z  �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� $��* �.+��� $ PART_HorizontalScrollBar��$��1��# z $ 
Horizontal=�#y�z  # z!  �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+.���� # z " ]� # �� $ �@��
IsGrouping% . �� "$ �@%�IsVirtualizingWhenGrouping% .  ./���  � �� .  �� "  n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #��z��# z���� "   .���  � ��# �  ��  � ��# �  ��  � ��$ SemiBold"���  � ��$ 10q���  � ��$ 32����  � ��$	 5,0q���  � ��$ Center=���  � �� �� "  .R�� .+��� #��z��#��z��#��z��# z��._�� #��z�� �� �� $
��Auto �.+��� #��z����. # z #��z���� $��1��$& 
Horizontal=�$��5,0,0,0q�.+�F� $' 
SortUpIcon��#���  #��z��$��10��#���  $( Uniform=�F� $' SortDownIcon��#���  #��z��$��10��#���  $( Uniform=�n� $) PART_LeftHeaderGripper��$
��Left=�8��  n� $) PART_RightHeaderGripper��$��Right=�8�� * P� + �@ SortDirection$, 	AscendingX�. ��� $- SortDownIcon��# � 	  � ��P� + �@ SortDirection$, 
DescendingX�. ��� $- 
SortUpIcon��# � 	  � ���� "   .���  �@�Cursor$
 Hand���� "   .���  �@J�SnapsToDevicePixels . ��  � ��$ 30����  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� 
���  ��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $. 
DGR_Border��#��z��#��z��#��z�� . ._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z/ # z   $��1��$��1��#y�z0 1 �� *AreRowDetailsFrozen+# Z2 # Z3  �� "   
  $��2��$1 Vertical=�y��� *HeadersVisibility+# Z4 # Z  �� "   " P� + �@ 	IsNewItem, . . ���  � �� �� *NewItemMargin+ �� "   