namespace CarSalesAndService.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }
        public string? Baslik { get; set; }
        public string? Aciklama { get; set; }
        public string? Foto { get; set; }
        public string? Link { get; set; }

    }
}
