using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfTrojanWaves = int.Parse(Console.ReadLine());
            var platesOfSpartanDefense = Console.ReadLine().Split().Select(int.Parse).ToList();
            var powerOfEachTrojanWarrior = new Stack<int>();

            for (int i = 1; i <= numberOfTrojanWaves; i++)
            {
                if (platesOfSpartanDefense.Count == 0)
                {
                    break;
                }

                var warrior = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 3 == 0)
                {
                    var addPlate = int.Parse(Console.ReadLine());
                    platesOfSpartanDefense.Add(addPlate);
                }

                foreach (var war in warrior)
                {
                    powerOfEachTrojanWarrior.Push(war);
                }

                while (platesOfSpartanDefense.Count > 0 && powerOfEachTrojanWarrior.Count > 0)
                {

                    var trojanWarrior = powerOfEachTrojanWarrior.Pop();
                    var spartanPlate = platesOfSpartanDefense[0];

                    if (spartanPlate > trojanWarrior)
                    {
                        spartanPlate -= trojanWarrior;
                        platesOfSpartanDefense[0] = spartanPlate;
                    }
                    else if (spartanPlate < trojanWarrior)
                    {
                        trojanWarrior -= spartanPlate;
                        powerOfEachTrojanWarrior.Push(trojanWarrior);
                        platesOfSpartanDefense.RemoveAt(0);
                    }
                    else
                    {
                        platesOfSpartanDefense.RemoveAt(0);
                    }

                }

            }
            if (powerOfEachTrojanWarrior.Count > 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", powerOfEachTrojanWarrior)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfSpartanDefense)}");
            }
        }
    }
}
