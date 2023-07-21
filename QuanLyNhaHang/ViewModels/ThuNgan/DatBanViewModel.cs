using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class DatBanViewModel : BaseViewModel {
        #region Background
        private Helpers.BlurBackground _screen;
        public Helpers.BlurBackground screen { get { return _screen; } set { _screen = value; OnPropertyChanged(nameof(screen)); } }
        #endregion
        #region Command
        public ICommand btnDanhMucCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand selectedMonCommand { get; set; }
        public ICommand plusCommand { get; set; }
        public ICommand minusCommand { get; set; }
        public ICommand saveCommand { get; set; }
        public ICommand DeleteMonCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ThanhToanCommand { get; set; }
        #endregion
        #region Init Bidding
        private Models.HoaDon _hoaDonTemp;
        public Models.HoaDon hoaDonTemp { get { return _hoaDonTemp; } set { _hoaDonTemp = value; OnPropertyChanged(nameof(hoaDonTemp)); } }

        public Models.HoaDon _hoaDon;
        public Models.HoaDon hoaDon { get { return _hoaDon; } set { _hoaDon = value; OnPropertyChanged(nameof(hoaDon)); } }

        private double _tongTien;
        public double tongTien { get { return _tongTien; } set { _tongTien = value; OnPropertyChanged(nameof(tongTien)); } }
        public double thanhTien { get; set; }

        #endregion
        public ObservableCollection<Models.DanhMuc> danhMucs { get; set; }
        private Models.DanhMuc _selectedDanhMuc;
        public Models.DanhMuc selectedDanhMuc { get { return _selectedDanhMuc; } set { _selectedDanhMuc = value; OnPropertyChanged(nameof(selectedDanhMuc)); } }
        public static Models.Ban ban { get; set; }

        public DatBanViewModel() {
            //cấu hình blur background
            screen = Helpers.Effect.blurBackground;

            hoaDonTemp = new Models.HoaDon();
            hoaDonTemp.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>();
            danhMucs = new ObservableCollection<Models.DanhMuc>(Models.DataProvider.Ins.DB.DanhMucs);
            // Load Command
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                if (ban.IdTinhTrang == 0) {
                    hoaDon = new Models.HoaDon {
                        Id = DateTime.Now.ToString("ddMMyyyyhhmmss") + "-" + ban.Id,
                        IdBan = ban.Id,
                        IdCa = GlobalVariable.Ca.Id,
                        IdUser = GlobalVariable.User.Id,
                        Status = 1,
                        Ngay = DateTime.Now,
                        GioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                    };
                    Models.DataProvider.Ins.DB.HoaDons.Add(hoaDon);
                    var ban_temp = (from item in Models.DataProvider.Ins.DB.Bans
                                    where item.Id.CompareTo(ban.Id) == 0
                                    select item).SingleOrDefault();
                    ban_temp.IdTinhTrang = 1;
                    Models.DataProvider.Ins.DB.SaveChanges();
                    hoaDon.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>();
                } else {
                    hoaDonTemp = new Models.HoaDon();
                    hoaDonTemp.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>();
                    danhMucs = new ObservableCollection<Models.DanhMuc>(Models.DataProvider.Ins.DB.DanhMucs);
                    var temp = (from item in Models.DataProvider.Ins.DB.HoaDons
                                where item.Status == 1 && item.IdBan.CompareTo(ban.Id) == 0
                                select item).FirstOrDefault();
                    if (temp == null)
                        return;
                    hoaDon = temp;
                    hoaDon.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>(temp.ChiTietHoaDons);
                    tongTien = hoaDon.ChiTietHoaDons.Select(x => (double)x.Mon.Price * x.Quantity).Sum();
                    hoaDon.ThanhTien = int.Parse(tongTien.ToString());
                }
            });
            btnDanhMucCommand = new RelayCommand<Button>((p) => true, (p) => {
                selectedDanhMuc = p.DataContext as Models.DanhMuc;
            });

            selectedMonCommand = new RelayCommand<Button>((p) => true, (p) => {
                var mon = p.DataContext as Models.Mon;
                try {
                    var item = (from ct in hoaDonTemp.ChiTietHoaDons
                                where ct.Mon.Id.CompareTo(mon.Id) == 0
                                select ct).FirstOrDefault();
                    item.Quantity++;
                }
                catch (Exception e) {
                    var chiTietHoaDon = new Models.ChiTietHoaDon {
                        Quantity = 1,
                        Mon = mon,
                    };
                    hoaDonTemp.ChiTietHoaDons.Add(chiTietHoaDon);
                }
            });

            minusCommand = new RelayCommand<Models.ChiTietHoaDon>((p) => true, (p) => {
                var item = (from ct in hoaDonTemp.ChiTietHoaDons
                            where ct.Mon.Id.CompareTo(p.Mon.Id) == 0
                            select ct).FirstOrDefault();
                item.Quantity--;
                if (item.Quantity == 0)
                    hoaDonTemp.ChiTietHoaDons.Remove(item);
            });

            plusCommand = new RelayCommand<Models.ChiTietHoaDon>((p) => true, (p) => {
                var item = (from ct in hoaDonTemp.ChiTietHoaDons
                            where ct.Mon.Id.CompareTo(p.Mon.Id) == 0
                            select ct).FirstOrDefault();
                item.Quantity++;
            });

            saveCommand = new RelayCommand<object>((p) => true, (p) => {
                Models.ChiTietHoaDon chiTietHoaDon = null;
                foreach (var item in hoaDonTemp.ChiTietHoaDons) {
                    var check = (from ct in hoaDon.ChiTietHoaDons
                                 where ct.Mon.Id.CompareTo(item.Mon.Id) == 0
                                 select ct).SingleOrDefault();
                    if (check != null) {
                        chiTietHoaDon = (from ct in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                             where ct.IdMon.CompareTo(check.IdMon) == 0 && ct.IdHoaDon.CompareTo(hoaDon.Id) == 0
                                             select ct).SingleOrDefault();
                        chiTietHoaDon.Quantity += item.Quantity;
                        Models.DataProvider.SaveDatabase();
                    } else {
                        // Insert
                        chiTietHoaDon = new Models.ChiTietHoaDon {
                            IdHoaDon = hoaDon.Id,
                            IdMon = item.Mon.Id,
                            Quantity = item.Quantity,
                            PriceBan = (double)item.Mon.Price * item.Quantity,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now,
                        };
                        Models.DataProvider.Ins.DB.ChiTietHoaDons.Add(chiTietHoaDon);
                        Models.DataProvider.SaveDatabase();
                    }
                }
                tongTien = hoaDon.ChiTietHoaDons.Select(x => (double)x.Mon.Price * x.Quantity).Sum();
                hoaDon.ThanhTien = int.Parse(tongTien.ToString());
                hoaDonTemp.ChiTietHoaDons.Clear();
            });
            DeleteMonCommand = new RelayCommand<Models.ChiTietHoaDon>((p) => true, (p) => {
                if (p == null)
                    return;
                var screen = new Views.ThuNgan.frmManHinhGiamSat();
                ViewModels.ManHinhGiamSatViewModel.chiTietHoaDon = p;
                screen.ShowDialog();
            });
            ThanhToanCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (hoaDon.ChiTietHoaDons.Count != 0) {
                    var screen = new Views.ThuNgan.frmThanhToanHoaDon();
                    ViewModels.ThanhToanHoaDonViewModel.hoadon = hoaDon;
                    screen.ShowDialog();
                    p.Close();
                } else
                    DialogCustom.Alert("Thông báo", "chưa chọn món");

            });

            ExitCommand = new RelayCommand<Window>((p) => true, (p) => {
                p.Close();
            });
        }
    }
}
