using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (true)
            {
                var commandsPats = Console.ReadLine().Split();
                string command = commandsPats[0].ToLower();

                if (command == "add")
                {
                    stack.Push(int.Parse(commandsPats[1]));
                    stack.Push(int.Parse(commandsPats[2]));

                }
                else if (command == "remove")
                {
                    var removeCount = int.Parse(commandsPats[1]);

                    if (stack.Count >= removeCount)
                    {
                        for (int i = 0; i < removeCount; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "end")
                {
                    if (stack.Count > 0)
                    {
                        int sum = stack.Sum();
                        Console.WriteLine($"Sum: {sum}");
                    }
                    else
                    {
                        Console.WriteLine($"Sum: 0");
                    }
                    return;
                }
            }
        }
    }
}
