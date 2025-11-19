using EL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class Kullanici: IdentityUser<int>
    {

        //public int Id { get; set; }
        public string AdSoyad { get; set; }
        //public string Eposta { get; set; }
        //public string? Telefon { get; set; }

        //public byte[] SifreHash { get; set; }
        //public byte[] SifreTuzu { get; set; }

        //public KullaniciRol Rol { get; set; }

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellemeTarihi { get; set; }

        // İlişkiler
        public ICollection<Hayvan> Hayvanlar { get; set; } = new List<Hayvan>();
        public ICollection<Randevu> Randevular { get; set; } = new List<Randevu>();
        public ICollection<Odeme> Odemeler { get; set; } = new List<Odeme>();

    }
}
