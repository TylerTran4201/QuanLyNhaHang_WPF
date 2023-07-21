﻿using QuanLyNhaHang.ViewModels;
using QuanLyNhaHang.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyNhaHang {
    class SideMenuViewModel {
        //to call resource dictionary in our code behind
        ResourceDictionary dict = Application.LoadComponent(new Uri("/QuanLyNhaHang;component/Assets/IconDictionary.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;

        //Our Source List for Menu Items
        public List<MenuItemsData> MenuList {
            get {
                return new List<MenuItemsData>
                {
                    //MainMenu without SubMenu Button 
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_dashboard"], MenuText="Dashboard",title="Dashboard", SubMenuList=null},
                 
                    //MainMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_users"], MenuText="MainQuanLy",title="Quản Lý"
                    
                    //SubMenu Button
                    , SubMenuList=new List<SubMenuItemsData>{
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_adduser"], SubMenuText="TaiKhoan",title="Tài Khoản" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="VaiTroTaiKhoan",title="Vai Trò Tài Khoản" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="VaiTro",title="Vai Trò" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="MonAn",title="Món Ăn" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="DanhMucMonAn",title="Danh Mục Món Ăn" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="KhuVuc",title="Khu Vực" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="LoaiBan",title="Loại Bàn" },
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_alluser"], SubMenuText="Ban",title="Bàn Ăn" }}
                    },

                    //MainMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_mails"], MenuText="Mails",title="Chưa Phát Triển"

                    //SubMenu Button
                    , SubMenuList=new List<SubMenuItemsData>{
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_inbox"], SubMenuText="Inbox" ,title="Chưa Phát Triển"},
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_outbox"], SubMenuText="Outbox" , title="Chưa Phát Triển"},
                    new SubMenuItemsData(){ PathData=(PathGeometry)dict["icon_sentmail"], SubMenuText="Sent" , title="Chưa Phát Triển"}}},

                    //MainMenu without SubMenu Button
                    new MenuItemsData(){ PathData= (PathGeometry)dict["icon_settings"], MenuText="Settings", title="Chưa Phát Triển", SubMenuList=null}
                };
            }
        }
    }

    public class MenuItemsData : BaseViewModel {
        //Icon Data
        public PathGeometry PathData { get; set; }
        public string MenuText { get; set; }
        public string title { get; set; }
        public List<SubMenuItemsData> SubMenuList { get; set; }

        //To Add click event to our Buttons we will use ICommand here to switch pages when specific button is clicked
        public MenuItemsData() {
            Command = new CommandViewModel(Execute);
        }

        public ICommand Command { get; }

        private void Execute() {
            //our logic comes here
            string MT = MenuText.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(MT))
                navigateToPage(MT);
        }

        private void navigateToPage(string Menu) {
            //We will search for our Main Window in open windows and then will access the frame inside it to set the navigation to desired page..
            //lets see how... ;)
            foreach (Window window in Application.Current.Windows) {
                if (window.GetType() == typeof(frmMainAdmin)) {
                    (window as frmMainAdmin).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Admin/Pages/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
    public class SubMenuItemsData {
        public PathGeometry PathData { get; set; }
        public string SubMenuText { get; set; }
        public string title { get; set; }

        //To Add click event to our Buttons we will use ICommand here to switch pages when specific button is clicked
        public SubMenuItemsData() {
            SubMenuCommand = new CommandViewModel(Execute);
        }

        public ICommand SubMenuCommand { get; }

        private void Execute() {
            //our logic comes here
            string SMT = SubMenuText.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(SMT))
                navigateToPage(SMT);
        }

        private void navigateToPage(string Menu) {
            //We will search for our Main Window in open windows and then will access the frame inside it to set the navigation to desired page..
            //lets see how... ;)
            foreach (Window window in Application.Current.Windows) {
                if (window.GetType() == typeof(frmMainAdmin)) {
                    (window as frmMainAdmin).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Admin/Pages/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}
