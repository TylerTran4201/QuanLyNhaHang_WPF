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
    
    public partial class Ca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ca()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.HuyMons = new HashSet<HuyMon>();
            this.LuuKhuyenMais = new HashSet<LuuKhuyenMai>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.TimeSpan ThoiGianBatDau { get; set; }
        public System.TimeSpan ThoiGianKetThuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HuyMon> HuyMons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuKhuyenMai> LuuKhuyenMais { get; set; }
    }
}
