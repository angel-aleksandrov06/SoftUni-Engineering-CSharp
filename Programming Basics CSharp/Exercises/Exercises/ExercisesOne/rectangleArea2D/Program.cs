using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangleArea2D
{
    class Program
    {
        static void Main(string[] args)
        {
            // read coordinats x1,y1,x2,y2
            // calculate lenght = x1 - x2
            // calcualte width = y1 - y2 
            // calculate area = lenght * width
            // calculate perimeter = 2* (len + wid)
            // Print

            double x1 = double.Parse(Console.ReadLine()); //60
            double y1 = double.Parse(Console.ReadLine()); //20
            double x2 = double.Parse(Console.ReadLine()); //10
            double y2 = double.Parse(Console.ReadLine()); //50

            double length = Math.Abs(x1 - x2);
            double width  = Math.Abs(y1 - y2);
            double area = length * width;
            double perimeter = 2 * (length + width);

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");

        }
    }
}
