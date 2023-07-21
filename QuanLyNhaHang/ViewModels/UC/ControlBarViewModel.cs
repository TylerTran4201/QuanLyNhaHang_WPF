using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyNhaHang.ViewModels {
    public class ControlBarViewModel : BaseViewModel {
        #region Command
        public ICommand CloseCommand { get; set; }
        public ICommand MiniCommand { get; set; }
        public ICommand MaxiCommand { get; set; }
        #endregion
        public ControlBarViewModel() {
            CloseCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                var w = GetWindowParent(p) as Window;
                if (w != null) {
                    App.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();
                }
            });
            MiniCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                var w = GetWindowParent(p) as Window;
                if (w != null)
                    if (w.WindowState != WindowState.Maximized)
                        w.WindowState = WindowState.Minimized;
                    else
                        w.WindowState = WindowState.Maximized;
            });
            MaxiCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                var w = GetWindowParent(p) as Window;
                if (w != null) {
                    if (w.WindowState != WindowState.Maximized)
                        w.WindowState = WindowState.Maximized;
                    else
                        w.WindowState = WindowState.Normal;
                }
            });
        }
        FrameworkElement GetWindowParent(UserControl p) {
            FrameworkElement parent = p;
            while (parent.Parent != null) {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }

    }
}
