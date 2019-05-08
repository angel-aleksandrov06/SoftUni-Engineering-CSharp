using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {

            double r = double.Parse(Console.ReadLine());
            // Goal 1 -> Area
            double area = Math.PI * r * r;
            // Goal 2 > Perimeter
            double perimeter = 2 * Math.PI * r;

            // From console -> Radius
            // Area => Pi * r * r 
            // primeter 2 * pi * r 

            // PI -> 3.14???
            double pi = Math.PI;
            // console - > write -> format
            Console.WriteLine("{0:F2}", area);
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}
