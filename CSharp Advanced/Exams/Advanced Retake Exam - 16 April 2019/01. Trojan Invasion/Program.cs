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
            var platesOfSpartanDefense = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            for (int i = 0; i < numberOfTrojanWaves; i++)
            {
                var powerOfEachTrojanWarrior = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                while (true)
                {
                    if (powerOfEachTrojanWarrior.Count == 0 || platesOfSpartanDefense.Count == 0)
                    {
                        break;
                    }

                    var trojanWarrior = powerOfEachTrojanWarrior.Pop();
                    var spartanPlate = platesOfSpartanDefense.Dequeue();

                    var attack = trojanWarrior - spartanPlate;

                    if (attack < 0)
                    {
                        spartanPlate = Math.Abs(attack);
                        platesOfSpartanDefense.Enqueue
                    }
                }
            }

        }
    }
}
