using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class TaiKhoanViewModel : BaseViewModel {
        #region Commands
        public ICommand SelectedItemCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        #endregion
        #region textboxInfor
        private int _txtId = 0;
        private string _txtName;
        private string _txtUserName;
        private string _txtPassword;
        private string _txtCMND;
        private string _txtPhone;
        private string _txtEmail;
        private string _txtAddress;
        public string txtName { get { return _txtName; } set { _txtName = value; OnPropertyChanged(nameof(txtName)); } }
        public string txtUserName { get { return _txtUserName; } set { _txtUserName = value; OnPropertyChanged(nameof(txtUserName)); } }
        public string txtPassword { get { return _txtPassword; } set { _txtPassword = value; OnPropertyChanged(nameof(txtPassword)); } }
        public string txtCMND { get { return _txtCMND; } set { _txtCMND = value; OnPropertyChanged(nameof(txtCMND)); } }
        public string txtPhone { get { return _txtPhone; } set { _txtPhone = value; OnPropertyChanged(nameof(txtPhone)); } }
        public string txtEmail { get { return _txtEmail; } set { _txtEmail = value; OnPropertyChanged(nameof(txtEmail)); } }
        public string txtAddress { get { return _txtAddress; } set { _txtAddress = value; OnPropertyChanged(nameof(txtAddress)); } }

        #endregion

        public ObservableCollection<Models.User> users { get; set; }
        public TaiKhoanViewModel() {
            users = new ObservableCollection<Models.User>(Models.DataProvider.Ins.DB.Users);

            SelectedItemCommand = new RelayCommand<Models.User>((p) => true, (p) => {
                ChangeAllTextBox(p);
            });
            ClearCommand = new RelayCommand<object>((p) => true, (p) => {
                ClearAllTextBox();
            });
            AddCommand = new RelayCommand<object>((p) => true, (p) => {
                if (txtUserName != string.Empty) {
                    AddNewUser(txtUserName);
                }
            });
            UpdateCommand = new RelayCommand<object>((p) => true, (p) => {
                if (_txtId != 0) {
                    UpdateUser(_txtId);
                }
            });
            DeleteCommand = new RelayCommand<Models.User>((p) => true, (p) => {
                if (DialogCustom.YesNo("Thông Báo", "Xác nhận xóa " + p.UserName) == DialogResults.Yes) {
                    DeleteUser(p.Id);
                }
            });
            ChangeStatusCommand = new RelayCommand<Models.User>((p) => true, (p) => {
                if (DialogCustom.YesNo("Thông Báo", (p.Status == 1) ? "xác nhận khóa tài khoản" : "Xác nhận mở tài khoản") == DialogResults.Yes) {
                    ChangeStatus(p);
                }
            });
        }
        public void ChangeAllTextBox(Models.User user) {
            if (user != null) {
                txtName = user.Name;
                txtUserName = user.UserName;
                txtEmail = user.Email;
                txtPhone = user.Phone;
                txtCMND = user.CMND;
                txtAddress = user.Address;
                _txtId = user.Id;
            }
        }
        public void ClearAllTextBox() {
            txtName = string.Empty;
            txtUserName = string.Empty;
            txtPassword = string.Empty;
            txtEmail = string.Empty;
            txtPhone = string.Empty;
            txtCMND = string.Empty;
            txtAddress = string.Empty;
        }
        public bool isInfoEmpty() {
            return (txtUserName == "" || txtName == "" || txtCMND == "" || txtUserName == null || txtName == null || txtCMND == null) ? true : false;
        }

        public int countUsernameExist(string username) {
            var check = (from u in users
                         where u.UserName.CompareTo(username) == 0
                         select u).ToList();
            return check.Count;
        }


        public void AddNewUser(string username) {
            if (countUsernameExist(username) == 0) {
                if (!isInfoEmpty() || txtPassword != "" || txtPassword != null) {
                    var lastId = (from u in users
                                  select u.Id).LastOrDefault() + 1;
                    Models.User user = new Models.User {
                        Id = lastId,
                        Name = txtName,
                        UserName = txtUserName,
                        Password = MD5.MD5Hash(MD5.Base64Encode(txtPassword)),
                        CMND = txtCMND,
                        Phone = txtPhone,
                        Address = txtAddress,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    Models.DataProvider.Ins.DB.Users.Add(user);
                    Models.DataProvider.SaveDatabase();
                    users.Add(user);
                    DialogCustom.Alert("Thông Báo", "Thêm thành công");
                } else {
                    DialogCustom.Alert("Thông Báo", "Nhập đầy đủ thông tin");
                }
            } else {
                DialogCustom.Alert("Thông Báo", "Trùng Username");
            }
        }
        public void UpdateUser(int id) {
            if (!isInfoEmpty()) {

                Models.User user = (from u in Models.DataProvider.Ins.DB.Users
                                    where u.Id == id
                                    select u).SingleOrDefault();
                user.Name = txtName;
                user.UserName = txtUserName;
                if (txtPassword != string.Empty)
                    user.Password = MD5.MD5Hash(MD5.Base64Encode(txtPassword));
                user.CMND = txtCMND;
                user.Phone = txtPhone;
                user.Address = txtAddress;
                user.Email = txtEmail;
                user.ModifiedAt = DateTime.Now;
                Models.DataProvider.Ins.DB.SaveChanges();
                ClearAllTextBox();
                DialogCustom.Alert("Thông Báo", "Đã sửa thành công");
            } else {
                DialogCustom.Alert("Thông Báo", "Nhập đầy đủ thông tin");
            }
        }
        public void ChangeStatus(Models.User user) {
            var item = (from u in Models.DataProvider.Ins.DB.Users
                        where u.Id == user.Id
                        select u).SingleOrDefault();
            if (user.Status == 1) {
                item.Status = 0;
            } else {
                item.Status = 1;
            }
            Models.DataProvider.Ins.DB.SaveChanges();
        }
        public void DeleteUser(int id) {
            if (DialogCustom.YesNo("Thông Báo", "Xác Nhận Xóa người dùng" + id) == DialogResults.Yes) {
                var userRole = (from ur in Models.DataProvider.Ins.DB.UserRoles
                                where ur.IdUser == id
                                select ur).ToList();
                var user = (from u in Models.DataProvider.Ins.DB.Users
                            where u.Id == id
                            select u).SingleOrDefault();
                Models.DataProvider.Ins.DB.UserRoles.RemoveRange(userRole);
                Models.DataProvider.Ins.DB.Users.Remove(user);
                users.Remove(user);
                ClearAllTextBox();
                Models.DataProvider.SaveDatabase();
            }
        }
    }
}
