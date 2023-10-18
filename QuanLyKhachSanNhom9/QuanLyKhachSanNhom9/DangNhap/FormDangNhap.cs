
using Nhom9_DoAnQuanLiKhachSan;
using QuanLyKhachSanNhom9.KeToan;
using QuanLyKhachSanNhom9.QuanLyNhanVien;
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

namespace QuanLyKhachSanNhom9.DangNhap
{
    public partial class FormDangNhap : Form
    {
        Modify modify = new Modify();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        

        private void picThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void llbFogot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau form = new QuenMatKhau();
            form.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            if (tenTaiKhoan.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }
            if (matKhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            string query = @"select * from TaiKhoan where AcountName = '" + tenTaiKhoan + "' and Password = '" + matKhau + "'";
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string loaiPhongBan = reader.GetString(2);
                    if (loaiPhongBan.Contains("LT"))
                    {
                        this.Hide();
                        MainNhanVien leTan = new MainNhanVien();
                        Font largerFont = new Font(leTan.Font.FontFamily, 12, leTan.Font.Style);

                        // Gán đối tượng Font vừa tạo cho Form leTan
                        leTan.Font = largerFont;
                        leTan.ShowDialog();

                        this.Show();
                    }
                    else if (loaiPhongBan.Contains("NV"))
                    {
                        this.Hide();
                        giaodienchinh giaoDien = new giaodienchinh();
                        Font largerFont = new Font(giaoDien.Font.FontFamily, 12, giaoDien.Font.Style);

                        // Gán đối tượng Font vừa tạo cho Form leTan
                        //giaoDien.Font = largerFont;
                        giaoDien.ShowDialog();

                        this.Show();
                    }
                    else if (loaiPhongBan.Contains("KT"))
                    {
                        this.Hide();
                        Tongdoanhthu keToan = new Tongdoanhthu();
                        Font largerFont = new Font(keToan.Font.FontFamily, 12, keToan.Font.Style);

                        // Gán đối tượng Font vừa tạo cho Form leTan
                        //keToan.Font = largerFont;
                        keToan.ShowDialog();

                        this.Show();
                    }
                    else if (loaiPhongBan.Contains("BP"))
                    {
                        this.Hide();
                        BuonPhongMain buonPhong = new BuonPhongMain();
                        Font largerFont = new Font(buonPhong.Font.FontFamily, 12, buonPhong.Font.Style);

                        // Gán đối tượng Font vừa tạo cho Form leTan
                        //buonPhong.Font = largerFont;
                        buonPhong.ShowDialog();
                        this.Show();
                    }    
                        
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
                }
            }    
            /*if (modify.TaiKhoans(query).Count() != 0)
            {
                //MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainNhanVien leTan = new MainNhanVien();
                Font largerFont = new Font(leTan.Font.FontFamily, 12, leTan.Font.Style);

                // Gán đối tượng Font vừa tạo cho Form leTan
                leTan.Font = largerFont;
                leTan.ShowDialog();

                this.Close();
            }*/
           
        }

        private void llbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CHưa có

        }

        private void picThoat_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                this.Close();
            }    
        }
        private bool hienMatKhau = false;
        private void ptcEye_Click(object sender, EventArgs e)
        {
            hienMatKhau = !hienMatKhau;
            if (hienMatKhau)
            {
                //biểu tượng con mắt hiện mật khẩu
                ptcEye.Image = Properties.Resources.con_mat_hien1;
                //hiển thị mật khẩu
                txtMatKhau.UseSystemPasswordChar = true;
            }
            else
            {
                //biểu tượng con mắt hiện mật khẩu
                ptcEye.Image = Properties.Resources.con_mat_an1;
                //ẩn thị mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

  

   

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Danh sách các ký tự không dấu cho phép
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

            // Kiểm tra xem ký tự nhập vào có trong danh sách cho phép và có phải là backspace hay không
            if (!allowedChars.Contains(ch) && ch != 8) // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Nhập đúng ký tự a-Z và '_'");
                e.Handled = true; // Ngăn chặn ký tự không phù hợp được nhập vào
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            ptcEye_Click(sender, e);
        }
    }

}
