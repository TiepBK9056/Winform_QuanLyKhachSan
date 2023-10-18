using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public class Connection
    {
        //public static string strConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\OWNER\source\repos\QuanLyKhachSanNhom9_Final1\QuanLyKhachSan_Tuan7\Database\Database1.mdf;Integrated Security=True";
        public static string strConnection = @"Data Source=TiepNguyen\SQLEXPRESS;Initial Catalog=QuanLyKhachSanNhom9;Integrated Security=True";

        public static SqlConnection GetSqlConnectinon()
        {
            return new SqlConnection(strConnection);
        }
    }
}
