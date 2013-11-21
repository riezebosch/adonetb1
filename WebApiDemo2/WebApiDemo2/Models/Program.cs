using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo2
{
    public class Persoon
    {
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

    public class MijnContext : DbContext
    {
        //static MijnContext()
        //{
        //    Database.SetInitializer<MijnContext>(new MijnDatabaseInitializer());
        //}

        public MijnContext() 
            : base("name=MijnContext")
        {

        }

        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Product> Producten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class MijnDatabaseInitializer : DropCreateDatabaseAlways<MijnContext>
    {
        protected override void Seed(MijnContext context)
        {
            base.Seed(context);

            var manuel = new Persoon
            {
                Naam = "Manuel",
                Geboortedatum = new DateTime(1982, 4, 5),
                Email = "mriezebosch@gmail.com",
            };

            var printer = new Product
            {
                Omschrijving2 = "Printer",
                Prijs = 145
            };

            manuel.Producten.Add(printer);

            var muis = new Product
            {
                Omschrijving2 = "Muis",
                Prijs = 19.95m
            };

            manuel.Producten.Add(muis);
            context.Personen.Add(manuel);

            var ezra = new Persoon
            {
                Naam = "Ezra",
                Geboortedatum = new DateTime(2009, 11, 9),
                Email = "NA"
            };

            ezra.Producten.Add(muis);
            context.Personen.Add(ezra);
        }
    }
}
