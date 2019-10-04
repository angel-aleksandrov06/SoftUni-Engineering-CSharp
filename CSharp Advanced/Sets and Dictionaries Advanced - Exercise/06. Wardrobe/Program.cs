using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var inputCommand = Console.ReadLine().Split(" -> ");
                var color = inputCommand[0];

                if (!dict.ContainsKey(color))
                {
                    dict[color] = new Dictionary<string, int>();
                }
                var inputClothes = inputCommand[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var clothes in inputClothes)
                {
                    if (!dict[color].ContainsKey(clothes))
                    {
                        dict[color].Add(clothes, 0);
                    }
                    dict[color][clothes]++;
                }
            }
            var lastCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var colorToSearch = lastCommand[0];
            var clothingToSearch = lastCommand[1];

            foreach (var cloathing in dict)
            {
                Console.WriteLine($"{cloathing.Key} clothes:");

                foreach (var piece in cloathing.Value)
                {
                    if (colorToSearch == cloathing.Key && clothingToSearch == piece.Key)
                    {
                        Console.WriteLine($"* {piece.Key} - {piece.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {piece.Key} - {piece.Value} ");
                    }
                }
            }
        }
    }
}
