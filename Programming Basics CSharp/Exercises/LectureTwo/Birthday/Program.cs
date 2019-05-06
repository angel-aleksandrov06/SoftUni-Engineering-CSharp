using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double Percent = double.Parse(Console.ReadLine());

            double capacity = lenght * width * height;
            double totalLiters = capacity * 0.001;
            double calculatePecent = Percent * 0.01;
            double literNeeded = totalLiters * (1 - calculatePecent);

            Console.WriteLine("{0:F3}", literNeeded);




        }
    }
}
