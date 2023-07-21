using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class ThanhToanHoaDonViewModel : BaseViewModel {
        #region Command
        public ICommand LoadedCommand { get; set; }
        public ICommand ThanhToanCommand { get; set; }
        public ICommand TienKhachDuaChangedCommand { get; set; }
        #endregion
        #region Init
        private int _tongTien;
        private int _tienKhachDua;
        private int _traLai;
        private int _tienNo;
        private string _ghiChuKhachHang;

        public int tongTien { get { return _tongTien; } set { _tongTien = value; OnPropertyChanged(nameof(tongTien)); } }
        public int tienKhachDua { get { return _tienKhachDua; } set { _tienKhachDua = value; OnPropertyChanged(nameof(tienKhachDua)); } }
        public int traLai { get { return _traLai; } set { _traLai = value; OnPropertyChanged(nameof(traLai)); } }
        public int tienNo { get { return _tienNo; } set { _tienNo = value; OnPropertyChanged(nameof(tienNo)); } }
        public string ghiChuKhachHang { get { return _ghiChuKhachHang; } set { _ghiChuKhachHang = value; OnPropertyChanged(nameof(ghiChuKhachHang)); } }
        public static Models.HoaDon hoadon { get; set; }
        private bool flag = false;
        #endregion
        public ThanhToanHoaDonViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                tongTien = (int)hoadon.ThanhTien;
            });
            TienKhachDuaChangedCommand = new RelayCommand<object>((p) => true, (p) => {
                ChangedValue();
                if (flag == false)
                    flag = true;
            });
            ThanhToanCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (flag == false)
                    ChangedValue();
                if (tienKhachDua != 0) {
                    var item = (from i in Models.DataProvider.Ins.DB.HoaDons
                                where i.Id.CompareTo(hoadon.Id) == 0
                                select i).SingleOrDefault();
                    item.SoTienKhachDua = tienKhachDua;
                    item.SoTienTraLai = traLai;
                    item.GhiChuKhachHang = ghiChuKhachHang;
                    item.TienNo = tienNo;
                    item.GioRa = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    item.Status = 0;
                    Models.DataProvider.SaveDatabase();

                    var item1 = (from i in Models.DataProvider.Ins.DB.Bans
                                 where i.Id.CompareTo(hoadon.IdBan) == 0
                                 select i).SingleOrDefault();
                    item1.IdTinhTrang = 0;
                    Models.DataProvider.SaveDatabase();

                    var lichSuThanhToan = new Models.LichSuHoaDonThanhToan {
                        IdHoaDon = hoadon.Id,
                        SoTienNo = tienNo,
                        SoTienTra = traLai,
                        SoTienConLai = (tienNo == 0) ? 0 : tongTien - tienNo,
                        GhiChu = ghiChuKhachHang,
                        Ngay = DateTime.Now,
                        Gio = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                    };
                    Models.DataProvider.Ins.DB.LichSuHoaDonThanhToans.Add(lichSuThanhToan);
                    Models.DataProvider.SaveDatabase();
                    p.Close();
                }
            });
        }
        private void ChangedValue() {
            if (tienKhachDua != 0) {
                if (tongTien < tienKhachDua) {
                    traLai = tienKhachDua - tongTien;
                    tienNo = 0;
                } else if (tongTien > tienKhachDua) {
                    traLai = 0;
                    tienNo = tongTien - tienKhachDua;
                } else if (tongTien == tienKhachDua) {
                    traLai = 0;
                    tienNo = 0;
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Chưa nhập tiền khách đưa");
            }
        }
    }
}
