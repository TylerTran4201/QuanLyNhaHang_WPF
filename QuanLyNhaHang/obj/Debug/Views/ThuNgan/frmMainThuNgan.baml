   M S B A M L   `   `   `  ����H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLyNhaHang.ViewsQuanLyNhaHang.Views  5   	   =#clr-namespace:QuanLyNhaHang.HelpersQuanLyNhaHang.Helpers  5   	   ?$clr-namespace:QuanLyNhaHang.Views.UCQuanLyNhaHang.Views.UC  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   (    "QuanLyNhaHang.Views.frmMainThuNgan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuanLyNhaHang.Views     5   	   6global#clr-namespace:QuanLyNhaHang.Helpers     5   	   3uc$clr-namespace:QuanLyNhaHang.Views.UC     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
   	   -   5          �Name$  _this��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	      MainThuNganVM � DataContext# [  5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � .+�5      )   #QuanLyNhaHang.Views.UC.ControlBarUC  5      � 5   
   $��1��6    5      �� 5       $��50 �6    �� 5!      $��50 �6    �� 5"      �� 5#      $	��150 �6    .+�5%      � $��0��6     Primary#���  6     5&      �� 5'      �� 5(      .+�5*      �� 
�������$��15(�5+      $��Medium"�5,      $��10,0,0,0q�5-      ��5*      �� *
InfoUser+5-      �� 5.      $��1��6   $��Medium"�50      $��15(�51      $��10,0,0,0q�52      
��� �����5/      �� *InfoCa+53      54      � 55      $��1��6    � ColumnDefinitions 56      �� 57      �� 58      $	��300 �6'   .+�5:      � $��0��6   .+�5;      �� -   5        $��itemArea��5<      
������ $��0q�5=      $��Disabled=�5>      $��Center=�5?      ��5@      �� *	khuVucs+��5A      �� 5B      .R�5C   "   � 5D      ��5F      �� 5G      .R�5H   "   �� $��	btnKhuVuc��5I   !     ThuNgan.KhuVuc.Button#���  5H   )   ��5J   !   ��  �� ElementName$ _this��	 �� Path$%	 DataContext.SelectKhuVucCommand���5K   !   �� $ 	btnKhuVuc����5L   &   �� 5M   *   
 �� Orientation$
 Vertical=�65   .+�5N   .   �� $��15(�5O   0   $��Center=�5P   0   $��Center=�5Q   0   ��5N   8   �� *Name+5Q   0   5R   +   5T   #   5U      5W      5X      � 5Y      $��1��6   .+�5Z      �� $
 
Horizontal=�6!   .+�5[      �� $
 
Horizontal=�6%   .+�5\      �� $��Có khách:��6$   $��Medium"�5]      �� 5^      $��Medium"�5_      ��5^   $   �� *	coKhach+5_      �� 5`      $��/��6$   $��Medium"�5a      �� 5b      $��Medium"�5c      ��5b   $   �� *	tongBan+5c      5d      �� 5e      $
 
Horizontal=�6%   .+�5f      �� $��Bàn trống:��6$   $��Medium"�5g      �� 5h      $��Medium"�5i      ��5h   $   �� *
banTrong+5i      �� 5j      $��/��6$   $��Medium"�5k      �� 5l      $��Medium"�5m      ��5l   $   �� *	tongBan+5m      5n      5o      5p      5q      � 5r      $��2��6   .+�5s      �� -   5        $��	itemTable��5t      
������ $��0q�5u      $��Disabled=�5v      $��Center=�5x      ��5w      �� *bans+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5y      �� 5z      .R�5{      � 5|      ��5~      �� 5      .R�5�      �� $��btnBan��5�   !   $	��180��5�   %   $��80��61    � Cursor$
 Hand��5�   !   $��5q�5�   !   ��5�   !   �� $ _this��$"	 DataContext.SelectBanCommand���5�   !   �� $ btnBan����5�   !   �� $	 TinhTrang.Color���5�   !   �� $	 TinhTrang.BackgroundColor���5�   "   �� 5�   &   $
 Vertical=�61   .+�5�   *   �� $��15(�5�   0   
�������$��Center=�5�   0   $��Center=�5�   0   ��5�   4   �� *Name+5�   0   5�   '   5�      5�      5�      5�      � 5�      $��3��6    5�      �� 5�      �� 5�      $	��500 �6'   .+�5�      �� $��0��6   $	��Top=�6-   $��0 10 0 0q�5�      $
 
Horizontal=�6%   .+�5�      �� $��0��6     ThuNgan.ChucNang.Button#���  5�      $��Chuyển bàn��5�      ��5�      �� *ChuyenBanCommand+�� 5�      $��1��6   #���  5�      $��
Hủy Bàn��5�      ��5�      �� *HuyBanCommand+�� 5�      $��2��6   #���  5�      $��Gộp tách bàn��5�      ��5�      �� *GopTachBanCommand+�� 5�      $��3��6   #���  5�      $	��Chi��5�      ��5�      �� *
ChiCommand+�� 5�      $��4��6   #���  5�      $	��Thu��5�      �� 5�      $��5��6   #���  5�      $��H/Đ gần đây��5�      �� 5�      $��6��6   #���  5�      $��Giao ca��5�      5�      5�      5�      5�      5�      