   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5   R   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
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
4   Row�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      VThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  6R   %�  '         &	 }	    '  �
    7  7  '  
    '  [    �� 5      "    6   .�5   
   ��   �@  AlternatingRowBackground# �   65   �� 5   
    � ��# � ��6'   �� 5   
    � ��$ 0,0,0,1q�6,   �� 5   
    � ��# � ��6'   �� 5	   
    � ��# �  6(   �� 5
   
    �@  GridLinesVisibility$ 
Horizontal=�60   �� 5   
     �@  HorizontalGridLinesBrush# �  65   �� 5   
    �@  HeadersVisibility$ Column=�6.   �� 5   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5   
    � �� .  6:   �� 5   
    �@  SelectionMode$ Single=�6*   �� 5   
    �@��PanningMode$
 Both=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� #��z��6   #��z��6I   #��z��6}   # z��6�    . ._�5      �� $ DG_ScrollViewer��6'   |�.  ��5      �� 5   "   " ��62   .R�5   &   �  5   *   �� 5   .   $
��Auto �6?   �� 5   .   $��* �6?   �� 5   .   $
��Auto �6?    5   *   �� 5    .   $
��Auto �6<   �� 5!   .   $��* �6<   �� 5"   .   $
��Auto �6<   .+�5$   *   �� #��Z	 61   |�.  ��6r   C� *�� $"
 DataGridSelectAllButtonStyle��"   +y�6�   �� *HeadersVisibility+# Z # Z  �� "   ��6�  �� *CellsPanelHorizontalOffset+ �� "     5%   *   $! PART_ColumnHeadersPresenter��6I   $��1��6n   y�6~   �� *HeadersVisibility+# Z # Z  �� "   �� 5&   *   $! PART_ScrollContentPresenter��6A   # z��6f   $��2��6�   $��1��6�   �� 5'   *   $ PART_VerticalScrollBar��64   $��2��6T   # z 6d   $ Vertical=�6�   $��1��6�   #y�z 6�   # z 6W   6�   �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+6W  � 5(   *   $��1��6/   $��2��6?    5)   .   �� 5*   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 5+   2   $��* �6C   .+�5-   .   �� $ PART_HorizontalScrollBar��68   $��1��6Z   # z 6j   $ 
Horizontal=�6�   #y�z  6�   # z! 6U   6�   �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+6U  5.   +   5/   '   50   #   .��52      �� # z 6-   53      54      55      57      " 58   
   ]� 59      # 5:      �� 5;      $ �@��
IsGrouping% . 66   �� 5<      "$ �@%�IsVirtualizingWhenGrouping% .  6X   ./�5>      ��  � �� .  6B   5?      5A      �� 5B      "  n�6-   .�5C   
   ��  � ��$ 8��6"   �� 5D   
    � ��
 ���� 6'   �� 5E   
    �@�Cursor$ SizeWE��6#   �� 5F   
    � �� 5G      �� 5H      " n�6"   .R�5I      �� #��z��6   # z��6G   5J      5L      5M      �� 5N      "   6   .�5O   
   ��  � ��# �  6'   �� 5P   
    � ��# �  6'   �� 5Q   
    � ��$ SemiBold"�6'   �� 5R   
    � ��$ 10q�6$   �� 5S   
    � ��$ 32��6#   �� 5T   
    � ��$	 5,0q�6$   �� 5U   
    � ��$ Center=�65   �� 5V   
    � �� 5W      �� 5X      "  6"   .R�5Y      � .+�5Z      �� #��z��6!   #��z��5[   !   #��z��5\   !   # z��5]   !   ._�5^      � #��z��6#    5_   "   �� 5`   &   �� 5a   &   $
��Auto �67   .+�5c   "   �� #��z��63   ��. # z 6�   #��z��6�   �� 5d   "   $��1��6-   $& 
Horizontal=�5e   -   $��5,0,0,0q�5f   -   .+�5g   &   F� $' 
SortUpIcon��6+   #���  5h   +   #��z��5i   +   $��10��5j   +   #���  5k   +   $( Uniform=�5l   +   F� 5m   &   $' SortDownIcon��6+   #���  5n   +   #��z��5o   +   $��10��5p   +   #���  5q   +   $( Uniform=�5r   +   5s   #   5t      5u      n� 5v      $) PART_LeftHeaderGripper��6    $
��Left=�6@   8��  6[   n� 5w      $) PART_RightHeaderGripper��6    $��Right=�6A   8�� 6]   5x      * 5y      P� 5z      + �@ SortDirection$, 	AscendingX�6;   . �5{      �� $- SortDownIcon��6%   # � 	 5}   %    � ��5~      P� 5      + �@ SortDirection$, 
DescendingX�6;   . �5�      �� $- 
SortUpIcon��6%   # � 	 5�   %    � ��5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  �@�Cursor$
 Hand��6#   5�      �� 5�      "   6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ 30��6&   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      �� 
���  ��$��2,0,0,0q�61   $��!��6B   $��Center=�6K   5�      5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $. 
DGR_Border��6   #��z��61   #��z��6]   #��z��6�    . ._�5�         5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�        $��1��65   #��z/ 6E   # z 6o     5�      $��1��67   $��1��6G   #y�z0 6k  1 6T   �� *AreRowDetailsFrozen+# Z2 # Z3  �� "   6k  
  5�      $��2��60   $1 Vertical=�6A   y�6�   �� *HeadersVisibility+# Z4 # Z  �� "   5�      5�      5�      5�      " 5�   
   P� 5�      + �@ 	IsNewItem, . . �5�      ��  � �� 6+   �� *NewItemMargin+ �� "   5�      5�      5�      