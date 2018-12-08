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
    public partial class GecmisKayitlarTablo : Form
    {
        AmtsDbContext vt;
        public GecmisKayitlarTablo(AmtsDbContext vt)
        {
            InitializeComponent();
            this.vt = vt; 
        }

        public void GecmisKayitlarTablo_Load(object sender, EventArgs e)
        {
            GecmisKayitlar gecmisKayitlar;

            for (int i = 0; i < vt.GecmisKayitlar.Count(); i++)
            {
                gecmisKayitlar = vt.GecmisKayitlar.OrderBy(x => x.Tarih).Skip(i).First();

                ListViewItem bilgiler = new ListViewItem(gecmisKayitlar.Id.ToString());
                bilgiler.SubItems.Add(gecmisKayitlar.RuhsatNo);
                bilgiler.SubItems.Add(gecmisKayitlar.PlakaNo);
                bilgiler.SubItems.Add(gecmisKayitlar.Ad);
                bilgiler.SubItems.Add(gecmisKayitlar.Soyadi);
                bilgiler.SubItems.Add(gecmisKayitlar.TelNo);
                bilgiler.SubItems.Add(gecmisKayitlar.Sehir);
                bilgiler.SubItems.Add(gecmisKayitlar.Istasyon);
                bilgiler.SubItems.Add(gecmisKayitlar.AracTipi);
                bilgiler.SubItems.Add(gecmisKayitlar.Tarih);
                bilgiler.SubItems.Add(gecmisKayitlar.Saat);
                bilgiler.SubItems.Add(gecmisKayitlar.MuayaneSonucu);

                gecmisKayitlari.Items.Add(bilgiler);
            }
        }

        private void gecmisKayitlari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
