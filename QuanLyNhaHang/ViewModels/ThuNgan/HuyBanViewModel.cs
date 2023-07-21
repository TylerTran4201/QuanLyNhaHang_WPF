using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class HuyBanViewModel : BaseViewModel {
        #region Command
        public ICommand KhuVucSelectedChangeCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        #endregion
        #region Init
        private ObservableCollection<Models.KhuVuc> _khuVucs { get; set; }
        public ObservableCollection<Models.KhuVuc> khuVucs { get { return _khuVucs; } set { _khuVucs = value; OnPropertyChanged(nameof(khuVucs)); } }
        private ObservableCollection<Models.Ban> _bans { get; set; }
        public ObservableCollection<Models.Ban> bans { get { return _bans; } set { _bans = value; OnPropertyChanged(nameof(bans)); } }
        private Models.Ban _SelectedBan { get; set; }
        public Models.Ban SelectedBan { get { return _SelectedBan; } set { _SelectedBan = value; OnPropertyChanged(nameof(SelectedBan)); } }
        #endregion
        public HuyBanViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                bans = null;
                khuVucs = new ObservableCollection<Models.KhuVuc>(Models.DataProvider.Ins.DB.KhuVucs);
            });
            KhuVucSelectedChangeCommand = new RelayCommand<Models.KhuVuc>((p) => true, (p) => {
                bans = new ObservableCollection<Models.Ban>((from b in p.Bans
                                                             where b.IdTinhTrang == 1
                                                             select b).ToList());
            });
            HuyCommand = new RelayCommand<object>((p) => true, (p) => {
                var item = (from hd in Models.DataProvider.Ins.DB.HoaDons
                            where hd.IdBan.CompareTo(SelectedBan.Id) == 0 && hd.Status == 1
                            select hd).FirstOrDefault();
                if (item == null)
                    return;
                if (item.ChiTietHoaDons.Count > 0)
                    DialogCustom.Alert("Thông Báo", "Bàn " + SelectedBan.Name + " đã đặt món");
                else if(DialogCustom.YesNo("Thông Báo","Xác nhận hủy bàn "+SelectedBan.Name)== DialogResults.Yes){
                    var item1 = (from b in Models.DataProvider.Ins.DB.Bans
                                 where b.Id.CompareTo(SelectedBan.Id) == 0
                                 select b).SingleOrDefault();
                    item1.IdTinhTrang = 0;      
                    Models.DataProvider.Ins.DB.HoaDons.Remove(item);
                    Models.DataProvider.SaveDatabase();
                }
            });
        }
    }
}
