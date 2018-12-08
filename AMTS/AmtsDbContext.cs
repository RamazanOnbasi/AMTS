using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AMTS
{
    public class AmtsDbContext : DbContext
    {
        public DbSet<MuayeneBilgisi> AracBilgileri { get; set; }
        public DbSet<GecmisKayitlar> GecmisKayitlar { get; set; }
    }
}
