using QuanLyKhachSanNhom9.LeTan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9.QuanLyNhanVien
{
    
    public partial class ServiceNV : Form
    {
        public static string MaPhongTextBox = "";
     

        //////
        private void danThongTinMaPhong(object sender, EventArgs e)
        {
            
        }
        public ServiceNV()
        {
            InitializeComponent();
        }
        public void loadDaTa()
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection)) { 
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                        Select * 
                        From DichVu
                                    ";

                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();
                dgvDichVu.Rows.Clear();
               
                for(; reader.Read();)
                {
                    int index = dgvDichVu.Rows.Add();
                    dgvDichVu.Rows[index].Cells[2].Value = reader.GetString(0);
                    dgvDichVu.Rows[index].Cells[1].Value = reader.GetString(1);
                    dgvDichVu.Rows[index].Cells[3].Value = reader.GetFloat(2);
                    dgvDichVu.Rows[index].Cells[4].Value = reader.GetString(3);
                }   
            }
        }

        private void ServiceNV_Load(object sender, EventArgs e)
        {
            loadDaTa();
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loadForm();
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDichVu.SelectedRows.Count ==0)
            {
                txtTenDichVu.Text = "";
            }    
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                int index = e.RowIndex;
                bool isChecked = Convert.ToBoolean(dgvDichVu.Rows[index].Cells[0].Value);
                if (isChecked)
                {
                    dgvDichVu.Rows[index].Cells[0].Value = false;
                }
                else dgvDichVu.Rows[index].Cells[0].Value = true;
                txtTenDichVu.Text = dgvDichVu.Rows[index].Cells[1].Value.ToString();
               
            }
        }
        /////Thêm dịch vụ cho khách hàng
        public void themDichVu(string MaPhong, string maDichVu, int SoLuong)
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"
                        Select count(*) 
                        from Phong
                        where ID_Phong ='{MaPhong}' AND TrangThai = N'{"Có Người"}'
                                ";
                cmd.Connection = sqlCon;
                int count = (int)cmd.ExecuteScalar();

                if(count == 0 )
                {
                    MessageBox.Show("Phòng không hoạt động vui lòng nhập đúng phòng!");
                    return;
                }
                string gioSuDungDV = DateTime.Now.ToString("HH:mm:ss");
                cmd.CommandText = $@"
                        INSERT INTO SuDungDichVu (ID_KhachHang, ID_Service, SoLuong, ThoiGianMua)
                        SELECT KhachHang.ID_KhachHang, '{maDichVu}', {SoLuong}, '{gioSuDungDV}'
                        FROM KhachHang
                        Where (KhachHang.MaPhong = {MaPhong} AND KhachHang.TimeCheckOut IS NULL)
                                    ";
                count = cmd.ExecuteNonQuery();
                if (count == 0) MessageBox.Show("Thêm dịch vụ thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadForm();
        }
        private void btnXacNhanThem_Click(object sender, EventArgs e)
        {
            if(txtMaphong.Text == "")
            {
                MessageBox.Show("Vui lòng thêm mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtTenDichVu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            if(numSoLuong.Value == 0)
            {
                MessageBox.Show("Vui lòng chỉ định số lượng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maDichVu;
            string maPhong;
            int soLuong;
            string thongTinThem = "";
            int dem = 0;
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                if (isChecked == true)
                {
                    row.Cells[0].Value = false;
                    maDichVu = row.Cells[2].Value.ToString();
                    maPhong = txtMaphong.Text;
                    soLuong = (int)numSoLuong.Value;

                    themDichVu(maPhong, maDichVu, soLuong);
                    thongTinThem += $"{(int)numSoLuong.Value} {row.Cells[1].Value.ToString()}\n";
                    dem += soLuong;
                }    
                

               
                //MessageBox.Show($"Mã dịch vụ: {maDichVu}, Tên khách hàng: {tenKhachHang}");
            } 
            MessageBox.Show($"Đã thêm : {dem} sản phẩm\n{thongTinThem}");

        }
        private void loadForm()
        {
                using(SqlConnection sqlcon = new SqlConnection(TruyVan.strConnection))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"SELECT DV.Name, DV.Type ,SV.soLuong, SV.thoiGianMua
                                        FROM SuDungDichVu  SV
                                        INNER JOIN DichVu DV ON SV.ID_Service = DV.ID_Service
                                        WHERE SV.ID_KhachHang = '{RoomNV.ID_KhachHang}'
                                        ORDER BY SV.thoiGianMua DESC;
                                    ";
                    cmd.Connection = sqlcon;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dgvKhachHang.Rows.Clear();
                    while (reader.Read())
                    {
                        int index = dgvKhachHang.Rows.Add();

                        dgvKhachHang.Rows[index].Cells[0].Value = reader.GetString(0).ToString();
                        dgvKhachHang.Rows[index].Cells[1].Value = reader.GetString(1).ToString();
                        dgvKhachHang.Rows[index].Cells[2].Value = reader.GetInt32(2).ToString();
                        dgvKhachHang.Rows[index].Cells[3].Value = reader.GetTimeSpan(3).ToString();
                    }
                
                }
        }
        private void dgvDichVu_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // Kiểm tra nếu có nhiều hơn một hàng được chọn, hủy bỏ chọn các hàng trước đó
            if (dgvDichVu.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow row in dgvDichVu.SelectedRows)
                {
                    if (row.Index != e.Row.Index)
                    {
                        row.Selected = false;
                    }
                }
            }
        }

        private void timerDanMaPhong_Tick(object sender, EventArgs e)
        {
            txtMaphong.Text = MaPhongTextBox;
            txtTenKhachHang.Text = "Khách Hàng : " + RoomNV.tenKhachHang;
        
        }

        private void dgvDichVu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count == 0)
            {
                txtTenDichVu.Text = "";
            }
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                int index = e.RowIndex;
                bool isChecked = Convert.ToBoolean(dgvDichVu.Rows[index].Cells[0].Value);
                if (isChecked)
                {
                    dgvDichVu.Rows[index].Cells[0].Value = false;
                }
                else dgvDichVu.Rows[index].Cells[0].Value = true;
                txtTenDichVu.Text = dgvDichVu.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public void BindGrid()
        {
            using(SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $@"
                        
                                    ";
            }    
        }
    }
}
