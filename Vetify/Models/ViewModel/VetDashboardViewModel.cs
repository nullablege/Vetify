using EL.Entities;

namespace Vetify.Models.ViewModel
{
    public class VetDashboardViewModel
    {
        public int ToplamHayvan { get; set; }
        public int BugunkuRandevu { get; set; }
        public int BugunkuRandevuTamamlandi { get; set; }
        public int BekleyenRandevu { get; set; }
        public decimal AylıkGelir { get; set; }
        public List<Randevu> BugunkuRandevular {  get; set; }

    }
}
