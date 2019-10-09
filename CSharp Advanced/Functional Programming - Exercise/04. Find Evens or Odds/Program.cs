using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;
            Action<List<int>> printNumbers = nums => Console.WriteLine(string.Join(" ", nums));

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbers = new List<int>();

            var startNumber = input[0];
            var endNumber = input[1];

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            var numberType = Console.ReadLine();

            if (numberType == "even")
            {
                numbers.RemoveAll(x => !isEvenPredicate(x));
            }
            else if (numberType == "odd")
            {
                numbers.RemoveAll(x => isEvenPredicate(x));
            }

            printNumbers(numbers);
        }
    }
}
