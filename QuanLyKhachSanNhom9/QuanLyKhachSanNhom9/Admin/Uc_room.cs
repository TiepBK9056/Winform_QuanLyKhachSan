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
using System.Windows.Data;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Nhom9_DoAnQuanLiKhachSan
{
    public partial class UC_room : Form
    {
        QLKSContextDB khachsan = new QLKSContextDB();

        public UC_room()
        {
            InitializeComponent();




        }

        private void ResetFormData()
        {
           /* txtMaPhong.Clear();
            cmbLoaiPhong.SelectedIndex = -1;*/
            cbtimloaiphong.SelectedIndex = -1;

        }
        private void UC_room_Load(object sender, EventArgs e)   //sửa lại để liên kết với database
        {
            List<LoaiPhong> loaiPhongs = khachsan.LoaiPhongs.ToList();
            dgvbanggialoaiphong.Rows.Clear();

            // Retrieve the data from the LoaiPhong table
            foreach (var loaiPhong in loaiPhongs)
            {
                int index = dgvbanggialoaiphong.Rows.Add();
                dgvbanggialoaiphong.Rows[index].Cells[0].Value = loaiPhong.ID_LoaiPhong;
                dgvbanggialoaiphong.Rows[index].Cells[1].Value = loaiPhong.Gia;
            }

            List<Phong> phongs = khachsan.Phongs.ToList();
            BindDataGridView(phongs);
            List<LoaiPhong> loais = khachsan.LoaiPhongs.ToList();
            FillComboBox1(loaiPhongs);
            FillComboBox2(loais);
            this.cbtimloaiphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //this.cmbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            ResetFormData();

            reload();


        }





        private void BindDataGridView(List<Phong> phongs)
        {
            dgvDSPhong.Rows.Clear();
            foreach (var phong in phongs)
            {
                int index = dgvDSPhong.Rows.Add();
                dgvDSPhong.Rows[index].Cells[0].Value = phong.ID_Phong;
                dgvDSPhong.Rows[index].Cells[1].Value = phong.LoaiPhong?.ID_LoaiPhong;
                //  dgvDSPhong.Rows[index].Cells[2].Value = phong.LoaiPhong?.Gia;
            }
        }


        private void FillComboBox1(List<LoaiPhong> loaiPhongs)
        {
            /*cmbLoaiPhong.DataSource = loaiPhongs;
            cmbLoaiPhong.DisplayMember = "ID_LoaiPhong";
            cmbLoaiPhong.ValueMember = "ID_LoaiPhong";*/


        }

        private void FillComboBox2(List<LoaiPhong> loais)
        {
            cbtimloaiphong.DataSource = loais;
            cbtimloaiphong.DisplayMember = "ID_LoaiPhong";
            cbtimloaiphong.ValueMember = "ID_LoaiPhong";


        }


        private int GetSelectedRow(string MaPhong)
        {
            try
            {
                for (int i = 0; i < dgvDSPhong.Rows.Count; i++)
                {
                    if (dgvDSPhong.Rows[i].Cells[0].Value != null && dgvDSPhong.Rows[i].Cells[0].Value.ToString() == MaPhong)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }


        private void txtMaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }



        private void dgvDSPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSPhong.Rows[e.RowIndex];
                //txtMaPhong.Text = row.Cells[0].Value.ToString();
                //cmbLoaiPhong.SelectedValue = row.Cells[1].Value.ToString();
                //txtgia.Text = row.Cells[2].Value.ToString();
            }
        }

        /*private void btthem_Click(object sender, EventArgs e)
        {
            QLKSContextDB s = new QLKSContextDB();
            try
            {
                *//*if (string.IsNullOrWhiteSpace(txtMaPhong.Text) || cmbLoaiPhong.SelectedItem == null)
                    throw new Exception("Vui lòng nhập đầy đủ thông tin phòng!");

                string maPhong = txtMaPhong.Text.Trim();
                string loaiPhongID = cmbLoaiPhong.SelectedValue.ToString();*//*

                // Kiểm tra và chuyển đổi giá thành kiểu dữ liệu float
                //  if (!float.TryParse(txtgia.Text, out float giaPhong))
                //    throw new Exception("Giá phòng không hợp lệ!");


                //int selectedRow = GetSelectedRow(maPhong);

                if (selectedRow == -1)
                {
                    // Add new room
                    Phong newRoom = new Phong
                    {
                        //ID_Phong = maPhong.PadRight(10),
                        //ID_LoaiPhong = loaiPhongID.PadRight(10),
                        TrangThai = "Trống", // Thiết lập trạng thái mặc định (hoặc thay đổi trạng thái theo yêu cầu)
                                             //     Gia = giaPhong
                    };


                    khachsan.Phongs.Add(newRoom);
                    khachsan.SaveChanges();
                    List<Phong> phongs = khachsan.Phongs.ToList();
                    BindDataGridView(phongs);
                    // Sau khi thêm mới, cập nhật lại DataGridView

                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }*/

        /*private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhong.Text) || cmbLoaiPhong.SelectedItem == null)
                    throw new Exception("Vui lòng nhập đầy đủ thông tin phòng!");

                // Lấy mã phòng và loại phòng đã chọn
                string maPhong = txtMaPhong.Text.Trim();
                string loaiPhongID = cmbLoaiPhong.SelectedValue.ToString();

                // Kiểm tra xem phòng có tồn tại trong cơ sở dữ liệu không
                Phong selectedRoom = khachsan.Phongs.Find(maPhong.PadRight(10));
                if (selectedRoom == null)
                {
                    MessageBox.Show("Không tìm thấy phòng với mã này.", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                // Kiểm tra xem loại phòng đã chọn có khác với loại phòng hiện tại của phòng hay không
                if (selectedRoom.ID_LoaiPhong != loaiPhongID.PadRight(10))
                {
                    // Nếu khác, thực hiện cập nhật loại phòng và giá phòng
                    // Lấy giá mới từ nguồn dữ liệu
                    float newPrice = (float)selectedRoom.LoaiPhong.Gia;

                    // Cập nhật giá và loại phòng mới cho phòng đã chọn
                    selectedRoom.ID_LoaiPhong = loaiPhongID.PadRight(10);
                    selectedRoom.LoaiPhong.Gia = newPrice;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    khachsan.SaveChanges();

                    // Cập nhật DataGridView để hiển thị thông tin mới
                    List<Phong> phongs = khachsan.Phongs.ToList();
                    BindDataGridView(phongs);

                    MessageBox.Show("Cập nhật loại phòng và mã phòng thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    // Nếu loại phòng không thay đổi, thông báo không thực hiện sự thay đổi
                    MessageBox.Show("Không có sự thay đổi về loại phòng.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reload();
        }
*/
        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected room's ID from the DataGridView
                string selectedRoomID = dgvDSPhong.CurrentRow.Cells[0].Value.ToString();

                // Retrieve the room details from the database
                Phong selectedRoom = khachsan.Phongs.Find(selectedRoomID);

                if (selectedRoom != null)
                {
                    // Confirm with the user before deleting the room
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Remove the room from the database
                        khachsan.Phongs.Remove(selectedRoom);
                        khachsan.SaveChanges();

                        // Update the DataGridView to reflect the changes
                        List<Phong> phongs = khachsan.Phongs.ToList();
                        BindDataGridView(phongs);
                        List<LoaiPhong> loaiPhongs = khachsan.LoaiPhongs.ToList();
                        //    PopulateLoaiPhongDataGridView(loaiPhongs);

                        MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng với mã này.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reload();
        }


        private void btsearch_Click(object sender, EventArgs e)
        {
            

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
           // string strCon = @"Data Source=DESKTOP-2PG7N07;Initial Catalog=Quanlikhachsan;Integrated Security=True";
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"Select * from LoaiPhong";
                dgvbanggialoaiphong.Rows.Clear();

                cmd.Connection = sqlCon;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int index = dgvbanggialoaiphong.Rows.Add();
                    dgvbanggialoaiphong.Rows[index].Cells[0].Value = reader.GetString(0);
                    dgvbanggialoaiphong.Rows[index].Cells[1].Value = reader.GetValue(1).ToString();
                }
                reader.Close();
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<Phong> phongs = khachsan.Phongs.ToList();
            BindDataGridView(phongs);
        }

        private void btnSuaGia_Click(object sender, EventArgs e)
        {
            UC_room parent = new UC_room();
            Uc_SuaGiaPhong childForm = new Uc_SuaGiaPhong(parent);
            childForm.loadTrangForm -= loadLaiTrang;
            childForm.loadTrangForm += loadLaiTrang;
            childForm.ShowDialog();
           
        }
        public void loadLaiTrang(object sender, EventArgs e)
        {
            reload();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textnhaptimkiem.Text.Trim();
                string loaiPhongSearchText = cbtimloaiphong.Text.Trim();

                // Lấy danh sách tất cả các phòng
                List<Phong> allPhongs = khachsan.Phongs.ToList();

                if (!string.IsNullOrWhiteSpace(searchText) && !string.IsNullOrWhiteSpace(loaiPhongSearchText))
                {
                    // Tìm kiếm theo cả ID_Phong và Loại phòng
                    List<Phong> matchedPhongs = allPhongs
                        .Where(p => p.ID_Phong.Contains(searchText) && p.LoaiPhong.ID_LoaiPhong.Contains(loaiPhongSearchText))
                        .ToList();

                    // Cập nhật DataGridView với kết quả tìm kiếm
                    BindDataGridView(matchedPhongs);

                    if (matchedPhongs.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(searchText))
                {
                    // Tìm kiếm theo ID_Phong
                    List<Phong> matchedPhongs = allPhongs
                        .Where(p => p.ID_Phong.Contains(searchText))
                        .ToList();

                    // Cập nhật DataGridView với kết quả tìm kiếm
                    BindDataGridView(matchedPhongs);

                    if (matchedPhongs.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào theo ID phòng.", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(loaiPhongSearchText))
                {
                    // Tìm kiếm theo Loại phòng
                    List<Phong> matchedPhongs = allPhongs
                        .Where(p => p.LoaiPhong.ID_LoaiPhong.Contains(loaiPhongSearchText))
                        .ToList();

                    // Cập nhật DataGridView với kết quả tìm kiếm
                    BindDataGridView(matchedPhongs);

                    if (matchedPhongs.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào theo loại phòng.", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // Hiển thị toàn bộ danh sách phòng
                    BindDataGridView(allPhongs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reload();
        }
    }
}
