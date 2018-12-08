using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AMTS
{
    public class GecmisKayitlar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String RuhsatNo { get; set; }
        public String PlakaNo { get; set; }
        public String Ad { get; set; }
        public String Soyadi { get; set; }
        public String TelNo { get; set; }
        public String Sehir { get; set; }
        public String Istasyon { get; set; }
        public String AracTipi { get; set; }
        public String Tarih { get; set; }
        public String Saat { get; set; }
        public String MuayaneSonucu { get; set; }

        public GecmisKayitlar()
        {
            //
        }

        public GecmisKayitlar(String RuhsatNo, String PlakaNo, String Ad, String Soyadi, String TelNo, String Sehir, String Istasyon, String AracTipi, String Tarih, String Saat, String MuayaneSonucu)
        {
            this.RuhsatNo = RuhsatNo;
            this.PlakaNo = PlakaNo;
            this.Ad = Ad;
            this.Soyadi = Soyadi;
            this.TelNo = TelNo;
            this.Sehir = Sehir;
            this.Istasyon = Istasyon;
            this.AracTipi = AracTipi;
            this.Tarih = Tarih;
            this.Saat = Saat;
            this.MuayaneSonucu = MuayaneSonucu;
        }

        public GecmisKayitlar(MuayeneBilgisi muayeneBilgisi) : this(muayeneBilgisi.RuhsatNo, muayeneBilgisi.PlakaNo, muayeneBilgisi.Ad, muayeneBilgisi.Soyadi, muayeneBilgisi.TelNo, muayeneBilgisi.Sehir, muayeneBilgisi.Istasyon, muayeneBilgisi.AracTipi, muayeneBilgisi.Tarih, muayeneBilgisi.Saat, muayeneBilgisi.MuayaneSonucu)
        {
            //
        }

    }
}
