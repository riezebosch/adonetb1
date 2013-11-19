using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseFirstDemoLazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var entities = new SchoolEntities())
            {
                foreach (var person in entities.People.Include(p => p.StudentGrades.Select(g => g.Course)).Where()
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
                    if (person is Instructor)
                    {
                        Console.WriteLine("-- also instructor");
                    }

                    foreach (var grade in person.StudentGrades)
                    {
                        Console.WriteLine("  {0}", grade.Course.Title);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("-- instructors");
                foreach (var person in entities.People.OfType<Instructor>().Include(p => p.Courses))
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);

                    foreach (var course in person.Courses)
                    {
                        Console.WriteLine("  {0}", course.Title);
                    }
                }
            }

            //using (var entities =  new SchoolEntities())
            //{
            //    entities.People.Add(new Person
            //    {
            //        FirstName = "Manuel",
            //        LastName = "Riezebosch",
            //        HireDate = new DateTime(2007, 03, 01),
            //        Location = "Veenendaal",
            //    });

            //    entities.SaveChanges();
            //}
        }
    }
}
