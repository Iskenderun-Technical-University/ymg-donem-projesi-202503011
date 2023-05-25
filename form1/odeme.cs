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
    public partial class odeme : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
       
        SqlCommand cmd;
        DataSet ds;
       
        void DoldurGrid()
        {
            con = new SqlConnection(VeriTabani.baglantı());
            da = new SqlDataAdapter("select *from tbl_arac", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_arac");
            dataGridView1.DataSource = ds.Tables["tbl_arac"];
            con.Close();
        }
        public odeme()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void odeme_Load(object sender, EventArgs e)
        {
           
            DoldurGrid();
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(VeriTabani.baglantı());
            string sql = "insert into tbl_arac(aracSahip, aracPlaka, aracTur, yıkamaTur, fiyat) values (@sahip, @plaka, @tur, @yika, @odeme)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@sahip", textBox2.Text);
            cmd.Parameters.AddWithValue("@plaka", textBox3.Text);
            cmd.Parameters.AddWithValue("@odeme", textBox4.Text);
            cmd.Parameters.AddWithValue("@tur", textBox5.Text);
            cmd.Parameters.AddWithValue("@yika", textBox6.Text);
           
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            DoldurGrid();
            MessageBox.Show("Ödeme İşlemi Başarıyla Gerçekleştirilmiştir.");
        }
        public void ekleme(string sql)
        {
            con = new SqlConnection(VeriTabani.baglantı());

            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            DoldurGrid();
            MessageBox.Show("Ödeme Gerçekleştirilmiştir.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = radioButton5.Text;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = radioButton6.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(VeriTabani.baglantı());
            string sql = "delete from tbl_arac where aracSahip=@sahip and aracPlaka=@plaka and fiyat=@odeme and aracTur=@tur and yıkamaTur=@yika and kIDM=@kidm ";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@sahip", textBox2.Text);
            cmd.Parameters.AddWithValue("@plaka", textBox3.Text);
            cmd.Parameters.AddWithValue("@odeme", textBox4.Text);
            cmd.Parameters.AddWithValue("@tur", textBox5.Text);
            cmd.Parameters.AddWithValue("@yika", textBox6.Text);
            cmd.Parameters.AddWithValue("@kidm", textBox1.Text);
            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            DoldurGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(VeriTabani.baglantı());
            string sql = "update tbl_arac set fiyat=@odeme, aracTur=@tur, yıkamaTur=@yika where aracSahip=@sahip and aracPlaka=@plaka and kIDM=@kidm";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@sahip", textBox2.Text);
            cmd.Parameters.AddWithValue("@plaka", textBox3.Text);
            cmd.Parameters.AddWithValue("@odeme", textBox4.Text);
            cmd.Parameters.AddWithValue("@tur", textBox5.Text);
            cmd.Parameters.AddWithValue("@yika", textBox6.Text);
            cmd.Parameters.AddWithValue("@kidm", textBox1.Text);
           
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            DoldurGrid();
        }
        public int a = 0;
        private void button5_Click(object sender, EventArgs e)
        {    
            if (radioButton1.Checked == true && radioButton4.Checked == true)
            {
                 a = 30;
                textBox4.Text = a.ToString();
            }else if(radioButton1.Checked == true && radioButton5.Checked == true)
            {
                a = 40;
                textBox4.Text = a.ToString();
            }
            else if (radioButton1.Checked == true && radioButton6.Checked == true)
            {
                a = 60;
                textBox4.Text = a.ToString();
            }
            else if (radioButton2.Checked == true && radioButton4.Checked == true)
            {
                a = 10;
                textBox4.Text = a.ToString();
            }
            else if (radioButton2.Checked == true && radioButton5.Checked == true)
            {
                a = 15;
                textBox4.Text = a.ToString();
            }
            else if (radioButton2.Checked == true && radioButton6.Checked == true)
            {
                a = 22;
                textBox4.Text = a.ToString();
            }
            else if (radioButton3.Checked == true && radioButton4.Checked == true)
            {
                a = 40;
                textBox4.Text = a.ToString();
            }
            else if (radioButton3.Checked == true && radioButton5.Checked == true)
            {
                a = 50;
                textBox4.Text = a.ToString();
            }
            else if (radioButton3.Checked == true && radioButton6.Checked == true)
            {
                a = 80;
                textBox4.Text = a.ToString();
            }
        }
    }
}
