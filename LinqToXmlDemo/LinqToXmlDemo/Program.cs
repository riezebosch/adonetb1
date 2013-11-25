using MijnEigenMooieUniekeNamespaceProductenV2;
using MijnEigenMooieUniekeNamespaceV2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("Input.xml");
            PrintElement(doc.Root);
            Console.WriteLine();

            XNamespace xmlns = "MijnEigenMooieUniekeNamespace-V2";
            XNamespace producten = "MijnEigenMooieUniekeNamespace-Producten-V2";

            foreach (var item in from element in doc.Descendants(producten + "Product")
                                 let prijs = (decimal?)element.Element(producten + "Prijs") ?? -1
                                 where prijs < 500
                                 select prijs)
            {
                Console.WriteLine(item);
            }

            var 
                doc2 = new XDocument(
                    new XElement(xmlns + "Persoon",
                        new XElement(xmlns + "Naam", "klaas"),
                        new XElement(xmlns + "Achternaam", "Riezebosch"),
                        new XElement(xmlns + "Geboortedatum", new DateTime(2009,11,9).ToString("yyyy-MM-dd")),
                        new XElement(producten + "Producten",
                            new XElement(producten + "Product",
                                new XElement(producten + "Naam", "Printer"),
                                new XElement(producten + "Prijs", 145m)))));
            doc2.Save("klaas.xml");


            var persoon = new Persoon
            {
                Naam = "Jaël",
                Achternaam = "Riezebosch",
                Geboortedatum = new DateTime(2012, 5,14),
                Producten = new Producten
                { 
                    new Product { Naam = "Winkelwagentje", Prijs = 5m } 
                }
            };

            using (var stream = File.Create("Jaël.xml"))
            {
                var ser = new DataContractSerializer(typeof(Persoon));
                ser.WriteObject(stream, persoon);
            }

            Persoon inlezen = null;
            using (var stream = File.OpenRead("Jaël.xml"))
            {
                var ser = new DataContractSerializer(typeof(Persoon));
                inlezen = (Persoon)ser.ReadObject(stream);
            }

            Console.WriteLine(inlezen.Naam);
        }


        static void PrintElement(XElement element)
        {
            Console.WriteLine("Name: {0}, Value: {1}", element.Name, element.Value);
            foreach (var child in element.Elements())
            {
                PrintElement(child);
            }
        }

        static void NullCoallescingOperator(int? a1, decimal? a2, int? a3, int a4)
        {
            Console.WriteLine(a1 ?? a2 ?? a3 ?? a4);
        }
    }
}
