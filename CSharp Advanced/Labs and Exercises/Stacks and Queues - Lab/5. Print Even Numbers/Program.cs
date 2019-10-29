using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            foreach (var number in input)
            {
                if (number%2 == 0)
                {
                    queue.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
