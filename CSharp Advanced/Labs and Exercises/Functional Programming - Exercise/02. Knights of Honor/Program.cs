using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => "Sir " + x).ToArray();

            Action<string[]> printLines = items => Console.WriteLine(string.Join(Environment.NewLine, items));

            printLines(input);

        }
    }
}
