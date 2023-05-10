using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace form1
{
    class VeriTabani
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

       public static string baglantı()
        {
            string sqlcon = @"Data Source=DESKTOP-CN1FD9T\SQLEXPRESS01;Initial Catalog=202503011;Integrated Security=True";
            return sqlcon;
        }

       

        public static DataGridView GridDoldur(DataGridView gridim, string sqlSelectSorgu)
        {
            
            con = new SqlConnection(baglantı());
            da = new SqlDataAdapter(sqlSelectSorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);
            gridim.DataSource = ds.Tables[sqlSelectSorgu];
            con.Close();
            return gridim;


        }
        public static bool Giris(string kullanici, string sifre)
        {
            string sor = "select * from tbl_login where kullanici=@user and sifre=@pass";
            con = new SqlConnection(baglantı());
            cmd = new SqlCommand(sor, con);
            cmd.Parameters.AddWithValue("@user", kullanici);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(sifre));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }


        public static string MD5Sifrele(string SifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(SifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();
        }
        public static void komut(string sql)
        {
            con = new SqlConnection(baglantı());
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
