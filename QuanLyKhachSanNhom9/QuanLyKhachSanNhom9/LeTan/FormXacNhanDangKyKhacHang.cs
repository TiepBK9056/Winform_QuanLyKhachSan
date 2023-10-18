using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace QuanLyKhachSanNhom9.LeTan
{
    public partial class FormXacNhanDangKyKhacHang : Form
    {
        public static string maPhong = "";
        public static string maPhongDangKy = "";
        public FormXacNhanDangKyKhacHang()
        {
            InitializeComponent();
        }
        
        public bool checkIDKhachHang(string ID_khachHang)
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string query = "Select count(*) From KhachHang as KH where KH.NumberPhone = '" + ID_khachHang + "'"; ;


                SqlCommand cmd = sqlCon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sqlCon;
                int count = (int)cmd.ExecuteScalar();

                if (count > 0) return false;
                else return true;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtTenKhachHang.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đăng ký phòng nhanh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtSoDienThoai.Text.Length < 9 || txtSoDienThoai.Text.Length > 12)
            {
                MessageBox.Show("Số điện thoại không tồn tại trên bất kì nơi nào!");
                return;
            }
            if (txtTenKhachHang.Text == "" || !txtTenKhachHang.Text.Contains(' '))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                
                
                if(!checkIDKhachHang(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Nhập đúng số điện thoại!", "Thông báo");
                    return;
                }
                string dateTime = string.Format("{0}", DateTime.Now.ToString("yyyy/MM/dd"));
                string gioVao = DateTime.Now.ToString("HH:mm:ss");
                string query = "Insert into KhachHang (ID_KhachHang, Name, NumberPhone, MaPhong, TimeCheckIN, GioVao) Values ('" + txtSoDienThoai.Text + "',N'" + txtTenKhachHang.Text + "','" + txtSoDienThoai.Text + "','" + maPhongDangKy  + "','" + dateTime + "','" + gioVao + "')";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sqlCon;

                int count = cmd.ExecuteNonQuery();//kiểm tra có thay đổi trong bảng không
                sqlCon.Close();
                if(count > 0)
                {
                    MessageBox.Show("Thêm Khách hàng thành công!", "Thông báo!");
                    using(SqlConnection con = new SqlConnection(TruyVan.strConnection))
                    {
                        con.Open();
                        string query1 = "Update Phong Set TrangThai = N'Có Người' where ID_Phong = '" + maPhongDangKy + "'"; ;
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = query1;
                        cmd2.Connection = con;

                         int count1 = cmd2.ExecuteNonQuery();
             
                    }    
                    this.Close();
                    return;
                } 
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo!");
                }
            }  
            
        }

        private void FormXacNhanDangKyKhacHang_Load(object sender, EventArgs e)
        {
            txtMaPhong.Text = maPhong;
        }

        private void pctThoat_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Bạn có thực sự muốn thoát!", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsLetter(ch) && ch != 8 && ch != ' ') // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Chỉ được nhập chữ cái!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Kiểm tra xem ký tự nhập vào có phải là số (0-9) hoặc backspace hay không
            if (!char.IsDigit(ch) && ch != 8) // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Chỉ được nhập số!");
                e.Handled = true; // Ngăn chặn các ký tự không phù hợp
            }
        }
    }
}
