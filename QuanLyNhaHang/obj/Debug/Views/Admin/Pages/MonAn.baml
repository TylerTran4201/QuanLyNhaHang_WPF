   M S B A M L   `   `   `  ����H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:QuanLyNhaHang.Views.Admin.PagesQuanLyNhaHang.Views.Admin.Pages  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      +    %QuanLyNhaHang.Views.Admin.Pages.MonAn   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:QuanLyNhaHang.Views.Admin.Pages     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5         MonAnVM  � DataContext#  �   5
      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5      �   PrimaryBackground#���  6    � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��30 �6   �� 5      .+�5   
   �� $��0��6     Primary#���  6    $��3q�5      $��20q�6'   ��5      �� 5      #���  6   $	��100��5       �� CornerRadius$ 2��5      $��25��5      ._�5      �� $��Center=�6    $��Center=�5       $��
Thông Tin��5       
�������5        5!      .��5#      �  5$      �� 5%      �� 5&      �� 5'       � ColumnDefinitions 5)      �� 5*      �� 5+      �� 5,      �� 5-      .+�5/      � .+�50      �� $��Name:��6    $��20 0 0 0q�6-   �� 51      $
��auto��6   $��25��52      $
��10 0q�53      $��Bottom=�54      ��55      �� *	txtName+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�56      � 57      $��1��6   .+�58      �� $��Giá Xuất:��6    $��20 0 0 0q�61   �� 59      $
��auto��6   $��25��5:      $
��10 0q�5;      $��Bottom=�5<      ��5=      �� *
txtPrice+$ TwoWay=�$	 PropertyChanged=�5>      � 5?      $��2��6   .+�5@      �� $��Giá Nhập:��6    $��20 0 0 0q�61   �� 5A      $
��auto��6   $��25��5B      $
��10 0q�5C      $��Bottom=�5D      ��5E      �� *txtPriceInput+$ TwoWay=�$	 PropertyChanged=�5F      � 5G      $��3��6   .+�5H      �� $��Danh Mục:��6    $��20 0 0 0q�61   �� 5I      $
��auto��6   $��25��5J      $
��10 0q�5K      $��Bottom=�5L      
 �� DisplayMemberPath$

 Name��5M      ��5N      �� *
DanhMucs+ �� SelectedItem 5O      �� *SelectedDanhMuc+5P      � 5Q      $��1��6   .+�5R      �� $��Đơn Vị:��6    $��20 0 0 0q�6/   �� 5S      $
��auto��6   $��25��5T      $
��10 0q�5U      $��Bottom=�5V      $

 Name��5W      ��5X      �� *Units+ 5Y      �� *SelectedUnit+5Z      � 5[      $��1��6   $��1��6'   .+�5\      �� $��Máy In:��6    $��20 0 0 0q�6/   �� 5]      $
��auto��6   $��25��5^      $
��10 0q�5_      $��Bottom=�5`      $

 Name��5a      ��5b      �� *MayIns+ 5c      �� *SelectedMayIn+5d      �� 5e      $��2��6   #���  5f      $��Thêm��5g        ButtonCustom#���  5h      ��5i      �� *
AddCommand+�� 5j      $��2��6   $��1��6&   #���  5k      $��Sửa��5l      #���  5m      ��5n      �� *UpdateCommand+�� 5o      $��2��6   $��3��6&   #���  5p      $��
Làm Mới��5q      #���  5r      ��5s      �� *ClearCommad+5t      5u      � 5v   
   $��1��6   .+�5w      �� $��10 0 0 0q�5x      $	��200��5y      $
��Left=�5z      $

 Name��5}      ��5{      �� *
DanhMucs+ 5|      �� *ComboboxDanhMuc+ 5~        5      $ SelectionChanged��6%   . 5�         60   �� *ComboboxSelectedCommand+5�      5�      �� 5�      $��Center=�5�      $��20(�5�      $��Medium"�5�        	Secundary#���  5�      $��Danh Sách Món Ăn��5�      5�      &   System.Windows.Controls.DataGrid  5�   
   $��2��6      AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�5�         
IsReadOnly .    CanUserResizeColumns .  $��10q�5�       J� 	AllowDrop .  ��5�      �� *Mons+$ TwoWay=�$	 PropertyChanged=� 5�        5�      $ MouseLeftButtonUp��6!   . 5�         6,   �� *SelectedCommand+   CommandParameter 5�   ,   ��  �� Path$ SelectedItem� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ DataGridL�5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 60   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5�   %   �� *Id+  5�      $
 Tên��6%    5�   %   �� *Name+  5�      $ Giá Xuất��6%    5�   %   �� *Price+  5�      $ Giá Nhập��6%    5�   %   �� *
PriceInput+  5�      $ 
Danh Mục��6%    5�   %   �� *DanhMuc.Name+  5�      $ 
Đơn Vị��6%    5�   %   �� *	Unit.Name+  5�      $ Máy In��6%    5�   %   �� *
MayIn.Name+4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      $ Trạng Thái��6)    
  CellTemplate 5�      �� 5�      .R�5�      �� $	��100��6%   #���  5�   %   #���  5�   %   ��5�   %   �� $% DataContext.ChangeStatusCommand� �� "  ��5�   %   �� $ SelectedItem� �� $ FindAncestor=�$ DataGridL���5�   "   �� 5�   &   $��Center=�6,   $��Center=�5�   0   $��10(�5�   0   ��5�   *   �� 5�   .    �� 
TargetType" ��64    �� Triggers 5�   2   �� 5�   6    �� Binding 6B   �� $ Status� �� Value 06b   .a�5�   :   ��   �� Property  � ��! �� Value$! Không hoạt động��6T   �� 5�   :     � ��! �#F5CE3B6W   5�   7   �� 5�   6    6B   �� $ Status� 16b   .a�5�   :   ��   � ��$! hoạt động��6T   �� 5�   :     � ��! �#4CF4F46W   5�   7   5�   /   5�   '   5�      5�      5�        5�      $ Ngày Tạo��6%    5�   %   �� *	CreatedAt+  5�      $ Ngày Sửa��6%    5�   %   �� *
ModifiedAt+
  5�      $	 100 6)    5�      �� 5�      .R�5�      �� $��0q�6%   " � Cursor$
" Hand��5�   %     	RedButton#���  5�   %   ��5�   %   �� *DataContext.DeleteCommand+ �� "  ��5�   %   �� *SelectedItem+ �� "  $ FindAncestor=�.��5�   "   F� 
�������# �� Stretch$
# Fill=�5�   '   $��20��5�   '   $��20��5�   '     icon_delete#���  5�   '   5�      5�      5�      5�      5�      5�      