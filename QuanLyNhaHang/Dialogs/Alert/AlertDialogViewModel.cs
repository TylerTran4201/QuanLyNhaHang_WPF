using QuanLyNhaHang.Dialogs.Service;
using QuanLyNhaHang.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.Dialogs.Alert {
    public class AlertDialogViewModel : DialogViewModelBase<DialogResults> {
        public ICommand OKCommand { get; private set;}
        public AlertDialogViewModel(string title, string message):base(title, message) {
            OKCommand = new RelayCommand<IDialogWindow>((p)=>true, (p)=>OK(p));
        }
        private void OK(IDialogWindow window) {
            CloseDialogWithResult(window, DialogResults.Undefined);
        }
    }
}
