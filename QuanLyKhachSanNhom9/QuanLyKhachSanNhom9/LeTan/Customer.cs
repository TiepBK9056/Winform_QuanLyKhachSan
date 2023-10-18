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

namespace QuanLyKhachSanNhom9.LeTan
{
    public partial class Customer : Form
    {
        private void LoadStart()
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                        Select p.Name, p.NumberPhone,p.MaPhong,  p.TimeCheckIN, p.GioVao, p.TongTien,
	                    Cast(p.TimeCheckIN AS datetime) + Cast(gioVao AS datetime) as NgayGioVao
                        From KhachHang as p
                        Order by NgayGioVao Desc
                                    ";
                cmd.Connection = sqlCon;

                SqlDataReader reader = cmd.ExecuteReader();
                dgvKhachHang.Rows.Clear();
                while(reader.Read())
                {
                    int index = dgvKhachHang.Rows.Add();
                    dgvKhachHang.Rows[index].Cells[0].Value = reader.GetString(0);
                    dgvKhachHang.Rows[index].Cells[1].Value = reader.GetString(1);
                    dgvKhachHang.Rows[index].Cells[2].Value = reader.GetString(2);
                    dgvKhachHang.Rows[index].Cells[3].Value = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                    dgvKhachHang.Rows[index].Cells[4].Value = reader.GetTimeSpan(4).ToString();
                    if (!reader.IsDBNull(5))
                    {
                        dgvKhachHang.Rows[index].Cells[5].Value = reader.GetDouble(5).ToString();
                    }
                    else dgvKhachHang.Rows[index].Cells[5].Value = "NULL";
                   
                }
            }
        }
        public Customer()
        {
            InitializeComponent();
        }

        public void timKiem()
        {
            if (ckbTheoSDT.Checked == false && ckbTheoTen.Checked == true)
            {
                if (txtHoTen.Text == "")
                {
                    LoadStart();
                    return;
                }
                using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"
                            Select * from KhachHang 
                            where LOWER(KhachHang.Name) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%{txtHoTen.Text}%')             
                                      ";
                    cmd.Connection = sqlCon;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvKhachHang.Rows.Clear();
                    while (reader.Read())
                    {
                        int index = dgvKhachHang.Rows.Add();
                        dgvKhachHang.Rows[index].Cells[0].Value = reader.GetString(1);
                        dgvKhachHang.Rows[index].Cells[1].Value = reader.GetString(2);
                        dgvKhachHang.Rows[index].Cells[2].Value = reader.GetString(6);
                        dgvKhachHang.Rows[index].Cells[3].Value = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                        dgvKhachHang.Rows[index].Cells[4].Value = reader.GetTimeSpan(8).ToString();
                        if (!reader.IsDBNull(5))
                        {
                            dgvKhachHang.Rows[index].Cells[5].Value = reader.GetDouble(5).ToString();
                        }
                        else dgvKhachHang.Rows[index].Cells[5].Value = "NULL";
                    }

                }
            }
            else if (ckbTheoSDT.Checked == true && ckbTheoTen.Checked == false)
            {
                if (txtSoDienThoai.Text == "")
                {
                    LoadStart();
                    return;
                }
                using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"
                            Select * from KhachHang 
                            where LOWER(KhachHang.NumberPhone) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%{txtSoDienThoai.Text}%')             
                                      ";
                    cmd.Connection = sqlCon;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvKhachHang.Rows.Clear();
                    while (reader.Read())
                    {
                        int index = dgvKhachHang.Rows.Add();
                        dgvKhachHang.Rows[index].Cells[0].Value = reader.GetString(1);
                        dgvKhachHang.Rows[index].Cells[1].Value = reader.GetString(2);
                        dgvKhachHang.Rows[index].Cells[2].Value = reader.GetString(6);
                        dgvKhachHang.Rows[index].Cells[3].Value = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                        dgvKhachHang.Rows[index].Cells[4].Value = reader.GetTimeSpan(8).ToString();
                        if (!reader.IsDBNull(5))
                        {
                            dgvKhachHang.Rows[index].Cells[5].Value = reader.GetDouble(5).ToString();
                        }
                        else dgvKhachHang.Rows[index].Cells[5].Value = "NULL";
                    }

                }
            }
            else if (ckbTheoSDT.Checked == true && ckbTheoTen.Checked == true)
            {
                if (txtSoDienThoai.Text == "")
                {
                    LoadStart();
                    return;
                }
                if (txtSoDienThoai.Text == "")
                {
                    LoadStart();
                    return;
                }
                using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"
                            Select * from KhachHang 
                            where LOWER(KhachHang.NumberPhone) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%{txtSoDienThoai.Text}%')             
                                  AND  LOWER(KhachHang.Name) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%{txtHoTen.Text}%')    
                                        ";
                    cmd.Connection = sqlCon;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvKhachHang.Rows.Clear();
                    while (reader.Read())
                    {
                        int index = dgvKhachHang.Rows.Add();
                        dgvKhachHang.Rows[index].Cells[0].Value = reader.GetString(1);
                        dgvKhachHang.Rows[index].Cells[1].Value = reader.GetString(2);
                        dgvKhachHang.Rows[index].Cells[2].Value = reader.GetString(6);
                        dgvKhachHang.Rows[index].Cells[3].Value = reader.GetDateTime(3).ToString("yyyy-MM-dd");
                        dgvKhachHang.Rows[index].Cells[4].Value = reader.GetTimeSpan(8).ToString();
                        if (!reader.IsDBNull(5))
                        {
                            dgvKhachHang.Rows[index].Cells[5].Value = reader.GetDouble(5).ToString();
                        }
                        else dgvKhachHang.Rows[index].Cells[5].Value = "NULL";
                    }

                }
            }
            else LoadStart();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            LoadStart();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            timKiem();
        }
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            timKiem();
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)//kiểm tra sự kiện nhập số của người dùng
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                MessageBox.Show("Nhập đúng số điện thoại không nhập chữ cái!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true; // Ngăn chặn ký tự này được nhập vào
            }
        }

        private void ckbTheoTen_CheckedChanged(object sender, EventArgs e)
        {
            timKiem();
        }

        private void ckbTheoSDT_CheckedChanged(object sender, EventArgs e)
        {
            timKiem();
        }
    }
}
