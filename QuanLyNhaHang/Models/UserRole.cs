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

    public partial class UserRole : INotifyPropertyChanged {
        private Nullable<int> _Status;

        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public string MaGiamSat { get; set; }
        public Nullable<int> Status { get { return _Status; } set { _Status = value; OnPropertyChanged("Status"); } }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ModifiedAt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
