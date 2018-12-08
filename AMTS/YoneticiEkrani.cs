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
    public partial class YoneticiEkrani : Form
    {
        private AmtsDbContext vt;
        private SonucGirisi sonucGirisi;
        private Form mdi;

        public YoneticiEkrani(AmtsDbContext vt, Form mdi)
        {
            InitializeComponent();
            this.vt = vt;
            this.mdi = mdi;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kayitlar.SelectedItems.Count == 1)
            {
                int indeks = Convert.ToInt32(kayitlar.SelectedItems[0].Text) - 1;
                sonucGirisi = new SonucGirisi(vt, kayitlar, indeks);
                sonucGirisi.ShowDialog();
            }

            else
                MessageBox.Show("Lütfen bir kayıt seçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void YoneticiEkrani_Load(object sender, EventArgs e)
        {
            MuayeneBilgisi muayeneBilgisi;

            for (int i=0; i <vt.AracBilgileri.Count(); i++)
            {
                muayeneBilgisi = vt.AracBilgileri.OrderBy(x => x.Tarih).Skip(i).First();

                ListViewItem bilgiler = new ListViewItem((i+1).ToString());
                bilgiler.SubItems.Add(muayeneBilgisi.RuhsatNo);
                bilgiler.SubItems.Add(muayeneBilgisi.PlakaNo);
                bilgiler.SubItems.Add(muayeneBilgisi.Ad);
                bilgiler.SubItems.Add(muayeneBilgisi.Soyadi);
                bilgiler.SubItems.Add(muayeneBilgisi.TelNo);
                bilgiler.SubItems.Add(muayeneBilgisi.Sehir);
                bilgiler.SubItems.Add(muayeneBilgisi.Istasyon);
                bilgiler.SubItems.Add(muayeneBilgisi.AracTipi);
                bilgiler.SubItems.Add(muayeneBilgisi.Tarih);
                bilgiler.SubItems.Add(muayeneBilgisi.Saat);
                bilgiler.SubItems.Add(muayeneBilgisi.MuayaneSonucu);

                kayitlar.Items.Add(bilgiler);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (kayitlar.SelectedItems.Count == 1)
            {
                DialogResult sonuc = MessageBox.Show("Bu kaydı silmek istediğinize gerçekten emin misiniz?", "Dikkatli olun", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (sonuc == DialogResult.Yes)
                {
                    int indeks = Convert.ToInt32(kayitlar.SelectedItems[0].Text) - 1;
                    MuayeneBilgisi muayeneBilgisi = vt.AracBilgileri.Find(kayitlar.Items[indeks].SubItems[1].Text);
                    vt.AracBilgileri.Remove(muayeneBilgisi);
                    vt.SaveChanges();
                    MessageBox.Show("Kayıt başarıyla silindi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kayitlar.Items.Clear();
                    YoneticiEkrani_Load(this, null);
                }
            }

            else
                MessageBox.Show("Lütfen bir kayıt seçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kayitlar.SelectedItems.Count == 1)
            {
                DialogResult sonuc = MessageBox.Show("Bu kaydı Geçmiş Kayıtlar'a aktarmak istediğinize gerçekten emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (sonuc == DialogResult.Yes)
                {
                    if (kayitlar.SelectedItems[0].SubItems[11].Text != "Girilmedi")
                    {
                        int indeks = Convert.ToInt32(kayitlar.SelectedItems[0].Text) - 1;
                        MuayeneBilgisi muayeneBilgisi = vt.AracBilgileri.Find(kayitlar.Items[indeks].SubItems[1].Text);
                        
                            GecmisKayitlar gecmisKayitlar = new GecmisKayitlar(muayeneBilgisi);
                            vt.GecmisKayitlar.Add(gecmisKayitlar);
                            vt.AracBilgileri.Remove(muayeneBilgisi);
                            vt.SaveChanges();
                            MessageBox.Show("Kayıt başarılya aktarıldı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            kayitlar.Items.Clear();
                            YoneticiEkrani_Load(this, null);
                    }

                    else
                        MessageBox.Show("Bir kayıt muayene edilemeden geçmiş kayıtlara aktarılamaz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Lütfen bir kayıt seçiniz.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kayitlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
