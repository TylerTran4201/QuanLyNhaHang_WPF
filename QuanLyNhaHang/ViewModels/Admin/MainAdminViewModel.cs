using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class MainAdminViewModel : BaseViewModel {
        #region Background
        private Helpers.BlurBackground _screen;
        public Helpers.BlurBackground screen { get { return _screen; }set { _screen = value; OnPropertyChanged(nameof(screen)); } }
        #endregion
        public MainAdminViewModel() {
            screen = Helpers.Effect.blurBackground;
        }
    }
}
