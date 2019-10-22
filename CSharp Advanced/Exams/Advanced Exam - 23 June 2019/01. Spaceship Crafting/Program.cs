using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueLiquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var stackItems = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var dict = new Dictionary<string, int>();
            dict.Add("Glass", 0);
            dict.Add("Aluminium", 0);
            dict.Add("Lithium", 0);
            dict.Add("Carbon fiber", 0);

            var isGlassDone = false;
            var isAluminiumDone = false;
            var isLithiumDone = false;
            var isCarbonDone = false;

            while (true)
            {
                if (queueLiquids.Count == 0 || stackItems.Count == 0)
                {
                    break;
                }
                var currentLiuid = queueLiquids.Dequeue();
                var currentphysicalItem = stackItems.Pop();
                var sumofcurrentValues = currentphysicalItem + currentLiuid;

                if (sumofcurrentValues == 25)
                {
                    dict["Glass"] += 1;
                    isGlassDone = true;
                }
                else if (sumofcurrentValues == 50)
                {
                    dict["Aluminium"] += 1;
                    isAluminiumDone = true;
                }
                else if (sumofcurrentValues == 75)
                {
                    dict["Lithium"] += 1;
                    isLithiumDone = true;
                }
                else if (sumofcurrentValues == 100)
                {
                    dict["Carbon fiber"] += 1;
                    isCarbonDone = true;
                }
                else
                {
                    currentphysicalItem += 3;
                    stackItems.Push(currentphysicalItem);
                }
            }

            if (isGlassDone && isAluminiumDone && isLithiumDone && isCarbonDone)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueLiquids.Count<=0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueLiquids)}");
            }

            if (stackItems.Count <= 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackItems)}");
            }

            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
