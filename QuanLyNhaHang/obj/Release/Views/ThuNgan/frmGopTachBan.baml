   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  H DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:QuanLyNhaHang.Views.ThuNganQuanLyNhaHang.Views.ThuNgan /   )QuanLyNhaHang.Views.ThuNgan.frmGopTachBan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     ;local)clr-namespace:QuanLyNhaHang.Views.ThuNgan       � WindowStartupLocation$  CenterScreen=� � Title$ frmGopTachBan��$	��550��$
��1200��   GopTachBanVM � DataContext# �   .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadedCommand+.���  � ColumnDefinitions �� �� $	��150 ��� .+��� $��0��  Primary#���  $��3q�$��5q����� #���  $	��250�� �� CornerRadius$ 2��$��25��._��� $��Center=�$��Center=�$-��'DANH SÁCH BÀN PHỤ ĐANG SỬ DỤNG��
�������$��Medium"�.��� 	 � RowDefinitions	 �� $	��100 ��� $��50 ��� .+�� $��0��$��Center=�.+��� $��16(�$��DS BÀN SỬ DỤNG:��$��Medium"�#���  �� $	��150��$��50 0 0 0q�
 �� DisplayMemberPath$

 Name������ *bans+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *selectedBan1+   $ SelectionChanged��.    �� *!DataContext.BanSelectedChanged1+ �� RelativeSource ��  �� AncestorType" ��   CommandParameter �� *SelectedItem+ �� " �� �� Mode$ FindAncestor=�� $��1��$��Center=�$��Right=�.+��� $��16(�$��Tổng tiền bàn phụ:��$��Medium"�$��	0 0 100 0q�#���  �� $��16(�$��Right=�$�� ��$��Medium"�  	RedButton#���  &   System.Windows.Controls.DataGrid  $��2��   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeColumns .  $��10q� J� 	AllowDrop .  ���� *hoadon1.ChiTietHoaDons+$ TwoWay=�$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mặt hàng��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Mon.Name+  $
 ĐVT�� �� *Mon.Unit.Name+  $ Số lượng��   Width5	  /System.Windows.Controls.DataGridLengthConverter$ 50	  �� *
Quantity+  $ 
Đơn giá�� �� *	Mon.Price+  $ T.Tiền�� �� *	Mon.Price+4
  .System.Windows.Controls.DataGridTemplateColumn
  $	 100	  
  CellTemplate �� .R��� $��0q� � Cursor$
 Hand��$��20��$��20��#���  ���� *DataContext.plusCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
������� �� Stretch$
 Fill=�$��20��$��20��  	icon_Plus#���  
  $ 50	  �� .R��� $��0q�$
 Hand��$��20��$��20��#���  ���� *DataContext.minusCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
�������$
 Fill=�$��20��$��20��  
icon_Minus#���  � $��1��$	��Top=�.+��� $	��120��$��40��$��
Gộp bàn������  �� 
TargetType" ��.���   �� Property  �@�Cursor! �� Value$
! Hand����   � ��$	! 5 2q���   � ��
! �������   � ��#! �  ��   � ��$	! 100����   � ��$! 35����   � ��$! 14(���   � ��$! 0q���   � ��$
! Bold"���   � ��#! �  " �� 	Resources" ��%9   '��       �� " ��.���   �@��CornerRadius$! 5��# �� Triggers# �� $ �� Binding$ �� % �� Path$% hoadon1�& �� Value& Z� .a���   � {�! .  �� $ �� $% hoadon2�& Z� .a���   � {�! .  ��   ThuNgan.ChucNang.Button#���  $	��120��$��40��$��	0 100 0 0q�$��Lưu ���� #���  $	��120��$��40��$��	0 200 0 0q�$��
Làm mới������ *LamMoiCommand+�� $��2��
��� ���$��3q�$��5q����� 
��� ���$	��250��$ 2��$��25��._��� $��Center=�$��Center=�$.��(DANH SÁCH BÀN CHÍNH ĐANG SỬ DỤNG��
�������$��Medium"�.��� 	 �� $	��100 ��� $��50 ��� .+�� $��0��$��Center=�.+��� $��16(�$��DS BÀN SỬ DỤNG:��$��Medium"�#���  �� $	��150��$��50 0 0 0q�$

 Name������ *bans+ �� *selectedBan2+   $ SelectionChanged��.    �� *!DataContext.BanSelectedChanged2+ �� " �� �� *SelectedItem+ �� " ��$ FindAncestor=�� $��1��$��Center=�$��Right=�.+��� $��16(�$ ��Tổng tiền bàn chính:��$��Medium"�$��	0 0 100 0q�
��� ����� $��16(�$��Right=�$�� ��$��Medium"�#���    $��2�� .   .  $ Single=� .  .  $��10q� .  ���� *hoadon2.ChiTietHoaDons+$ TwoWay=�$ PropertyChanged=�   $ Mặt hàng�� �� *
Mon.Name+  $
 ĐVT�� �� *Mon.Unit.Name+  $ Số lượng��$ 50	  �� *
Quantity+  $ 
Đơn giá�� �� *	Mon.Price+  $ T.Tiền�� �� *	Mon.Price+
  $	 100	  �� .R��� $��0q�$
 Hand��$��20��$��20��#���  ���� *DataContext.plusCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
�������$
 Fill=�$��20��$��20��#���  
  $ 50	  �� .R��� $��0q�$
 Hand��$��20��$��20��#���  ���� *DataContext.minusCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
�������$
 Fill=�$��20��$��20��#���  