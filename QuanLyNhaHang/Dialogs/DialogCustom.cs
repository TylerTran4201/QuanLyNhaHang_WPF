using QuanLyNhaHang.Dialogs;
using QuanLyNhaHang.Dialogs.Alert;
using QuanLyNhaHang.Dialogs.Service;
using QuanLyNhaHang.Dialogs.YesNo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang{
    public class DialogCustom {
        private static IDialogService _Ins;
        private static IDialogService Ins {
            get {
                if (_Ins == null) _Ins = new DialogService();
                return _Ins;
            }
            set {
                _Ins = value;
            }
        }
        public static void Alert(string title, string message) {
            Helpers.Effect.ShowBlurScreen();
            var dialog = new AlertDialogViewModel(title, message);
            var result = Ins.OpenDiaglog(dialog);
            Helpers.Effect.CloseBlurScreen();
        }
        public static DialogResults YesNo(string title, string message) {
            Helpers.Effect.ShowBlurScreen();
            var dialog = new YesNoDialogViewModel(title, message);
            var result = Ins.OpenDiaglog(dialog);
            Helpers.Effect.CloseBlurScreen();
            return result;
        }
    }
}
