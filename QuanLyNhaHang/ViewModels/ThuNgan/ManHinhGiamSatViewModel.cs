using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class ManHinhGiamSatViewModel: BaseViewModel {
        #region Command
        public ICommand LoadedCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        #endregion
        #region Init
        private string _username;
        private string _password;
        private Models.LiDo _selectedLiDo;
        private ObservableCollection<Models.LiDo> _liDoes;

        public string username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(username)); } }
        public string password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(password)); } }
        public Models.LiDo selectedLiDo { get { return _selectedLiDo; } set { _selectedLiDo = value; OnPropertyChanged(nameof(selectedLiDo)); } }
        public ObservableCollection<Models.LiDo> liDoes { get { return _liDoes; } set { _liDoes = value; OnPropertyChanged(nameof(liDoes)); } }
        public static Models.ChiTietHoaDon chiTietHoaDon { get; set; }
        #endregion
        public ManHinhGiamSatViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true,(p)=> {
                liDoes = new ObservableCollection<Models.LiDo>(Models.DataProvider.Ins.DB.LiDoes);
                selectedLiDo = null;
                username = null;
                password = null;
                selectedLiDo = null;
            });
            SubmitCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || selectedLiDo == null) {
                    MessageBox.Show("Nhập Đầy Đủ Thông Tin");
                    return;
                }
                Models.User account = new Models.User();
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
                        DialogCustom.Alert("Thông Báo", "Tài Khoản chưa được cài đặt quyền");
                        return;
                    }
                    if (user.person.Status == 0) {
                        MessageBox.Show("Tài khoản đã bị khóa");
                        return;
                    }
                    if ("GiamSat".CompareTo(user.role) == 0) {
                        var item1 = new Models.HuyMon {
                            IdMon = chiTietHoaDon.IdMon,
                            IdUser = GlobalVariable.User.Id,
                            IdLiDo = selectedLiDo.Id,
                            Ngay = DateTime.Now,
                            IdCa = GlobalVariable.Ca.Id,
                            Gio = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                        };
                        Models.DataProvider.Ins.DB.HuyMons.Add(item1);
                        Models.DataProvider.SaveDatabase();

                        var item = (from cthd in Models.DataProvider.Ins.DB.ChiTietHoaDons
                                    where cthd.Id == chiTietHoaDon.Id
                                    select cthd).SingleOrDefault();
                        Models.DataProvider.Ins.DB.ChiTietHoaDons.Remove(item);
                        Models.DataProvider.SaveDatabase();
                        p.Close();
                    } else{
                        MessageBox.Show("Thông báo", "Tài khoản không phải giám sát");
                    }

                } else {
                    MessageBox.Show("Wrong account");
                    return;
                }
            });
        }
        public bool CheckLogin(Models.User account) {
            var user = Models.DataProvider.Ins.DB.Users.Where(p => string.Compare(p.UserName, account.UserName) == 0 && string.Compare(p.Password, account.Password) == 0).ToList();
            if (user.Count != 0)
                return true;
            return false;
        }
    }
}
