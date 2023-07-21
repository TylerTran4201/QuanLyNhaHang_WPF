using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class GopTachbanViewModel : BaseViewModel {
        #region command
        public ICommand BanSelectedChanged1 { get; set; }
        public ICommand BanSelectedChanged2 { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand LamMoiCommand { get; set; }
        public ICommand GopBanCommand { get; set; }
        public ICommand LuuCommand { get; set; }
        public ICommand PlusCommand { get; set; }
        #endregion
        #region Init
        private Models.Ban _selectedBan1;
        private Models.Ban _selectedBan2;


        private Models.HoaDon _hoadon1;
        private Models.HoaDon _hoadon2;

        public static int Item_Quantity = 0;

        private bool _btnLuuEnable { get; set; }
        public bool btnLuuEnable { get { return _btnLuuEnable; } set { _btnLuuEnable = value; OnPropertyChanged(nameof(btnLuuEnable)); } }
        public Models.Ban selectedBan1 { get { return _selectedBan1; } set { _selectedBan1 = value; OnPropertyChanged(nameof(selectedBan1)); } }
        public Models.Ban selectedBan2 { get { return _selectedBan2; } set { _selectedBan2 = value; OnPropertyChanged(nameof(selectedBan2)); } }
        public Models.HoaDon hoadon1 { get { return _hoadon1; } set { _hoadon1 = value; OnPropertyChanged(nameof(hoadon1)); } }
        public Models.HoaDon hoadon2 { get { return _hoadon2; } set { _hoadon2 = value; OnPropertyChanged(nameof(hoadon2)); } }
        private Models.HoaDon hoadonTemp;
        private ObservableCollection<Models.Ban> _bans;
        public ObservableCollection<Models.Ban> bans { get { return _bans; } set { _bans = value; OnPropertyChanged(nameof(bans)); } }
        #endregion
        public GopTachbanViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                bans = new ObservableCollection<Models.Ban>((from b in Models.DataProvider.Ins.DB.Bans
                                                             where b.IdTinhTrang == 1
                                                             select b).ToList());
                hoadonTemp = new Models.HoaDon();
                hoadonTemp.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>();
                selectedBan1 = null;
                selectedBan2 = null;
                hoadon1 = null;
                hoadon2 = null;
                btnLuuEnable = false;
            });
            BanSelectedChanged1 = new RelayCommand<Models.Ban>((p) => true, (p) => {
                if (p == null)
                    return;
                hoadon1 = new Models.HoaDon();
                var temp = (from hd in Models.DataProvider.Ins.DB.HoaDons
                            where hd.IdBan.CompareTo(p.Id) == 0 && hd.Status == 1
                            select hd).FirstOrDefault();
                if (temp == null)
                    return;
                hoadon1 = temp;
                hoadon1.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>(temp.ChiTietHoaDons);
            });
            BanSelectedChanged2 = new RelayCommand<Models.Ban>((p) => true, (p) => {
                if (p == null)
                    return;
                hoadon2 = new Models.HoaDon();
                var temp = (from hd in Models.DataProvider.Ins.DB.HoaDons
                            where hd.IdBan.CompareTo(p.Id) == 0 && hd.Status == 1
                            select hd).SingleOrDefault();
                if (temp == null)
                    return;
                hoadon2 = temp;
                hoadon2.ChiTietHoaDons = new ObservableCollection<Models.ChiTietHoaDon>(hoadon2.ChiTietHoaDons);
            });
            LamMoiCommand = new RelayCommand<object>((p) => true, (p) => {
                selectedBan1 = null;
                selectedBan2 = null;
                hoadon1 = null;
                hoadon2 = null;
                hoadonTemp = new Models.HoaDon();
                btnLuuEnable = false;
            });
            GopBanCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (selectedBan1.Id.CompareTo(selectedBan2.Id) != 0) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác nhận gộp hai bàn " + selectedBan1.Name + " và bàn " + selectedBan2.Name) == DialogResults.Yes) {
                        this.GopBan(hoadon1, hoadon2);
                        p.Close();
                    }
                } else
                    DialogCustom.Alert("Thông Báo", "Hai bàn đã trùng nhau");
            });
            PlusCommand = new RelayCommand<Models.ChiTietHoaDon>((p) => true, (p) => {
                if (selectedBan2 != null) {
                    if (selectedBan1.Id.CompareTo(selectedBan2.Id) == 0) {
                        DialogCustom.Alert("Thông Báo", "Hai bàn đã trùng nhau");
                        return;
                    }
                    if (p != null) {
                        if (hoadon2 != null) {
                            var screen = new Views.ThuNgan.frmGopTachBan_NhapSoLuong();
                            screen.ShowDialog();

                            if (Item_Quantity != 0) {
                                if (Item_Quantity == p.Quantity) {
                                    hoadon2.ChiTietHoaDons.Add(p);
                                    hoadonTemp.ChiTietHoaDons.Add(p);
                                    hoadon1.ChiTietHoaDons.Remove(p);
                                } else if (Item_Quantity < p.Quantity) {
                                    var item = (from i in hoadon1.ChiTietHoaDons
                                                where i.Id == p.Id
                                                select i).SingleOrDefault();
                                    item.Quantity -= Item_Quantity;
                                    var item1 = item;
                                    item1.Quantity = Item_Quantity;
                                    hoadon2.ChiTietHoaDons.Add(item1);
                                    hoadonTemp.ChiTietHoaDons.Add(item1);

                                } else
                                    DialogCustom.Alert("Thông Báo", "Lớn hơn số lượng");
                            }

                            if (btnLuuEnable == false)
                                btnLuuEnable = true;
                        }
                    }
                } else
                    DialogCustom.Alert("Thông Báo", "Chưa chọn bàn chuyển đến");
            });
            LuuCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (selectedBan1.Id.CompareTo(selectedBan2.Id) == 0)
                    DialogCustom.Alert("Thông Báo", "Hai bàn đã trùng nhau");
                else if (DialogCustom.YesNo("Thông Báo", "Xác nhận gộp tách bàn " + selectedBan1.Name + " và bàn " + selectedBan2.Name) == DialogResults.Yes) {
                    if (hoadonTemp != null) {
                        this.TachBan(hoadonTemp, hoadon2,hoadon1);
                        p.Close();
                    } else
                        DialogCustom.Alert("Thông Báo", "Chưa chuyển món");
                }
            });
        }
        private void TachBan(Models.HoaDon hoadon_temp, Models.HoaDon hoadon_2,Models.HoaDon hoadon_1) {
            ObservableCollection<Models.ChiTietHoaDon> items = new ObservableCollection<Models.ChiTietHoaDon>(hoadon_temp.ChiTietHoaDons);
            foreach (var item1 in items) {
                var check = (from cthd in Models.DataProvider.Ins.DB.ChiTietHoaDons
                             where cthd.IdHoaDon.CompareTo(hoadon_2.Id) == 0 && cthd.IdMon.CompareTo(item1.IdMon) == 0
                             select cthd).SingleOrDefault();
                if (check != null) {
                    var chiTietHoaDon = (from cthd in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                         where cthd.IdHoaDon.CompareTo(hoadon_2.Id) == 0 && cthd.IdMon.CompareTo(check.IdMon) == 0
                                         select cthd).SingleOrDefault();
                    chiTietHoaDon.Quantity += item1.Quantity;
                    Models.DataProvider.SaveDatabase();
                    // xét trường hợp có cần phải xóa chi tiết hoa đơn cũ hay không
                    var check2 = (from i in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                  where i.Id.CompareTo(item1.Id) == 0
                                  select i).SingleOrDefault();
                    if (check2.Quantity == item1.Quantity) {
                        var temp = (from i in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                    where i.Id == item1.Id
                                    select i).SingleOrDefault();
                        Models.DataProvider.Ins.DB.ChiTietHoaDons.Remove(temp);
                        Models.DataProvider.SaveDatabase();
                    }

                } else {
                    Models.DataProvider.Ins = null;// reset database (xóa liên kết)
                    var check2 = (from i in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                  where i.Id.CompareTo(item1.Id) == 0
                                  select i).SingleOrDefault();

                    if (item1.Quantity == check2.Quantity)
                        item1.IdHoaDon = hoadon_2.Id;
                    else if (item1.Quantity < check2.Quantity) {
                        // Insert
                        check2.Quantity -= item1.Quantity;
                        Models.DataProvider.SaveDatabase();
                        var chiTietHoaDon = new Models.ChiTietHoaDon {
                            IdHoaDon = hoadon_2.Id,
                            IdMon = item1.Mon.Id,
                            Quantity = item1.Quantity,
                            PriceBan = (double)item1.Mon.Price * item1.Quantity,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now,
                        };
                        Models.DataProvider.Ins.DB.ChiTietHoaDons.Add(chiTietHoaDon);
                        Models.DataProvider.SaveDatabase();
                    }
                }
            }
            if (hoadon_1.ChiTietHoaDons.Count == 0) {// trường hợp tách bàn mà chuyển hết món
                var item2 = (from hd in Models.DataProvider.Ins.DB.HoaDons
                             where hd.Id.CompareTo(hoadon_temp.Id) == 0
                             select hd).SingleOrDefault();
                if (item2 != null) {
                    Models.DataProvider.Ins.DB.HoaDons.Remove(item2);
                    Models.DataProvider.SaveDatabase();
                }

                var item3 = (from b in Models.DataProvider.Ins.DB.Bans
                             where b.Id.CompareTo(selectedBan1.Id) == 0
                             select b).SingleOrDefault();
                item3.IdTinhTrang = 0;
                Models.DataProvider.SaveDatabase();
            }
        }
        private void GopBan(Models.HoaDon hoadon_1, Models.HoaDon hoadon_2) {
            ObservableCollection<Models.ChiTietHoaDon> items = new ObservableCollection<Models.ChiTietHoaDon>(hoadon_1.ChiTietHoaDons);
            foreach (var item1 in items) {
                var check = (from cthd in Models.DataProvider.Ins.DB.ChiTietHoaDons
                             where cthd.IdHoaDon.CompareTo(hoadon_2.Id) == 0 && cthd.IdMon.CompareTo(item1.IdMon) == 0
                             select cthd).SingleOrDefault();
                if (check != null) {
                    var chiTietHoaDon = (from cthd in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                         where cthd.IdHoaDon.CompareTo(hoadon_2.Id) == 0 && cthd.IdMon.CompareTo(check.IdMon) == 0
                                         select cthd).SingleOrDefault();
                    chiTietHoaDon.Quantity += item1.Quantity;

                    Models.DataProvider.Ins.DB.ChiTietHoaDons.Remove(item1);
                    item1.IdHoaDon = hoadon_2.Id;
                    Models.DataProvider.SaveDatabase();
                } else {
                    item1.IdHoaDon = hoadon2.Id;
                    Models.DataProvider.SaveDatabase();
                }
            }

            var item2 = (from hd in Models.DataProvider.Ins.DB.HoaDons
                         where hd.Id.CompareTo(hoadon_1.Id) == 0
                         select hd).SingleOrDefault();
            if (item2 != null)
                Models.DataProvider.Ins.DB.HoaDons.Remove(item2);

            var item3 = (from b in Models.DataProvider.Ins.DB.Bans
                         where b.Id.CompareTo(selectedBan1.Id) == 0
                         select b).SingleOrDefault();
            item3.IdTinhTrang = 0;
            Models.DataProvider.SaveDatabase();
        }

    }
}
