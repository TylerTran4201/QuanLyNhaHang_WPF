   M S B A M L   `   `   `  ���� H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:QuanLyNhaHang.Views.Admin.PagesQuanLyNhaHang.Views.Admin.Pages  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity +    %QuanLyNhaHang.Views.Admin.Pages.MonAn   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?local-clr-namespace:QuanLyNhaHang.Views.Admin.Pages     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity        MonAnVM  � DataContext#  �   .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���   PrimaryBackground#���   � RowDefinitions �� $	��200 ��� $��30 ��� .+��� $��0��  Primary#���  $��3q�$��20q����� #���  $	��100�� �� CornerRadius$ 2��$��25��._��� $��Center=�$��Center=�$��
Thông Tin��
�������.���  �� �� ��  � ColumnDefinitions �� �� �� �� .+�� .+��� $��Name:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *	txtName+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�� $��1��.+��� $��Giá Xuất:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *
txtPrice+$ TwoWay=�$	 PropertyChanged=�� $��2��.+��� $��Giá Nhập:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *txtPriceInput+$ TwoWay=�$	 PropertyChanged=�� $��3��.+��� $��Danh Mục:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=�
 �� DisplayMemberPath$

 Name������ *
DanhMucs+ �� SelectedItem �� *SelectedDanhMuc+� $��1��.+��� $��Đơn Vị:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=�$

 Name������ *Units+ �� *SelectedUnit+� $��1��$��1��.+��� $��Máy In:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=�$

 Name������ *MayIns+ �� *SelectedMayIn+�� $��2��#���  $��Thêm��  ButtonCustom#���  ���� *
AddCommand+�� $��2��$��1��#���  $��Sửa��#���  ���� *UpdateCommand+�� $��2��$��3��#���  $��
Làm Mới��#���  ���� *ClearCommad+� $��1��.+��� $��10 0 0 0q�$	��200��$
��Left=�$

 Name������ *
DanhMucs+ �� *ComboboxDanhMuc+   $ SelectionChanged��.    �� *ComboboxSelectedCommand+�� $��Center=�$��20(�$��Medium"�  	Secundary#���  $��Danh Sách Món Ăn��&   System.Windows.Controls.DataGrid  $��2��   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeColumns .  $��10q� J� 	AllowDrop .  ���� *Mons+$ TwoWay=�$	 PropertyChanged=�   $ MouseLeftButtonUp��.    �� *SelectedCommand+   CommandParameter ��  �� Path$ SelectedItem� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ DataGridL�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $
 Tên�� �� *Name+  $ Giá Xuất�� �� *Price+  $ Giá Nhập�� �� *
PriceInput+  $ 
Danh Mục�� �� *DanhMuc.Name+  $ 
Đơn Vị�� �� *	Unit.Name+  $ Máy In�� �� *
MayIn.Name+4
  .System.Windows.Controls.DataGridTemplateColumn
  $ Trạng Thái�� 
  CellTemplate �� .R��� $	��100��#���  #���  ���� $% DataContext.ChangeStatusCommand� �� "  ���� $ SelectedItem� �� $ FindAncestor=�$ DataGridL����� $��Center=�$��Center=�$��10(�����  �� 
TargetType" �� �� Triggers ��  �� Binding �� $ Status� �� Value 0.a���   �� Property  � ��! �� Value$! Không hoạt động����   � ��! �#F5CE3B��  �� $ Status� 1.a���   � ��$! hoạt động����   � ��! �#4CF4F4  $ Ngày Tạo�� �� *	CreatedAt+  $ Ngày Sửa�� �� *
ModifiedAt+
  $	 100  �� .R��� $��0q�" � Cursor$
" Hand��  	RedButton#���  ���� *DataContext.DeleteCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
�������# �� Stretch$
# Fill=�$��20��$��20��  icon_delete#���  