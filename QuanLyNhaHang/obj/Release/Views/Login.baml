   M S B A M L   `   `   `  ���� H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLyNhaHang.ViewsQuanLyNhaHang.Views  9!clr-namespace:QuanLyNhaHang.StyleQuanLyNhaHang.Style      QuanLyNhaHang.Views.Login   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:QuanLyNhaHang.Views     ;CustomControl!clr-namespace:QuanLyNhaHang.Style     -     �Name$  Window�� � WindowStartupLocation$ CenterScreen=� � Title$ Login��$	��500��$	��700��   LoginVM � DataContext# [   J� InputBindings �� 
 �� Key$ Return�� �� Command �� *LoginCommand+ �� CommandParameter ��  �� ElementName$ Window��.��� ���� *screen.Background+	 J� Opacity	 �� *screen.Opacity+.+�� 
�������
 � RowDefinitions
 �� $��40 ��� .+��� $
��35,0q�$��0��$��29(�$
��Left=�$	��Top=��� $�
Quản Lý�� �� $
��Bold"�$�
Nhà Hàng��� $��1��$	��400��$��Center=�$��Center=�
 �� $	��100 ��� $	��100 ��� $	��100 ��� �� .+��� $��Center=�$��30(����	#FF01A3ff$
��Bold"�$��Login��0   *QuanLyNhaHang.Style.TextBoxWithPlaceHolder  $��1��   PlaceHolder$ UserName��   Text �� *
username+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  $��2��$ Password��   
IsPassword .  �� *
password+$ TwoWay=�$ PropertyChanged=��� $��3��  ButtonCustom#���  $��60��$��Right=����	#FF01A3ff
�������$��Login������ *LoginCommand+���� $ Window��