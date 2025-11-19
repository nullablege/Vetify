using EL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Odeme
    {
        public int Id { get; set; }
        public decimal Tutar { get; set; }
        public OdemeYontemi OdemeYontemi { get; set; }

        public DateTime OdemeTarihi { get; set; }
        public OdemeDurum Durum { get; set; }
        public string? Notlar { get; set; }

        // FK
        public int MusteriId { get; set; }
        public Kullanici Musteri { get; set; }

        public int RandevuId { get; set; }
        public Randevu Randevu { get; set; }

    }
}
