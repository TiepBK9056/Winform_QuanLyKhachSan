namespace QuanLyKhachSanNhom9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(40)]
        public string AcountName { get; set; }

        [Required]
        [StringLength(40)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string AcoountType { get; set; }

        [StringLength(30)]
        public string ID_NhanVien { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
