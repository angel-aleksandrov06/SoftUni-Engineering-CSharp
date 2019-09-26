using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count == 0 )
                        {
                            break;
                        }

                        var car = queue.Dequeue();
                        count++;
                        Console.WriteLine(car + " passed!");
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine(count + " cars passed the crossroads.");
        }
    }
}
