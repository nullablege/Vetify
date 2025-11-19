using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Tedavi
    {

        public int Id { get; set; }
        public string TedaviTuru { get; set; }
        public string Aciklama { get; set; }
        public decimal Ucret { get; set; }

        public DateTime TedaviTarihi { get; set; }

        // FK
        public int RandevuId { get; set; }
        public Randevu Randevu { get; set; }

    }
}
