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

namespace Projem
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-74F1HKQB\SQLEXPRESS;Initial Catalog=TekneDb;Integrated Security=True;TrustServerCertificate=True");
        private void FillName() { 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TekneTbl",baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd",typeof(string));
            dt.Load(reader);
            Oadcb.ValueMember = "TAd";
            Oadcb.DataSource = dt;
            baglanti.Close();
        }

        private void TekneFiltreleme()
        {
            baglanti.Open();
            string query = "select * from OdemeTbl where OTekneAdı='"+Aratb.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet(query);
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Tekneler()
        {
            baglanti.Open();
            string query = "select * from OdemeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet(query);
            sda.Fill(ds);
            OdemeDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oadcb.Text = "";
            Ofiyattb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            FillName();
            Tekneler();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Oadcb.Text==""||Ofiyattb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi Girildi");
            }
            else
            {
                string Odemeperiyot=Otarih.Value.Month.ToString()+Otarih.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from OdemeTbl where OTekneAdı='" + Oadcb.SelectedValue.ToString() + "' and OAy='" + Odemeperiyot + "'", baglanti); 
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Zaten Ödeme Alındı");
                }
                else
                {
                    string query="insert into OdemeTbl values('"+Odemeperiyot+"','"+Oadcb.SelectedValue.ToString()+"',"+Ofiyattb.Text+")";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Başarıyla Ödendi");
                  

                }
                baglanti.Close();
                Tekneler();
            }
        }

        private void Otarih_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TekneFiltreleme();
            Aratb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tekneler();
        }
    }
}
