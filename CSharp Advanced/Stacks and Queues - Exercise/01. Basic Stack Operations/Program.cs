using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < Math.Min(N, numbers.Length); i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                if (stack.Count != 0)
                {
                    stack.Pop();
                }
            }

            bool contains = stack.Contains(X);

            if (contains)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int minNumber = stack.Min();
                    Console.WriteLine(minNumber);
                }
            }
        }
    }
}
