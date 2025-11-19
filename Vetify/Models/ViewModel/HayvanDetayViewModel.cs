using EL.Entities;

namespace Vetify.Models.ViewModel
{
    public class HayvanDetayViewModel
    {
        public List<Randevu> Randevular {  get; set; }
        public string HayvanAd { get; set; }
        public string HayvanCins { get; set; }
        public string HayvanTur { get; set; }
        public int HayvanYas { get; set; }
        public double? HayvanKilo { get; set; }
        public string KayitTarihi { get; set; }
        public List<Tedavi> Tedaviler { get; set; }
        public decimal ToplamOdeme { get; set; }
        public decimal KalanBorc {  get; set; }
        public List<SaglikKaydi> SaglikGecmisi { get; set; }
    }
}
