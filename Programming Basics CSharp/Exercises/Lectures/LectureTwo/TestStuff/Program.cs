using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            double testNumber = 4.1234;
            Console.WriteLine(Math.Ceiling(testNumber));    // 5
            Console.WriteLine(Math.Floor(testNumber));      // 4
            Console.WriteLine(Math.Round(testNumber, 2));   // 4.12
            Console.WriteLine($"{testNumber:F2}");          // 4.12
         
        }
    }
}
