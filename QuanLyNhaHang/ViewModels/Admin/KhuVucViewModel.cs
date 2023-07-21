using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class KhuVucViewModel : BaseViewModel {
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
        private string idKhuVuc;
        private string _selectedColor;
        public string selectedColor { get { return _selectedColor; } set { _selectedColor = value; OnPropertyChanged(nameof(selectedColor)); } }
        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }

        #endregion
        private ObservableCollection<Models.KhuVuc> _khuVucs;
        public ObservableCollection<Models.KhuVuc> khuVucs { get { return _khuVucs; } set { _khuVucs = value; OnPropertyChanged(nameof(khuVucs)); } }
        public ObservableCollection<string> colors { get; set; }
        public KhuVucViewModel() {
            khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
            colors = new ObservableCollection<string>(Helpers.Color.GetColors());

            SelectedCommand = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                if (p != null) {
                    idKhuVuc = p.Id;
                    txtName = p.Name;
                    selectedColor = p.Color;
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
            DeleteCommnad = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void Update() {
            if (!isInputEmpty()) {
                if (!isKhuVucExist(1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Thông Báo Sửa Món") == DialogResults.Yes) {
                        Models.KhuVuc khuvuc = (from item in Models.DataProvider.Ins.DB.KhuVucs
                                                where item.Id.CompareTo(idKhuVuc) == 0
                                                select item).SingleOrDefault();
                        khuvuc.Name = txtName;
                        khuvuc.Color = selectedColor;
                        khuvuc.ModifiedAt = DateTime.Now;
                        Models.DataProvider.Ins.DB.SaveChanges();
                        ClearInput();
                        DialogCustom.Alert("Thông Bá0", "Đã Sửa Thành Công");
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Khu Vực");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void AddNew() {
            // convert a string to int with no charater
            int Id_Temp = int.Parse(string.Concat((from item in khuVucs select item.Id).LastOrDefault().ToString().Where(Char.IsDigit))) + 1;
            if (!isInputEmpty()) {
                if (!isKhuVucExist(0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Loại Bàn") == DialogResults.Yes) {
                        Models.KhuVuc khuVuc = new Models.KhuVuc {
                            Id = "KV" + ((Id_Temp % 10 != 0) ? "0" : "") + Id_Temp.ToString(),
                            Name = txtName,
                            Color = selectedColor,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.KhuVucs.Add(khuVuc);
                        Models.DataProvider.SaveDatabase();
                        khuVucs.Add(khuVuc);
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
        public void Delete(Models.KhuVuc khuvuc) {
            if (DialogCustom.YesNo("Thông Báo", "Khi Xóa Sẽ Ảnh Hưởng Nhiều Thành Phần \n Xác Nhận Xóa" + khuvuc.Name) == DialogResults.Yes) {
                var bans = (from item in Models.DataProvider.Ins.DB.Bans
                           where item.IdKhuVuc.CompareTo(khuvuc.Id) == 0
                           select item).ToList();
                Models.DataProvider.Ins.DB.Bans.RemoveRange(bans);
                Models.DataProvider.Ins.DB.KhuVucs.Remove(khuvuc);
                Models.DataProvider.SaveDatabase();
                khuVucs.Remove(khuvuc);
            }
        }
        public void ChangeStatus(Models.KhuVuc khuVuc) {
            if (khuVuc != null) {
                if (DialogCustom.YesNo("Thông Báo", (khuVuc.Status == 1) ? "Xác Nhận Khóa Khu Vực" : "Xác Nhận Mở Khu Vực") == DialogResults.Yes) {
                    var item = (from m in Models.DataProvider.Ins.DB.KhuVucs
                                where m.Id.CompareTo(khuVuc.Id) == 0
                                select m).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.SaveDatabase();
                }
            }
        }
        public void ClearInput() {
            idKhuVuc = null;
            txtName = null;
            selectedColor = null;
        }
        public bool isKhuVucExist(int mode) {
            List<Models.KhuVuc> item;
            if (mode == 0) {// add
                item = (from m in khuVucs
                        where m.Name.CompareTo(txtName) == 0
                        select m).ToList();
            } else if (mode == 1) {// update
                item = (from m in khuVucs
                        where m.Name.CompareTo(txtName) == 0 && m.Id.CompareTo(idKhuVuc) == 1
                        select m).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtName == null || SelectedCommand == null) ? true : false;
        }
    }
}
