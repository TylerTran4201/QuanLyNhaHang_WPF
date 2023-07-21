using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class MonAnViewModel : BaseViewModel {
        #region Command
        public ICommand ComboboxSelectedCommand { get; set; }
        public ICommand ClearCommad { get; set; }
        public ICommand SelectedCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        #endregion
        #region Input
        private string IdMon;
        private string _txtName;
        private string _txtPrice;
        private string _txtPriceInput;
        private Models.DanhMuc _SelectedDanhMuc;
        private Models.Unit _SelectedUnit;
        private Models.MayIn _SelectedMayIn;
        private ObservableCollection<Models.DanhMuc> _DanhMucs;
        private ObservableCollection<Models.Unit> _Units;
        private ObservableCollection<Models.MayIn> _MayIns;
        private ObservableCollection<Models.Mon> _Mons;
        private Models.DanhMuc _ComboboxDanhMuc;

        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        public string txtPrice { get { return _txtPrice; } set { _txtPrice = value; OnPropertyChanged(nameof(txtPrice)); } }
        public string txtPriceInput { get { return _txtPriceInput; } set { _txtPriceInput = value; OnPropertyChanged(nameof(txtPriceInput)); } }
        public Models.DanhMuc SelectedDanhMuc { get { return _SelectedDanhMuc; } set { _SelectedDanhMuc = value; OnPropertyChanged(nameof(SelectedDanhMuc)); } }
        public Models.Unit SelectedUnit { get { return _SelectedUnit; } set { _SelectedUnit = value; OnPropertyChanged(nameof(SelectedUnit)); } }
        public Models.MayIn SelectedMayIn { get { return _SelectedMayIn; } set { _SelectedMayIn = value; OnPropertyChanged(nameof(SelectedMayIn)); } }
        public Models.DanhMuc ComboboxDanhMuc { get { return _ComboboxDanhMuc; } set { _ComboboxDanhMuc = value; OnPropertyChanged(nameof(ComboboxDanhMuc)); } }
        public ObservableCollection<Models.DanhMuc> DanhMucs { get { return _DanhMucs; } set { _DanhMucs = value; OnPropertyChanged(nameof(txtName)); } }
        public ObservableCollection<Models.Unit> Units { get { return _Units; } set { _Units = value; OnPropertyChanged(nameof(txtName)); } }
        public ObservableCollection<Models.MayIn> MayIns { get { return _MayIns; } set { _MayIns = value; OnPropertyChanged(nameof(txtName)); } }
        #endregion
        public ObservableCollection<Models.Mon> Mons { get { return _Mons; } set { _Mons = value; OnPropertyChanged(nameof(Mons)); } }
        public MonAnViewModel() {
            DanhMucs = new ObservableCollection<Models.DanhMuc>(Models.DataProvider.Ins.DB.DanhMucs);
            Units = new ObservableCollection<Models.Unit>(Models.DataProvider.Ins.DB.Units);
            MayIns = new ObservableCollection<Models.MayIn>(Models.DataProvider.Ins.DB.MayIns);

            Mons = new ObservableCollection<Models.Mon>(Models.DataProvider.Ins.DB.Mons);
            LoadCommand = new RelayCommand<object>((p) => true, (p) => {
                DanhMucs = new ObservableCollection<Models.DanhMuc>(Models.DataProvider.Ins.DB.DanhMucs);
                Units = new ObservableCollection<Models.Unit>(Models.DataProvider.Ins.DB.Units);
                MayIns = new ObservableCollection<Models.MayIn>(Models.DataProvider.Ins.DB.MayIns);

                Mons = new ObservableCollection<Models.Mon>(Models.DataProvider.Ins.DB.Mons);
                ComboboxDanhMuc = null;
            });
            ComboboxSelectedCommand = new RelayCommand<object>((p) => true, (p) => {
                if (ComboboxDanhMuc != null) {
                    Mons = new ObservableCollection<Models.Mon>(ComboboxDanhMuc.Mons);
                }
            });
            SelectedCommand = new RelayCommand<Models.Mon>((p) => true, (p) => {
                if (p != null) {
                    SelectedDanhMuc = p.DanhMuc;
                    SelectedUnit = p.Unit;
                    SelectedMayIn = p.MayIn;
                    txtName = p.Name;
                    txtPriceInput = p.PriceInput.ToString();
                    txtPrice = p.Price.ToString();
                    IdMon = p.Id;
                }
            });
            ClearCommad = new RelayCommand<object>((p) => true, (p) => {
                ClearInput();
            });
            AddCommand = new RelayCommand<object>((p) => true, (p) => {
                AddNew(txtName);
            });
            UpdateCommand = new RelayCommand<object>((p) => true, (p) => {
                Update(txtName);
            });
            DeleteCommand = new RelayCommand<Models.Mon>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.Mon>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void ClearInput() {
            txtName = "";
            txtPrice = "";
            txtPriceInput = "";
            SelectedDanhMuc = null;
            SelectedMayIn = null;
            SelectedUnit = null;
        }
        public void AddNew(string name) {
            if (!isInputEmpty()) {
                if (!isMonExist(name, 0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Món") == DialogResults.Yes) {
                        Models.Mon mon = new Models.Mon {
                            Id = "F-" + DateTime.Now.ToString("ddMMyyHHmmss"),
                            Name = txtName,
                            Price = int.Parse(txtPrice),
                            PriceInput = int.Parse(txtPriceInput),
                            IdDanhMuc = SelectedDanhMuc.Id,
                            IdUnit = SelectedUnit.Id,
                            IdMayIn = SelectedMayIn.Id,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.Mons.Add(mon);
                        Models.DataProvider.SaveDatabase();
                        Mons.Add(mon);
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Tên Món Đã Trùng");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Update(string name) {
            if (!isInputEmpty()) {
                if (!isMonExist(name, 1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Thông Báo Sửa Món") == DialogResults.Yes) {
                        Models.Mon mon = (from m in Models.DataProvider.Ins.DB.Mons
                                          where m.Id.CompareTo(IdMon) == 0
                                          select m).SingleOrDefault();
                        mon.Name = txtName;
                        mon.Price = int.Parse(txtPrice);
                        mon.PriceInput = int.Parse(txtPriceInput);
                        mon.IdDanhMuc = SelectedDanhMuc.Id;
                        mon.IdUnit = SelectedUnit.Id;
                        mon.IdMayIn = SelectedMayIn.Id;
                        mon.ModifiedAt = DateTime.Now;
                        Models.DataProvider.Ins.DB.SaveChanges();
                        ClearInput();
                        DialogCustom.Alert("Thông Bá0", "Đã Sửa Thành Công");
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Món");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Delete(Models.Mon mon) {
            if (DialogCustom.YesNo("Thông Báo", "Khi Xóa Sẽ Ảnh Hưởng Nhiều Thành Phần \n Xác Nhận Xóa" + mon.Name) == DialogResults.Yes) {

                var luuKhuyenMai = (from item in Models.DataProvider.Ins.DB.LuuKhuyenMais
                                    where item.IdMon.CompareTo(mon.Id) == 0
                                    select item).ToList();
                var chiTietPhieuNhap = (from item in Models.DataProvider.Ins.DB.ChiTietPhieuNhaps
                                        where item.IdMon.CompareTo(mon.Id) == 0
                                        select item).ToList();
                var chiTietHoaDon = (from item in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                     where item.IdMon.CompareTo(mon.Id) == 0
                                     select item).ToList();
                var chiTietHoaDonTemp = (from item in Models.DataProvider.Ins.DB.ChiTietHoaDonTemps
                                         where item.IdMon.CompareTo(mon.Id) == 0
                                         select item).ToList();
                var sanPhamKhuyenMai = (from item in Models.DataProvider.Ins.DB.SanPhamKhuyenMais
                                        where item.IdMon.CompareTo(mon.Id) == 0
                                        select item).ToList();
                var huyMon = (from item in Models.DataProvider.Ins.DB.HuyMons
                              where item.IdMon.CompareTo(mon.Id) == 0
                              select item).ToList();
                var kho = (from item in Models.DataProvider.Ins.DB.Khoes
                           where item.IdMon.CompareTo(mon.Id) == 0
                           select item).ToList();
                Models.DataProvider.Ins.DB.LuuKhuyenMais.RemoveRange(luuKhuyenMai);
                Models.DataProvider.Ins.DB.ChiTietPhieuNhaps.RemoveRange(chiTietPhieuNhap);
                Models.DataProvider.Ins.DB.ChiTietHoaDons.RemoveRange(chiTietHoaDon);
                Models.DataProvider.Ins.DB.ChiTietHoaDonTemps.RemoveRange(chiTietHoaDonTemp);
                Models.DataProvider.Ins.DB.SanPhamKhuyenMais.RemoveRange(sanPhamKhuyenMai);
                Models.DataProvider.Ins.DB.HuyMons.RemoveRange(huyMon);
                Models.DataProvider.Ins.DB.Khoes.RemoveRange(kho);
                Models.DataProvider.Ins.DB.Mons.Remove(mon);
                Mons.Remove(mon);
                Models.DataProvider.Ins.DB.SaveChanges();
            }
        }
        public void ChangeStatus(Models.Mon mon) {
            if (mon != null) {
                if (DialogCustom.YesNo("Thông Báo", (mon.Status == 1) ? "Xác Nhận Khóa Món" : "Xác Nhận Mở Món") == DialogResults.Yes) {
                    var item = (from m in Models.DataProvider.Ins.DB.Mons
                                where m.Id.CompareTo(mon.Id) == 0
                                select m).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.SaveDatabase();
                }
            }
        }
        public bool isMonExist(string name, int mode) {
            List<Models.Mon> item;
            if (mode == 0) {// add
                item = (from m in Mons
                        where m.Name.CompareTo(name) == 0
                        select m).ToList();
            } else if (mode == 1) {// update
                item = (from m in Mons
                        where m.Name.CompareTo(name) == 0 && m.Id.CompareTo(IdMon) == 1
                        select m).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtName == "" || txtPrice == "" || txtPriceInput == "" || 
                SelectedDanhMuc == null || SelectedUnit == null || SelectedMayIn == null || 
                txtName == string.Empty || txtPrice == string.Empty || txtPriceInput == string.Empty) ? true : false;
        }
    }
}
