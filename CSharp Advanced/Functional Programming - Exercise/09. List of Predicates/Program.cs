using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var endOfTheRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], List<int>> sortDividers = (endOfRange, theDividers) =>
            {
                var result = new List<int>();

                var isDivided = false;

                for (int i = 1; i <= endOfRange; i++)
                {
                    foreach (var divider in dividers)
                    {
                        if (i % divider == 0)
                        {
                            isDivided = true;
                        }
                        else
                        {
                            isDivided = false;
                            break;
                        }
                    }
                    if (isDivided)
                    {
                        result.Add(i);
                    }
                }
                return result;
            };

            var filteredNumbers = sortDividers(endOfTheRange, dividers);
            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
