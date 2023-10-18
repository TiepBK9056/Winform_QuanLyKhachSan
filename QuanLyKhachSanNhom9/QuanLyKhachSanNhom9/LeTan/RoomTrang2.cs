using FontAwesome.Sharp;
using QuanLyKhachSanNhom9.QuanLyNhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace QuanLyKhachSanNhom9.LeTan
{
    public partial class RoomTrang2 : Form
    {
        //Tạo sự kiện khi ấn vào nút chuyển trang gọi tới sự kiện của form mainNhanVien
        public delegate void SuKienChuyenTrang1(object sender, EventArgs e);
        public event SuKienChuyenTrang1 suKienChuyenTrang1;


        //Tạo sự kiện thêm thông tin và thêm dịch vụ 
        public delegate void SuKienThemDichVu(object sender, EventArgs e);
        public SuKienThemDichVu suKienThemDichVu2;

        //Tạo sự kiện chuyển trang tính tiền
        public delegate void SuKienTinhTien2(object sender, EventArgs e);
        public SuKienTinhTien2 suKienTinhTien2;


        //KHởi tạo danh sách giờ sử dụng của khách hàng
        int gioSuDung1 = 0;
        int gioSuDung2 = 0;
        int gioSuDung3 = 0;
        int gioSuDung4 = 0;
        int gioSuDung5 = 0;
        int gioSuDung6 = 0;
        int gioSuDung7 = 0;
        int gioSuDung8 = 0;
        int gioSuDung9 = 0;
        int gioSuDung10 = 0;
        int gioSuDung11 = 0;
        int gioSuDung12 = 0;

        private static string chuyenTenPhong(string loaiPhong)
        {
            return RoomNV.chuyenTenPhong(loaiPhong);
        }
        public RoomTrang2()
        {
            InitializeComponent();
        }
        private void loadRoomStart(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(TruyVan.strConnection))
            {
                /*string query1 = $@"
                    Select *  
                    From Phong
                    where Cast(ID_Phong as INT) > 206
                                ";*/
                string query = $@"
                         SELECT 
                             p.ID_Phong,
                             p.ID_LoaiPhong,
                             p.TrangThai,
                             NULL AS ThoiGian
                         FROM phong AS p
                         WHERE p.TrangThai = N'Trống' AND CAST(ID_Phong as int) > 206
                         UNION
                         SELECT 
                             p.ID_Phong,
                             p.ID_LoaiPhong,
                             p.TrangThai,
                             k.GioVao AS ThoiGian
                         FROM phong AS p
                         INNER JOIN khachHang AS k ON p.ID_Phong = k.MaPhong
                         WHERE p.TrangThai = N'Có Người' AND k.TimeCheckOut IS NULL AND CAST(ID_Phong as int) > 206"
                                    ; 
                                                ;
                //Truy vấn chỉ lấy 12 dòng cuối để chọn 12 phòng cho trang 2 để thao tác thêm lệnh where

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection = sqlCon;
                SqlDataReader reader = cmd.ExecuteReader();

                int dem = 1;
                while (reader.Read())
                {

                    if (dem == 1)
                    {

                        lblLoaiPhong1.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong1.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong1.IconChar = IconChar.Bed;

                            icbPhong1.Text = reader.GetString(2);
                            lblMaPhong1.Text = reader.GetString(0);

                            timer1.Enabled = false;
                            lblSoGioPhut1.Text = "00:00:00";
                            gioSuDung1 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong1.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong1.IconChar = IconChar.Bed;

                            icbPhong1.Text = reader.GetString(2);
                            lblMaPhong1.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung1 = (int)timeDifference.TotalSeconds;

                            timer1.Enabled = true;
                        }
                        else
                        {
                            panelPhong1.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong1.IconChar = IconChar.Broom;
                            icbPhong1.Text = reader.GetString(2);
                            lblMaPhong1.Text = reader.GetString(0);

                            timer1.Enabled = false;
                            lblSoGioPhut1.Text = "00:00:00";
                            gioSuDung1 = 0;
                        }
                    }

                    else if (dem == 2)
                    {

                        lblLoaiPhong2.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong2.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong2.IconChar = IconChar.Bed;

                            icbPhong2.Text = reader.GetString(2);
                            lblMaPhong2.Text = reader.GetString(0);


                            timer2.Enabled = false;
                            lblSoGioPhut2.Text = "00:00:00";
                            gioSuDung2 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong2.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong2.IconChar = IconChar.Bed;

                            lblMaPhong2.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader.GetTimeSpan(3);

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung2 = (int)timeDifference.TotalSeconds;

                            icbPhong2.Text = reader.GetString(2);
                            timer2.Enabled = true;
                        }
                        else
                        {
                            panelPhong2.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong2.IconChar = IconChar.Broom;
                            icbPhong2.Text = reader.GetString(2);
                            lblMaPhong2.Text = reader.GetString(0);

                            timer2.Enabled = false;
                            lblSoGioPhut2.Text = "00:00:00";
                            gioSuDung2 = 0;
                        }
                    }

                    else if (dem == 3)
                    {

                        lblLoaiPhong3.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong3.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong3.IconChar = IconChar.Bed;

                            icbPhong3.Text = reader.GetString(2);
                            lblMaPhong3.Text = reader.GetString(0);


                            timer3.Enabled = false;
                            lblSoGioPhut3.Text = "00:00:00";
                            gioSuDung3 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong3.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong3.IconChar = IconChar.Bed;

                            lblMaPhong3.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung3 = (int)timeDifference.TotalSeconds;

                            icbPhong3.Text = reader.GetString(2);
                            timer3.Enabled = true;
                        }
                        else
                        {
                            panelPhong3.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong3.IconChar = IconChar.Broom;
                            icbPhong3.Text = reader.GetString(2);
                            lblMaPhong3.Text = reader.GetString(0);

                            timer3.Enabled = false;
                            lblSoGioPhut3.Text = "00:00:00";
                            gioSuDung3 = 0;
                        }
                    }



                    else if (dem == 4)
                    {

                        lblLoaiPhong4.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong4.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong4.IconChar = IconChar.Bed;

                            icbPhong4.Text = reader.GetString(2);
                            lblMaPhong4.Text = reader.GetString(0);
                    

                            timer4.Enabled = false;
                            lblSoGioPhut4.Text = "00:00:00";
                            gioSuDung4 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong4.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong4.IconChar = IconChar.Bed;

                            icbPhong4.Text = reader.GetString(2);
                            lblMaPhong4.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung4 = (int)timeDifference.TotalSeconds;

                            timer4.Enabled = true;
                        }
                        else
                        {
                            panelPhong4.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong4.IconChar = IconChar.Broom;
                            icbPhong4.Text = reader.GetString(2);
                            lblMaPhong4.Text = reader.GetString(0);

                            timer4.Enabled = false;
                            lblSoGioPhut4.Text = "00:00:00";
                            gioSuDung4 = 0;
                        }
                    }


                    else if (dem == 5)
                    {

                        lblLoaiPhong5.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong5.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong5.IconChar = IconChar.Bed;

                            icbPhong5.Text = reader.GetString(2);
                            lblMaPhong5.Text = reader.GetString(0);


                            timer5.Enabled = false;
                            lblSoGioPhut4.Text = "00:00:00";
                            gioSuDung4 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong5.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong5.IconChar = IconChar.Bed;

                            icbPhong5.Text = reader.GetString(2);
                            lblMaPhong5.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung5 = (int)timeDifference.TotalSeconds;

                            timer5.Enabled = true;
                        }
                        else
                        {
                            panelPhong5.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong5.IconChar = IconChar.Broom;
                            icbPhong5.Text = reader.GetString(2);
                            lblMaPhong5.Text = reader.GetString(0);

                            timer5.Enabled = false;
                            lblSoGioPhut5.Text = "00:00:00";
                            gioSuDung5 = 0;
                        }
                    }


                    else if (dem == 6)
                    {

                        lblLoaiPhong6.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong6.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong6.IconChar = IconChar.Bed;

                            icbPhong6.Text = reader.GetString(2);
                            lblMaPhong6.Text = reader.GetString(0);


                            timer6.Enabled = false;
                            lblSoGioPhut6.Text = "00:00:00";
                            gioSuDung6 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong6.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong6.IconChar = IconChar.Bed;

                            icbPhong6.Text = reader.GetString(2);
                            lblMaPhong6.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung6 = (int)timeDifference.TotalSeconds;

                            timer6.Enabled = true;
                        }
                        else
                        {
                            panelPhong6.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong6.IconChar = IconChar.Broom;
                            icbPhong6.Text = reader.GetString(2);
                            lblMaPhong6.Text = reader.GetString(0);

                            timer6.Enabled = false;
                            lblSoGioPhut6.Text = "00:00:00";
                            gioSuDung6 = 0;
                        }
                    }


                    else if (dem == 7)
                    {

                        lblLoaiPhong7.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong7.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong7.IconChar = IconChar.Bed;

                            icbPhong7.Text = reader.GetString(2);
                            lblMaPhong7.Text = reader.GetString(0);


                            timer7.Enabled = false;
                            lblSoGioPhut7.Text = "00:00:00";
                            gioSuDung7 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong7.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong7.IconChar = IconChar.Bed;

                            icbPhong7.Text = reader.GetString(2);
                            lblMaPhong7.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung7 = (int)timeDifference.TotalSeconds;

                            timer7.Enabled = true;
                        }
                        else
                        {
                            panelPhong7.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong7.IconChar = IconChar.Broom;
                            icbPhong7.Text = reader.GetString(2);
                            lblMaPhong7.Text = reader.GetString(0);

                            timer7.Enabled = false;
                            lblSoGioPhut7.Text = "00:00:00";
                            gioSuDung7 = 0;
                        }
                    }



                    else if (dem == 8)
                    {

                        lblLoaiPhong8.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong8.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong8.IconChar = IconChar.Bed;

                            icbPhong8.Text = reader.GetString(2);
                            lblMaPhong8.Text = reader.GetString(0);


                            timer8.Enabled = false;
                            lblSoGioPhut8.Text = "00:00:00";
                            gioSuDung8 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong8.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong8.IconChar = IconChar.Bed;

                            icbPhong8.Text = reader.GetString(2);
                            lblMaPhong8.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung8 = (int)timeDifference.TotalSeconds;

                            timer8.Enabled = true;
                        }
                        else
                        {
                            panelPhong8.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong8.IconChar = IconChar.Broom;
                            icbPhong8.Text = reader.GetString(2);
                            lblMaPhong8.Text = reader.GetString(0);

                            timer8.Enabled = false;
                            lblSoGioPhut8.Text = "00:00:00";
                            gioSuDung8 = 0;
                        }
                    }


                    else if (dem == 9)
                    {

                        lblLoaiPhong9.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong9.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong9.IconChar = IconChar.Bed;

                            icbPhong9.Text = reader.GetString(2);
                            lblMaPhong9.Text = reader.GetString(0);


                            timer9.Enabled = false;
                            lblSoGioPhut9.Text = "00:00:00";
                            gioSuDung9 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong9.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong9.IconChar = IconChar.Bed;

                            icbPhong9.Text = reader.GetString(2);
                            lblMaPhong9.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung9 = (int)timeDifference.TotalSeconds;

                            timer9.Enabled = true;
                        }
                        else
                        {
                            panelPhong9.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong9.IconChar = IconChar.Broom;
                            icbPhong9.Text = reader.GetString(2);
                            lblMaPhong9.Text = reader.GetString(0);

                            timer9.Enabled = false;
                            lblSoGioPhut9.Text = "00:00:00";
                            gioSuDung9 = 0;
                        }
                    }


                    else if (dem == 10)
                    {

                        lblLoaiPhong10.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong10.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong10.IconChar = IconChar.Bed;

                            icbPhong10.Text = reader.GetString(2);
                            lblMaPhong10.Text = reader.GetString(0);


                            timer10.Enabled = false;
                            lblSoGioPhut10.Text = "00:00:00";
                            gioSuDung10 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong10.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong10.IconChar = IconChar.Bed;

                            icbPhong10.Text = reader.GetString(2);
                            lblMaPhong10.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung10 = (int)timeDifference.TotalSeconds;

                            timer10.Enabled = true;
                        }
                        else
                        {
                            panelPhong10.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong10.IconChar = IconChar.Broom;
                            icbPhong10.Text = reader.GetString(2);
                            lblMaPhong10.Text = reader.GetString(0);

                            timer10.Enabled = false;
                            lblSoGioPhut10.Text = "00:00:00";
                            gioSuDung10 = 0;
                        }
                    }


                    else if (dem == 11)
                    {

                        lblLoaiPhong11.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong11.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong11.IconChar = IconChar.Bed;

                            icbPhong11.Text = reader.GetString(2);
                            lblMaPhong11.Text = reader.GetString(0);


                            timer11.Enabled = false;
                            lblSoGioPhut11.Text = "00:00:00";
                            gioSuDung11 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong11.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong11.IconChar = IconChar.Bed;

                            icbPhong11.Text = reader.GetString(2);
                            lblMaPhong11.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung11 = (int)timeDifference.TotalSeconds;

                            timer11.Enabled = true;
                        }
                        else
                        {
                            panelPhong11.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong11.IconChar = IconChar.Broom;
                            icbPhong11.Text = reader.GetString(2);
                            lblMaPhong11.Text = reader.GetString(0);

                            timer11.Enabled = false;
                            lblSoGioPhut11.Text = "00:00:00";
                            gioSuDung11 = 0;
                        }
                    }

                    else if (dem == 12)
                    {

                        lblLoaiPhong12.Text = reader.GetString(1);
                        if (reader.GetString(2).Trim() == "Trống")
                        {
                            panelPhong12.BackColor = Color.FromArgb(153, 204, 51);
                            icbPhong12.IconChar = IconChar.Bed;

                            icbPhong12.Text = reader.GetString(2);
                            lblMaPhong12.Text = reader.GetString(0);


                            timer12.Enabled = false;
                            lblSoGioPhut12.Text = "00:00:00";
                            gioSuDung12 = 0;
                        }
                        else if (reader.GetString(2).Contains("Có Người"))
                        {
                            panelPhong12.BackColor = Color.FromArgb(255, 108, 0);
                            icbPhong12.IconChar = IconChar.Bed;

                            icbPhong12.Text = reader.GetString(2);
                            lblMaPhong12.Text = reader.GetString(0);
                            /////
                            TimeSpan timeFromDatabase = (TimeSpan)reader["ThoiGian"];

                            //Tính thời gian chênh lệch
                            TimeSpan timeDifference = DateTime.Now.TimeOfDay - timeFromDatabase;

                            // Chuyển thời gian chênh lệch thành tổng số giây
                            //Ép kiểu chuyển sang int vì time với độ chính xác time(0) 
                            gioSuDung12 = (int)timeDifference.TotalSeconds;

                            timer12.Enabled = true;
                        }
                        else
                        {
                            panelPhong12.BackColor = Color.FromArgb(54, 54, 54);
                            icbPhong12.IconChar = IconChar.Broom;
                            icbPhong12.Text = reader.GetString(2);
                            lblMaPhong12.Text = reader.GetString(0);

                            timer12.Enabled = false;
                            lblSoGioPhut12.Text = "00:00:00";
                            gioSuDung12 = 0;
                        }
                    }

                    dem++;
                }
                reader.Close();
                sqlCon.Close();
            }
        }


        private void Room_Load(object sender, EventArgs e)
        {
            loadRoomStart(sender, e);

        }     
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Sự kiện clich vào panel màu xanh là đăng ký màu đỏ là chuyển sang sự kiện thêm dịch vụ cho khách hàng
        private void panelPhong1_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong1.Text);//khi click đưa thông tin mã phòng và khách lên
            if(panelPhong1.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if (panelPhong1.BackColor == Color.FromArgb(153, 204, 51))
            {
                //một mã là đưa vào ô textbox
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong1.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong1.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                //Mã đưa vào truy vấn làm đỏ panel
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong1.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong1.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong1.Text);//phải thay gán thông tin trước khi chuyển form
                    suKienTinhTien2?.Invoke(this, e);
                    //khi click đưa thông tin mã phòng và khách lên
                    //Chỉ sử dụng một phương thức tĩnh của RoomNV để dể thao tác trên các form
                    //static khachhang, id_khachhang, maphong moi su kien se chi lay duoc mot chuoi thong tin khach hang
                }
                else return;
            }
        }
       
        private void panelPhong2_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong2.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong2.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong2.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong2.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong2.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong2.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong2.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong2.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong3_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong3.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong3.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong3.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong3.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong3.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong3.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong3.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong3.Text);
                    suKienTinhTien2?.Invoke(this, e);

                }
                else return;
            }
        }

        private void panelPhong4_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong4.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong4.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong4.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong4.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong4.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong4.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong4.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong4.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong5_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong5.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong5.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong5.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong5.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong5.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong5.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong5.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong5.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong6_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong6.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong6.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong6.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong6.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong6.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong6.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong6.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong6.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong7_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong7.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong7.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong7.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong7.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong7.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong7.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong7.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong7.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong8_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong8.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong8.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong8.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong8.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong8.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong8.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong8.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong8.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong9_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong9.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong9.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong9.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong9.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong9.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong9.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong9.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong9.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong10_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong10.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong10.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong10.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong10.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong10.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong10.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong10.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong10.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong11_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong11.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong11.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong11.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong11.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong11.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong11.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong11.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong11.Text);
                    suKienTinhTien2?.Invoke(this, e);
                    
                }
                else return;
            }
        }

        private void panelPhong12_Click(object sender, EventArgs e)
        {
            RoomNV.takeInfoCustomer(lblMaPhong12.Text);//khi click đưa thông tin mã phòng và khách lên
            if (panelPhong12.BackColor == Color.FromArgb(54, 54, 54))
            {
                MessageBox.Show("Phòng đang dọn, vui lòng không chọn phòng này!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (panelPhong12.BackColor == Color.FromArgb(153, 204, 51))
            {
                FormXacNhanDangKyKhacHang.maPhong = lblMaPhong12.Text + " Loại Phòng : " + chuyenTenPhong(lblLoaiPhong12.Text);
                FormXacNhanDangKyKhacHang formXacNhan = new FormXacNhanDangKyKhacHang();
                FormXacNhanDangKyKhacHang.maPhongDangKy = lblMaPhong12.Text;

                formXacNhan.ShowDialog();
                loadRoomStart(sender, e);
            }
            else
            {
                ThongBaoTInhTien_ThemDichVu xacNhan = new ThongBaoTInhTien_ThemDichVu();
                xacNhan.ShowDialog();
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == 1)
                {
                    suKienThemDichVu2?.Invoke(this, e);
                    ServiceNV.MaPhongTextBox = lblMaPhong12.Text;
                }
                if (ThongBaoTInhTien_ThemDichVu.xacNhanChuyenTrang == -1)
                {
                    RoomNV.takeInfoCustomer(lblMaPhong12.Text);
                    suKienTinhTien2?.Invoke(this, e);
                   
                }
                else return;
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            string ngayThang = string.Format("{0}", DateTime.Now.ToString("dd/MM/yyy"));
            lblNgayThang1.Text = lblNgayThang2.Text = ngayThang;
            lblNgayThang3.Text = lblNgayThang4.Text = ngayThang;
            lblNgayThang5.Text = lblNgayThang6.Text = ngayThang;
            lblNgayThang7.Text = lblNgayThang8.Text = ngayThang;
            lblNgayThang9.Text = lblNgayThang10.Text = ngayThang;
            lblNgayThang11.Text = lblNgayThang12.Text = ngayThang;

            string gio = string.Format("{0}", DateTime.Now.ToString("hh:mm:ss tt"));
            lblGio1.Text = lblGio2.Text = lblGio3.Text = gio;
            lblGio4.Text = lblGio5.Text = lblGio6.Text = gio;
            lblGio7.Text = lblGio8.Text = lblGio9.Text = gio;
            lblGio10.Text = lblGio12.Text = lblGio11.Text = gio;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gioSuDung2++;

            int hours = gioSuDung2 / 3600;
            int minutes = (gioSuDung2 % 3600) / 60;
            int seconds = gioSuDung2 % 60;

            lblSoGioPhut2.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gioSuDung1++;

            int hours = gioSuDung1 / 3600;
            int minutes = (gioSuDung1 % 3600) / 60;
            int seconds = gioSuDung1 % 60;

            lblSoGioPhut1.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            gioSuDung3++;

            int hours = gioSuDung3 / 3600;
            int minutes = (gioSuDung3 % 3600) / 60;
            int seconds = gioSuDung3 % 60;

            lblSoGioPhut3.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            gioSuDung4++;

            int hours = gioSuDung4 / 3600;
            int minutes = (gioSuDung4 % 3600) / 60;
            int seconds = gioSuDung4 % 60;

            lblSoGioPhut4.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            gioSuDung5++;

            int hours = gioSuDung5 / 3600;
            int minutes = (gioSuDung5 % 3600) / 60;
            int seconds = gioSuDung5 % 60;

            lblSoGioPhut5.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            gioSuDung6++;

            int hours = gioSuDung6 / 3600;
            int minutes = (gioSuDung6 % 3600) / 60;
            int seconds = gioSuDung6 % 60;

            lblSoGioPhut6.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            gioSuDung7++;

            int hours = gioSuDung7 / 3600;
            int minutes = (gioSuDung7 % 3600) / 60;
            int seconds = gioSuDung7 % 60;

            lblSoGioPhut7.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            gioSuDung8++;

            int hours = gioSuDung8 / 3600;
            int minutes = (gioSuDung8 % 3600) / 60;
            int seconds = gioSuDung8 % 60;

            lblSoGioPhut8.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            gioSuDung9++;

            int hours = gioSuDung9 / 3600;
            int minutes = (gioSuDung9 % 3600) / 60;
            int seconds = gioSuDung9 % 60;

            lblSoGioPhut9.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            gioSuDung10++;

            int hours = gioSuDung10 / 3600;
            int minutes = (gioSuDung10 % 3600) / 60;
            int seconds = gioSuDung10 % 60;

            lblSoGioPhut10.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            gioSuDung12++;

            int hours = gioSuDung12 / 3600;
            int minutes = (gioSuDung12 % 3600) / 60;
            int seconds = gioSuDung12 % 60;

            lblSoGioPhut12.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            gioSuDung11++;

            int hours = gioSuDung11 / 3600;
            int minutes = (gioSuDung11 % 3600) / 60;
            int seconds = gioSuDung11 % 60;

            lblSoGioPhut11.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbTimKiem.SelectedIndex = 0;
            suKienChuyenTrang1?.Invoke(this, e);
        }

        private void RoomTrang2_Load(object sender, EventArgs e)
        {
            loadRoomStart(sender, e);
            cmbTimKiem.SelectedIndex = 0;
        }

        public static bool xacThucLoadTrang = false;//Khi xác thực load một lần
        private int demLoad = 0;//sau 30s load một lần
        private void RefreshTrang2_Tick(object sender, EventArgs e)
        {
            demLoad++;
            if (demLoad % 31 == 0)
            {
                loadRoomStart(sender, e);
                demLoad = 1;
                return;
            }

            if (xacThucLoadTrang == true)
            {
                loadRoomStart(sender, e);
                xacThucLoadTrang = false;
                return;
            }
        }

        private void anPanelALl()
        {
            panelPhong1.Visible = false;
            panelPhong2.Visible = false;
            panelPhong3.Visible = false;
            panelPhong4.Visible = false;
            panelPhong5.Visible = false;
            panelPhong6.Visible = false;
            panelPhong7.Visible = false;
            panelPhong8.Visible = false;
            panelPhong9.Visible = false;
            panelPhong10.Visible = false;
            panelPhong11.Visible = false;
            panelPhong12.Visible = false;
        }
        private void hienThiPanelAll()
        {
            panelPhong1.Visible = true;
            panelPhong2.Visible = true;
            panelPhong3.Visible = true;
            panelPhong4.Visible = true;
            panelPhong5.Visible = true;
            panelPhong6.Visible = true;
            panelPhong7.Visible = true;
            panelPhong8.Visible = true;
            panelPhong9.Visible = true;
            panelPhong10.Visible = true;
            panelPhong11.Visible = true;
            panelPhong12.Visible = true;
        }

        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            anPanelALl();
            if(cmbTimKiem.SelectedIndex == 0) {
                hienThiPanelAll();
            }
            else if(cmbTimKiem.SelectedIndex == 1)
            {
                timKiemPhong("DonThuong");
            } 
            else if(cmbTimKiem.SelectedIndex == 2)
            {
                timKiemPhong("DoiVip");
            }    
            else if(cmbTimKiem.SelectedIndex == 3)
            {
                timKiemPhong("DoiThuong");
            }    
            else if(cmbTimKiem.SelectedIndex == 4)
            {
                timKiemPhong("DonVip");
            }   
            else if(cmbTimKiem.SelectedIndex == 5)
            {
                timKiemPhong("GDThuong");
            }    
            else if(cmbTimKiem.SelectedIndex == 6)
            {
                timKiemPhong("GDVip");
            }    
            
            
        }
        private void timKiemPhong(string hienThi)
        {
            if(lblLoaiPhong1.Text.Contains(hienThi))
            {
                panelPhong1.Visible = true;
            }
            if (lblLoaiPhong2.Text.Contains(hienThi))
            {
                panelPhong2.Visible = true;
            }
            if (lblLoaiPhong3.Text.Contains(hienThi))
            {
                panelPhong3.Visible = true;
            }
            if (lblLoaiPhong4.Text.Contains(hienThi))
            {
                panelPhong4.Visible = true;
            }
            if (lblLoaiPhong5.Text.Contains(hienThi))
            {
                panelPhong5.Visible = true;
            }
            if (lblLoaiPhong6.Text.Contains(hienThi))
            {
                panelPhong6.Visible = true;
            }
            if (lblLoaiPhong7.Text.Contains(hienThi))
            {
                panelPhong7.Visible = true;
            }
            if (lblLoaiPhong8.Text.Contains(hienThi))
            {
                panelPhong8.Visible = true;
            }
            if (lblLoaiPhong9.Text.Contains(hienThi))
            {
                panelPhong9.Visible = true;
            }
            if (lblLoaiPhong10.Text.Contains(hienThi))
            {
                panelPhong10.Visible = true;
            }
            if (lblLoaiPhong11.Text.Contains(hienThi))
            {
                panelPhong11.Visible = true;
            }
            if (lblLoaiPhong12.Text.Contains(hienThi))
            {
                panelPhong12.Visible = true;
            }
        }
    }
}
