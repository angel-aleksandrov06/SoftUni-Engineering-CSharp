using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromInchToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            // read iches from console
            double inches = double.Parse(Console.ReadLine());
            double convertRatio = 2.54;
            // convert to cm
            double centimeters = inches * convertRatio;

            // write to console the cm

            Console.WriteLine("{0:F2}", centimeters);
        }
    }
}
