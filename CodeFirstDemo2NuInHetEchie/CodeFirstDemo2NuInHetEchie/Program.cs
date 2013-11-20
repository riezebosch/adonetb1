using CodeFirstDemo2NuInHetEchie.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo2NuInHetEchie
{
    class Persoon
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

    class Product
    {
        public int Id { get; set; }
        
        [MaxLength(500)]
        public string Omschrijving2 { get; set; }
        public decimal Prijs { get; set; }

        public virtual ICollection<Persoon> Klanten { get; set; }
    }

    class MijnContext : DbContext
    {
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Product> Producten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<MijnContext>(new MigrateDatabaseToLatestVersion<MijnContext, Configuration>());

            using (var context = new MijnContext())
            {
                context.Configuration.LazyLoadingEnabled =
                    context.Configuration.ProxyCreationEnabled = true;

                foreach (var persoon in context.Personen.Include(p => p.Producten))
                {
                    Console.WriteLine("{0} {1}", persoon.Naam, persoon.Geboortedatum);

                    foreach (var prijs in persoon.Producten)
                    {
                        Console.WriteLine("  {0}", prijs.Prijs);
                    }
                }
            }
         }
    }
}
