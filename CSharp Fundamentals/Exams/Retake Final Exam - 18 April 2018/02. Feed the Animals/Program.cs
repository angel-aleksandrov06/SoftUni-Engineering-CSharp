using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictAnimalsFood = new Dictionary<string, int>();
            var dictAreas = new Dictionary<string, List<string>>();

            while (input != "Last Info")
            {
                var splitedInput = input.Split(":");
                var command = splitedInput[0];

                if (command == "Add")
                {
                    var animalName = splitedInput[1];
                    var daylyFoodLimit = int.Parse(splitedInput[2]);
                    var area = splitedInput[3];

                    if (!dictAnimalsFood.ContainsKey(animalName))
                    {
                        dictAnimalsFood[animalName] = 0;
                    }

                    dictAnimalsFood[animalName] += daylyFoodLimit;

                    if (!dictAreas.ContainsKey(area))
                    {
                        dictAreas[area] = new List<string>();
                    }
                    if (!dictAreas[area].Contains(animalName))
                    {
                        dictAreas[area].Add(animalName);
                    }
                }
                else if (command == "Feed")
                {
                    var animalName = splitedInput[1];
                    var food = int.Parse(splitedInput[2]);
                    var area = splitedInput[3];

                    if (dictAnimalsFood.ContainsKey(animalName))
                    {
                        dictAnimalsFood[animalName] -= food;
                        if (dictAnimalsFood[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            dictAnimalsFood.Remove(animalName);
                            dictAreas[area].Remove(animalName);
                        }
                    }
                }

                input = Console.ReadLine();
            }


            Console.WriteLine("Animals:");
            foreach (var item in dictAnimalsFood.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in dictAreas.OrderByDescending(x => x.Value.Count).Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"{item.Key} : {item.Value.Count}");
            }
        }
    }
}
