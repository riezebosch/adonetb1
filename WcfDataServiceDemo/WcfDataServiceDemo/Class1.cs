using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfDataServiceDemo
{
    public class Persoon
    {
        public Persoon()
        {
            Producten = new List<Product>();
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Product> Producten { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Omschrijving2 { get; set; }
        public decimal Prijs { get; set; }

        public virtual ICollection<Persoon> Klanten { get; set; }
    }

    public class MijnContext : DbContext
    {
        static MijnContext()
        {
            Database.SetInitializer<MijnContext>(new MijnInitializer());
        }

        public MijnContext()
        {
            Configuration.ProxyCreationEnabled =
                Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Product> Producten { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }

    class MijnInitializer : DropCreateDatabaseAlways<MijnContext>
    {
        protected override void Seed(MijnContext context)
        {
            base.Seed(context);
            context.Personen.Add(new Persoon
            {
                Naam = "Manuel",
                Geboortedatum = new DateTime(1982, 5, 4),
                Email = "mriezebosch@gmail.com",
                Producten = new List<Product>
                {
                    new Product { Omschrijving2 = "Printer", Prijs = 199m },
                    new Product { Omschrijving2 = "Muis", Prijs = 19.99m }
                }
            });
        }
    }
}