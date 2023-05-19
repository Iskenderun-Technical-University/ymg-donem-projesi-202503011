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
    public partial class AramaYap : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
       // public static string SqlCon = @"Data Source=KUTHAN\SQLEXPRESS;Initial Catalog=202503011;Integrated Security=True";

       
        public string sqlSor;
        void GridDoldurma(string sql)
        {
            con = new SqlConnection(VeriTabani.baglantı());
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_arac");
            dataGridView1.DataSource = ds.Tables["tbl_arac"];
            con.Close();
        }
        public AramaYap()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        sqlSor = "select * from tbl_arac where aracSahip like '%" + textBox1.Text + "%' order by aracSahip ASC";
                        GridDoldurma(sqlSor);

                    }
                    else if (radioButton5.Checked)
                    {
                        sqlSor = "select * from tbl_arac where aracSahip like '%" + textBox1.Text + "%' order by aracSahip DESC";
                        GridDoldurma(sqlSor);
                    }

                }
                else if (radioButton2.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        sqlSor = "select * from tbl_arac where aracTur like '%" + textBox1.Text + "%' order by aracTur ASC";
                        GridDoldurma(sqlSor);

                    }
                    else if (radioButton5.Checked)
                    {
                        sqlSor = "select * from tbl_arac where aracTur like '%" + textBox1.Text + "%' order by aracTur DESC";
                        GridDoldurma(sqlSor);
                    }
                }
                else if (radioButton3.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        sqlSor = "select * from tbl_arac where fiyat> " + textBox1.Text;
                        GridDoldurma(sqlSor);

                    }
                    else if (radioButton5.Checked)
                    {
                        sqlSor = "select * from tbl_arac where fiyat<" + textBox1.Text;
                        GridDoldurma(sqlSor);
                    }
                }
            }
        }
    }
}
