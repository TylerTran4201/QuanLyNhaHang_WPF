   M S B A M L   `   `   `  ���� H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:QuanLyNhaHang.Views.ThuNganQuanLyNhaHang.Views.ThuNgan  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity Q-clr-namespace:QuanLyNhaHang.Helpers.ConverterQuanLyNhaHang.Helpers.Converter  +    %QuanLyNhaHang.Views.ThuNgan.frmDatBan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:QuanLyNhaHang.Views.ThuNgan     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     C	converter-clr-namespace:QuanLyNhaHang.Helpers.Converter     -     �Name$  _this�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � WindowState$ 	Maximized=�
������ $
��1366��$	��768��   DatBanVM � DataContext# �   .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadedCommand+	   CommandParameter	 �� 
 �� ElementName$
 _this��.��� ���� *screen.Background+ J� Opacity �� *screen.Opacity+.+�� 
������  � RowDefinitions �� $��30 ��� .+��   Primary#���  .+���   ButtonCustom#���  $��20��$��70��  	RedButton#���  $��Thoát��$��12(� � Cursor$
 Hand������ *ExitCommand+���� $
 _this��� $��1�� � ColumnDefinitions �� �� .+��� $��0��
���   �$��0 0 1 0q�._�� 
������� �� $��35 ��� $	��150 ��� $
��auto ��� .+��� 
���   �$��1 1 0 1q�$��0��._��� $��Center=�$��Center=�$��20(�#���  $��Medium"���`�  �� StringFormat$ 
 {0} - {1}��.1���  �� Path$ ban.KhuVuc.Name��� $ ban.Name�� $��1�� �� �� �� �� .+�� $��0��$��Center=�.+��� $��Tổng Tiền:��$��5 0 0 0q��� $	��200��$
��Left=�$��80 0 0 0q����� *
tongTien+� $��1��$��Center=�.+��� $��Giảm % (tiền):��$��5 0 0 0q��� $	��200��$
��Left=�$��80 0 0 0q�� $��2��$��Center=�.+��� $��Giảm Trừ:��$��5 0 0 0q��� $	��200��$
��Left=�$��80 0 0 0q�� $��3��$��Center=�.+��� $��Thành Tiền:��$��5 0 0 0q��� $	��200��$
��Left=�$��80 0 0 0q�� $��2�� �� $��20 ��� .+��� $��0�� �� CornerRadius$ 5 5 0 0��#���  ._��� $)��#DANH SÁCH MẶT HÀNG TẠM THỜI��
�������$��Center=�� $��1�� �� �� $	��100 �.+�&   System.Windows.Controls.DataGrid  $��0��   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeColumns .  $��10q� J� 	AllowDrop .  ���� *hoaDonTemp.ChiTietHoaDons+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $ Mặt hàng�� �� *
Mon.Name+  $
 ĐVT�� �� *Mon.Unit.Name+  $ Số lượng�� �� *
Quantity+  $ 
Đơn giá�� �� *	Mon.Price+  $ Thành tiền�� `�  `� ConverterParameter$	 x*y�� `� 	Converter 3
   -QuanLyNhaHang.Helpers.Converter.MathConverter
  .1��� $ 	Mon.Price��� $ Quantity�4  .System.Windows.Controls.DataGridTemplateColumn  $	 100     CellTemplate  �� .R��� $��0q�$
 Hand��$��20��$��20��#���  ���� *DataContext.plusCommand+! �� RelativeSource! �� " �� AncestorType""  ���� *SelectedItem+! �� ""  # �� Mode$# FindAncestor=�.��F� 
�������$ �� Stretch$
$ Fill=�$��20��$��20��  	icon_Plus#���    $	 100   �� .R��� $��0q�$
 Hand��$��20��$��20��#���  ���� *DataContext.minusCommand+! �� ""  ���� *SelectedItem+! �� ""  $# FindAncestor=�.��F� 
�������$
$ Fill=�$��20��$��20��  
icon_Minus#���  �� $��1��$��30��$��Lưu dữ liệu��$
��auto��$��Medium"����� *saveCommand+���� % �� 
TargetType"% ��& �� Triggers& �� ' �� Binding' �� $% hoaDonTemp.ChiTietHoaDons.Count�( �� Value( 0.a��� ) �� Property) � {�* �� Value* .  � $��3�� �� $��20 ��� .+��� $��0��$ 5 5 0 0��#���  $��2��._��� $)��#DANH SÁCH MẶT HÀNG TẠM THỜI��
�������$��Center=�  $��1�� .   .  $ Single=� .  .  $��10q� .  ���� *hoaDon.ChiTietHoaDons+$ TwoWay=�$ PropertyChanged=�   $ Mặt hàng�� �� *
Mon.Name+  $
 ĐVT�� �� *Mon.Unit.Name+  $ Số lượng�� �� *
Quantity+  $ 
Đơn giá�� �� *	Mon.Price+  $ Thành tiền�� `� $	 x*y�� 
  .1��� $ 	Mon.Price��� $ Quantity�  $ Hình Thức��  $ Ghi Chú��  $	 100   �� .R��� $��0q�$
 Hand��#���  ���� *DataContext.DeleteMonCommand+! �� ""  ���� *SelectedItem+! �� ""  $# FindAncestor=�.��F� 
�������$
$ Fill=�$��20��$��20��  icon_delete#���  � $��1��
������� �� $	��100 ��� $	��150 ��� .+�� $��0�� �� �� $	��100 �.+�� $��0�� �� $��35 ��� .+��  �� �� �� �� $	��260 �.+��� -     ThuNgan.ChucNang.Button#���  $��25��$��90��$��Center=�$��Medium"�$��Tặng���� -   $��1��#���  $��25��$��90��$��Center=�$��Medium"�$��In bếp - bar���� -   $��2��#���  $��25��$��90��$��Center=�$��Medium"�$��In Tạm Tính���� $��1��$ 	0 10 10 0��
���   �$��0 1 1 1q�._��  �� ��  �� �� .+�� .+��� $
��Left=�$��Center=�$��Ngày: ��$
��Bold"��� $
��Left=�$��50 0 0 0q�$��Center=�$
��Bold"����� *hoaDon.Ngay+� $��1��.+��� $
��Left=�$��Center=�$��	Mã HĐ: ��$
��Bold"��� $
��Left=�$��	100 0 0 0q�$��Center=�$
��Bold"����� *	hoaDon.Id+� $��1��.+��� $
��Left=�$��Center=�$��Phụ Thu: ��#���  $
��Bold"��� $
��Left=�$��Center=�$��16��$	��100��$��60 0 0 0q�� $��1��$��1��.+��� $
��Left=�$��Center=�$��Ghi chú phụ thu: ��$
��Bold"��� $
��Left=�$��Center=�$��16��$	��100��$��	100 0 0 0q�� $��1��.+��� #���  $
��auto��$
��auto��$��5q�$��Thanh Toán��
��� ����� $��1��$��1q�
���   �._��� 
������ $��0q�$��Disabled=�$��Center=����� *
danhMucs+$ TwoWay=�$ PropertyChanged=����� .R�� ���� .R��� $��
btnDanhMuc��$	��100��$��40��$
 Hand��$��5q�#���  ���� $
 _this��$# DataContext.btnDanhMucCommand����� $
 
btnDanhMuc������ + �� Orientation$+ Vertical=�.+��� $��15(�
�������$��Center=�$��Center=����� *Name+� $��2�� �� $��20 ��� .+�� $��0��.+��� $
��Left=�$��Center=�#���  $D��>Nhấp đôi chuột để sử dụng sử dụng mặt hàng���� $��Right=�$��Center=�#���  $)��#Bạn Đang Chọn: Mì Cay Cấp 7���� $��1��
���   �$��1q�._��� 
������ $��0q�$��Disabled=�$��Center=����� *selectedDanhMuc.Mons+$ TwoWay=�$ PropertyChanged=����� .R�� ���� .R��� $��btnMon��$	��180��$��80��$
 Hand��$��5q�#���  ���� $
 _this��$$ DataContext.selectedMonCommand����� $
 btnMon������ $+ Vertical=�.+��� $��15(�
�������$��Center=�$��Center=����� *Name+