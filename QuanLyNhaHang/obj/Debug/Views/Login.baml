   M S B A M L   `   `   `  ����H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLyNhaHang.ViewsQuanLyNhaHang.Views  5   	   ?$clr-namespace:QuanLyNhaHang.Views.UCQuanLyNhaHang.Views.UC  5   	   9!clr-namespace:QuanLyNhaHang.StyleQuanLyNhaHang.Style  5   	       QuanLyNhaHang.Views.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:QuanLyNhaHang.Views     5   	   3uc$clr-namespace:QuanLyNhaHang.Views.UC     5   	   ;CustomControl!clr-namespace:QuanLyNhaHang.Style     5   	   -   5          �Name$  Window��5	   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � Title$ Login��5   	   $	��500��6   $	��700��6$    � 
ResizeMode$ NoResize=�5   	      LoginVM � DataContext# [  5   	    J� InputBindings 5      �� 5   
   
 �� Key$ Return��6    �� Command 5      �� *LoginCommand+	 �� CommandParameter	 5      �� 
 �� ElementName$
 Window��.��5      � ��6   �� *screen.Background+ J� Opacity 5      �� *screen.Opacity+ � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � .+�5      )   #QuanLyNhaHang.Views.UC.ControlBarUC  5      � 5   
   
�������$��1��5        5!      �� 5"      $��40 �6    �� 5#      .+�5&      �� $
��35,0q�6   $��0��5'      $��29(�5(      $
��Left=�5)      $	��Top=�5*      �� 5+      $�
Quản Lý��6    �� 5,      $
��Bold"�6   $�
Nhà Hàng��5-      5.      � 5/      $��1��6   $	��400��50      $��Center=�51      $��Center=�52       53      �� 54      $	��100 �6$   �� 56      $	��100 �6$   �� 58      $	��100 �6$   �� 5:      �� 5<      .+�5?      �� $��Center=�6   $��30(�5@      ���	#FF01A3ff$
��Bold"�5B      $��Login��5C      0   *QuanLyNhaHang.Style.TextBoxWithPlaceHolder  5D      $��1��67      PlaceHolder$ UserName��5E   3      Text 5F   3   �� *
username+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  5G      $��2��67   $ Password��5H   3      
IsPassword .  5J   3   �� *
password+$ TwoWay=�$ PropertyChanged=��� 5K      $��3��6     ButtonCustom#���  6&   $��60��5L      $��Right=�5M      ���	#FF01A3ff
�������$��Login��5P      ��5Q      �� *LoginCommand+��5R      �� $
 Window��5S      5T      5U      5V      