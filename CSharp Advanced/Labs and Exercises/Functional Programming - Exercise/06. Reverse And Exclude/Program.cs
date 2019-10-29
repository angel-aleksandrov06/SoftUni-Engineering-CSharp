using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

            var divisibleNumber = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = num => num % divisibleNumber == 0;

            var result = inputNumbers.Where(x => !isDivisible(x)).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
