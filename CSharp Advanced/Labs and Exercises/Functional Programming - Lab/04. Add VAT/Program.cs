using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            input = input.Select(x => (x + x * 0.20)).ToList();

            foreach (var numb in input)
            {
                Console.WriteLine($"{numb:f2}");
            }
        }
    }
}
