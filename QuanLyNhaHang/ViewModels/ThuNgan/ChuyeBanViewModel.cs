using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class ChuyeBanViewModel : BaseViewModel {
        #region Command
        public ICommand XacNhanCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand KhuVucSelectedChangeCommand1 { get; set; }
        public ICommand KhuVucSelectedChangeCommand2 { get; set; }
        #endregion
        #region Init
        public ObservableCollection<Models.KhuVuc> khuVucs { get; set; }
        private ObservableCollection<Models.Ban> _bans1 { get; set; }
        private ObservableCollection<Models.Ban> _bans2 { get; set; }

        public ObservableCollection<Models.Ban> bans1 { get { return _bans1; } set { _bans1 = value; OnPropertyChanged(nameof(bans1)); } }
        public ObservableCollection<Models.Ban> bans2 { get { return _bans2; } set { _bans2 = value; OnPropertyChanged(nameof(bans2)); } }

        private Models.Ban _SelectedBan1 { get; set; }
        public Models.Ban SelectedBan1 { get { return _SelectedBan1; } set { _SelectedBan1 = value; OnPropertyChanged(nameof(SelectedBan1));}}
        private Models.Ban _SelectedBan2 { get; set; }
        public Models.Ban SelectedBan2 { get { return _SelectedBan2; } set { _SelectedBan2 = value; OnPropertyChanged(nameof(SelectedBan2)); } }
        #endregion

        public ChuyeBanViewModel() {
            khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                bans1 = null;
                bans2 = null;
                khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
            });
            XacNhanCommand = new RelayCommand<object>((p) => true, (p) => {
                if (SelectedBan1.Id.CompareTo(SelectedBan2.Id) == 0)
                    DialogCustom.Alert("Thông Báo", "Hai Bàn Đã Trùng");
                else if (SelectedBan1.IdTinhTrang == 0)
                    DialogCustom.Alert("Thông Báo", "Bàn " + SelectedBan1.Name + " chưa chọn món");
                else if (SelectedBan2.IdTinhTrang == 1)
                    DialogCustom.Alert("Thông Báo", "Bàn " + SelectedBan2.Name + " đã có người đặt");
                else if(DialogCustom.YesNo("Thông Báo","Xác nhận chuyển bàn") == DialogResults.Yes){
                    var item = (from hd in Models.DataProvider.Ins.DB.HoaDons
                                where hd.IdBan.CompareTo(SelectedBan1.Id) == 0 && hd.Status == 1
                                select hd).FirstOrDefault();
                    item.IdBan = SelectedBan2.Id;

                    var item1 = (from b in Models.DataProvider.Ins.DB.Bans
                                 where b.Id.CompareTo(SelectedBan2.Id) == 0
                                 select b).SingleOrDefault();
                    item1.IdTinhTrang = 1;
                    
                    var item2 = (from b in Models.DataProvider.Ins.DB.Bans
                                 where b.Id.CompareTo(SelectedBan1.Id) == 0
                                 select b).SingleOrDefault();
                    item2.IdTinhTrang = 0;

                    Models.DataProvider.SaveDatabase();
                }
            });
            KhuVucSelectedChangeCommand1 = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                bans1 = new ObservableCollection<Models.Ban>(p.Bans);
            });
            KhuVucSelectedChangeCommand2 = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                bans2 = new ObservableCollection<Models.Ban>(p.Bans);
            });
        }
    }
}
