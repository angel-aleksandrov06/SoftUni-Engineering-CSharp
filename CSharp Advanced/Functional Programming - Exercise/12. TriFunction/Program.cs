using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEqualOrLargerFunc= (name, criteria) => name.Sum(x => x) >= criteria;
            Func<string[], Func<string, int, bool>,int, string> myFunc = (names, isLargerFunc, totalSum) => names.FirstOrDefault(x => isEqualOrLargerFunc(x, totalSum));
            
            var numberN = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var targetName = myFunc(inputNames, isEqualOrLargerFunc, numberN);

            Console.WriteLine(targetName);
        }
    }
}
