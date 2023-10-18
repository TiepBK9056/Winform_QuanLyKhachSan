
using QuanLyKhachSanNhom9;
using QuanLyKhachSanNhom9.Admin;
using QuanLyKhachSanNhom9.DangNhap;
using QuanLyKhachSanNhom9.LeTan;
using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom9_DoAnQuanLiKhachSan
{

    public partial class giaodienchinh : Form
    {
        private DangKy dangKy;
        private Uc_DanhSachDichVu danhSachDichVu;
        private Uc_ThongtinNhanVien thongTinNhanVien;
        private UC_room room;



        private Form currentForm = null;
        public giaodienchinh()
        {
            InitializeComponent();
        }
        //ham de goi ben form dang nhap
        public void HidePanelMoving()
        {
            panelmoving.Visible = false;//lam cho panelmoving ẩn đi
        }


        private void MovePanelToButton(Guna.UI2.WinForms.Guna2Button button)
        {
            panelmoving.Top = button.Top;//điều chỉnh vị trí panelmoving dọc với button
        }



        private void btroom_Click(object sender, EventArgs e)
        {

            /*if (currentForm != null)
            {
                currentForm.Close();
            }
            UC_room c = new UC_room();// tao doi tuong form Uc_room gan cho bien c
            panelmoving.Visible = true;//panelmoving se ko bi an 
            c.TopLevel = false;//dùng để chỉ ra đối tượng c không phải là đối tượng cao nhất
                               //  pictureBox1.Visible = false;
            c.FormBorderStyle = FormBorderStyle.None;//tạo ra một cửa sổ tùy chỉnh
            c.Dock = DockStyle.Fill;//tự động điều chỉnh size để lấp đầy 
            panelgiaodienchinh.Controls.Add(c);//dùng để thêm một user control vào panel
            c.Show();

            currentForm = c;//gán giá trị cho c
            MovePanelToButton(btroom);//di chuyển đến btroom*/
            currentForm = room;//gán giá trị cho c
            MovePanelToButton(btroom);//di chuyển đến btroom
            room.BringToFront();
        }

        private void btformDangky_Click(object sender, EventArgs e)

        {
            /*
            if (currentForm != null)
            {
                currentForm.Close();
            }*/
            /*  DangKy d = new DangKy();
              d.TopLevel = false;
              panelmoving.Visible = true;
              //  pictureBox1.Visible = false;
              d.FormBorderStyle = FormBorderStyle.None;
              d.Dock = DockStyle.Fill;
              panelgiaodienchinh.Controls.Add(d);
              d.Show();
              currentForm = d;
              MovePanelToButton(btformDangky);*/
            dangKy.BringToFront();
        }

        private void btstaff_Click(object sender, EventArgs e)
        {
            /* if (currentForm != null)
             {
                 currentForm.Close();
             }
             Uc_ThongtinNhanVien d = new Uc_ThongtinNhanVien();
             d.TopLevel = false;
             panelmoving.Visible = true;
             //  pictureBox1.Visible = false;
             d.FormBorderStyle = FormBorderStyle.None;
             d.Dock = DockStyle.Fill;
             panelgiaodienchinh.Controls.Add(d);
             d.Show();
             currentForm = d;

             MovePanelToButton(btstaff);*/
            currentForm = thongTinNhanVien;
            MovePanelToButton(btstaff);
            thongTinNhanVien.BringToFront();
        }



        private void btclose_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                this.Close(); // Đóng Form nếu người dùng chọn "Có"
            }

        }

        private void btDichVu_Click(object sender, EventArgs e)
        {
            currentForm = danhSachDichVu;
            MovePanelToButton(btDichVu);
            danhSachDichVu.BringToFront(); 
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            currentForm = dangKy;
            MovePanelToButton(btnDangKy);
            dangKy.BringToFront();
        }

        private void giaodienchinh_Load(object sender, EventArgs e)
        {
            //THêm form đăng ký vào khi giao diện load khi nào cần dùng chỉ gọi bring to font
            dangKy = new DangKy();
            dangKy.TopLevel = false;
            dangKy.FormBorderStyle = FormBorderStyle.None;
            panelgiaodienchinh.Controls.Add(dangKy);
            dangKy.Dock = DockStyle.Fill;
            dangKy.Show();

            //Khởi tạo form UC_danh sach dich vu
            danhSachDichVu = new Uc_DanhSachDichVu();
            danhSachDichVu.TopLevel = false;
            //panelmoving.Visible = true;
            danhSachDichVu.FormBorderStyle = FormBorderStyle.None;
            danhSachDichVu.Dock = DockStyle.Fill;
            panelgiaodienchinh.Controls.Add(danhSachDichVu);
            danhSachDichVu.Show();
            


            //**** Khởi tạo form thông tin nhân viên
            thongTinNhanVien = new Uc_ThongtinNhanVien();
            thongTinNhanVien.TopLevel = false;
            //panelmoving.Visible = true;
            //  pictureBox1.Visible = false;
            thongTinNhanVien.FormBorderStyle = FormBorderStyle.None;
            thongTinNhanVien.Dock = DockStyle.Fill;
            panelgiaodienchinh.Controls.Add(thongTinNhanVien);
            thongTinNhanVien.Show();
            


            //Khởi tạo form room
            room = new UC_room();// tao doi tuong form Uc_room gan cho bien c
            //panelmoving.Visible = true;//panelmoving se ko bi an 
            room.TopLevel = false;//dùng để chỉ ra đối tượng c không phải là đối tượng cao nhất
                               //  pictureBox1.Visible = false;
            room.FormBorderStyle = FormBorderStyle.None;//tạo ra một cửa sổ tùy chỉnh
            room.Dock = DockStyle.Fill;//tự động điều chỉnh size để lấp đầy 
            panelgiaodienchinh.Controls.Add(room);//dùng để thêm một user control vào panel
            room.Show();

            room.BringToFront();
        }

        private void panelmoving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
