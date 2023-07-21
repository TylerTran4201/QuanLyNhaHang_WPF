using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class MainThuNganViewModel : BaseViewModel {
        #region Current User
        public string InfoUser { get; set; }
        public string InfoCa { get; set; }
        #endregion

        #region commands
        public ICommand SelectBanCommand { get; set; }
        public ICommand SelectKhuVucCommand { get; set; }
        public ICommand ConnectServerCommand { get; set; }
        public ICommand ChuyenBanCommand { get; set; }
        public ICommand HuyBanCommand { get; set; }
        public ICommand GopTachBanCommand { get; set; }
        public ICommand ChiCommand { get; set; }
        #endregion
        private int _coKhach { get; set; }
        private int _tongBan { get; set; }
        private int _banTrong { get; set; }
        private ObservableCollection<Models.Ban> _bans { get; set; }
        private Models.KhuVuc _SelectedKhuVuc { get; set; }
        public int coKhach { get { return _coKhach; } set { _coKhach = value; OnPropertyChanged(nameof(coKhach)); } }
        public int tongBan { get { return _tongBan; } set { _tongBan = value; OnPropertyChanged(nameof(tongBan)); } }
        public int banTrong { get { return _banTrong; } set { _banTrong = value; OnPropertyChanged(nameof(banTrong)); } }
        public static ObservableCollection<Models.Ban> bansTemp { get; set; }
        public ObservableCollection<Models.KhuVuc> khuVucs { get; set; }
        public Models.KhuVuc SelectedKhuVuc { get { return _SelectedKhuVuc; } set { _SelectedKhuVuc = value; OnPropertyChanged(nameof(SelectedKhuVuc)); } }
        public ObservableCollection<Models.Ban> bans {
            get { return _bans; }
            set {
                _bans = value;
                OnPropertyChanged(nameof(bans));
            }
        }

        private bool _btnIsEnabled { get; set; }
        public bool btnIsEnabled { get { return _btnIsEnabled; } set { _btnIsEnabled = value; OnPropertyChanged(nameof(btnIsEnabled)); } }
        MultiClient.Client client { get; set; }
        public MainThuNganViewModel() {
            //Khai báo trạng thái bàn
            coKhach = (from i in Models.DataProvider.Ins.DB.Bans
                       where i.IdTinhTrang == 1 && i.Status == 1
                       select i).Count();
            tongBan = (from i in Models.DataProvider.Ins.DB.Bans
                       where i.Status == 1
                       select i).Count();
            banTrong = (from i in Models.DataProvider.Ins.DB.Bans
                       where i.IdTinhTrang == 0 && i.Status == 1
                       select i).Count();

            // Khai Báo current user
            InfoUser = GlobalVariable.User.UserName + "-" + GlobalVariable.User.Name;
            InfoCa = GlobalVariable.Ca.Name;


            ConnectServerCommand = new RelayCommand<object>((p) => true, (p) => {// kết nối đến server
                client = new MultiClient.Client();
                client.Connected();
                btnIsEnabled = false;
            });

            var list = Models.DataProvider.Ins.DB.KhuVucs.Select(d => d).ToList();
            khuVucs = new ObservableCollection<Models.KhuVuc>(list);
            btnIsEnabled = true;


            SelectKhuVucCommand = new RelayCommand<Button>((p) => true, (p) =>// Chọn khu vực 
            {
                var item = p.DataContext as Models.KhuVuc;
                bans = new ObservableCollection<Models.Ban>(item.Bans);
                SelectedKhuVuc = item;
            });

            SelectBanCommand = new RelayCommand<Button>((p) => true, (p) => {// chọn bàn
                var item = p.DataContext as Models.Ban;

                ViewModels.DatBanViewModel.ban = item;
                Views.ThuNgan.frmDatBan screen = new Views.ThuNgan.frmDatBan();
                screen.ShowDialog();
                bans = new ObservableCollection<Models.Ban>(SelectedKhuVuc.Bans);
            });
            ChuyenBanCommand = new RelayCommand<object>((p) => true, (p) => {
                var screen = new Views.ThuNgan.frmChuyenBan();
                screen.Show();
            });
            HuyBanCommand = new RelayCommand<object>((p) => true, (p) => {
                var screen = new Views.ThuNgan.frmHuyBan();
                screen.Show();
            });
            GopTachBanCommand = new RelayCommand<object>((p) => true, (p) => {
                var screen = new Views.ThuNgan.frmGopTachBan();
                screen.Show();
                bans = new ObservableCollection<Models.Ban>(SelectedKhuVuc.Bans);
            });
            ChiCommand = new RelayCommand<object>((p) => true, (p) => {
                var screen = new Views.ThuNgan.frmChi();
                screen.ShowDialog();
            });
        }

    }
}