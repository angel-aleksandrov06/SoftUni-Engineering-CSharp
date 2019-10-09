using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxNamesLength = int.Parse(Console.ReadLine());

            var inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<int, string[], List<string>> FiltringNames = (x, y) =>
            {

                var result = new List<string>();
                foreach (var name in y)
                {
                    if (name.Length <= x)
                    {
                        result.Add(name);
                    }
                }

                return result;
            };

            var FilteredNames = FiltringNames(maxNamesLength, inputNames);

            Console.WriteLine(string.Join(Environment.NewLine, FilteredNames));
        }
    }
}
