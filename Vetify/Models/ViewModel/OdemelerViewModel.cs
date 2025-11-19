using EL.Entities;

namespace Vetify.Models.ViewModel
{
    public class OdemelerViewModel
    {
        public decimal BuAyToplam { get; set; }
        public decimal BugunAlinan { get; set; }
        public int BugunIslemSayisi { get; set; }
        public decimal BekleyenBorc { get; set; }
        public int BorcluMusteriSayisi { get; set; }
        public decimal YillikToplam { get; set; }
        public List<Odeme> Odemeler { get; set; }
    }
}
