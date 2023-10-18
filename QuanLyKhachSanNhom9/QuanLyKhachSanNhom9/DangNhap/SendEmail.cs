using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public class SendEmail
    {
        //tao chuoi ran dom opt
        public static Random radom = new Random();

        public static int otp;
        public static string chuoi = "";
        public static NhanMaOTP nhanMaOTP;


        public static void sendEmail(string txtEmail, Form form)
        {
            otp = radom.Next(100000, 1000000);

            var fromAddress = new MailAddress("thuyettrinhsendemail@gmail.com");
            var toAddress = new MailAddress(txtEmail);
            const string fromPassword = "throesfhqrhuemdl";
            const string subject = "OTP code";
            string body = otp.ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 10000
            };

            // Ẩn Form cụ thể để ngăn người dùng nhập liệu
            form.Cursor = Cursors.WaitCursor;


            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Sau khi gửi email xong đưa con trỏ trở về bình thường
                form.Cursor = Cursors.Default;

            }
        }
        //----------------------------------------------------------------------------------------------
        public static bool GuiOTp(string txtEmail, Form form)
        {//tai ma otp random 6 so
            try
            {
                sendEmail(txtEmail, form);

                if (MessageBox.Show("OTP đã được gửi qua mail\nVui lòng xác nhận vào ô OTP") == DialogResult.OK)
                {

                    nhanMaOTP = new NhanMaOTP();
                    nhanMaOTP.ShowDialog();


                    if (nhanMaOTP.textCheck != otp.ToString())
                    {
                        if (chuoi.ToLower() == "DangKy".ToLower())
                        {
                            MessageBox.Show("Đăng ký không thành công");
                            NhanMaOTP.soLanGui = 5;
                        }
                        if (chuoi.ToLower() == "QuenMatKhau".ToLower())
                        {
                            MessageBox.Show("Xác thực tài khoản không thành công");
                            NhanMaOTP.soLanGui = 5;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nYêu cầu nhập đúng Email", "Cảnh Báo!");
            }
            return true;
        }
    }
}
