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

namespace Projem
{
    public partial class KayıtOl : Form
    {
        public KayıtOl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-74F1HKQB\SQLEXPRESS;Initial Catalog=TekneDb;Integrated Security=True;TrustServerCertificate=True");
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personeltb (personel,sifre) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1",Kayıttb.Text);
            komut.Parameters.AddWithValue("@p2",kayıtsifretb.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            DialogResult result = MessageBox.Show("Personel Kaydı Oluşturuldu", "Bilgi", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
                if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
