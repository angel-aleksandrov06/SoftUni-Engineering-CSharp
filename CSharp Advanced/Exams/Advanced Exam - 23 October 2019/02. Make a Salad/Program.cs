using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Make_a_Salad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetables = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => x == "tomato" || x == "carrot" || x == "lettuce" || x == "potato"));
            var receivedCalories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var dict = new Dictionary<string, int>();
            dict.Add("tomato", 80);
            dict.Add("carrot", 136);
            dict.Add("lettuce", 109);
            dict.Add("potato", 215);

            var ReadySalads = new List<int>();

            while (vegetables.Count > 0 && receivedCalories.Count > 0)
            {
                var currentSalad = receivedCalories.Peek();

                while (currentSalad > 0 && vegetables.Count > 0)
                {
                    currentSalad -= dict[vegetables.Dequeue()];
                }

                ReadySalads.Add(receivedCalories.Pop());
            }

            if (ReadySalads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", ReadySalads));
            }
            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            else if (receivedCalories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", receivedCalories));
            }
        }
    }
}
