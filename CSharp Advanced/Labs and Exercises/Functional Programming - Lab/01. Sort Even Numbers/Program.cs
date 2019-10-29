using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numbers = numbers.OrderBy(x => x).Where(x => x % 2 == 0).ToList();

            if (numbers.Any())
            {
                Console.WriteLine(string.Join(", ", numbers));
            }

        }
    }
}
