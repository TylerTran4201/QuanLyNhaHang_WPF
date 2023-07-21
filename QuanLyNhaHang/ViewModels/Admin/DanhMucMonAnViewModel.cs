using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class DanhMucMonAnViewModel : BaseViewModel {
        #region Command
        public ICommand ClearCommad { get; set; }
        public ICommand SelectedCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        #endregion
        #region Input
        private string _txtId; 
        private string _txtName;
        private bool _cbChoPhepNhapKho;

        public string txtId { get { return _txtId; } set { _txtId = value; OnPropertyChanged(nameof(txtId)); } }
        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        public bool cbChoPhepNhapKho { get { return _cbChoPhepNhapKho; } set { _cbChoPhepNhapKho = value; OnPropertyChanged(nameof(cbChoPhepNhapKho)); } }
        #endregion
        public ObservableCollection<Models.DanhMuc> DanhMucs { get; set; }
        public DanhMucMonAnViewModel() {
            DanhMucs = new ObservableCollection<Models.DanhMuc>(Models.DataProvider.Ins.DB.DanhMucs);
            SelectedCommand = new RelayCommand<Models.DanhMuc>((p) => true, (p) => {
                if (p != null) {
                    txtId = p.Id;
                    txtName = p.Name;
                    cbChoPhepNhapKho = p.ChoPhepNhapKho == null ? default(bool): p.ChoPhepNhapKho.Value;
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
            DeleteCommand = new RelayCommand<Models.DanhMuc>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.DanhMuc>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void ClearInput() {
            txtId = "";
            txtName = "";
            cbChoPhepNhapKho = new bool();
        }
        public void AddNew(string name) {
            if (!isInputEmpty()) {
                if (!isDanhMucExist(name, 0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Danh Mục") == DialogResults.Yes) {
                        Models.DanhMuc danhMuc = new Models.DanhMuc {
                            Id = txtId,
                            Name = txtName,
                            ChoPhepNhapKho = cbChoPhepNhapKho,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.DanhMucs.Add(danhMuc);
                        Models.DataProvider.SaveDatabase();
                        DanhMucs.Add(danhMuc);
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Tên Danh Mục Đã Trùng");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Update(string name) {
            if (!isInputEmpty()) {
                if (!isDanhMucExist(name, 1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Danh Mục") == DialogResults.Yes) {
                        Models.DanhMuc danhMuc = (from dm in Models.DataProvider.Ins.DB.DanhMucs
                                                  where dm.Id.CompareTo(txtId) == 0
                                                  select dm).SingleOrDefault();
                        danhMuc.Id = txtId;
                        danhMuc.Name = txtName;
                        danhMuc.ChoPhepNhapKho = cbChoPhepNhapKho;
                        danhMuc.ModifiedAt = DateTime.Now;
                        Models.DataProvider.SaveDatabase();
                        ClearInput();
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Tên Danh Mục Đã Trùng");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }

        }
        public void Delete(Models.DanhMuc danhMuc) {

        }
        public void ChangeStatus(Models.DanhMuc danhMuc) {
            if (danhMuc != null) {
                if (DialogCustom.YesNo("Thông Báo", (danhMuc.Status == 1) ? "Xác Nhận Khóa Danh Mục" : "Xác Nhận Mở Danh Mục") == DialogResults.Yes) {
                    var item = (from dm in Models.DataProvider.Ins.DB.DanhMucs
                                where dm.Id.CompareTo(danhMuc.Id) == 0
                                select dm).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.SaveDatabase();
                }
            }
        }
        public bool isDanhMucExist(string name, int mode) {
            List<Models.DanhMuc> item;
            if (mode == 0) {// add
                item = (from dm in DanhMucs
                        where dm.Name.CompareTo(name) == 0
                        select dm).ToList();
            } else if (mode == 1) {// update
                item = (from dm in DanhMucs
                        where dm.Name.CompareTo(name) == 0 && dm.Id.CompareTo(txtId) == 0 
                        select dm).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtId == "" || txtName == "" || txtId == string.Empty || txtName == string.Empty) ? true : false;
        }
    }
}
