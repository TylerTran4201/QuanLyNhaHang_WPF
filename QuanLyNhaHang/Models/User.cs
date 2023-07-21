//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyNhaHang.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class User : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User() {
            this.HoaDons = new HashSet<HoaDon>();
            this.HuyMons = new HashSet<HuyMon>();
            this.LuuKhuyenMais = new HashSet<LuuKhuyenMai>();
            this.PhieuNhapKhoes = new HashSet<PhieuNhapKho>();
            this.UserFeatures = new HashSet<UserFeature>();
            this.UserRoles = new HashSet<UserRole>();
        }

        private int _Id;
        private string _Name;
        private string _UserName;
        private string _Password;
        private string _CMND;
        private string _Phone;
        private string _Email;
        private string _Address;
        private int _Status;
        private Nullable<System.DateTime> _CreatedAt;
        private Nullable<System.DateTime> _ModifiedAt;

        public int Id {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }

        public string Name {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
        }
        public string UserName {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged("UserName"); }
        }
        public string Password {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged("Password"); }
        }
        public string CMND {
            get  { return _CMND; }
            set { _CMND = value; OnPropertyChanged("CMND"); }
        }
        public string Phone {
            get  { return _Phone; }
            set { _Phone = value; OnPropertyChanged("Phone"); }
        }
        public string Email {
            get  { return _Email; }
            set { _Email = value; OnPropertyChanged("Email"); }
        }
        public string Address {
            get  { return _Address; }
            set { _Address = value; OnPropertyChanged("Address"); }
        }
        public int Status {
            get { return _Status; }
            set { _Status = value; OnPropertyChanged("Status"); }
        }
        public Nullable<System.DateTime> CreatedAt {
            get { return _CreatedAt; }
            set { _CreatedAt = value; OnPropertyChanged("CreatedAt"); }
        }
        public Nullable<System.DateTime> ModifiedAt {
            get  { return _ModifiedAt; }
            set { _ModifiedAt = value; OnPropertyChanged("ModifiedAt"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HuyMon> HuyMons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuuKhuyenMai> LuuKhuyenMais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapKho> PhieuNhapKhoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFeature> UserFeatures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
