using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WcfDemo
{
    public class MijnContext : DbContext
    {
        public DbSet<PersoonEF> Personen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PersoonEF>().Map(p => 
                {
                    p.Property(p2 => p2.VolledigeNaam).HasColumnName("Naam");
                    p.ToTable("Persoon");
                });
        }
    }
}