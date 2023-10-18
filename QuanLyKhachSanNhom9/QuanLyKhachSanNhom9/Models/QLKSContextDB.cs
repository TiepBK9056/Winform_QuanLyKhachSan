using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhachSanNhom9.Models
{
    public partial class QLKSContextDB : DbContext
    {
        public QLKSContextDB()
            : base("name=QLKSContextDB2")
        {
        }

        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>()
                .Property(e => e.ID_Service)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.ID_KhachHang)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.GioVao)
                .HasPrecision(0);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.ID_LoaiPhong)
                .IsFixedLength();

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.Phongs)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ID_NhanVien)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ID_PhongBan)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<Phong>()
                .Property(e => e.ID_Phong)
                .IsFixedLength();

            modelBuilder.Entity<Phong>()
                .Property(e => e.ID_LoaiPhong)
                .IsFixedLength();

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.Phong)
                .HasForeignKey(e => e.MaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.ID_PhongBan)
                .IsFixedLength();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.ID_NhanVien)
                .IsFixedLength();

            
        }
    }
}
