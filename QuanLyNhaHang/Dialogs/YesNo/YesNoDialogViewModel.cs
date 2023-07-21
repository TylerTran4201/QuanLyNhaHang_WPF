using QuanLyNhaHang.Dialogs.Service;
using QuanLyNhaHang.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyNhaHang.Dialogs.YesNo {
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResults> {
        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }
        public YesNoDialogViewModel(string message, string title) : base(message, title) {
            YesCommand = new RelayCommand<IDialogWindow>((p)=>true, (p)=>Yes(p));
            NoCommand = new RelayCommand<IDialogWindow>((p) => true, (p) => No(p));
        }
        private void Yes(IDialogWindow window) {
            CloseDialogWithResult(window, DialogResults.Yes);
        }
        private void No(IDialogWindow window) {
            CloseDialogWithResult(window, DialogResults.No);
        }
    }
}
