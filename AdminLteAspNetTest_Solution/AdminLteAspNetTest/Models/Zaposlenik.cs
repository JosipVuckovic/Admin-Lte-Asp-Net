using System;
using System.Data.Entity;

namespace Zaposlenici.Models
{
    public class Zaposlenik
    {
        public int ID { get; set; }
        public string ImeIPrezime { get; set; }
        public string DatumRođenja { get; set; }
        public string Adresa { get; set; }
        public string KontaktBroj { get; set; }
        public string KontaktEMail { get; set; }
    }

    public class BazaZaposlenici : DbContext
    {
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
    }
}

