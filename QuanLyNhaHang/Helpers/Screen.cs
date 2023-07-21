using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Helpers {
    public class Effect {
        public static BlurBackground blurBackground = new BlurBackground();
        public static void ShowBlurScreen() {
            blurBackground.Background = "Black";
            blurBackground.Opacity = 0.3;
        }
        public static void CloseBlurScreen() {
            blurBackground.Background = "Transparent";
            blurBackground.Opacity = 1;
        }
    }
    public class BlurBackground : INotifyPropertyChanged {
        private double _Opacity;
        private string _Background;

        public double Opacity { get { return _Opacity; } set { _Opacity = value; OnPropertyChanged("Opacity"); } }
        public string Background { get { return _Background; } set { _Background = value; OnPropertyChanged("Background"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public BlurBackground() {
            this.Background = "Transparent";
            this.Opacity = 1;
        }
    }
}
