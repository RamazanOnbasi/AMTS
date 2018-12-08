using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace AMTS
{
    public partial class Giris : Form
    {
        private Boolean randevuMu { get; set; }
        private Form Secim { get; set; }
        private Boolean kapa { get; set; }
        private Boolean arkadaAcik { get; set; }

        public Giris(Boolean randevuMu, Form Secim)
        {
            InitializeComponent();
            this.randevuMu = randevuMu;
            this.Secim = Secim;
            kapa = true;
            arkadaAcik = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kapa = false;
            Close();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kapa && !arkadaAcik)
                Secim.Close();

            else
                Secim.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ilPlakaKodu;

            if (plakaNo.Text.Length == 9)
            {

                arkadaAcik = true;

                ilPlakaKodu = Int32.Parse(plakaNo.Text.Substring(0, 2));

                if (ruhsatNo.Text.Length == 9 && ilPlakaKodu <= 81 && ilPlakaKodu > 0)
                {
                    Boolean var = false;
                    AmtsDbContext vt = new AmtsDbContext();

                    if (randevuMu)
                    {
                        if (vt.AracBilgileri.Where(r => r.RuhsatNo == ruhsatNo.Text.ToLower()).Any())
                            var = true;

                        if (!var)
                        {
                            Randevu randevu = new Randevu(ruhsatNo.Text, plakaNo.Text, Secim, this);
                            Hide();
                            randevu.Show();
                        }

                        else
                        {
                            Guncelle guncelle = new Guncelle(ruhsatNo.Text, plakaNo.Text, Secim, this);
                            Hide();
                            guncelle.Show();
                        }

                    }

                    else
                    {
                        if (vt.GecmisKayitlar.Where(r => r.RuhsatNo == ruhsatNo.Text).Any())
                            var = true;

                        if (var)
                        {
                            MuayeneSonucu muayeneSonucu = new MuayeneSonucu(ruhsatNo.Text, plakaNo.Text, Secim);
                            Hide();
                            muayeneSonucu.Show();
                        }

                        else
                        {
                            MessageBox.Show("Bu araçla ilgili bir kayıt bulunmamaktadır.", "Kayıt Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Ruhsat numarasını ve/veya plaka numarasını hatalı girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            MessageBox.Show("Ruhsat numarasını ve/veya plaka numarasını hatalı girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
