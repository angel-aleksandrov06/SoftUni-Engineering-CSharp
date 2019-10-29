using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int N = command[0];
            int S = command[1];
            int X = command[2];

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < Math.Min(N, numbers.Length); i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                }
            }

            bool contains = queue.Contains(X);

            if (contains)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int minNumber = queue.Min();
                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
