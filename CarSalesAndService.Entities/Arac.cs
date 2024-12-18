using System.ComponentModel.DataAnnotations;

namespace CarSalesAndService.Entities
{
    public class Arac : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka"), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public int MarkaId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !")] //Data Annotation
        public string Renk { get; set; }
        public decimal Fiyati { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !"), Display(Name = "Fiyatı")]
        public string Modeli { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !"), Display(Name = "Kasa Tipi")]
        public string KasaTipi { get; set; }
        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }
        [Display(Name = "Satışta Mı ?")]
        public bool SatistaMi { get; set; }
        [Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Notlar { get; set; }
        public virtual Marka? Marka { get; set; } //Araç sınıfı ile Marka sınıfı arasında bağlantı
    }
}
