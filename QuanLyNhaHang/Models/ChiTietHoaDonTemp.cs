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
    
    public partial class ChiTietHoaDonTemp
    {
        public int Id { get; set; }
        public string IdHoaDon { get; set; }
        public string IdMon { get; set; }
        public double Quantity { get; set; }
        public double QuantityTemp { get; set; }
        public double PriceBan { get; set; }
        public double Amount { get; set; }
        public int isGift { get; set; }
        public string CachThucKhuyenMai { get; set; }
        public string GhiChu { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual Mon Mon { get; set; }
    }
}