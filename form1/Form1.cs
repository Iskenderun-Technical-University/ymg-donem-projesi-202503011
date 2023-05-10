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

namespace form1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
       
        SqlCommand cmd;
        DataSet ds;
          //public static string SqlCon=@"Data Source=KUTHAN\SQLEXPRESS;Initial Catalog=202503011;Integrated Security=True";
        
        void GridDoldur()
        {
            con = new SqlConnection(VeriTabani.baglantı());
            da = new SqlDataAdapter("select *from tbl_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_login");
            dataGridView1.DataSource = ds.Tables["tbl_login"];
            con.Close();
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
          /* Form2 a = new Form2();
           a.Show();
            this.Hide();*/
            VeriTabani.GridDoldur(dataGridView1, "select *from tbl_login");
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            con = new SqlConnection(VeriTabani.baglantı());
            string sql = "insert into tbl_login(kullanici, sifre, tarih) values (@user, @pass, @tarih)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox3.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();

        }
        public void ekle(string sql)
        {
            con = new SqlConnection(VeriTabani.baglantı());
            
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection(VeriTabani.baglantı());
            string sql = "delete from tbl_login where kullanici=@user and sifre=@pass and kID=@idm";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox3.Text);
            cmd.Parameters.AddWithValue("@idm", Convert.ToInt32(textBox1.Text)) ;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           

           con = new SqlConnection(VeriTabani.baglantı());
            string sql = "update tbl_login set kullanici=@user where sifre=@pass and kID=@idm";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox3.Text));
            cmd.Parameters.AddWithValue("@idm", Convert.ToInt32(textBox1.Text));
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();

        }

        private void şifreDeğiştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifredegistir a = new sifredegistir();
            a.ShowDialog();
        }

        private void ödemeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fiyatBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiyatGoster a = new FiyatGoster();
            a.ShowDialog();
        }

        private void ödemeYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odeme b = new odeme();
            b.ShowDialog();

        }

        private void detaylıAramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AramaYap c = new AramaYap();
            c.ShowDialog();
        }
    }
}
