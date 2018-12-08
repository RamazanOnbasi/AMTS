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
    public partial class YoneticiMDI : Form
    {
        private YoneticiEkrani yoneticiEkrani { get; set; }
        private GecmisKayitlarTablo gecmisKayitlar { get; set; }
        private AmtsDbContext vt { get; set; }
        private Boolean kapa { get; set; }
        private Form Secim { get; set; }

        public YoneticiMDI(Form Secim)
        {
            InitializeComponent();
            vt = new AmtsDbContext();
            yoneticiEkrani = new YoneticiEkrani(vt ,this);
            yoneticiEkrani.MdiParent = this;
            yoneticiEkrani.Dock = DockStyle.Fill;
            gecmisKayitlar = new GecmisKayitlarTablo(vt);
            gecmisKayitlar.MdiParent = this;
            gecmisKayitlar.Dock = DockStyle.Fill;
            kapa = true;
            this.Secim = Secim;
        }

        private void Tablo_Load(object sender, EventArgs e)
        {
            yoneticiEkrani.Show();
        }

        private void YoneticiMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kapa)
                Secim.Close();

            else
                Secim.Show();
        }

        private void kayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!yoneticiEkrani.Visible)
            {
                gecmisKayitlar.Hide();
                yoneticiEkrani.Show();
            }
        }

        private void geçmişKayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yoneticiEkrani.Visible)
            {
                yoneticiEkrani.Hide();
                gecmisKayitlar.Show();
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yoneticiEkrani.Visible)
            {
                yoneticiEkrani.kayitlar.Items.Clear();
                yoneticiEkrani.YoneticiEkrani_Load(this, null);
            }

            else
            {
                gecmisKayitlar.gecmisKayitlari.Items.Clear();
                gecmisKayitlar.GecmisKayitlarTablo_Load(this, null);
            }
        }

        private void çıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(sonuc == DialogResult.Yes)
            {
                kapa = false;
                Close();

            }
        }
    }
}
