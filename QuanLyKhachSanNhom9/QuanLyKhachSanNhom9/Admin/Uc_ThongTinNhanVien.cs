using QuanLyKhachSanNhom9.Admin;
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

namespace Nhom9_DoAnQuanLiKhachSan
{
    public partial class Uc_ThongtinNhanVien : Form
    {

        QLKSContextDB ListNhanVien = new QLKSContextDB();

        public Uc_ThongtinNhanVien()
        {

            InitializeComponent();

        }



        private void Uc_ThongtinNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien> nhanViens = ListNhanVien.NhanViens.ToList();
            //List<QuanLyNhanVien> quanLyNhanViens = ListNhanVien.QuanLyNhanViens.ToList();
            List<PhongBan> phongBans = ListNhanVien.PhongBans.ToList();

            // Xóa hoặc đặt giá trị mặc định cho các TextBox sau khi Load
            // Đặt ComboBox về trạng thái mặc định
            //BindDataGridView(nhanViens);

            reload();
            //FillComboBox(phongBans);
            this.cbPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //ResetFormData();
            ResetFormData();
        }

        private void BindDataGridView(List<NhanVien> nhanViens)
        {
            dgvDanhSachNhanVien.Rows.Clear();
            foreach (var item in nhanViens)
            {
                int index = dgvDanhSachNhanVien.Rows.Add();
                dgvDanhSachNhanVien.Rows[index].Cells[0].Value = item.ID_NhanVien;
                dgvDanhSachNhanVien.Rows[index].Cells[1].Value = item.Name;
                dgvDanhSachNhanVien.Rows[index].Cells[2].Value = item.Email;
                dgvDanhSachNhanVien.Rows[index].Cells[3].Value = item.BirthDate;
                dgvDanhSachNhanVien.Rows[index].Cells[4].Value = item.PhongBan?.Name;
            }
        }

        private void FillComboBox(List<PhongBan> phongBans)
        {

            cbPhongBan.DataSource = phongBans;
            cbPhongBan.DisplayMember = "Name";
            cbPhongBan.ValueMember = "ID_PhongBan";

        }


        private int GetSelectedRow(string facultyID)
        {
            try
            {
                for (int i = 0; i < dgvDanhSachNhanVien.Rows.Count; i++)
                {
                    if (dgvDanhSachNhanVien.Rows[i].Cells[0].Value != null && dgvDanhSachNhanVien.Rows[i].Cells[0].Value.ToString() == facultyID)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }
       
      
        private void ResetFormData()
        {
            txtMNV.Clear();
            txthoten.Clear();
            cbPhongBan.SelectedIndex = -1;

            txtEmail.Clear();
            txtNgaySinh.Clear();
        }
     
        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSachNhanVien.Rows[e.RowIndex];
                txtMNV.Text = row.Cells[0].Value?.ToString();
                txthoten.Text = row.Cells[1].Value?.ToString();
                txtEmail.Text = row.Cells[2].Value?.ToString();
                txtNgaySinh.Text = row.Cells[3].Value?.ToString();
                cbPhongBan.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void quảnLíPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uc_QuanLiPhongBan c = new Uc_QuanLiPhongBan();
            c.loadTrangForm -= loadLaiTrang;
            c.loadTrangForm += loadLaiTrang;
            c.Show();
        }
        public void loadLaiTrang(object sender, EventArgs e)
        {
            reload();
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
                List<PhongBan> phongBanList = new List<PhongBan>();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"Select * from PhongBan";


                cmd.Connection = sqlCon;

                SqlDataReader reader = cmd.ExecuteReader();
                //cbPhongBan.DataSource = null;

                while (reader.Read())
                {
                    PhongBan phongBan = new PhongBan();
                    phongBan.ID_PhongBan = reader.GetValue(0).ToString(); // Giá trị từ cột 0
                    phongBan.Name = reader.GetString(1); // Hiển thị từ cột 1

                    phongBanList.Add(phongBan);
                }
                FillComboBox(phongBanList);
            }
            //LoadTrang dgv
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                dgvDanhSachNhanVien.Rows.Clear();
                cmd.CommandText = $@"Select NV.ID_NhanVien,NV.Name,NV.Email,NV.BirthDate,PB.Name
                                    from NhanVien as NV
                                    Inner join PhongBan PB on NV.ID_PhongBan =PB.ID_PhongBan ";


                cmd.Connection = sqlCon;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int selectedRow = dgvDanhSachNhanVien.Rows.Add();
                    dgvDanhSachNhanVien.Rows[selectedRow].Cells[0].Value = reader.GetValue(0);
                    dgvDanhSachNhanVien.Rows[selectedRow].Cells[1].Value = reader.GetValue(1);
                    dgvDanhSachNhanVien.Rows[selectedRow].Cells[2].Value = reader.GetValue(2);
                    dgvDanhSachNhanVien.Rows[selectedRow].Cells[3].Value = reader.GetValue(3);
                    dgvDanhSachNhanVien.Rows[selectedRow].Cells[4].Value = reader.GetValue(4);
                }
            }

        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow selectedRow in dgvDanhSachNhanVien.SelectedRows)
            {
                if (!selectedRow.IsNewRow) // Đảm bảo không xóa dòng trống
                {
                    rowsToDelete.Add(selectedRow);
                }
            }

            if (rowsToDelete.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa " + rowsToDelete.Count + " dòng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    QLKSContextDB dbContext = new QLKSContextDB();

                    foreach (DataGridViewRow row in rowsToDelete)
                    {
                        // Lấy ID của nhân viên cần xóa từ cột phù hợp trong DataGridView
                        string ID_NhanVien = row.Cells[0].Value?.ToString();

                        // Tìm nhân viên trong cơ sở dữ liệu
                        TaiKhoan taiKhoanToDelete = dbContext.TaiKhoans.FirstOrDefault(p => p.ID_NhanVien == ID_NhanVien);
                        NhanVien nhanVienToDelete = dbContext.NhanViens.FirstOrDefault(nv => nv.ID_NhanVien == ID_NhanVien);

                        if (nhanVienToDelete != null && taiKhoanToDelete != null)
                        {
                            // Xóa nhân viên khỏi cơ sở dữ liệu
                            dbContext.TaiKhoans.Remove(taiKhoanToDelete);
                            dbContext.NhanViens.Remove(nhanVienToDelete);
                        }
                    }

                    dbContext.SaveChanges();
                    ResetFormData();
                    // Cập nhật DataGridView sau khi xóa
                    List<NhanVien> nhanViens = dbContext.NhanViens.ToList();
                    BindDataGridView(nhanViens);
                }
            }
            else
            {
                MessageBox.Show("Không có dòng nào được chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu các thay đổi trong cơ sở dữ liệu
                ListNhanVien.SaveChanges();
                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách nhân viên từ cơ sở dữ liệu và cập nhật DataGridView
                List<NhanVien> nhanViens = ListNhanVien.NhanViens.ToList();
                List<PhongBan> phongBans = ListNhanVien.PhongBans.ToList();
                ResetFormData();
                BindDataGridView(nhanViens);
                MessageBox.Show("Load danh sách nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string tenNV = txthoten.Text.Trim();
                string ngaySinh = txtNgaySinh.Text.Trim();
                string maNV = txtMNV.Text.Trim();
                string phongBan = cbPhongBan.Text.Trim();

                // Tìm kiếm dựa trên các thông tin nhập vào
                List<NhanVien> nhanViens = ListNhanVien.NhanViens.Where(nv =>
                    nv.Name.Contains(tenNV) &&
                    nv.BirthDate.ToString().Contains(ngaySinh) &&
                    nv.ID_NhanVien.Contains(maNV) &&
                    nv.PhongBan.Name.Contains(phongBan)
                ).ToList();

                // Cập nhật DataGridView với kết quả tìm kiếm
                BindDataGridView(nhanViens);

                if (nhanViens.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Tìm kiếm thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try { 
                // Lấy mã nhân viên cần sửa
                string maNV = dgvDanhSachNhanVien.CurrentRow.Cells[0].Value?.ToString();

                // Tìm nhân viên trong cơ sở dữ liệu
                NhanVien nhanVienToUpdate = ListNhanVien.NhanViens.Find(maNV);

                if (nhanVienToUpdate != null)
                {
                    // Cập nhật thông tin nhân viên từ các TextBox
                    nhanVienToUpdate.Name = txthoten.Text.Trim();
                    nhanVienToUpdate.Email = txtEmail.Text.Trim();
                    nhanVienToUpdate.BirthDate = DateTime.Parse(txtNgaySinh.Text);
                    nhanVienToUpdate.PhongBan.Name = cbPhongBan.Text.Trim();

                    // Lưu các thay đổi
                    ListNhanVien.SaveChanges();

                    // Cập nhật DataGridView để hiển thị thông tin sau khi sửa
                    List<NhanVien> nhanViens = ListNhanVien.NhanViens.ToList();
                    BindDataGridView(nhanViens);

                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã này.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
