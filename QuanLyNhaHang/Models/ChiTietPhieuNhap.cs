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
    
    public partial class ChiTietPhieuNhap
    {
        public int Id { get; set; }
        public string IdPhieuNhapKho { get; set; }
        public string IdMon { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> PriceInput { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<System.TimeSpan> Gio { get; set; }
    
        public virtual Mon Mon { get; set; }
        public virtual PhieuNhapKho PhieuNhapKho { get; set; }
    }
}
