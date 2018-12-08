using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMTS
{
    public partial class Secim : Form
    {
        public Secim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris(true, this);
            Hide();
            giris.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiGirisi yoneticiGirisi = new YoneticiGirisi(this);
            Hide();
            yoneticiGirisi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris(false, this);
            Hide();
            giris.Show();
        }
    }
}
