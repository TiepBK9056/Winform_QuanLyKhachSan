using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyKhachSanNhom9.Models;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9
{
    public partial class BuonPhongMain : Form
    {
        QLKSContextDB DBContext = new QLKSContextDB();
        public BuonPhongMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSoPhongSuaChua.Text = dgvQLTTPhong.RowCount.ToString() + " " + "phòng cần dọn dẹp";
            try
            {
                List<Phong> phongs = DBContext.Phongs.ToList();
                BindGrid(phongs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BindGrid(List<Phong> phongs)
        {
            dgvQLTTPhong.Rows.Clear();
            var filteredPhongs = phongs.Where(s => s.TrangThai.Contains("Sửa"));
            foreach (var item in filteredPhongs)
            {
                int index = dgvQLTTPhong.Rows.Add();
                dgvQLTTPhong.Rows[index].Cells[0].Value = item.ID_Phong;
                dgvQLTTPhong.Rows[index].Cells[1].Value = item.ID_LoaiPhong;
                dgvQLTTPhong.Rows[index].Cells[2].Value = item.TrangThai;
            }
            txtSoPhongSuaChua.Text = dgvQLTTPhong.RowCount.ToString() + " " + "phòng cần dọn dẹp";
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsoPhong.Text))
            {
                if(MessageBox.Show("Xác nhận hoàn thành công việc phòng" + txtsoPhong.Text, "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }    
                string sophong = txtsoPhong.Text;
                Phong phong = DBContext.Phongs.FirstOrDefault(p => p.ID_Phong == sophong);
                if (phong != null)
                {
                    phong.TrangThai = "Trống";
                    DBContext.SaveChanges();
                    MessageBox.Show("Đã cập nhật trạng thái phòng thành Trống.");
                    List<Phong> phongs = DBContext.Phongs.ToList();
                    BindGrid(phongs);
                }
                else
                {
                    MessageBox.Show("Phòng không tồn tại trong cơ sở dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!");
            }
        }

       


        

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            string sophong = new string(txtsoPhong.Text.Where(char.IsDigit).ToArray());
            txtsoPhong.Text = sophong;
            txtsoPhong.SelectionStart = txtsoPhong.Text.Length; // Đặt con trỏ văn bản vào cuối TextBox

            var filteredPhongs = DBContext.Phongs.Where(p => p.ID_Phong.Contains(sophong)).ToList();
            BindGrid(filteredPhongs);
        }

        private void dgvQLTTPhong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvQLTTPhong.CurrentCell.RowIndex;
            if (e.RowIndex >= 0)
            {
                txtsoPhong.Text = dgvQLTTPhong.Rows[index].Cells[0].Value.ToString().Trim();
                txtMaPhong.Text = dgvQLTTPhong.Rows[index].Cells[1].Value.ToString().Trim();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
