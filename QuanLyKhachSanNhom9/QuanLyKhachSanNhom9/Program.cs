using QuanLyKhachSanNhom9.DangNhap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSanNhom9.LeTan;
using QuanLyKhachSanNhom9.Admin;
using QuanLyKhachSanNhom9.QuanLyNhanVien;
using QuanLyKhachSanNhom9.KeToan;
using Nhom9_DoAnQuanLiKhachSan;

namespace QuanLyKhachSanNhom9
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDangNhap());
        }
    }
}
