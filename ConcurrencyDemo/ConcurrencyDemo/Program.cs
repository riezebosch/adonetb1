using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConcurrencyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new TransactionScope())
            using (var entities = new SchoolEntities())
            {
                var person = entities.People.SingleOrDefault(p => p.FirstName == "Kees");
                person.HireDate = person.HireDate.Value.AddDays(1);

                using (var stiekem = new SchoolEntities())
                {
                    var temp = stiekem.People.SingleOrDefault(p => p.FirstName == "Kees");
                    temp.FirstName = "TEMP";

                    stiekem.SaveChanges();
                }

                try
                {
                    entities.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        var dbValues = entry.GetDatabaseValues();
                        var currentValues = entry.CurrentValues;
                        var originalValues = entry.OriginalValues;

                        foreach (var property in currentValues.PropertyNames)
                        {
                            Console.WriteLine("Original: {0}, Current: {1}, Database: {2}", 
                                originalValues.GetValue<object>(property),
                                currentValues.GetValue<object>(property),
                                dbValues.GetValue<object>(property));
                        }
                    }
                }
            }
        }
    }
}
