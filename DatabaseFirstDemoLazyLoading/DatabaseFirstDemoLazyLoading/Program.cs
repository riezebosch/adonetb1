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
                foreach (var person in from p in entities
                                                    .People
                                                    .Include(p => p.Courses.Select(c => c.StudentGrades))
                                                  //.Include("Courses.StudentGrades")
                                         select p)
                {
                    Console.WriteLine(person.FirstName + " "  + person.LastName);
                    foreach (var course in person.Courses)
                    {
                        Console.WriteLine("  " + course.Title);
                        foreach (var grade in course.StudentGrades)
                        {
                            Console.WriteLine("    " + grade.Grade);
                        }
                    }
                }
            }
        }
    }
}
