using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class LoaiBanViewModel : BaseViewModel {
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
        private string _txtName;
        private string idLoaiBan;
        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        #endregion
        public ObservableCollection<Models.TableType> _LoaiBans;
        public ObservableCollection<Models.TableType> LoaiBans { get { return _LoaiBans; } set { _LoaiBans = value; OnPropertyChanged(nameof(LoaiBans)); } }

        public LoaiBanViewModel() {
            LoaiBans = new ObservableCollection<Models.TableType>(Models.DataProvider.Ins.DB.TableTypes);

            SelectedCommand = new RelayCommand<Models.TableType>((p) => true, (p) => {
                if (p != null) {
                    txtName = p.Name;
                    idLoaiBan = p.Id;
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
            DeleteCommnad = new RelayCommand<Models.TableType>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.TableType>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void ClearInput() {
            txtName = null;
        }
        public void Update() {
            if (!isInputEmpty()) {
                if (!isLoaiBanExist(1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Thông Báo Sửa Loại Bàn") == DialogResults.Yes) {
                        Models.TableType loaiban = (from item in Models.DataProvider.Ins.DB.TableTypes
                                                where item.Id.CompareTo(idLoaiBan) == 0
                                                select item).SingleOrDefault();
                        loaiban.Name = txtName;
                        loaiban.ModifiedAt = DateTime.Now;
                        Models.DataProvider.Ins.DB.SaveChanges();
                        ClearInput();
                        DialogCustom.Alert("Thông Bá0", "Đã Sửa Thành Công");
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Loại Bàn");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void AddNew() {
            // convert a string to int with no charater
            int Id_Temp = int.Parse(string.Concat((from item in LoaiBans select item.Id).LastOrDefault().ToString().Where(Char.IsDigit))) + 1;
            if (!isInputEmpty()) {
                if (!isLoaiBanExist(0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Loại Bàn") == DialogResults.Yes) {
                        Models.TableType loaiBan = new Models.TableType {
                            Id = "T" + ((Id_Temp % 10 != 0) ? "0" : "") + Id_Temp.ToString(),
                            Name = txtName,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.TableTypes.Add(loaiBan);
                        Models.DataProvider.SaveDatabase();
                        LoaiBans.Add(loaiBan);
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Tên Khu Vực Đã Trùng");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Delete(Models.TableType loaiBan) {
            if (DialogCustom.YesNo("Thông Báo", "Khi Xóa Sẽ Ảnh Hưởng Nhiều Thành Phần \n Xác Nhận Xóa" + loaiBan.Name) == DialogResults.Yes) {
                var bans = (from item in Models.DataProvider.Ins.DB.Bans
                            where item.IdTableType.CompareTo(loaiBan.Id) == 0
                            select item).ToList();
                Models.DataProvider.Ins.DB.Bans.RemoveRange(bans);
                Models.DataProvider.Ins.DB.TableTypes.Remove(loaiBan);
                Models.DataProvider.SaveDatabase();
                LoaiBans.Remove(loaiBan);
            }
        }
        public  void ChangeStatus(Models.TableType loaiBan) {
            if (loaiBan != null) {
                if (DialogCustom.YesNo("Thông Báo", (loaiBan.Status == 1) ? "Xác Nhận Khóa Món" : "Xác Nhận Mở Món") == DialogResults.Yes) {
                    var item = (from m in Models.DataProvider.Ins.DB.TableTypes
                                where m.Id.CompareTo(loaiBan.Id) == 0
                                select m).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.SaveDatabase();
                }
            }
        }
        public bool isLoaiBanExist(int mode) {
            List<Models.TableType> item;
            if (mode == 0) {// add
                item = (from m in LoaiBans
                        where m.Name.CompareTo(txtName) == 0
                        select m).ToList();
            } else if (mode == 1) {// update
                item = (from m in LoaiBans
                        where m.Name.CompareTo(txtName) == 0 && m.Id.CompareTo(idLoaiBan) == 1
                        select m).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtName == null) ? true : false;
        }
    }
}
