using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace form1
{
    public partial class sifredegistir : Form
    {
         SqlConnection con;
         SqlDataReader dr;
        SqlCommand cmd;
       
        public int sonuc = 0;
        public sifredegistir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox4.Text == sonuc.ToString())
            {
                if (textBox2.Text ==textBox3.Text)
                {
                    eskisifrekontrol();
                }
                else
                {
                    label5.Text = "Eski Ve Yeni Şifre Aynı Değil";
                    CaptchaDegistir();
                }
            }
            else
            {
                label5.Text = "Captcha Hatalı Girilmiştir ";
                CaptchaDegistir();
            }
        }
        public  bool eskisifrekontrol()
        {
            string sor = "select sifre from tbl_login where kullanici=@user and sifre=@pass";
            con = new SqlConnection(VeriTabani.baglantı());
            cmd = new SqlCommand(sor, con);
            cmd.Parameters.AddWithValue("@user", Form3.kullaniciSession);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox1.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string sql= "update tbl_login set sifre='"+VeriTabani.MD5Sifrele(textBox2.Text)+"'";
                VeriTabani.komut(sql);
                MessageBox.Show("Şifreniz Başarıyla Değiştirildi");
            }
            else
            {
                label5.Text = "Eski Şifreniz Yanlış";
                CaptchaDegistir();
            }
            con.Close();
            return true;
        }
        public void CaptchaDegistir()
        {
            Random a = new Random();
            int ilk = a.Next(0, 50);
            int iki = a.Next(0, 50);
            sonuc = ilk + iki;
            label4.Text = ilk.ToString() + "+" + iki.ToString() + "=";
            //label5.Text = Form3.kullaniciSession;
            textBox4.Clear();
        }

        private void sifredegistir_Load(object sender, EventArgs e)
        {
            label5.Name = "";
            CaptchaDegistir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
