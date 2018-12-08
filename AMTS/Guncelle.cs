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
    public partial class Guncelle : Form
    {
        private String RuhsatNo { get; set; }
        private String PlakaNo { get; set; }
        private Form Secim { get; set; }
        private AmtsDbContext vt { get; set; }
        private Boolean kapa { get; set; }
        private Form Giris { get; set; }
        private Boolean arkadaAcık { get; set; }
        public Guncelle(String RuhsatNo, String PlakaNo, Form Secim, Form Giris)
        {
            InitializeComponent();
            this.RuhsatNo = RuhsatNo;
            this.PlakaNo = PlakaNo;
            this.Secim = Secim;
            vt = new AmtsDbContext();
            kapa = true;
            this.Giris = Giris;
            arkadaAcık = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            kapa = false;
            Close();
            Secim.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuncellemeForm guncellemeForm = new GuncellemeForm(RuhsatNo, PlakaNo, Secim, this);
            Hide();
            arkadaAcık = true;
            guncellemeForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Randevunuzu iptal etmek istediğinize emin misiniz?", "Dikkatli olun!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                vt.AracBilgileri.Remove(vt.AracBilgileri.Find(RuhsatNo));
                vt.SaveChanges();
                MessageBox.Show("Başarıyla silindi.");
                kapa = false;
                Close();
                Secim.Show();
            }
        }

        private void Guncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kapa && !arkadaAcık) 
                Secim.Close();

            else
                Giris.Close();
        }
    }
}
