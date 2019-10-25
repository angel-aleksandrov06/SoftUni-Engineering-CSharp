using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var rightSocks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var pairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                var leftSock = leftSocks.Pop();
                var rightSock = rightSocks.Peek();

                if (leftSock == rightSock)
                {
                    rightSocks.Dequeue();
                    leftSock++;
                    
                    leftSocks.Push(leftSock);
                    continue;
                }

                if (leftSock < rightSock)
                {
                    continue;
                }

                pairs.Add(leftSock + rightSock);
                rightSocks.Dequeue();
            }

            Console.WriteLine(pairs.OrderByDescending(x=>x).FirstOrDefault());

            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
