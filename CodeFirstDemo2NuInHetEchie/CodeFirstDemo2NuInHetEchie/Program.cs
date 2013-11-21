using CodeFirstDemo2NuInHetEchie.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Gebruik Enable-Migrations om de migration files aan te maken
 * Daarna Add-Migration "naam" om een nieuwe migration toe te voegen met de wijzigingen
 * En (eventueel) Update-Database om de migrations toe te passen.
 * Dit laatste kan automatisch at runtime door de MigrateDatabaseToLatestVersion als Database Initializer in te stellen.
 */

namespace CodeFirstDemo2NuInHetEchie
{
    public class Persoon
    {
        // Moet public zijn voor LazyLoading
        public Persoon()
        {
            // Uitgezet ivm LazyLoading
            //Producten = new List<Product>();
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        // Moet virtual zijn voor LazyLoading
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

    class MijnContext : DbContext
    {
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Product> Producten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initializer om automatisch de database te upgraden advh de handmatig gemaakte migrations.
            // Dit staat standaard typisch in de static constructor van de context zodat hij eenmalig voor 
            // het AppDomain wordt uitgevoerd zodra de eerste context aangemaakt wordt.
            Database.SetInitializer<MijnContext>(new MigrateDatabaseToLatestVersion<MijnContext, Configuration>());

            using (var context = new MijnContext())
            {
                context.Configuration.LazyLoadingEnabled =
                    context.Configuration.ProxyCreationEnabled = true;

                foreach (var persoon in context.Personen)
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
