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
using System.Globalization;

namespace AMTS
{
    public partial class GuncellemeForm : AMTS.Randevu
    {
        private AmtsDbContext vt { get; set; }
        private String RuhsatNo { get; set; }
        private String PlakaNo { get; set; }
        private Form Secim { get; set; }
        private Form Guncelle { get; set; }
        private Boolean kapa { get; set; }

        public GuncellemeForm(String ruhsatNo, String plakaNo, Form Secim, Form Guncelle)
        {
            InitializeComponent();
            RuhsatNo = ruhsatNo;
            PlakaNo = plakaNo;
            vt = new AmtsDbContext();
            this.Secim = Secim;
            kapa = true;
            tarih.MinDate = DateTime.Today;
            this.Guncelle = Guncelle;
        }

        protected override void button2_Click(object sender, EventArgs e)
        {
            if (ad.Text.Length > 1 && soyadi.Text.Length > 1 && telNo.Text.Length > 1 && telNo.Text.Length == 14)
            {
                MuayeneBilgisi aracBilgisi = new MuayeneBilgisi(RuhsatNo, PlakaNo, ad.Text, soyadi.Text, telNo.Text, sehir.Text, istasyon.Text, aracTipi.Text, tarih.Text, saat.Text);
                vt.AracBilgileri.AddOrUpdate(aracBilgisi);
                vt.SaveChanges();
                MessageBox.Show("Randevunuz başarıyla güncellenmiştir.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kapa = false;
                Close();
            }

            else
                MessageBox.Show("Tüm alanları doğru bir şekilde doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void GuncellemeForm_Load(object sender, EventArgs e)
        {
            MuayeneBilgisi bilgiler = vt.AracBilgileri.Find(RuhsatNo);

            ad.Text = bilgiler.Ad;
            soyadi.Text = bilgiler.Soyadi;
            telNo.Text = bilgiler.TelNo;
            sehir.Text = bilgiler.Sehir;
            istasyon.Text = bilgiler.Istasyon;
            aracTipi.Text = bilgiler.AracTipi;
            tarih.Text = bilgiler.Tarih;
            saat.Text = bilgiler.Saat;
        }

        protected override void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(kapa)
                Guncelle.Show();

            else
            {
                Guncelle.Close();
                Secim.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
