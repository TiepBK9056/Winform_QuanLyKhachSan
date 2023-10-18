using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using QuanLyKhachSanNhom9.Admin;
using QuanLyKhachSanNhom9.DangNhap;
using System.Security.RightsManagement;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public partial class NhanMaOTP : Form
    {
        
        public static int soLanGui = 5;
        public string textCheck = "";
        public NhanMaOTP()
        {
            InitializeComponent();
        }
        private void SetRoundCorners(Form form, int radius)
        {
            GraphicsPath formPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, form.Width, form.Height);

            formPath.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            formPath.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            formPath.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            formPath.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

            formPath.CloseAllFigures();

            form.Region = new Region(formPath);
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            textCheck = txtNhapOtp.Text;
            if (txtNhapOtp.Text == "")
            {
                MessageBox.Show("Không được để trống mã OTP");
                return;
            }
            if (txtNhapOtp.Text == SendEmail.otp.ToString())
            {
                if (MessageBox.Show("Mã OTP hợp lệ", "Thông báo") == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Mã sai vui lòng nhập lại");
                txtNhapOtp.Text = "";
            }
        }

        private void btnThoatOtp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_gui_lai_Click(object sender, EventArgs e)
        {
            if (soLanGui > 0)
            {
                soLanGui--;
                MessageBox.Show($"Bạn còn {soLanGui} lần gửi");

                //SendEmail.sendEmail(DangKy.textEmail_Gui, this);
                if(SendEmail.chuoi == "QuenMatKhau")
                    SendEmail.sendEmail(QuenMatKhau.dangKy, this);
                else if(SendEmail.chuoi =="DangKy")
                    SendEmail.sendEmail(DangKy.dangKy, this);

                MessageBox.Show("OTP đã được gửi qua mail\nVui lòng xác nhận vào ô OTP");
            }
            else
            {
                MessageBox.Show($"Bạn đã hết số lần gửi lại", "Cảnh báo");
            }
        }

        private void NhanMaOTP_Load(object sender, EventArgs e)
        {
            SetRoundCorners(this, 50);
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            textCheck = txtNhapOtp.Text;
            if (txtNhapOtp.Text == "")
            {
                MessageBox.Show("Không được để trống mã OTP");
                return;
            }
            if (txtNhapOtp.Text == SendEmail.otp.ToString())
            {
                if (MessageBox.Show("Mã OTP hợp lệ", "Thông báo") == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Mã sai vui lòng nhập lại");
                txtNhapOtp.Text = "";
            }
        }

        private void btnGuiLai_Click(object sender, EventArgs e)
        {
            if (soLanGui > 0)
            {
                soLanGui--;
                MessageBox.Show($"Bạn còn {soLanGui} lần gửi");
                if(SendEmail.chuoi.ToLower() == "DangKy".ToLower())
                    SendEmail.sendEmail(DangKy.dangKy, this);
                else
                    SendEmail.sendEmail(QuenMatKhau.dangKy, this);
                MessageBox.Show("OTP đã được gửi qua mail\nVui lòng xác nhận vào ô OTP");
            }
            else
            {
                MessageBox.Show($"Bạn đã hết số lần gửi lại", "Cảnh báo");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                this.Close();
                soLanGui = 5;
            }    
        }
    }
}
