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

    public partial class TableType : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableType() {
            this.Bans = new HashSet<Ban>();
        }
        private string _Id;
        private string _Name;
        private int _Status;
        private Nullable<System.DateTime> _CreatedAt;
        private Nullable<System.DateTime> _ModifiedAt;
        public string Id {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }
        public string Name {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
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
            get { return _ModifiedAt; }
            set { _ModifiedAt = value; OnPropertyChanged("ModifiedAt"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ban> Bans { get; set; }
    }
}
