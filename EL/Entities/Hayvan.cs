using EL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Hayvan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Tur { get; set; }        // Köpek, Kedi
        public string? Cins { get; set; }      // Tekir, Golden
        public DateTime? DogumTarihi { get; set; }
        public double? Kilo { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public string? Renk { get; set; }
        public string? TibbiGecmis { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }

        // FK
        public int SahipId { get; set; }
        public Kullanici Sahip { get; set; }

        // Navigation
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
        public ICollection<SaglikKaydi> SaglikKayitlari { get; set; } = new List<SaglikKaydi>();

    }
}
