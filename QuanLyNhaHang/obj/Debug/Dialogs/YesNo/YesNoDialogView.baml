   M S B A M L   `   `   `  ����H  DQuanLyNhaHang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:QuanLyNhaHang.Dialogs.YesNoQuanLyNhaHang.Dialogs.YesNo  5      1    +QuanLyNhaHang.Dialogs.YesNo.YesNoDialogView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:QuanLyNhaHang.Dialogs.YesNo     5      $	��128��5      $	��300��6   .��5	      �   � RowDefinitions  5
   
   �� 5      $��80 �6   �� 5      .+�5   
   �� $��0��6   .+�5      �� 
�������$��Center=�5      $��Center=�65   $��16(�6P   ��5      �� *	Message+5   P   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $	��Yes��6   $��0��5      $��0q�6%   $��0q�5         	RedButton#���   5      
������� � Cursor$
 Hand��5      ��5   #   �� *
YesCommand+��5      ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL��� 5       $��No��6   $��1��5!      $��0q�6%   $��0q�5"      
�������$
 Hand��5$      ��5    "   �� *	NoCommand+��5%      ��  �� $ FindAncestor=�$ WindowL�5'      5(      5)      