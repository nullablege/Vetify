using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Entities
{
    public class SaglikKaydi
    {

        public int Id { get; set; }
        public string KayitTuru { get; set; }      // Aşı Kaydı, Kontrol, Teşhis, vb.
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? SonrakiKontrolTarihi { get; set; }

        // FK
        public int HayvanId { get; set; }
        public Hayvan Hayvan { get; set; }

        public int? RandevuId { get; set; }        // Bazı sağlık kayıtları randevusuz olabilir
        public Randevu? Randevu { get; set; }

    }
}
