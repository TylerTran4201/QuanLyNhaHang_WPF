using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyNhaHang.Models
{
    public class DataProvider {
        private static DataProvider _Ins;
        public static DataProvider Ins {
            get {
                if (_Ins == null) _Ins = new DataProvider();
                return _Ins;
            }
            set {
                _Ins = value;
            }
        } // singleton
        public QuanLyNhaHangEntities DB { get; set; }

        private DataProvider() {
            DB = new QuanLyNhaHangEntities();
        }
        public static void SaveDatabase() {
            try {
                Ins.DB.SaveChanges();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
