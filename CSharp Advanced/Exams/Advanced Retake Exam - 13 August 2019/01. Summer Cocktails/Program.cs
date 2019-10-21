using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var stack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var dict = new Dictionary<string, int>();
            dict.Add("Mimosa", 0);
            dict.Add("Daiquiri", 0);
            dict.Add("Sunshine", 0);
            dict.Add("Mojito", 0);

            var isMimosaDone = false;
            var isDaiquiriDone = false;
            var isSunshineDone = false;
            var isMojitoDone = false;

            while (true)
            {
                if (queue.Count == 0 || stack.Count == 0)
                {
                    break;
                }

                if (queue.Peek() == 0)
                {
                    queue.Dequeue();
                    continue;
                }

                int currentIngredient = queue.Dequeue();
                int currentFreshness = stack.Pop();

                int currentMultyplay = currentIngredient * currentFreshness;

                if (currentMultyplay == 150)
                {
                    dict["Mimosa"] += 1;
                    isMimosaDone = true;
                }
                else if (currentMultyplay == 250)
                {
                    dict["Daiquiri"] += 1;
                    isDaiquiriDone = true;
                }
                else if (currentMultyplay == 300)
                {
                    dict["Sunshine"] += 1;
                    isSunshineDone = true;
                }
                else if (currentMultyplay == 400)
                {
                    dict["Mojito"] += 1;
                    isMojitoDone = true;
                }
                else
                {
                    currentIngredient += 5;
                    queue.Enqueue(currentIngredient);
                }
            }

            var SortedDict = dict.OrderBy(x => x.Key).Where(x => x.Value != 0);

            if (isMimosaDone && isDaiquiriDone && isSunshineDone && isMojitoDone)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");

                if (queue.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {queue.Sum()}");
                }
                foreach (var kvp in SortedDict)
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

                if (queue.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {queue.Sum()}");
                }
                foreach (var kvp in SortedDict)
                {
                    Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
                }
            }
        }
    }
}
