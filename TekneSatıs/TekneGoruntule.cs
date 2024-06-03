using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Guna.UI2.Native.WinApi;

namespace Projem
{
    public partial class TekneGoruntule : Form
    {
        public TekneGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-74F1HKQB\SQLEXPRESS;Initial Catalog=TekneDb;Integrated Security=True;TrustServerCertificate=True");
        private void Tekneler()
        {
            baglanti.Open();
            string query = "select * from TekneTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds= new DataSet(query);
            sda.Fill(ds);
            TekneDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void TekneGoruntule_Load(object sender, EventArgs e)
        {
            Tekneler();
        }

        private void TekneDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void AraTeknetb_TextChanged(object sender, EventArgs e)
        {

        }
        private void TekneFiltreleme()
        {
            baglanti.Open();
            string query = "select * from TekneTbl where TAd='" + AraTeknetb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet(query);
            sda.Fill(ds);
            TekneDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TekneFiltreleme();
            AraTeknetb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tekneler();
        }
    }
}
