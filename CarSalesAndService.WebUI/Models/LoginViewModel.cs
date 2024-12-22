using System.ComponentModel.DataAnnotations;

namespace CarSalesAndService.WebUI.Models
{
    public class LoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Email { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Sifre { get; set; }
    }
}
