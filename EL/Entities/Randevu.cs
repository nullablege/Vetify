using EL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Randevu
    {

        public int Id { get; set; }
        public DateTime RandevuZamani { get; set; }

        public RandevuDurum Durum { get; set; }
        public string? Notlar { get; set; }
        [NotMapped]
        public string? Tarih { get; set; }  // yyyy-MM-dd gelecek
        [NotMapped]
        public string? Saat { get; set; }   // HH:mm gelecek

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }

        // FK'lar
        public int HayvanId { get; set; }
        public Hayvan Hayvan { get; set; }

        public int MusteriId { get; set; }     // redundant ama hızlı sorgu için gerekli
        public Kullanici Musteri { get; set; }

        // Navigation
        public ICollection<Tedavi> Tedaviler { get; set; } = new List<Tedavi>();
        public ICollection<Odeme> Odemeler { get; set; } = new List<Odeme>();
        public Fatura? Fatura { get; set; }

    }
}
