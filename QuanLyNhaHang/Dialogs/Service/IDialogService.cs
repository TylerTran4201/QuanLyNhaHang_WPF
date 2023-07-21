using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Dialogs.Service
{
    public interface IDialogService
    {
        T OpenDiaglog<T>(DialogViewModelBase<T> viewmodel);
    }
}
