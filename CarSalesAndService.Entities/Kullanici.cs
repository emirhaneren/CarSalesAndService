using System.ComponentModel.DataAnnotations;

namespace CarSalesAndService.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Adi { get; set; }
        [StringLength(100)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Soyadi { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Email { get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        [StringLength(50)]
        public string? KullaniciAdi { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş bırakılamaz !")]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        public int RolId { get; set; }
        public virtual Rol? Rol { get; set; }
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}
