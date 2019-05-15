using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uprajnenie1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. read radians
            // 2. Calculate degrees -> 5 * 180 /pi
            // 3. Print -> round

            double rad = double.Parse(Console.ReadLine());

            double deg = rad * 180 / Math.PI;
            
            Console.WriteLine(Math.Round(deg));
        }
    }
}
