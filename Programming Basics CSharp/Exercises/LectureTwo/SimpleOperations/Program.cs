using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // get sqare side size from console
            int squareSide = int.Parse(Console.ReadLine());

            // calculate area 
            int squareArea = squareSide * squareSide;
            // write to console
            Console.WriteLine(squareArea);
        }
    }
}
