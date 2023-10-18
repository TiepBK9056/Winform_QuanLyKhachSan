
using Newtonsoft.Json;
//using QuanLyKhachSanNhom9.DangNhap;
using QuanLyKhachSanNhom9.LeTan;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QuanLyKhachSanNhom9
{
    public partial class PaymentNVcs : Form
    {
        public delegate void LoadTrangRoom(object sender, EventArgs e);
        public LoadTrangRoom loadTrangRoom;

        /*public static string TenKH;
        public static string */
        public PaymentNVcs()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var apiRequest = new APIRequest();
            apiRequest.acqId = Convert.ToInt32(cbbNganHang.SelectedValue.ToString());
            apiRequest.accountNo = long.Parse(txtSoTaiKhoan.Text);
            apiRequest.accountName = txtTenTaiKhoan.Text;
            apiRequest.amount = Convert.ToInt32(txtSoTien.Text);
            apiRequest.template = "Compact";
            apiRequest.addInfo = txtThongTin.Text;
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            var response = client.Execute(request);
            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<ApiReponse>(content);
            var imange = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            pictureBox1.Image = imange;
            timer2.Enabled = true;
        }
        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        private void PaymentNVcs_Load(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                var bankRowJson = Encoding.UTF8.GetString(htmlData);
                var listData = JsonConvert.DeserializeObject<PayQr>(bankRowJson);
                var listBankDaTa = listData.data;
                cbbNganHang.DataSource = listBankDaTa;
                cbbNganHang.DisplayMember = "custom_name";
                cbbNganHang.ValueMember = "bin";
                cbbNganHang.SelectedValue = listData.data.FirstOrDefault()?.bin;
                
            }
            cbbNganHang.SelectedIndex = 3;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
            {
                txtTenKhachHang.Text = RoomNV.tenKhachHang;
                RoomNV.TongTienKhachHang(RoomNV.ID_KhachHang);//Tinh tổng tiền của khách hàng dựa vào id_lấy khi chuyển form
                txtSoTien.Text = RoomNV._TongTien.ToString();//Lấy xuất tổng tiền khách hàng
                txtThongTin.Text = "THANH TOAN PHONG " + RoomNV.MaPhong;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ma phong la {RoomNV.MaPhong}");
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            //Insert dữ liệu vào bảng
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                sqlCon.Open();
                string dateTime = string.Format("{0}", DateTime.Now.ToString("yyyy/MM/dd"));
                SqlCommand cmd = new SqlCommand();
                double tongTien = (double)RoomNV._TongTien;
                string query = $@"UPDATE KhachHang
                                SET TimeCheckOut = '{dateTime}', TongTien = {tongTien}
                                WHERE ID_KhachHang = '{RoomNV.ID_KhachHang}'";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sqlCon;

                int count = cmd.ExecuteNonQuery();//kiểm tra có thay đổi trong bảng không
                //chuyển trạng thái sang dọn phòng

                query = $@"UPDATE Phong
                            SET TrangThai = N'Sửa Chữa'
                            WHERE ID_Phong = '{RoomNV.MaPhong}'";//Thay đổi trạng thái theo mã phòng
                cmd.CommandText = query;
                count = cmd.ExecuteNonQuery();
            }

            RoomNV.xacThucLoadTrang = true;//kích hoạt load dữ liệu khi xác nhận
            RoomTrang2.xacThucLoadTrang = true;
              
            MessageBox.Show("Xác nhận trả phòng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadTrangRoom?.Invoke(this, e);//Kích hoạt sự kiện đưa form trở về room
        }
      
        int inHoaDon = 0;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
            HoaDonNhanVien hoaDon = new HoaDonNhanVien();
            hoaDon.ShowDialog();
      
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            inHoaDon++;
            if(inHoaDon == 10)
            {
                MessageBox.Show("Bạn Cần phải ấn xác nhận để hoàn thất thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inHoaDon = 0;
                timer2.Enabled = false;
            }    
        }
    }
}
