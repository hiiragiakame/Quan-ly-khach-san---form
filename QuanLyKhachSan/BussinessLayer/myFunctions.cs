using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class myFunctions
    {
        public static String _srv = ".\\sqlexpress";
        public static String _us = "sa";
        public static String _ps = "123abc";
        public static String _db = "KhachSan";
        static SqlConnection con = new SqlConnection();
        public static void taoKetNoi()
        {
            con.ConnectionString = "Data Source=" + _srv + ";Initial Catalog=" + _db + ";User ID=" + _us + ";Password=" + _ps;
            try
            {
                con.Open();
            }
            catch (Exception)
            {

            }
        }
        public static void dongKetNoi()
        {
            con.Close();
        }
        public static DataTable layDuLieu(String qr)
        {
            taoKetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(qr, con);
            da.Fill(dt);
            dongKetNoi();
            return dt;
        }
        public static DateTime layNgayDauCuaThang(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
    }
}
