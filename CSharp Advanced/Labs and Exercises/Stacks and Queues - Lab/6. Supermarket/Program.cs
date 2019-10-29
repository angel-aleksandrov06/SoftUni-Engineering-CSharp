using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    return;
                }
                else if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
        }
    }
}
