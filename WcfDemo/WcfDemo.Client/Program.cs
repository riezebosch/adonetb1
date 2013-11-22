using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MijnWcfService.MijnWcfServiceClient();
            client.DoWork(new MijnWcfService.Persoon
            {
                Naam = "Manuel",
                Leeftijd = 31,
                Salaris = -1
            });

            Console.WriteLine(client.Get(1).Naam);
        }
    }
}
