
using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9.KeToan
{
    public partial class Tongdoanhthu : Form
    {
        static QLKSContextDB context = new QLKSContextDB();
        List<DichVu> dichVu = context.DichVus.ToList();
        List<KhachHang> khachHangs = context.KhachHangs.ToList();
        List<Phong> phongs = context.Phongs.ToList();
        List<LoaiPhong> loais = context.LoaiPhongs.ToList();

        public Tongdoanhthu()
        {
            InitializeComponent();
            BindToGridView(khachHangs);

        }
        private void btnDoanhthutong_Click(object sender, EventArgs e)
        {
            /* // Tạo một instance mới của Form2
             Baocaodoanhthu form = new Baocaodoanhthu();

             // Hiển thị Form2
             form.Show();

             // Ẩn Form1
             this.Hide();*/

        }

        public void BindToGridView(List<KhachHang> khachHangs)
        {
            dgvDoanhThu.Rows.Clear();
            foreach (var item in khachHangs)
            {
                int index = dgvDoanhThu.Rows.Add();
                dgvDoanhThu.Rows[index].Cells[0].Value = index + 1;
                dgvDoanhThu.Rows[index].Cells[1].Value = item.Name;
                dgvDoanhThu.Rows[index].Cells[2].Value = item.MaPhong;
                dgvDoanhThu.Rows[index].Cells[3].Value = item.TimeCheckIN;
                dgvDoanhThu.Rows[index].Cells[4].Value = item.TimeCheckOut;
                dgvDoanhThu.Rows[index].Cells[5].Value = tinhTienPhong(item.MaPhong);
                dgvDoanhThu.Rows[index].Cells[6].Value = tinhTienDichVu(item.ID_KhachHang, item.MaPhong);
                dgvDoanhThu.Rows[index].Cells[7].Value = tinhTongTien(item.ID_KhachHang, item.MaPhong);
            }
        }
        public double tinhTienPhong(string maphong)
        {
            return 0;
        }


        public double tinhTienDichVu(string idKhachHang, string maPhong)
        {

            double tongTien = tinhTongTien(idKhachHang, maPhong);
            double tienPhong = tinhTienPhong(idKhachHang);

            double tienDichVu = tongTien - tienPhong;

            return tienDichVu;
        }

        public double tinhTongTien(string idKhachHang, string maPhong)
        {
            var khachHang = context.KhachHangs.FirstOrDefault(kh => kh.ID_KhachHang.Equals(idKhachHang));
            double tongTien = 0;

            if (khachHang != null && khachHang.TimeCheckOut != null)
            {
                tongTien = khachHang.TongTien ?? 0; // Lấy giá trị tổng tiền từ trường TongTien của đối tượng KhachHang
            }
            return tongTien;
        }


        public void TinhTongDoanhThu()
        {
            double tongDoanhThu = 0;

            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                if (row.Cells[7].Value != null)
                {
                    double giaTri;
                    if (double.TryParse(row.Cells[7].Value.ToString(), out giaTri))
                    {
                        tongDoanhThu += giaTri;
                    }
                }
            }
            txtTongTien.Text = tongDoanhThu.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            /*if (ckbThang.Checked)
            {
                var khachHangList = context.KhachHangs.ToList();
                BindToGridView(khachHangList);
            }
            else
            {
                DateTime startTime = dtpNgayBatDau.Value.Date;
                DateTime endTime = dtpNgayKetThuc.Value.Date.AddDays(1).AddSeconds(-1);
                var khachHangList = context.KhachHangs.Where(kh => kh.TimeCheckOut >= startTime && kh.TimeCheckOut <= endTime).ToList();
                BindToGridView(khachHangList);
            }
            TinhTongDoanhThu();*/
            if (ckbThang.Checked)
            {
                using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
                {
                    sqlCon.Open();
                    string date1 = DateTime.Now.ToString("yyyy/MM/dd");

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"
                        select kh.Name, kh.MaPhong ,kh.TimeCheckIN, kh.TimeCheckOut, lp.Gia, (kh.TongTien - lp.Gia) as TienDichVu, kh.TongTien
                        from KhachHang as kh
                        INner join Phong p on kh.MaPhong = P.ID_Phong
                        INner join LoaiPhong lp on lp.ID_LoaiPhong = p.ID_LoaiPhong
                        WHERE kh.TimeCheckOut IS NOT NULL AND MONTH(kh.TimeCheckOut) = MONTH('{date1}')
                            ";
                    cmd.Connection = sqlCon;
                    SqlDataReader reader = cmd.ExecuteReader();

                    int dem = 1;
                    dgvDoanhThu.Rows.Clear();
                    while (reader.Read())
                    {
                        int index = dgvDoanhThu.Rows.Add();
                        dgvDoanhThu.Rows[index].Cells[0].Value = dem.ToString();
                        dgvDoanhThu.Rows[index].Cells[1].Value = reader.GetValue(0);
                        dgvDoanhThu.Rows[index].Cells[2].Value = reader.GetValue(1);
                        dgvDoanhThu.Rows[index].Cells[3].Value = reader.GetValue(2);
                        dgvDoanhThu.Rows[index].Cells[4].Value = reader.GetValue(3);
                        dgvDoanhThu.Rows[index].Cells[5].Value = reader.GetValue(4);
                        dgvDoanhThu.Rows[index].Cells[6].Value = reader.GetValue(5);
                        dgvDoanhThu.Rows[index].Cells[7].Value = reader.GetValue(6);
                        dem++;
                    }
                }
            }
            else
                loadDuLieu();
            TinhTongDoanhThu();
        }
        private void loadDuLieu()
        {
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string date1 = dtpNgayBatDau.Value.ToString("yyyy/MM/dd");
                string date2 = dtpNgayKetThuc.Value.ToString("yyyy/MM/dd");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"
                        select kh.Name, kh.MaPhong ,kh.TimeCheckIN, kh.TimeCheckOut, lp.Gia, (kh.TongTien - lp.Gia) as TienDichVu, kh.TongTien
                        from KhachHang as kh
                        INner join Phong p on kh.MaPhong = P.ID_Phong
                        INner join LoaiPhong lp on lp.ID_LoaiPhong = p.ID_LoaiPhong
                        where kh.TimeCheckOut IS NOT NULL AND kh.TimeCheckOut >= '{date1}'  AND kh.TimeCheckOut <= '{date2}'
                            ";
                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();

                int dem = 1;
                dgvDoanhThu.Rows.Clear();
                while (reader.Read())
                {
                    int index = dgvDoanhThu.Rows.Add();
                    dgvDoanhThu.Rows[index].Cells[0].Value = dem.ToString();
                    dgvDoanhThu.Rows[index].Cells[1].Value = reader.GetValue(0);
                    dgvDoanhThu.Rows[index].Cells[2].Value = reader.GetValue(1);
                    dgvDoanhThu.Rows[index].Cells[3].Value = reader.GetValue(2);
                    dgvDoanhThu.Rows[index].Cells[4].Value = reader.GetValue(3);
                    dgvDoanhThu.Rows[index].Cells[5].Value = reader.GetValue(4);
                    dgvDoanhThu.Rows[index].Cells[6].Value = reader.GetValue(5);
                    dgvDoanhThu.Rows[index].Cells[7].Value = reader.GetValue(6);
                    dem++;
                }
            }
        }


        private void Tongdoanhthu_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string date1 = dtpNgayBatDau.Value.ToString("yyyy/MM/dd");
                string date2 = dtpNgayKetThuc.Value.ToString("yyyy/MM/dd");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"
                        select kh.Name, kh.MaPhong ,kh.TimeCheckIN, kh.TimeCheckOut, lp.Gia, (kh.TongTien - lp.Gia) as TienDichVu, kh.TongTien
                        from KhachHang as kh
                        INner join Phong p on kh.MaPhong = P.ID_Phong
                        INner join LoaiPhong lp on lp.ID_LoaiPhong = p.ID_LoaiPhong
                        where kh.TimeCheckOut IS NOT NULL
                            ";
                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();

                int dem = 1;
                dgvDoanhThu.Rows.Clear();
                while (reader.Read())
                {
                    int index = dgvDoanhThu.Rows.Add();
                    dgvDoanhThu.Rows[index].Cells[0].Value = dem.ToString();
                    dgvDoanhThu.Rows[index].Cells[1].Value = reader.GetValue(0);
                    dgvDoanhThu.Rows[index].Cells[2].Value = reader.GetValue(1);
                    dgvDoanhThu.Rows[index].Cells[3].Value = reader.GetValue(2);
                    dgvDoanhThu.Rows[index].Cells[4].Value = reader.GetValue(3);
                    dgvDoanhThu.Rows[index].Cells[5].Value = reader.GetValue(4);
                    dgvDoanhThu.Rows[index].Cells[6].Value = reader.GetValue(5);
                    dgvDoanhThu.Rows[index].Cells[7].Value = reader.GetValue(6);
                    dem++;
                }
            }
            TinhTongDoanhThu();
        }
        private void Tongdoanhthu_Load(object sender, EventArgs e)
        {
            TinhTongDoanhThu();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }    
        }
    }
}
