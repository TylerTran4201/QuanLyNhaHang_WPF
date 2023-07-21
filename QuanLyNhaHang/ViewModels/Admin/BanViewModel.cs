using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class BanViewModel : BaseViewModel{
        #region Command
        public ICommand LoadCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand SelectedCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand DeleteCommnad { get; set; }
        #endregion
        #region textboxInfo
        private string idBan;
        private string _txtName;
        private Models.TableType _selectedLoaiBan;
        private Models.KhuVuc _selectedKhuVuc;
        private Models.TinhTrang _selectedTinhTrang;
        private ObservableCollection<Models.TableType> _loaiBans;
        private ObservableCollection<Models.KhuVuc> _khuVucs;
        private ObservableCollection<Models.TinhTrang> _tinhTrangs;

        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        public Models.TableType selectedLoaiBan { get { return _selectedLoaiBan; } set { _selectedLoaiBan = value; OnPropertyChanged(nameof(selectedLoaiBan)); } }
        public Models.KhuVuc selectedKhuVuc { get { return _selectedKhuVuc; } set { _selectedKhuVuc = value; OnPropertyChanged(nameof(selectedKhuVuc)); } }
        public Models.TinhTrang selectedTinhTrang { get { return _selectedTinhTrang; } set { _selectedTinhTrang = value; OnPropertyChanged(nameof(selectedTinhTrang)); } }
        public ObservableCollection<Models.TableType> loaiBans { get { return _loaiBans; } set { _loaiBans = value; OnPropertyChanged(nameof(loaiBans)); } }
        public ObservableCollection<Models.KhuVuc> khuVucs { get { return _khuVucs; } set { _khuVucs = value; OnPropertyChanged(nameof(khuVucs)); } }
        public ObservableCollection<Models.TinhTrang> tinhTrangs { get { return _tinhTrangs; } set { _tinhTrangs = value; OnPropertyChanged(nameof(tinhTrangs)); } }
        #endregion
        private ObservableCollection<Models.Ban> _bans;
        public ObservableCollection<Models.Ban> bans { get { return _bans; } set { _bans = value; OnPropertyChanged(nameof(bans)); } }
        public BanViewModel() {
            bans = new ObservableCollection<Models.Ban>(Models.DataProvider.Ins.DB.Bans);
            loaiBans = new ObservableCollection<Models.TableType>(Models.DataProvider.Ins.DB.TableTypes);
            khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
            tinhTrangs = new ObservableCollection<Models.TinhTrang>(Models.DataProvider.Ins.DB.TinhTrangs);
            LoadCommand = new RelayCommand<object>((p) => true, (p) => {
                bans = new ObservableCollection<Models.Ban>(Models.DataProvider.Ins.DB.Bans);
                loaiBans = new ObservableCollection<Models.TableType>(Models.DataProvider.Ins.DB.TableTypes);
                khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
                tinhTrangs = new ObservableCollection<Models.TinhTrang>(Models.DataProvider.Ins.DB.TinhTrangs);
            });
            SelectedCommand = new RelayCommand<Models.Ban>((p) => true, (p) => {
                if (p != null) {
                    idBan = p.Id;
                    txtName = p.Name;
                    selectedTinhTrang = p.TinhTrang;
                    selectedLoaiBan = p.TableType;
                    selectedKhuVuc = p.KhuVuc;
                }
            });
            ClearCommand = new RelayCommand<object>((p) => true, (p) => {
                ClearInput();
            });
            UpdateCommand = new RelayCommand<object>((p) => true, (p) => {
                Update();
            });
            AddCommand = new RelayCommand<object>((p) => true, (p) => {
                AddNew();
            });
            DeleteCommnad = new RelayCommand<Models.Ban>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.Ban>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void ClearInput() {
            txtName = null;
            selectedTinhTrang = null;
            selectedLoaiBan = null;
            selectedKhuVuc = null;
        }
        public void Update() {
            if (!isInputEmpty()) {
                if (!isBanExist(1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Thông Báo Sửa Bàn") == DialogResults.Yes) {
                        Models.Ban ban = (from item in Models.DataProvider.Ins.DB.Bans
                                                where item.Id.CompareTo(idBan) == 0
                                                select item).SingleOrDefault();
                        ban.Name = txtName;
                        ban.IdTinhTrang = selectedTinhTrang.Id;
                        ban.IdKhuVuc = selectedKhuVuc.Id;
                        ban.IdTableType = selectedLoaiBan.Id;
                        ban.ModifiedAt = DateTime.Now;
                        Models.DataProvider.Ins.DB.SaveChanges();
                        ClearInput();
                        DialogCustom.Alert("Thông Bá0", "Đã Sửa Thành Công");
                    } 
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Bàn");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void AddNew() {

            if (!isInputEmpty()) {
                if (!isBanExist(0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Bàn") == DialogResults.Yes) {
                        // convert a string to int with no charater
                        var IDFirst = "B" + string.Concat(Regex.Matches(selectedKhuVuc.Name, "[A-Z]").OfType<Match>().Select(match => match.Value));
                        var IdLast = (int.Parse(string.Concat((from item in selectedKhuVuc.Bans select item.Id).LastOrDefault().ToString().Where(Char.IsDigit))) + 1).ToString();
                        Models.Ban ban = new Models.Ban {
                            Id = IDFirst + IdLast,
                            Name = txtName,
                            IdTinhTrang = selectedTinhTrang.Id,
                            IdKhuVuc = selectedKhuVuc.Id,
                            IdTableType = selectedLoaiBan.Id,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.Bans.Add(ban);
                        Models.DataProvider.SaveDatabase();
                        bans.Add(ban);
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Tên Bàn Đã Trùng");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Delete(Models.Ban ban) {
            if (DialogCustom.YesNo("Thông Báo", "Khi Xóa Sẽ Ảnh Hưởng Nhiều Thành Phần \n Xác Nhận Xóa" + ban.Name) == DialogResults.Yes) {
                var hoaDons = (from item in Models.DataProvider.Ins.DB.HoaDons
                              where item.IdBan.CompareTo(ban.Id) == 0
                              select item).ToList();
                Models.DataProvider.Ins.DB.HoaDons.RemoveRange(hoaDons);
                Models.DataProvider.Ins.DB.Bans.Remove(ban);
                Models.DataProvider.SaveDatabase();
                bans.Remove(ban);
            }
        }
        public void ChangeStatus(Models.Ban ban) {
            if (ban != null) {
                if (DialogCustom.YesNo("Thông Báo", (ban.Status == 1) ? "Xác Nhận Khóa Bán" : "Xác Nhận Mở Bàn") == DialogResults.Yes) {
                    var item = (from m in Models.DataProvider.Ins.DB.Bans
                                where m.Id.CompareTo(ban.Id) == 0
                                select m).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.SaveDatabase();
                }
            }
        }
        public bool isBanExist(int mode) {
            List<Models.Ban> item;
            if (mode == 0) {// add
                item = (from m in bans
                        where m.Name.CompareTo(txtName) == 0
                        select m).ToList();
            } else if (mode == 1) {// update
                item = (from m in bans
                        where m.Name.CompareTo(txtName) == 0 && m.Id.CompareTo(idBan) == 1
                        select m).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtName == null || selectedLoaiBan == null || selectedKhuVuc == null|| selectedTinhTrang == null) ? true : false;
        }
    }
}
