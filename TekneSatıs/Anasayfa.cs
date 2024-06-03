using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projem
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            TekneEkle tekneEkle = new TekneEkle();
            tekneEkle.Show();
            this.Hide();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            guncelle.Show();
            this.Hide();

        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            TekneGoruntule tekneGoruntule = new TekneGoruntule();
            tekneGoruntule.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
