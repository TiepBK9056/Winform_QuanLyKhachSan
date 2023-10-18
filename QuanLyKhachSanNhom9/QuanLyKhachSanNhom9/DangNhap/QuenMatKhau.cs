using QuanLyKhachSanNhom9.Admin;
using QuanLyKhachSanNhom9.DangNhap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public partial class QuenMatKhau : Form
    {
        public static string dangKy = "";
        public QuenMatKhau()
        {
            InitializeComponent();
            panelThongTinTK.Visible = false;
        }
        Modify modify = new Modify();
        private void txtNhapEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public static int dem = 0;
        private void btnGetTK_Click(object sender, EventArgs e)
        {
            if (!DangKy.CheckEmail(txtEmailDK.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email");
                return;
            }
            SendEmail.chuoi = "QuenMatKhau";

            string email = txtEmailDK.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email đăng ký!");
            }
            else
            {
                dangKy = email;
                string query = "Select * from TaiKhoan where Email = '" + email + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    if (SendEmail.GuiOTp(txtEmailDK.Text, this))
                    {

                        lblTenTaiKhoan_QMK.Text = modify.TaiKhoans(query)[0].TenTaiKhoan;
                        lblMatKhau_QMK.Text = modify.TaiKhoans(query)[0].MatKhau;
                        btnGetMK.Enabled = false;
                        txtEmailDK.Enabled = false;
                        panelThongTinTK.Visible = true;
                    }
                    else this.Close();
                }
                else
                {
                    MessageBox.Show("Email chưa được đăng ký!", "Thông báo");
                    return;
                }
            }
        }
    }
}
