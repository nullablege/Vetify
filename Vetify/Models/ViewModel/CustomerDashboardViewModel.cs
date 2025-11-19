using EL.Entities;

namespace Vetify.Models.ViewModel
{
    public class CustomerDashboardViewModel
    {
        public int ToplamHayvan { get; set; }
        public int planlanmisRandevu { get; set; }
        public decimal son30OdemeTutar { get; set; }
        public int son30TedaviSayisi { get; set; }
        public int son30OdemeSayisi { get; set; }
        public decimal guncelBorc { get; set; }
        public List<Randevu> sonRandevular { get; set; }
    }
}
