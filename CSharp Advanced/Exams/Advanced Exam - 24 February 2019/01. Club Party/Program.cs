using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var dict = new Dictionary<string, List<int>>();
            var halls = new Queue<string>();

            while (input.Any())
            {
                var currentChar = input.Peek();

                if (!char.IsDigit(currentChar[0]))
                {
                    dict[currentChar] = new List<int>();
                    halls.Enqueue(currentChar);
                    input.Pop();
                    continue;
                }

                if (dict.Count == 0)
                {
                    input.Pop();
                    continue;
                }

                foreach (var hall in dict)
                {
                    if (hall.Value.Sum() + int.Parse(currentChar) <= capacity)
                    {
                        dict[hall.Key].Add(int.Parse(currentChar));
                        input.Pop();
                        break;
                    }

                    if (hall.Value.Sum() + int.Parse(currentChar) >= capacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
                        dict.Remove(hall.Key);
                    }

                    break;
                }
            }
        }
    }
}
