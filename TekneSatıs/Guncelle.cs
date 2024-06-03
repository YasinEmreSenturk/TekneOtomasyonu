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
    public partial class Guncelle : Form
    {
        public Guncelle()
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
            var ds = new DataSet(query);
            sda.Fill(ds);
            TekneDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int key = 0;
        private void TekneDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key=Convert.ToInt32(TekneDGV.SelectedRows[0].Cells[0].Value.ToString());
            Gadtb.Text = TekneDGV.SelectedRows[0].Cells[1].Value.ToString();
            Gyıltb.Text = TekneDGV.SelectedRows[0].Cells[2].Value.ToString();
            GFiyattb.Text = TekneDGV.SelectedRows[0].Cells[3].Value.ToString();
            Gserinotb.Text = TekneDGV.SelectedRows[0].Cells[4].Value.ToString();
            Gsatıscb.Text = TekneDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void Guncelle_Load(object sender, EventArgs e)
        {
            Tekneler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gadtb.Text = "";
            Gyıltb.Text = "";
            GFiyattb.Text = "";
            Gserinotb.Text = "";
            Gsatıscb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0||Gadtb.Text==""||Gyıltb.Text==""||GFiyattb.Text==""||Gserinotb.Text==""||Gsatıscb.Text=="")
            {
                MessageBox.Show("Eksik Veri Girdiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update TekneTbl set TAd='"+Gadtb.Text+"',TYıl='"+Gyıltb.Text+"',TOdeme='"+GFiyattb.Text+"',TSerino='"+Gserinotb.Text+"',TZaman='"+Gsatıscb.Text+"' where TId="+key+";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tekne Güncellendi");
                    baglanti.Close();
                    Tekneler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Anasayfa  anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key==0)
            {
                MessageBox.Show("Silinecek olan Tekneyi Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from TekneTbl where TId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tekne Başarıyla Silindi");
                    baglanti.Close();
                    Tekneler();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }
            }
        }

        private void Gadtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
