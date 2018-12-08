using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AMTS
{
    public class MuayeneBilgisi
    {
        [Key]
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

        public MuayeneBilgisi()
        {
            //
        }

        public MuayeneBilgisi(String RuhsatNo, String PlakaNo, String Ad, String Soyadi, String TelNo, String Sehir, String Istasyon, String AracTipi, String Tarih, String Saat)
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
            MuayaneSonucu = "Girilmedi";
        }

        public MuayeneBilgisi(String RuhsatNo, String PlakaNo, String Ad, String Soyadi, String TelNo, String Sehir, String Istasyon, String AracTipi, String Tarih, String Saat, String MuayaneSonucu)
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
            GetType().ToString();
        }




    }
}