using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public partial class DangKy : Form
    {
        Models.QLKSContextDB contex = new Models.QLKSContextDB ();
        public void fillComboBoxPhongBan()//ĐỔ dữ liệu các phòng ban vào combobox
        {

            List<PhongBan> list = contex.PhongBans.ToList ();
            cmbChucVu.DataSource = list;
            cmbChucVu.DisplayMember = "Name";
            cmbChucVu.ValueMember = "ID_PhongBan";
            cmbChucVu.SelectedIndex = 0;
        }    
        public static string dangKy = "";
        public void fillBoPhan()
        {
            
        }
        public DangKy()
        {
            InitializeComponent();
        }
        public static bool checkAccount(string taiKhoan)// dùng để kiểm tra mật khẩu và tài khoản
        {
            return Regex.IsMatch(taiKhoan, "^[a-zA-Z0-9]{6,50}$");
        }
        public static bool CheckEmail(string em)// check email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,100}@gmail.com(.vn|)$");
        }
        Modify modify = new Modify();
        private void btnDang_Ky_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text.Length <9 || txtSDT.Text.Length > 14)
            {
                MessageBox.Show("Số điện thoại không tồn tại, vui lòng nhập đúng số điện thoại", "Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
             dangKy = txtEmail.Text;
            SendEmail.chuoi = "DangKy";
            string tenTK = txtTenTK.Text;
            string matKhau = txtMatKhau.Text;
            string xNMatKhau = txtXNMatKhau.Text;
            string email = txtEmail.Text;
            if (!checkAccount(tenTK))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài đến 6-24 ký tự, với các ký tự chữ và số");
                return;
            }
            else if (!checkAccount(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài đến 6-24 ký tự, với các ký tự chữ và số");
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
                MessageBox.Show(modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email + "'").Count.ToString());
                MessageBox.Show("Email đã được đăng ký, vui lòng đăng ký email khác");
                return;
            }
            //trường hợp cố định có số phòng ban và giá trị không thay đổi

                string loai = "";
                int giaTriPhongBan = Convert.ToInt32(cmbChucVu.SelectedValue);
           
                if (giaTriPhongBan == 1) {
                    loai = "NV";
                }
                else if(giaTriPhongBan == 2)
                {
                    loai = "LT";
                }    
                else if(giaTriPhongBan == 3)
                {
                    loai = "BP";
                }    
                else if(giaTriPhongBan == 4)
                {
                    loai = "KT";
                }    
                

                if (SendEmail.GuiOTp(txtEmail.Text, this))
                {
                    string query = $@"Insert into TaiKhoan values ('{txtTenTK.Text}', '{txtMatKhau.Text}', '{loai}', N'{txtTenTK.Text}', '{txtEmail.Text}')";
                    using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(query, sqlCon);
                        cmd.CommandType = CommandType.Text;

                        string dateTime = string.Format("{0}", dtbngaysinh.Value.ToString("yyyy/MM/dd"));
                        cmd.Connection = sqlCon;
                        cmd.CommandText = $@"Insert into NhanVien values ('{txtTenTK.Text}', N'{txtTenNV.Text}', '{txtEmail.Text}', '{dateTime}', '{giaTriPhongBan}', '{txtSDT.Text}')";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query;
                        int count = cmd.ExecuteNonQuery();

                    }
                    BindGrid();
                    MessageBox.Show("đăng ký thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanMaOTP.soLanGui = 5;
                    
                 }
                else
                {
                    MessageBox.Show("Đăng ký không thành công!", "Thông báo!");
                }
           
                
        }
        private void BindGrid()
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"
                            select TK.AcountName, TK.Password, NV.Name, NV.SDT, NV.BirthDate, P.Name
                            from TaiKhoan as TK
                            Inner JOIN  NhanVien as NV ON NV.ID_NhanVien = TK.ID_NhanVien
                            Inner JOIN PhongBan as P ON P.ID_PhongBan = NV.ID_PhongBan
                                ";
                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();
                dgvDSNV.Rows.Clear();
                
                while(reader.Read())
                {
                    int index = dgvDSNV.Rows.Add();
                    if (!reader.IsDBNull(0))
                        dgvDSNV.Rows[index].Cells[0].Value = reader.GetValue(0);
                    else dgvDSNV.Rows[index].Cells[0].Value = null;

                    if (!reader.IsDBNull(1))
                        dgvDSNV.Rows[index].Cells[1].Value = reader.GetValue(1);
                    else dgvDSNV.Rows[index].Cells[1].Value = null;

                    if (!reader.IsDBNull(2))
                        dgvDSNV.Rows[index].Cells[2].Value = reader.GetValue(2);
                    else dgvDSNV.Rows[index].Cells[2].Value = null;


                    if (!reader.IsDBNull(3))
                        dgvDSNV.Rows[index].Cells[3].Value = reader.GetValue(3);
                    else
                        dgvDSNV.Rows[index].Cells[3].Value = null;

                    if (!reader.IsDBNull(4))
                        dgvDSNV.Rows[index].Cells[4].Value = reader.GetDateTime(4).ToString("yyyy/MM/dd");
                    else dgvDSNV.Rows[index].Cells[4].Value = null;

                    if (!reader.IsDBNull (5))
                        dgvDSNV.Rows[index].Cells[5].Value = reader.GetValue(5);
                    else
                        dgvDSNV.Rows[index].Cells[5].Value = reader.GetValue(5);
                }
            }
        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            fillComboBoxPhongBan();
            BindGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                this.Close();
            }    
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Kiểm tra xem ký tự nhập vào có phải là số (0-9) hoặc backspace hay không
            if (!char.IsDigit(ch) && ch != 8) // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Chỉ được nhập số!");
                e.Handled = true; // Ngăn chặn các ký tự không phù hợp
            }
        }

        

        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

           
            if (!char.IsLetter(ch) && ch != 8 && ch != ' ') // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Chỉ được nhập chữ cái!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true; 
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Kiểm tra xem ký tự nhập vào có phải là dấu cách hay không
            if (ch == ' ')
            {
                MessageBox.Show("Không được đăng ký mật khẩu là dấu cách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Handled = true; // Ngăn chặn dấu cách được nhập vào
                return;
            }

            // Kiểm tra xem ký tự nhập vào có phải là chữ cái có dấu hay không
            string specialChars = "áàạảãăắằẳẵặâấầậẩẫéèẹẻẽêếềệểễíìịỉĩóòọỏõôốồộổỗơớờợởỡúùụủũưứừựửữýỳỷỹỵđ";
            specialChars += specialChars.ToUpper(); // Thêm các ký tự in hoa

            if (specialChars.Contains(ch.ToString()))
            {
                MessageBox.Show("Không được đăng ký mật khẩu là chữ có dấu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true; // Ngăn chặn chữ cái có dấu được nhập vào
            }
        }

        private void txtXNMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Kiểm tra xem ký tự nhập vào có phải là dấu cách hay không
            if (ch == ' ')
            {
                MessageBox.Show("Không được đăng ký mật khẩu là dấu cách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Handled = true; // Ngăn chặn dấu cách được nhập vào
                return;
            }

            // Kiểm tra xem ký tự nhập vào có phải là chữ cái có dấu hay không
            string specialChars = "áàạảãăắằẳẵặâấầậẩẫéèẹẻẽêếềệểễíìịỉĩóòọỏõôốồộổỗơớờợởỡúùụủũưứừựửữýỳỷỹỵđ";
            specialChars += specialChars.ToUpper(); // Thêm các ký tự in hoa

            if (specialChars.Contains(ch.ToString()))
            {
                MessageBox.Show("Không được đăng ký mật khẩu là chữ có dấu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true; // Ngăn chặn chữ cái có dấu được nhập vào
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Kiểm tra xem ký tự nhập vào có phải là dấu cách hay không
            if (ch == ' ')
            {
                MessageBox.Show("Không được đăng ký mật khẩu là dấu cách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.Handled = true; // Ngăn chặn dấu cách được nhập vào
                return;
            }

            // Kiểm tra xem ký tự nhập vào có phải là chữ cái có dấu hay không
            string specialChars = "áàạảãăắằẳẵặâấầậẩẫéèẹẻẽêếềệểễíìịỉĩóòọỏõôốồộổỗơớờợởỡúùụủũưứừựửữýỳỷỹỵđ";
            specialChars += specialChars.ToUpper(); // Thêm các ký tự in hoa

            if (specialChars.Contains(ch.ToString()))
            {
                MessageBox.Show("Không được đăng ký mật khẩu là chữ có dấu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true; // Ngăn chặn chữ cái có dấu được nhập vào
            }
        }

        private void dtbngaysinh_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
