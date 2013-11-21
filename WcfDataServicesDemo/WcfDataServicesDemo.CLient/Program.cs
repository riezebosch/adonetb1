using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDataServicesDemo.CLient
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MijnODataService.MijnContext(new Uri("http://localhost:51800/MijnService.svc"));
            foreach (var item in ctx.Personen.Where(p => p.Naam.StartsWith("m")))
            {
                Console.WriteLine(item.Naam);
            }
        }
    }
}
