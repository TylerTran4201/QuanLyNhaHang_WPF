using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class ChiViewModel : BaseViewModel {
        #region Command
        public ICommand LoadedCommand { get; set; }
        public ICommand ThemCommand { get; set; }
        #endregion
        public ChiViewModel() {
            LoadedCommand = new RelayCommand<object>((p) => true, (p) => {

            });

        }
    }
}
