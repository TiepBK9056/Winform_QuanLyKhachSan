using FontAwesome.Sharp;
using QuanLyKhachSanNhom9.LeTan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.QuanLyNhanVien
{
    public partial class MainNhanVien : Form
    {


        //Khai báo các form con
        RoomNV romNV;
        Customer customer;
        ServiceNV serviceNV;
        PaymentNVcs paymentNVcs;
        RoomTrang2 romNV2;
        Contact contact;
        HomeHappy homeHappy;


        private IconButton currentBtn;
        private Panel leftBorderBtn;//thiết lập cho nút menu (tạo thanh đánh dấu dọc khi click vào)
        private Panel rightBorderBtn;//thiết lập cho nút logout 
        private struct RGBColors//các màu đặt sẵn
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
        }
        public MainNhanVien()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 70);//kích thước x phụ thuộc độ rộng mình muốn, y phụ thuộc vào chiều dài của icon button
            panelMeNu.Controls.Add(leftBorderBtn);
            rightBorderBtn = new Panel();
            rightBorderBtn.Size = new Size(128, 15);//tạo dối tượng đánh dấu vào panel trên cùng logout
            PanelHead.Controls.Add(rightBorderBtn);
            
        }
        private void DangKyChiTiet(object sender, EventArgs e)
        {
            serviceNV.BringToFront();
        }
        private void ActiveButton(object senderBtn, Color color, int danhDau)//danhDau để biêt thanh ngang hay dọc
        {
            if (danhDau == 1)
            {
                if (senderBtn != null)
                {
                    DisableButton();
                    currentBtn = (IconButton)senderBtn;//ép kiểu đối tượng được gửi tới
                    currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;//sau khi nhan dua text vao giua
                    currentBtn.ForeColor = color;
                    currentBtn.IconColor = color;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;//chinh lại thuoc tinh chu truoc icon
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;//cho icon chạy về cuối 

                    //cấu hình thanh đánh dấu
                    leftBorderBtn.BackColor = color;
                    leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);//vị trí bắt đầu x từ 0 vị trí y là nút ấn hiện tại
                    leftBorderBtn.Visible = true;//hiện thanh đánh dấu
                    leftBorderBtn.BringToFront();//để đưa thanh đánh dấu lên lớp đầu tiên 
                }
            }
            else
            {
                if (senderBtn != null)
                {
                    //DisableButton();
                    //cấu hình thanh đánh dấu 
                    currentBtn = (IconButton)senderBtn;
                    rightBorderBtn.BackColor = color;
                    rightBorderBtn.Location = new Point(currentBtn.Location.X, 70);//vị trí bắt đầu x từ 0 vị trí y là nút ấn hiện tại
                    rightBorderBtn.Visible = true;//hiện thanh đánh dấu
                    rightBorderBtn.BringToFront();//để đưa thanh đánh dấu lên lớp đầu tiên 
                }
            }
        }
        private void DisableButton()
        {

            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 128, 0);//màu của button sau khi không click
                currentBtn.ForeColor = Color.DarkBlue;//màu của chữ sau khi thoát click
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;//Vị trí sau khi thoát click

                currentBtn.IconColor = Color.FromArgb(0, 51, 51);//màu của iconchar sau khi thoát click
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;//thiết lập vị trí icon trước text
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;//Cho ảnh nằm ở vị trí giữa bên trái nhưng vẫn nằm trước icon
            }
        }
        private void thietLapKhiKhongChonGi()
        {
            leftBorderBtn.Visible = false;//ẩn thanh đánh dấu trên panel
            DisableButton();//thiết lập các trạng thái khi không click
        }
       ////////////////////////////////
  
        //Dang ky chi tiet
        private void CusChiTiet(object sender, EventArgs e)
        {
            customer.BringToFront();
        }
        ////////////////////////////////////
        

        private void icbService_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3, 1);
            contact.BringToFront();
            /*serviceNV.BringToFront();
            ServiceNV.MaPhongTextBox = "";*/
        }
      
       

        private void icbLogout_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RGBColors.color4, 2);
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();//thêm vào sau
            }
            else rightBorderBtn.Visible = false;

        }
        

        private void MainNhanVien_Load(object sender, EventArgs e)
        {
            //form rom
            romNV = new RoomNV();
            romNV.TopLevel = false;
            romNV.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
            panelMain.Controls.Add(romNV);// Điều chỉnh kích thước form con để phù hợp với Pane
            romNV.Dock = DockStyle.Fill;
            romNV.Show();

            customer = new Customer();
            customer.TopLevel = false;
            customer.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
            panelMain.Controls.Add(customer);// Điều chỉnh kích thước form con để phù hợp với Panel
            customer.Dock = DockStyle.Fill;
            customer.Show();

            serviceNV = new ServiceNV();
            serviceNV.TopLevel = false;
            serviceNV.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
            panelMain.Controls.Add(serviceNV);// Điều chỉnh kích thước form con để phù hợp với Panel
            serviceNV.Dock = DockStyle.Fill;
            serviceNV.Show();
//////////////////////////////////////////////////////////////////////////////////////////////////
            //Khởi tạo và thêm các sự kiện chuyển trang cho trang 1
            
            paymentNVcs = new PaymentNVcs();
            paymentNVcs.TopLevel = false;
            paymentNVcs.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(paymentNVcs);
            paymentNVcs.Dock = DockStyle.Fill;
            paymentNVcs.Show();

            



/////////////////////////////////////////////////////////////////////////////////////////////////////
            //Thêm trang nhân viên hai vào form để chuyển trang
            romNV2 = new RoomTrang2();
            romNV2.TopLevel = false;
            romNV2.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền
            panelMain.Controls.Add(romNV2);// Điều chỉnh kích thước form con để phù hợp với Pane
            romNV2.Dock = DockStyle.Fill;
            romNV2.Show();

            romNV2.suKienChuyenTrang1 -= chuyenTrang1;
            romNV2.suKienChuyenTrang1 += chuyenTrang1;

            romNV2.suKienThemDichVu2 -= DangKyChiTiet;
            romNV2.suKienThemDichVu2 += DangKyChiTiet;

            romNV2.suKienTinhTien2 -= TrangTinhTien;
            romNV2.suKienTinhTien2 += TrangTinhTien;


            //Thao tác bày đặt ngựa không cần trừ vẫn được
            ////sự kiện trang1
            
            romNV.suKienThemDichVu -= DangKyChiTiet;
            romNV.suKienThemDichVu += DangKyChiTiet;//dua su kien vao trước khi gọi

            romNV.suKienTinhTien -= TrangTinhTien;
            romNV.suKienTinhTien += TrangTinhTien;

            romNV.suKienChuyenTrang2 += chuyenTrang2;//dua su kien chuyển sang trang 2

            ///////////////////////////sự kiện payment
            paymentNVcs.loadTrangRoom -= chuyenTrang2;
            paymentNVcs.loadTrangRoom += chuyenTrang1;


            ///////////////////////////
            ///
            homeHappy = new HomeHappy();
            homeHappy.TopLevel = false;
            homeHappy.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(homeHappy);
            homeHappy.Dock = DockStyle.Fill;
            homeHappy.Show();

            contact = new Contact();
            contact.TopLevel = false;
            contact.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(contact);
            contact.Dock = DockStyle.Fill;
            contact.Show();

            contact.BringToFront();
            ///Làm ngược contact với home chưa có thời gian update
        }
        private void chuyenTrang2(object sender, EventArgs e)
        {
            romNV2.BringToFront();
        }
        private void chuyenTrang1(object sender, EventArgs e)
        {
            romNV.BringToFront();
        }
        private void TrangTinhTien(object sender, EventArgs e)
        {
            paymentNVcs.BringToFront();
        }
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icbRoom_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2, 1);
            romNV.BringToFront();
            romNV.suKienThemDichVu -= DangKyChiTiet;
            romNV.suKienThemDichVu += DangKyChiTiet;//dua su kien vao trước khi gọi
        }

        private void icbCustomer_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1, 1);

            customer.BringToFront();
        }

        private void icbPayment_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4, 1);
            homeHappy.BringToFront();
        }
    }
}
