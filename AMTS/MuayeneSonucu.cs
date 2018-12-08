using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace AMTS
{
    public partial class MuayeneSonucu : Form
    {
        private String RuhsatNo { get; set; }
        private String PlakaNo { get; set; }
        private AmtsDbContext vt { get; set; }
        private Form Secim { get; set; }
        private Boolean kapa { get; set; }
        public MuayeneSonucu(String ruhsatNo, String plakaNo, Form Secim)
        {
            InitializeComponent();
            RuhsatNo = ruhsatNo;
            PlakaNo = plakaNo;
            this.Secim = Secim;
            vt = new AmtsDbContext();
            kapa = true;
        }

        private void MuayeneSonucu_Load(object sender, EventArgs e)
        {
            GecmisKayitlar bilgiler = vt.GecmisKayitlar.Where(r => r.RuhsatNo == RuhsatNo).OrderByDescending(x => x.Id).First();
            istasyonAdi.Text = bilgiler.Istasyon;
            tarih.Text = bilgiler.Tarih;
            sonuc.Text = bilgiler.MuayaneSonucu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kapa = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MuayeneSonucu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!kapa)
                Secim.Show();

            else
                Secim.Close();
        }
    }
}
