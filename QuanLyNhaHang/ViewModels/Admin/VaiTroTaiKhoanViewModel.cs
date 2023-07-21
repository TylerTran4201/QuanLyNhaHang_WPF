 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    class VaiTroTaiKhoanViewModel : BaseViewModel {
        #region Command
        public ICommand LoadCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand SelectedItemCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand DeleteCommnad { get; set; }
        #endregion

        #region textboxInfo
        private string _txtMaGiamSat;
        private Models.Role _SelectedRole;
        private Models.User _SelectedUser;
        public string txtMaGiamSat { get { return _txtMaGiamSat; } set { _txtMaGiamSat = value; OnPropertyChanged(nameof(txtMaGiamSat)); } }
        public Models.Role SelectedRole { get { return _SelectedRole; } set { _SelectedRole = value; OnPropertyChanged(nameof(SelectedRole)); } }
        public Models.User SelectedUser { get { return _SelectedUser; } set { _SelectedUser = value; OnPropertyChanged(nameof(SelectedUser)); } }
        #endregion
        private ObservableCollection<Models.User> _Users;
        private ObservableCollection<Models.Role> _Roles;
        private ObservableCollection<Models.UserRole> _UserRoles;

        public ObservableCollection<Models.User> Users { get { return _Users; } set { _Users = value; OnPropertyChanged(nameof(Users)); } }
        public ObservableCollection<Models.Role> Roles { get { return _Roles; } set { _Roles = value; OnPropertyChanged(nameof(Roles)); } }
        public ObservableCollection<Models.UserRole> UserRoles { get { return _UserRoles; } set { _UserRoles = value; OnPropertyChanged(nameof(UserRoles)); } }

        public VaiTroTaiKhoanViewModel() {
            //Khai báo combobox : user && role 
            LoadCommand = new RelayCommand<object>((p) => true, (p) => {
                Users = new ObservableCollection<Models.User>(Models.DataProvider.Ins.DB.Users);
                Roles = new ObservableCollection<Models.Role>(Models.DataProvider.Ins.DB.Roles);

                UserRoles = new ObservableCollection<Models.UserRole>(Models.DataProvider.Ins.DB.UserRoles);
            });
            
            SelectedItemCommand = new RelayCommand<Models.UserRole>((p) => true, (p) => {
                if (p != null) {
                    SelectedUser = p.User;
                    SelectedRole = p.Role;
                }
            });
            ClearCommand = new RelayCommand<object>((p) => true, (p) => {
                SelectedUser = null;
                SelectedRole = null;
                txtMaGiamSat = "";
            });
            ChangeStatusCommand = new RelayCommand<Models.UserRole>((p) => true, (p) => {
                if (p != null) {
                    if (DialogCustom.YesNo("Thông Báo", (p.Status == 1) ? "Xác nhận khóa quyền" : "Xác nhận mở quyền") == DialogResults.Yes) {
                        ChangeStatus(p);
                    }
                }
            });
            AddCommand = new RelayCommand<object>((p) => true, (p) => {
                AddNew();
            });
            DeleteCommnad = new RelayCommand<Models.UserRole>((p) => true, (p) => {
                Delete(p.Id);
            });
        }
        public void ChangeStatus(Models.UserRole userRole) {
            if (userRole != null) {
                var item = (from ur in Models.DataProvider.Ins.DB.UserRoles
                            where ur.Id == userRole.Id
                            select ur).SingleOrDefault();
                item.Status = (item.Status == 1) ? 0 : 1;
                Models.DataProvider.SaveDatabase();
            }
        }
        public bool isUserRoleExist(int userId, int roleId) {
            var item = (from ur in Models.DataProvider.Ins.DB.UserRoles
                        where ur.IdUser == userId && ur.IdRole == roleId
                        select ur).ToList();
            return (item.Count > 0) ? true : false;
        }
        public void AddNew() {
            if (!isUserRoleExist(SelectedUser.Id, SelectedRole.Id)) {
                if (DialogCustom.YesNo("Thông Báo", "Xác nhận thêm quyền") == DialogResults.Yes) {
                    Models.UserRole userRole = new Models.UserRole {
                        Id = (from ur in UserRoles
                              select ur.Id).LastOrDefault() + 1,
                        IdRole = SelectedRole.Id,
                        IdUser = SelectedUser.Id,
                        MaGiamSat = txtMaGiamSat,
                        Status = 0,
                        ModifiedAt = DateTime.Now,
                        CreatedAt = DateTime.Now
                    };
                    Models.DataProvider.Ins.DB.UserRoles.Add(userRole);
                    Models.DataProvider.SaveDatabase();
                    UserRoles.Add(userRole);
                    DialogCustom.Alert("Thông Báo", "Đã thêm thành công");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Quyền đã tồn tại");
            }
        }
        public void Delete(int idUserRole) {
            if (DialogCustom.YesNo("Thông Báo", "Xác nhận xóa") == DialogResults.Yes) {
                var item = (from ur in Models.DataProvider.Ins.DB.UserRoles
                            where ur.Id == idUserRole
                            select ur).SingleOrDefault();
                Models.DataProvider.Ins.DB.UserRoles.Remove(item);
                Models.DataProvider.SaveDatabase();

                UserRoles.Remove(item);
            }
        }
    }
}
