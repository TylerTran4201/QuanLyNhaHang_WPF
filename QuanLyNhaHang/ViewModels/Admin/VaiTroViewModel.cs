using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels
{
    public class VaiTroViewModel : BaseViewModel {
        #region Command
        public ICommand ClearCommand { get; set; }
        public ICommand SelectedCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        #endregion
        #region Input
        private int IdRole = 0;
        private string _txtName;
        private string _txtDescription;
        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        public string txtDescription { get { return _txtDescription; } set { _txtDescription = value; OnPropertyChanged(nameof(txtDescription)); } }
        #endregion
        public ObservableCollection<Models.Role> Roles { get; set; }
        public VaiTroViewModel() {
            Roles = new ObservableCollection<Models.Role>(Models.DataProvider.Ins.DB.Roles);
            ClearCommand = new RelayCommand<object>((p) => true, (p)=> {
                ClearInput();
            });
            SelectedCommand = new RelayCommand<Models.Role>((p) => true, (p) => {
                if (p != null) {
                    IdRole = p.Id;
                    txtName = p.Name;
                    txtDescription = p.Description;
                }
            });
            AddCommand = new RelayCommand<object>((p) => true, (p) => {
                AddNew(txtName);
            });
            UpdateCommand = new RelayCommand<object>((p) => true, (p) => {
                Update(txtName);
            });
            DeleteCommand = new RelayCommand<Models.Role>((p) => true, (p) => {
                Delete(p);
            });
            ChangeStatusCommand = new RelayCommand<Models.Role>((p) => true, (p) => {
                ChangeStatus(p);
            });
        }
        public void ClearInput() {
            txtName = "";
            txtDescription = "";
        }
        public void AddNew(string Name) {
            if (!isInputEmpty()) {
                if (!isRoleExist(Name,0)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Thêm Quyền") == DialogResults.Yes) {
                        Models.Role role = new Models.Role {
                            Id = (from r in Roles
                                  select r.Id).LastOrDefault() + 1,
                            Name = txtName,
                            Description = txtDescription,
                            Status = 0,
                            CreatedAt = DateTime.Now,
                            ModifiedAt = DateTime.Now
                        };
                        Models.DataProvider.Ins.DB.Roles.Add(role);
                        Models.DataProvider.Ins.DB.SaveChanges();
                        Roles.Add(role);
                        DialogCustom.Alert("Thông Báo", "Đã Thêm Thành Công");
                        ClearInput();
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Quyền");
                }
            } else {
                DialogCustom.Alert("Thông Báo","Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Update(string Name) {
            if (!isInputEmpty()) {
                if (!isRoleExist(Name, 1)) {
                    if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Sửa Quyền") == DialogResults.Yes) {
                        Models.Role role = (from r in Models.DataProvider.Ins.DB.Roles
                                            where r.Id == IdRole
                                            select r).SingleOrDefault();
                        role.Name = txtName;
                        role.Description = txtDescription;
                        role.ModifiedAt = DateTime.Now;
                        Models.DataProvider.Ins.DB.SaveChanges();
                        ClearInput();
                        DialogCustom.Alert("Thông Báo", "Đã Sửa Thành Công");
                    }
                } else {
                    DialogCustom.Alert("Thông Báo", "Trùng Tên Quyền");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập Đầy Đủ Thông Tin");
            }
        }
        public void Delete(Models.Role role) {
           
            if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Xóa Quyền" + role.Name) == DialogResults.Yes) {
                var userRoles = (from ur in Models.DataProvider.Ins.DB.UserRoles
                                where ur.IdRole == role.Id
                                 select ur).ToList();
                Models.DataProvider.Ins.DB.UserRoles.RemoveRange(userRoles);
                Models.DataProvider.Ins.DB.Roles.Remove(role);
                Models.DataProvider.Ins.DB.SaveChanges();
                Roles.Remove(role);
            }
        }
        public void ChangeStatus(Models.Role role) {
            if (role != null) {
                if (DialogCustom.YesNo("Thông báo", (role.Status == 1) ? "Xác Nhận Khóa Quyền": "Xác Nhận Mở Quyền") == DialogResults.Yes) {
                    var item = (from r in Models.DataProvider.Ins.DB.Roles
                                where r.Id == role.Id
                                select r).SingleOrDefault();
                    item.Status = (item.Status == 1) ? 0 : 1;
                    Models.DataProvider.Ins.DB.SaveChanges();
                }
            }
        }
        public bool isRoleExist(string name, int mode) {
            List<Models.Role> item;
            if (mode == 0) {// add
                item = (from r in Models.DataProvider.Ins.DB.Roles
                        where r.Name.CompareTo(name) == 0
                        select r).ToList();
            } else if (mode == 1) {// updates
                item = (from r in Models.DataProvider.Ins.DB.Roles
                        where r.Name.CompareTo(name) == 0 && r.Id != IdRole
                        select r).ToList();
            } else
                return false;
            return (item.Count != 0) ? true : false;
        }
        public bool isInputEmpty() {
            return (txtName == "" || txtDescription == "" || txtName == null || txtDescription == null)? true: false;
        }
    }
}
