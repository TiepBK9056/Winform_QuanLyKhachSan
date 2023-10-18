using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9.LeTan
{
    public partial class HoaDonNhanVien : Form
    {
        
        public HoaDonNhanVien()
        {
            InitializeComponent();
        }

        private void HoaDonNhanVien_Load(object sender, EventArgs e)
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string sql = $@"
                    SELECT dv.ID_Service AS TenDichVu, dv.Price AS Gia1SanPham, SUM(su.SoLuong) AS TongSoLuong, SUM(su.SoLuong * dv.Price) AS TongGiaTien, su.ThoiGianMua
                    FROM SuDungDichVu su
                    INNER JOIN DichVu dv ON su.ID_Service = dv.ID_Service
                    WHERE su.ID_KhachHang = N'{RoomNV.ID_KhachHang}'
                    GROUP BY dv.ID_Service, dv.Price, su.ThoiGianMua
                            ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "DanhSachDichVu");
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSanNhom9.LeTan.HoaDon.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables["DanhSachDichVu"];
                
                /////////
                
                this.reportViewer1.LocalReport.DataSources.Add(rds);
            }
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string sql = $@"
        SELECT 
            kh.Name as TenKhachHang,
            k.ID_Phong AS MaPhong,
            kh.timecheckin as NgayVao,
            kh.GioVao as GioVao,
            lp.Gia AS GiaPhong,
            lp.Gia + ISNULL(SUM(dv.Price * sddv.SoLuong), 0) AS TongTien
        FROM 
            KhachHang kh
        INNER JOIN 
            Phong k ON kh.MaPhong = k.ID_Phong
        INNER JOIN 
            LoaiPhong lp ON k.ID_LoaiPhong = lp.ID_LoaiPhong
        LEFT JOIN 
            SuDungDichVu sddv ON kh.ID_KhachHang = sddv.ID_KhachHang
        LEFT JOIN 
            DichVu dv ON sddv.ID_Service = dv.ID_Service
        WHERE 
            kh.ID_KhachHang = '{RoomNV.ID_KhachHang}'
        GROUP BY 
            kh.Name,
            kh.timecheckin,
            kh.GioVao,
            k.ID_Phong,
            lp.Gia
                ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "KhachHang");
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSanNhom9.LeTan.HoaDon.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet2";
                rds.Value = ds.Tables["KhachHang"];
                this.reportViewer1.LocalReport.DataSources.Add(rds);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
