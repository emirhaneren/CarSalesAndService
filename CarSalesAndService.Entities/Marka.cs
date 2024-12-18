using System.ComponentModel.DataAnnotations;

namespace CarSalesAndService.Entities
{
    public class Marka : IEntity
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Adi { get; set; }
    }
}
