namespace QuanLyKhachSanNhom9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(12)]
        public string ID_KhachHang { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string NumberPhone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCheckIN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeCheckOut { get; set; }

        public double? TongTien { get; set; }

        [Required]
        [StringLength(12)]
        public string MaPhong { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public TimeSpan? GioVao { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
