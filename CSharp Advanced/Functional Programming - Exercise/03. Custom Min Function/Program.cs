using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            var minNumber = Console.ReadLine().Split().Select(int.Parse).MyMin();

            Console.WriteLine(minNumber);
        }
    }

     static class Class1
    {
        public static int MyMin(this IEnumerable<int> inputNumbers)
        {
            int minValue = int.MaxValue;

            foreach (var currentNumber in inputNumbers)
            {
                if (currentNumber < minValue)
                {
                    minValue = currentNumber;
                }
            }

            return minValue;
        }
    }
}
