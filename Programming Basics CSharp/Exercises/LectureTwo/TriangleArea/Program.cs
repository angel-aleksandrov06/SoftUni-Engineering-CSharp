using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            // read a (side)
            double side = double.Parse(Console.ReadLine());

            // read h (height)
            double height = double.Parse(Console.ReadLine());
            // calculate area
            //area = a * h /2
            double area = side * height / 2;
            // write area -> Format
            Console.WriteLine($" {area:F2}");
        }
    }
}
