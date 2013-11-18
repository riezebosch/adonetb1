using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = 0.1m;
            decimal b = 0.3m;
            decimal c = 0.2m;

            Console.WriteLine(b - a == c);
        }
    }
}
