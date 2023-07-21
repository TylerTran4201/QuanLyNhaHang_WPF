//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class HoaDon : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            this.ChiTietHoaDonTemps = new HashSet<ChiTietHoaDonTemp>();
            this.LichSuHoaDonThanhToans = new HashSet<LichSuHoaDonThanhToan>();
            this.LuuKhuyenMais = new HashSet<LuuKhuyenMai>();
        }
        private ICollection<ChiTietHoaDon> _ChiTietHoaDons;
        private Nullable<int> _ThanhTien;
        public string Id { get; set; }
        public string IdBan { get; set; }
        public int IdCa { get; set; }
        public System.DateTime Ngay { get; set; }
        public Nullable<System.TimeSpan> GioVao { get; set; }
        public Nullable<System.TimeSpan> GioRa { get; set; }
        public Nullable<int> PhuThu { get; set; }
        public string GhiChuPhuThu { get; set; }
        public Nullable<int> GiamGiaTheoPhanTram { get; set; }
        public Nullable<int> GiamGiaTheoTien { get; set; }
        public Nullable<int> SoTienKhachDua { get; set; }
        public Nullable<int> SoTienTraLai { get; set; }
        public string GhiChuKhachHang { get; set; }
        public Nullable<int> ThanhTien { get { return _ThanhTien; } set { _ThanhTien = value; OnPropertyChanged("ThanhTien"); } }
        public Nullable<int> TienNo { get; set; }
        public Nullable<int> ThanhTienThucThu { get; set; }
        public int IdUser { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> LanIn { get; set; }
        public Nullable<int> TinhTrangGiaoCa { get; set; }
        public Nullable<int> MaLSBGC { get; set; }

        public virtual Ban Ban { get; set; }
        public virtual Ca Ca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get { return _ChiTietHoaDons; } set { _ChiTietHoaDons = value; OnPropertyChanged("ChiTietHoaDons"); } }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonTemp> ChiTietHoaDonTemps { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuHoaDonThanhToan> LichSuHoaDonThanhToans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuKhuyenMai> LuuKhuyenMais { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
