
using QuanLyKhachSanNhom9.DangNhap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.Admin
{
    public partial class DangKy1 : Form
    {
        public static string textEmail_Gui = "";

        public DangKy1()
        {
            InitializeComponent();
        }
        public static bool checkAccount(string taiKhoan)// dùng để kiểm tra mật khẩu và tài khoản
        {
            return Regex.IsMatch(taiKhoan, "^[a-zA-Z0-9]{6,24}$");
        }
        public static bool CheckEmail(string em)// check email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,50}@(([a-zA-Z0-9_.]+\.com)|([a-zA-Z0-9_.]{3,50}\.vn)$)");

            // return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,50}@(gmail.com|[a-zA-Z0-9_.]{3,50})(/.vn|)$");
        }
        Modify modify = new Modify();
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SendEmail.chuoi = "DangKy";
            string tenTK = txtTenTK.Text;
            string matKhau = txtMK.Text;
            string xNMatKhau = txtXacNhan.Text;
            string email = txtEmail.Text;
            textEmail_Gui = email;


            if (!checkAccount(tenTK))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài đến 6-24 ký tự, với các ký tự chữ và số");
                return;
            }
            else if (!checkAccount(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài đến 6-24 ký tự, với các ký tự chữ và số");
                return;
            }
            else if (matKhau != xNMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác");
                return;
            }
            if (!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email");
                return;
            }
            if (modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email + "'").Count != 0)
            {
                MessageBox.Show("Email đã được đăng ký, vui lòng đăng ký email khác");
                return;
            }
            try
            {
                string query = "Insert into TaiKhoan values ('" + tenTK + "', '" + matKhau + "', '" + email + "')";
                modify.Command(query);
                if (SendEmail.GuiOTp(txtEmail.Text, this))
                {
                    if (MessageBox.Show("Đăng ký thành công! ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        NhanMaOTP.soLanGui = 5;
                        this.Close();
                    }
                }
                else
                {
                    string squery = "delete from TaiKhoan where Email = '" + txtEmail.Text + "'";
                    modify.Command(squery);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng nhập tài khoản khác!");
            }

        }


        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtMK.Text = txtTenTK.Text = txtXacNhan.Text = "";
        }
    }

}
    