   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  QuanLyNhaHang   QuanLyNhaHang.TaiKhoan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2        
TaiKhoanVM  � DataContext#  [  .���   PrimaryBackground#���   � RowDefinitions �� $	��200 ��� $��30 ��� .+��� $��0��  Primary#���  $��3q�$��20q����� #���  $	��100�� �� CornerRadius$ 2��$��25��._��� $��Center=�$��Center=�$��Nhập Thông Tin��.���  �� �� ��  � ColumnDefinitions �� �� �� �� �� .+�� $��0��.+��� $��Name:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *	txtName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� $��1��.+��� $��	UserName:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *txtUserName+$ TwoWay=�$ PropertyChanged=�� $��2��.+��� $��	Password:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *txtPassword+$ TwoWay=�$ PropertyChanged=�� $��3��.+��� $��CMND:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *	txtCMND+$ TwoWay=�$ PropertyChanged=�� $��4��.+��� $��Phone:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *
txtPhone+$ TwoWay=�$ PropertyChanged=�� $��1��$��0��.+��� $��Email:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *
txtEmail+$ TwoWay=�$ PropertyChanged=�� $��1��$��1��.+��� $��Adress:��$��20 0 0 0q��� $
��auto��$��25��$
��10 0q�$��Bottom=����� *
txtAddress+$ TwoWay=�$ PropertyChanged=��� $��2��$��0��$	��200��$��28��$��Thêm��  ButtonCustom#���    	Secundary#���  ���� *
AddCommand+�� $��2��$��1��$	��200��$��28��$��Sửa��#���  #���  ���� *UpdateCommand+�� $��2��$��2��$	��200��$��28��$��
Làm Mới��#���  #���  ���� *ClearCommand+�� $��1��$��Center=�$��20(�$��Medium"�#���  $��Danh Sách Tài Khoản��&   System.Windows.Controls.DataGrid  $��2��   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�	   
IsReadOnly	 . 
   CanUserResizeColumns
 .  $��10q� J� 	AllowDrop .  ���� *users+$ TwoWay=�$ PropertyChanged=� � 	Resources  �� 
TargetType �� 	Resources �� Property �� Value��%o   '��       �� " �� ���� '��       " ��.���  �@��CornerRadius$ 2��.���  � ��$ 50��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *SelectedItemCommand+   CommandParameter �� *SelectedItem+ �� RelativeSource ��  �� AncestorType"   �� Mode$ FindAncestor=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *Id+  $
 Name�� . $
 auto  �� *Name+  $ Username�� . $
 auto  �� *
UserName+  $ Password�� . $
 auto  �� *
Password+  $
 CMND�� . $
 auto  �� *CMND+  $
 SĐT�� . $
 auto  �� *Phone+  $ Email�� . $
 auto  �� *Email+  $ Địa Chỉ�� . $
 auto  �� *	Address+  $ Ngày Tạo�� . $
 auto  �� *	CreatedAt+  $ Ngày Chỉnh Sửa�� . $
 auto  �� *
ModifiedAt+4
  .System.Windows.Controls.DataGridTemplateColumn
   
  CellTemplate �� .R���  ��Name$ btnChangeStatus��$	��100��#���  ���� *!DataContext.ChangeStatusCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.���� $��Center=�$��Center=�$��10(����� " ��  �� Triggers  �� ! �� Binding! �� *Status+" �� Value" 0.a���  � ��$ Không hoạt động����  � �� �#F5CE3B�� ! �� *Status+" 1.a���  � ��$ hoạt động����  � �� �#4CF4F4
  $	 100  �� .R��� $��0q�# � Cursor$
# Hand��  	RedButton#���  ���� *DataContext.DeleteCommand+ �� "  ���� *SelectedItem+ �� "  $ FindAncestor=�.��F� 
�������$ �� Stretch$
$ Fill=�$��20��$��20��  icon_delete#���  