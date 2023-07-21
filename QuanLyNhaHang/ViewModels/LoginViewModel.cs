using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class LoginViewModel : BaseViewModel {
        #region Background
        private Helpers.BlurBackground _screen;
        public Helpers.BlurBackground screen { get { return _screen; } set { _screen = value; OnPropertyChanged(nameof(screen)); } }
        #endregion
        #region commands
        public ICommand LoginCommand { get; set; }
        public ICommand QuitCommnad { get; set; }
        #endregion
        private string _username { get; set; }
        private string _password { get; set; }
        public string username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(username)); } }
        public string password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(password)); } }

        public LoginViewModel() {
            // cấu hình backgroud
            screen = Helpers.Effect.blurBackground;

            LoginCommand = new RelayCommand<Window>((p) => true, (p) => { // UIElementCollection: kiểu dữ liệu của nguyên một stackpanel
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {
                    MessageBox.Show("Nhập Đầy Đủ Thông Tin");
                    return;
                }
                User account = new User();
                account.UserName = username;
                account.Password = MD5.MD5Hash(MD5.Base64Encode(password));
                if (this.CheckLogin(account) == true) {
                    // quyền 
                    var db = Models.DataProvider.Ins.DB;
                    var user = (from u in db.Users
                                join ur in db.UserRoles on u.Id equals ur.IdUser
                                where u.Id == ur.IdUser
                                from r in db.Roles
                                where ur.IdRole == r.Id

                                where u.Password.CompareTo(account.Password) == 0 && u.UserName.CompareTo(account.UserName) == 0
                                select new {
                                    person = u,
                                    role = r.Name,
                                }).FirstOrDefault();
                    if (user == null) {
                        DialogCustom.Alert("Thông Báo","Tài Khoản chưa được cài đặt quyền");
                        return;
                    }
                    if (user.person.Status == 0) {
                        MessageBox.Show("Tài khoản đã bị khóa");
                        return;
                    }
                    var screen = new Window();
                    if ("Admin".CompareTo(user.role) == 0) {
                        screen = new Views.frmMainAdmin();
                        p.Hide();
                        screen.Show();
                    } else if ("Thungan".CompareTo(user.role) == 0) {
                        
                        var now = DateTime.Now;
                        var ca = (from item in db.Cas
                                   where now.TimeOfDay >= item.ThoiGianBatDau && now.TimeOfDay <= item.ThoiGianKetThuc
                                   select item).FirstOrDefault();
                        //set curent user and ca lam viec
                        GlobalVariable.User = user.person;
                        GlobalVariable.Ca = ca;
                        if (ca == null) {
                            DialogCustom.Alert("Thông Báo", "Hết giờ làm việc, Vui lòng liên hệ Admin để thêm ca làm việc");
                            return;
                        }
                        DialogCustom.Alert("Thông báo", "Bạn đang đăng nhập vào thời điểm (Ngày: "+ now.ToString("d") + " và giờ: "+now.ToString("t")
                            + "\n Ca: "+ ca.Name);
                        screen = new Views.frmMainThuNgan();
                        p.Hide();
                        screen.Show();
                    } else if ("GiamSat".CompareTo(user.role) == 0) {

                    }

                } else {
                    MessageBox.Show("Wrong account");
                    return;
                }
            });
            QuitCommnad = new RelayCommand<Window>((p) => true, (p) => {
                p.Close();
            });
        }
        public bool CheckLogin(User account) {
            var user = Models.DataProvider.Ins.DB.Users.Where(p => string.Compare(p.UserName, account.UserName) == 0 && string.Compare(p.Password, account.Password) == 0).ToList();
            if (user.Count != 0)
                return true;
            return false;
        }
    }
}
