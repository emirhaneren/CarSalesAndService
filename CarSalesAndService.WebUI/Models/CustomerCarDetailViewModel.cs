using CarSalesAndService.Entities;

namespace CarSalesAndService.WebUI.Models
{
    public class CustomerCarDetailViewModel
    {
        public Arac Car { get; set; }
        public Musteri? Customer { get; set; }
    }
}
