   M S B A M L   `   `   `  ����H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:QuanLyNhaHang.Views.Admin.PagesQuanLyNhaHang.Views.Admin.Pages  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      )    #QuanLyNhaHang.Views.Admin.Pages.Ban   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:QuanLyNhaHang.Views.Admin.Pages     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5       	  BanVM  � DataContext#  �   5
      .��5      �   PrimaryBackground#���  6    � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��30 �6   �� 5      .+�5   
   �� $��0��6     Primary#���  6    $��3q�5      $��20q�6'   ��5      �� 5      #���  6   $	��100��5       �� CornerRadius$ 2��5      $��25��5      ._�5      �� $��Center=�6    $��Center=�5       $��
Thông Tin��5       
�������5       5      .��5      �  � ColumnDefinitions 5      �� 5       �� 5!      �� 5"       5$      �� 5%      �� 5&      �� 5'      .+�5)      � .+�5*      �� $��
Tên Bàn:��6    $��20 0 0 0q�60   �� 5+      $
��auto��6   $��25��5,      $
��10 0q�5-      $��Bottom=�5.      ��5/      �� *	txtName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�50      � 51      $��1��6   .+�52      �� $��Loại Bàn:��6    $��20 0 0 0q�61   �� 53      $
��auto��6   $��25��54      $
��10 0q�55      $��Bottom=�56       �� DisplayMemberPath$
 Name��57      ��58      �� *
loaiBans+ �� SelectedItem 59      �� *selectedLoaiBan+5:      � 5;      $��2��6   .+�5<      �� $��
Khu Vực:��6    $��20 0 0 0q�60   �� 5=      $
��auto��6   $��25��5>      $
��10 0q�5?      $��Bottom=�5@      $
 Name��5A      ��5B      �� *	khuVucs+ 5C      �� *selectedKhuVuc+5D      � 5E      $��1��6   .+�5F      �� $��Tình Trạng:��6    $��20 0 0 0q�63   �� 5G      $
��auto��6   $��25��5H      $
��10 0q�5I      $��Bottom=�5J      $
 Name��5K      ��5L      �� *
tinhTrangs+ 5M      �� *selectedTinhTrang+5N      �� 5O      $��2��6   #���  5P      $��Thêm��5Q        ButtonCustom#���  5R      ��5S      �� *
AddCommand+�� 5T      $��2��6   $��1��6&   #���  5U      $��Sửa��5V      #���  5W      ��5X      �� *UpdateCommand+�� 5Y      $��2��6   $��2��6&   #���  5Z      $��
Làm Mới��5[      #���  5\      ��5]      �� *ClearCommand+5^      5_      �� 5`   
   $��1��6   $��Center=�5a      $��20(�5b      $��Medium"�5c        	Secundary#���  5d      $��Danh Sách Khu Vực��5e      &   System.Windows.Controls.DataGrid  5f   
   $��2��6      AutoGenerateColumns .  	   CanUserAddRows	 .  
   SelectionMode$
 Single=�5i         
IsReadOnly .    CanUserResizeColumns .  $��10q�5l       J� 	AllowDrop .  ��5n      �� *bans+$ TwoWay=�$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5o      /  )System.Windows.Interactivity.EventTrigger  5p         	EventName$ MouseLeftButtonUp��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5q      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectedCommand+   CommandParameter 5r   ,   ��  �� Path$ SelectedItem� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ DataGridL�5s         Columns 5u      0  *System.Windows.Controls.DataGridTextColumn  5v      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5w   %   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5x   %   �� *Id+  5y      $
 Name��6%    5z   %   �� *Name+  5{      $ Loại Bàn��6%    5|   %   �� *TableType.Name+  5}      $ 	Khu Vực��6%    5~   %   �� *KhuVuc.Name+  5      $ Tình Trạng��6%    5�   %   �� *TinhTrang.Name+4
  .System.Windows.Controls.DataGridTemplateColumn
  5�      $ Trạng Thái��6)    
  CellTemplate 5�      �� 5�      .R�5�      �� $	��100��6%   #���  5�   %   #���  5�   %   ��5�   %   �� $% DataContext.ChangeStatusCommand� �� "  ��5�   %   �� $ SelectedItem� �� $ FindAncestor=�"  ��5�   "   �� 5�   &   $��Center=�6,   $��Center=�5�   0   $��10(�5�   0   ��5�   *   �� 5�   .    �� 
TargetType" ��64    �� Triggers 5�   2   �� 5�   6    �� Binding 6B   �� $ Status� �� Value 06b   .a�5�   :   ��   �� Property  � ��! �� Value$! Không hoạt động��6T   �� 5�   :     � ��! �#F5CE3B6W   5�   7   �� 5�   6    6B   �� $ Status� 16b   .a�5�   :   ��   � ��$! hoạt động��6T   �� 5�   :     � ��! �#4CF4F46W   5�   7   5�   /   5�   '   5�      5�      5�        5�      $ Ngày Tạo��6%    5�   %   �� *	CreatedAt+  5�      $ Ngày Sửa��6%    5�   %   �� *
ModifiedAt+
  5�      $	 100 6)    5�      �� 5�      .R�5�      �� $��0q�6%   " � Cursor$
" Hand��5�   %     	RedButton#���  5�   %   ��5�   %   �� *DataContext.DeleteCommnad+ �� "  ��5�   %   �� *SelectedItem+ �� "  $ FindAncestor=�.��5�   "   F� 
�������# �� Stretch$
# Fill=�5�   '   $��20��5�   '   $��20��5�   '     icon_delete#���  5�   '   5�      5�      5�      5�      5�      5�      