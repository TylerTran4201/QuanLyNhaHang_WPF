   M S B A M L   `   `   `  ����   QuanLyNhaHang8    2QuanLyNhaHang.CustomControl.MenuWithSubMenuControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$
  this��
������� � 	Resources    icon_default  DefaultSubMenuPadding u� Left  MenuTextStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� RelativeSource	 �� Mode
 �� AncestorType �� Value  Primary  MenuButtonStyle �� 
TargetType � ColumnDefinitions �� ElementName �� TargetNullValue �� FallbackValue �� Stretch �� Triggers P� Property P� Value �� Padding 	�Name 	� 	GroupName��%:
  &	        &	 �    &	 �    &	 �    7   7   7  '�� 4    '�� i    7  7  7  B� $����M4,2L4,22 12.683594,22C12.387594,21.378,12.181078,20.707,12.080078,20L12.074219,20C12.026219,19.673 12,19.34 12,19 12,15.474 14.609,12.566078 18,12.080078 18.327,12.033078 18.66,12 19,12 19.34,12 19.673,12.033078 20,12.080078L20,8 14,2 4,2z M13,3.4550781L18.5,9 13,9 13,3.4550781z M19,14C16.25,14 14,16.25 14,19 14,21.75 16.25,24 19,24 21.75,24 24,21.75 24,19 24,16.25 21.75,14 19,14z M19,16C19.461147,16,19.892436,16.114019,20.283203,16.300781L16.300781,20.285156C16.113553,19.893994 16,19.461758 16,19 16,17.346 17.346,16 19,16z M21.699219,17.716797C21.885981,18.107564 22,18.538853 22,19 22,20.654 20.654,22 19,22 18.538242,22 18.106006,21.886447 17.714844,21.699219L21.699219,17.716797zC�u� $ 10Q��� " ��.���  � ��
 �   ���  � ��$ Center=���  � ��$ 15(���  � ��$ CharacterEllipsis=� ��  �� *IsMouseOver+ �� $	 FindAncestor=�$
 ToggleButtonL� True.a���  � ��# �  ��  �� *	IsChecked+ �� $	 FindAncestor=�$
 ToggleButtonL� True.a���  � ��# �  ��  �� *IsMouseOver+ �� $	 FindAncestor=�$
 ListBoxItemL� True.a���  � ��# �  ��  �� *
IsSelected+ �� $	 FindAncestor=�$
 ListBoxItemL� True.a���  � ��# �  �� " d�.���  � ��$ 30����  � ��$ 0q���  � ��
 ���� ��  � |� .  ��  � ��$ Stretch=���  � ��$ Center=���  � �� �� " d�.R��� #��z��#��z��._�� $��5,0,5,0q� �� $
��Auto ��� $��* �.+�� $��30������ " � ��  �� *	HasIcon+$
 this��$ False��$ False��	 False.a���  � y�$ 	Collapsed=�.+�F� $ Uniform=�$��17��$��18��#���  ���� *
PathData+8   8  �� 8�� $��1��#��z�� P�  � ��$ 	Dashboard��. ���  �@d�	IsChecked$
 TrueY��� " ��.���  � ��$ 0q���  � ��
 �������  �@��SelectionMode$ Single=���  � |� .  ��  �@��SelectedIndex$ 0�� ��  �� *	IsChecked+$
 Menu��	 False.a���  � y�$ 	Collapsed=���  �� *SubMenuList+ Z� .a���  � y�$ 	Collapsed=��� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��$ 30����  � �� �� " ��.R���  �� *SubMenuPadding+$
 this��8   8  ._�	� $ SMenuButton��$ SubMenu��8�� ���� *title+$ MenuText��$ MenuText������ *SubMenuCommand+ �� $
 True�� �� *	IsChecked+$ SMenuButton��.a���  �@��
IsSelected . .���� $��Disabled=�$��Disabled=����� *
MenuList+���� .R��� .+�	� $
 Menu��$ MainMenu��#��[ ���� *title+���� *	Command+�� $��Disabled=�$��Disabled=����� *SubMenuList+