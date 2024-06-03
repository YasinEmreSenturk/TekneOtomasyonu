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
    public partial class TekneEkle : Form
    {
        public TekneEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-74F1HKQB\SQLEXPRESS;Initial Catalog=TekneDb;Integrated Security=True;TrustServerCertificate=True");


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TekneEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tadtb.Text == "" || Tyıltb.Text == "" || Tfiyattb.Text == "" || SerinoTb.Text == "" || ZamanlamaCb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "Insert into TekneTbl values ('" + Tadtb.Text + "','" + Tyıltb.Text + "','" + Tfiyattb.Text + "','" + SerinoTb.Text + "','" + ZamanlamaCb.SelectedItem.ToString() + "')";
                    SqlCommand komut=new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tekne Başarıyla Eklendi");
                    baglanti.Close();
                    Tadtb.Text = "";
                    Tyıltb.Text = "";
                    Tfiyattb.Text = "";
                    SerinoTb.Text = "";
                    ZamanlamaCb.Text = "";


                }
                catch(Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tadtb.Text = "";
            Tyıltb.Text = "";
            Tfiyattb.Text = "";
            SerinoTb.Text = "";
            ZamanlamaCb.Text = "";
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Anasayfa anasayfa = new Anasayfa();
           anasayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
