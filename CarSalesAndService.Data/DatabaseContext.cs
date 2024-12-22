using CarSalesAndService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarSalesAndService.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        //Db Bağlantısı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB; database=DBCarSalesAndService;
            integrated security=True; MultipleActiveResultSets=True;"); //Connection String

            optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentAPI
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            //Seed Data
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Admin",
                Soyadi = "admin",
                AktifMi = true,
                EklenmeTarihi = DateTime.Now,
                Email = "admin@otoservice.com",
                KullaniciAdi = "admin",
                Sifre = "1903",
                RolId = 1,
                Telefon = "19031903"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
