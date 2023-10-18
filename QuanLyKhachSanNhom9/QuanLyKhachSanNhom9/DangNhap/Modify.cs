
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanNhom9.DangNhap
{
    public class Modify
    {
        public Modify() { }
        SqlCommand sqlCommand;
        SqlDataReader dataReader;

        public List<TaiKhoan> TaiKhoans(string query)//check tài khoản
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();


            using (SqlConnection sqlConnection = new SqlConnection(WindowsFormsApp1.TruyVan.strConnection))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);

                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public void Command(string query)//dùng để đăng ký tài khoản
        {
            using (SqlConnection sqlCon = new SqlConnection(WindowsFormsApp1.TruyVan.strConnection))
            {
                sqlCon.Open();
                sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}
