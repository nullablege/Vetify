using EL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Fatura
    {
        public int Id { get; set; }

        public decimal ToplamTutar { get; set; }
        public decimal OdenenTutar { get; set; }

        [NotMapped]
        public decimal KalanTutar => ToplamTutar - OdenenTutar;

        public OdemeDurum Durum { get; set; }  // Odendi, KismiOdendi, Odenmedi

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        // FK
        public int RandevuId { get; set; }
        public Randevu Randevu { get; set; }
    }
}
