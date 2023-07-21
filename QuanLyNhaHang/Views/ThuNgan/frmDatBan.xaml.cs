using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyNhaHang.Views.ThuNgan {
    /// <summary>
    /// Interaction logic for frmDatBan.xaml
    /// </summary>
    public partial class frmDatBan : Window {
        public frmDatBan() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DialogCustom.Alert("Thông Báo", "Chưa Phát Triển");
        }
    }
}
