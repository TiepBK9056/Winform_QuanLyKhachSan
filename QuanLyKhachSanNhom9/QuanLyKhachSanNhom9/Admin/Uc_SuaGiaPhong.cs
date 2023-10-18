using Nhom9_DoAnQuanLiKhachSan;
using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSanNhom9.Admin;

namespace QuanLyKhachSanNhom9.Admin
{
    public partial class Uc_SuaGiaPhong : Form
    {
        public delegate void LoadTrang(object sender, EventArgs e);
        public LoadTrang loadTrangForm;

        QLKSContextDB listgiaphong = new QLKSContextDB();
      

        public Uc_SuaGiaPhong(UC_room parent)
        {
            InitializeComponent();
          
        }

        private void Uc_SuaGiaPhong_Load(object sender, EventArgs e)
        {
            List<LoaiPhong> loaiPhongs = listgiaphong.LoaiPhongs.ToList();
            FillCBB(loaiPhongs);
            this.cmbLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            ResetFormData();
        }

        private void ResetFormData()
        {
            cmbLoaiPhong.SelectedIndex = -1;

        }
        public void FillCBB(List<LoaiPhong> loaiPhongs)
        {


            cmbLoaiPhong.DataSource = loaiPhongs;
            cmbLoaiPhong.DisplayMember = "ID_LoaiPhong";
            cmbLoaiPhong.ValueMember = "ID_LoaiPhong";


        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiPhongID = cmbLoaiPhong.SelectedValue.ToString();
                float giaMoi = float.Parse(txtgia.Text);

                LoaiPhong loaiPhong = listgiaphong.LoaiPhongs.Find(loaiPhongID);

                if (loaiPhong != null)
                {

                    loaiPhong.Gia = giaMoi;
                    listgiaphong.Entry(loaiPhong).State = EntityState.Modified;
                    listgiaphong.SaveChanges();
                    MessageBox.Show("Cập nhật giá phòng thành công!", "Thông báo", MessageBoxButtons.OK);

                    // Cập nhật giá phòng trong DataGridView của UC_room

                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại phòng cần cập nhật.", "Thông báo", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
            loadTrangForm?.Invoke(this, e);
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
