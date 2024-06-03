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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-74F1HKQB\SQLEXPRESS;Initial Catalog=TekneDb;Integrated Security=True;TrustServerCertificate=True");
        private void button2_Click(object sender, EventArgs e)
        {
            PersonelTb.Text = "";
            SifreTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           baglanti.Open();
           SqlCommand komut = new SqlCommand("Select * from Personeltb Where personel=@p1 and sifre=@p2", baglanti);
           komut.Parameters.AddWithValue("@p1", PersonelTb.Text);
           komut.Parameters.AddWithValue("@p2", SifreTb.Text);
           SqlDataReader dr = komut.ExecuteReader();
           if(dr.Read())
            {
                Anasayfa ans = new Anasayfa();
                ans.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giris Yaptınız");
            }
           baglanti.Close();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KayıtOl kyt = new KayıtOl();
            kyt.Show();

           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
