using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;

namespace AMTS
{
    public partial class SonucGirisi : Form
    {
        private String Ruhsat { get; set; }
        private AmtsDbContext vt;
        private MuayeneBilgisi bilgiler;
        private ListView kayitlar;
        private int indeks;
        public SonucGirisi(AmtsDbContext vt, ListView kayitlar, int indeks)
        {
            InitializeComponent();
            this.kayitlar = kayitlar;
            this.indeks = indeks;
            Ruhsat = kayitlar.Items[indeks].SubItems[1].Text;
            this.vt = vt;
            bilgiler = vt.AracBilgileri.Find(Ruhsat);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String muayeneSonucu; 

            if(kusursuz.Checked || hafifKusurlu.Checked || emniyetsiz.Checked || agirKusurlu.Checked)
            {
                if (kusursuz.Checked)
                    muayeneSonucu = "Kusursuz";

                else if (hafifKusurlu.Checked)
                    muayeneSonucu = "Hafif Kusurlu";

                else if (emniyetsiz.Checked)
                    muayeneSonucu = "Emniyetsiz";

                else
                    muayeneSonucu = "Ağır Kusurlu";

                bilgiler.MuayaneSonucu = muayeneSonucu;
                vt.AracBilgileri.AddOrUpdate(bilgiler);
                vt.SaveChanges();

                kayitlar.Items[indeks].SubItems[11].Text = muayeneSonucu;
                MessageBox.Show("Muayene sonucu başarıyla girildi.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            else
                MessageBox.Show("Muayene sonucuunu seçiniz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void SonucGirisi_Load(object sender, EventArgs e)
        {
            ruhsatNo.Text = bilgiler.RuhsatNo;
            plakaNo.Text = bilgiler.PlakaNo;
            ad.Text = bilgiler.Ad;
            soyadi.Text = bilgiler.Soyadi;
            telNo.Text = bilgiler.TelNo;
            sehir.Text = bilgiler.Sehir;
            istasyon.Text = bilgiler.Istasyon;
            aracTipi.Text = bilgiler.AracTipi;
            tarih.Text = bilgiler.Tarih;
            saat.Text = bilgiler.Saat;
        }
    }
}
