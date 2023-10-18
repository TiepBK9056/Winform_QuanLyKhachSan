namespace QuanLyKhachSanNhom9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        [StringLength(12)]
        public string ID_Phong { get; set; }

        [Required]
        [StringLength(12)]
        public string ID_LoaiPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}
