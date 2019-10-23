using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Make_a_Salad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetables = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var receivedCalories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var dict = new Dictionary<string, int>();
            dict.Add("tomato", 80);
            dict.Add("carrot", 136);
            dict.Add("lettuce", 109);
            dict.Add("potato", 215);

            var ReadySalads = new List<int>();
            var residue = 0;
            var count = 0;

            while (vegetables.Count > 0 && receivedCalories.Count > 0)
            {

                var vegetable = vegetables.Dequeue();
                var caloriesValueOfSalad = receivedCalories.Peek();


                if (dict.ContainsKey(vegetable))
                {
                    if (caloriesValueOfSalad <= dict[vegetable])
                    {
                        residue += dict[vegetable] - caloriesValueOfSalad;
                        ReadySalads.Add(receivedCalories.Pop());
                    }
                    else if (caloriesValueOfSalad > dict[vegetable])
                    {
                        residue += dict[vegetable];

                        if (residue >= caloriesValueOfSalad)
                        {
                            residue = residue - caloriesValueOfSalad;
                            ReadySalads.Add(receivedCalories.Pop());
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", ReadySalads));

            if (vegetables.Count != 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
            if (receivedCalories.Count != 0)
            {
                Console.WriteLine(string.Join(" ", receivedCalories));
            }
        }
    }
}
