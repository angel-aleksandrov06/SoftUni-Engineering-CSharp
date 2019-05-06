using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            // read number from console
            int number = int.Parse(Console.ReadLine());

            // check if number is odd or even
            bool isNumberEven = (number % 2) == 0;

            // print to console
            if (isNumberEven)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}
