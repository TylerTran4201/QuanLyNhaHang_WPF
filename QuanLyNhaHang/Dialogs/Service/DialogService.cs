using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Dialogs.Service {
    public class DialogService : IDialogService {
        public T OpenDiaglog<T>(DialogViewModelBase<T> viewmodel) {
            IDialogWindow window = new DialogWindow();
            window.DataContext = viewmodel;
            window.ShowDialog();
            return viewmodel.DialogResult;

        }
    }
}
