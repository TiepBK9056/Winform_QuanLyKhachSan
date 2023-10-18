namespace QuanLyKhachSanNhom9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [Key]
        [StringLength(12)]
        public string ID_Service { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public float Price { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
