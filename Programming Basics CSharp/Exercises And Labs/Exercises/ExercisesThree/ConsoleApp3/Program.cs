using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool xEqual = (x == x1) || (x == x2);
            bool yBetween = (y >= y1) && (y <= y2);
            bool check1 = xEqual && yBetween;


            bool yEqual = (y == y1) || (y == y2);
            bool xBetween = (x >= x1) && (x <= x2);
            bool check2 = yEqual && xBetween;

            if (check1 || check2)
            {
                 Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }




        }
    }
}
