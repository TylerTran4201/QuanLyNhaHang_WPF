using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class GopTachBan_NhapSoLuongViewModel:BaseViewModel {
        #region Command
        public ICommand SubmitCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        #endregion
        #region Init
        private string _Quantity;
        public string Quantity { get { return _Quantity; } set { _Quantity = value; OnPropertyChanged(nameof(Quantity)); } }
        #endregion
        public GopTachBan_NhapSoLuongViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {
                Quantity = "0";
            });
            SubmitCommand = new RelayCommand<Window>((p) => true, (p) => {
                if (Quantity != null) {
                    if (Quantity.All(char.IsDigit) == true){
                        ViewModels.GopTachbanViewModel.Item_Quantity = int.Parse(Quantity);
                        p.Close();
                    } else
                        DialogCustom.Alert("Thông Báo", "Yêu cầu nhập số");
                } else
                    DialogCustom.Alert("Thông Báo", "Chưa nhập số");
            });
        }

    }
}
