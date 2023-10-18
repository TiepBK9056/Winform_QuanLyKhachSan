using QuanLyKhachSanNhom9.Admin;
using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Nhom9_DoAnQuanLiKhachSan
{
    public partial class Uc_DanhSachDichVu : Form
    {
        QLKSContextDB listdichvu = new QLKSContextDB();
        public Uc_DanhSachDichVu()
        {
            InitializeComponent();
        }

        private void Uc_DanhSachDichVu_Load(object sender, EventArgs e)
        {
            List<DichVu> dichVus = listdichvu.DichVus.ToList();
            BingGridDataView(dichVus);
            reload();
        }

        public void BingGridDataView(List<DichVu> dichVus)
        {
            dgvdichvu.Rows.Clear();
            foreach (var item in dichVus)
            {
                int index = dgvdichvu.Rows.Add();
                dgvdichvu.Rows[index].Cells[0].Value = item.ID_Service;
                dgvdichvu.Rows[index].Cells[1].Value = item.Name;
                dgvdichvu.Rows[index].Cells[2].Value = item.Price;
                // Kiểm tra xem có đường dẫn hình ảnh không


            }

        }








        private void btsuathongtin_Click(object sender, EventArgs e)
        {
            Uc_SuaThongTinDIchVu c = new Uc_SuaThongTinDIchVu();
            c.loadTrangForm -= loadLaiTrang;
            c.loadTrangForm += loadLaiTrang;
            c.ShowDialog();
        }

        public void loadLaiTrang(object sender, EventArgs e)
        {
            reload();
        }

   

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            // Lấy chuỗi tìm kiếm từ TextBox searchdanhsachDV
            string searchString = searchdanhsachDV.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchString))
            {
                // Nếu chuỗi tìm kiếm trống, hiển thị tất cả dữ liệu
                List<DichVu> dichVus = listdichvu.DichVus.ToList();
                BingGridDataView(dichVus);
            }
            else
            {
                // Tạo một danh sách kết quả tìm kiếm không phân biệt chữ hoa chữ thường
                List<DichVu> searchResults = listdichvu.DichVus
                    .Where(d => d.Name != null && d.Name.ToLower().Contains(searchString))
                    .ToList();

                // Hiển thị kết quả tìm kiếm trong DataGridView
                BingGridDataView(searchResults);

                // Nếu không tìm thấy kết quả, hiển thị thông báo
                if (searchResults.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void reload()
        {/*
            List<LoaiPhong> loaiPhongs = khachsan.LoaiPhongs.ToList();
            dgvbanggialoaiphong.Rows.Clear();

            // Retrieve the data from the LoaiPhong table
            foreach (var loaiPhong in loaiPhongs)
            {
                int index = dgvbanggialoaiphong.Rows.Add();
                dgvbanggialoaiphong.Rows[index].Cells[0].Value = loaiPhong.ID_LoaiPhong;
                dgvbanggialoaiphong.Rows[index].Cells[1].Value = loaiPhong.Gia;
            }*/
            //string strCon = @"Data Source=DESKTOP-2PG7N07;Initial Catalog=Quanlikhachsan;Integrated Security=True";
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"Select * from DichVu";
                dgvdichvu.Rows.Clear();

                cmd.Connection = sqlCon;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int index = dgvdichvu.Rows.Add();
                    dgvdichvu.Rows[index].Cells[0].Value = reader.GetString(0);
                    dgvdichvu.Rows[index].Cells[1].Value = reader.GetValue(1).ToString();
                    dgvdichvu.Rows[index].Cells[2].Value = reader.GetValue(2).ToString();
                }
                reader.Close();
            }

        }
      

        private void searchdanhsachDV_Click(object sender, EventArgs e)
        {
            searchdanhsachDV.Clear(); // Xóa nội dung trong TextBox
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            List<DichVu> dichVus = listdichvu.DichVus.ToList();
            BingGridDataView(dichVus);
            MessageBox.Show("Dữ liệu đã được tải thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng form này không?", "Xác nhận đóng form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

