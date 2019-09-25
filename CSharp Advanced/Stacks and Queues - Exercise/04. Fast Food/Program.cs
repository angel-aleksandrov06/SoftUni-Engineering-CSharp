using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int QuantityFood = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(orders);

            int max = queue.Max();

            while (queue.Count != 0)
            {
                int curretOrder = queue.Peek();
                if (curretOrder > QuantityFood)
                {
                    Console.WriteLine(max);
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(" ", queue));
                    return;
                }
                else
                {
                    queue.Dequeue();
                    QuantityFood -= curretOrder;
                }
            }

            Console.WriteLine(max);
            Console.WriteLine("Orders complete");
        }
    }
}
