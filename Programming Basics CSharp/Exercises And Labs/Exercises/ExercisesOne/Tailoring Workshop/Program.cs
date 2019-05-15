using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double lenghtTable = double.Parse(Console.ReadLine());
            double widthTable = double.Parse(Console.ReadLine());

            double areaCovers = tables * (lenghtTable + 0.60) * (widthTable + 0.60);
            double areaSquare = tables * (lenghtTable / 2) * (lenghtTable / 2);

            double priceUsd = areaCovers * 7 + areaSquare * 9;
            double priceBgn = priceUsd * 1.85;

            Console.WriteLine($"{priceUsd:F2} USD");
            Console.WriteLine($"{priceBgn:F2} BGN");


        }
    }
}
