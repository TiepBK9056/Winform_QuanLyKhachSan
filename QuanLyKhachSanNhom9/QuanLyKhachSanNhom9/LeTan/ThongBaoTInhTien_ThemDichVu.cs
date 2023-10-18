using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.LeTan
{
    public partial class ThongBaoTInhTien_ThemDichVu : Form
    {
        public static int xacNhanChuyenTrang = 2710;
        public ThongBaoTInhTien_ThemDichVu()
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

        private void ThongBaoTInhTien_ThemDichVu_Load(object sender, EventArgs e)
        {
            SetRoundCorners(this, 50);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            xacNhanChuyenTrang = 1;
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            xacNhanChuyenTrang = -1;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            xacNhanChuyenTrang = 0;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
