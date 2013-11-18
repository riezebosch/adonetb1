using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();


            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=SSPI"))
            using (var comm = new SqlCommand("SELECT FirstName, LastName FROM Person WHERE FirstName = 'Peggy'", conn))
            {
                conn.Open();

                sw.Restart();

                var reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }

                Console.WriteLine(sw.Elapsed);
            }

            using (var entities = new SchoolEntities())
            {
                sw.Restart();
                var query = from p in entities.People
                            where p.FirstName == "Peggy"
                            select p.FirstName + " " + p.LastName;

                foreach (var name in query)
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine(sw.Elapsed);

                sw.Restart();
                var query2 = from p in entities.People
                            where p.FirstName == "Peggy"
                            select p.FirstName + " " + p.LastName;

                foreach (var name in query2)
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine(sw.Elapsed);
            }


        }
    }
}
