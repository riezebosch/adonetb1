using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqDemo
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person { Name = "Manuel", Age = 31 },
                new Person { Name = "Ezra", Age = 4 }
            };

            var query = persons
                            .Where(p => p.Age > 4)
                            .OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase)
                            .Select(p => p.Name);

            var query2 = from p in persons
                        where p.Age > 4
                        orderby p.Name
                        select p.Name;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }

            var document = XDocument.Load("");
            document.Elements().Where(n => n.Value == "bla");
        }
    }
}
